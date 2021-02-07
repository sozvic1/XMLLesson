using System;
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
            XmlNode root = document.DocumentElement;

            foreach (XmlNode contacts in root.ChildNodes)
            {

                foreach (XmlNode contact in contacts.ChildNodes)
                {
                    Console.WriteLine($"Found Contact: {contact.InnerText} ");

                }
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
    
