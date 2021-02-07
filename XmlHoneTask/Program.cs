using System;
using System.IO;
using System.Xml;

namespace XmlHoneTask
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteXmlDocument();
            ReadXmlDocument();
            GetAttributeValue();
        }

        private static void WriteXmlDocument()
        {
            XmlTextWriter xmlWriter = new XmlTextWriter("TelephoneBook.xml", null);
            xmlWriter.Formatting = Formatting.Indented;
            xmlWriter.Indentation = 1;
            xmlWriter.QuoteChar = '\'';

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("MyContacts");
            xmlWriter.WriteStartElement("Contact");
            xmlWriter.WriteStartAttribute("TelephoneNumber");
            xmlWriter.WriteString("0761231234");
            xmlWriter.WriteEndAttribute();
            xmlWriter.WriteString("Alex");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Contact");
            xmlWriter.WriteStartAttribute("TelephoneNumber");
            xmlWriter.WriteString("234234234");
            xmlWriter.WriteEndAttribute();
            xmlWriter.WriteString("Ivan");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }


        private static void ReadXmlDocument()
        {
            XmlDocument document = new XmlDocument();
            document.Load("TelephoneBook.xml");
            Console.WriteLine(document.InnerXml);
        
            FileStream stream = new FileStream("TelephoneBook.xml", FileMode.Open);
            XmlTextReader reader = new XmlTextReader(stream);
            while (reader.Read())
            {
                Console.WriteLine("{0,-15} {1,-10} {2,-10}",
                    reader.NodeType.ToString(),
                    reader.Name,  
                    reader.Value);
            }

        }

        private static void GetAttributeValue()
        {
            XmlTextReader reader = new XmlTextReader("TelephoneBook.xml");


            while (reader.Read())
            {

                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("Contact"))
                    {
                        Console.WriteLine(reader.GetAttribute("TelephoneNumber"));
                    }
                }
            }
        }
    }
}
    
