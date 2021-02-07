using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLLesson
{
    class ReadXml
    {
        public void ReadXmlFile()
        {
            XmlDocument document = new XmlDocument();
            document.Load("TelephoneBook.xml");            
            Console.WriteLine(document.InnerXml);

            XmlNode root = document.DocumentElement;
            Console.WriteLine();

            FileStream stream = new FileStream("TelephoneBook.xml", FileMode.Open);
            XmlTextReader xmlReader = new XmlTextReader(stream);
            while (xmlReader.Read())
            {
                Console.WriteLine("{0,-15} {1,-15} {2,-15}",
                    xmlReader.NodeType,
                    xmlReader.Name, 
                    xmlReader.Value); 
            }
            xmlReader.Close();
        
        }
    }
}
