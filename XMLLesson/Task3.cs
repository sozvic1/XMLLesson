using System;
using System.Xml;

namespace XMLLesson
{
    class Task3
    {
        public void GetAttributeXml()
        {
            XmlTextReader reader = new XmlTextReader("TelephoneBook.xml");
            Console.WriteLine("Attribute value: ");
            while (reader.Read())
            {
               
                if (reader.NodeType == XmlNodeType.Element)
                {
                    
                    if (reader.HasAttributes)
                    {
                       
                        while (reader.MoveToNextAttribute())
                        {
                            Console.Write($"{reader.Value} ");
                        }

                    }
                }
            }
           
            Console.ReadKey();
        }
       
    }
}
