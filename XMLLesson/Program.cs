using System.Xml;

namespace XMLLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateXmlDocument();

            var readXml = new ReadXml();
            readXml.ReadXmlFile();

            var attribut = new Task3();
            attribut.GetAttributeXml();

        }

        private static void CreateXmlDocument()
        {
            XmlTextWriter xmlWriter = new XmlTextWriter("TelephoneBook.xml", null);
            xmlWriter.Formatting = Formatting.Indented;
            //xmlWriter.IndentChar = '\t';
            xmlWriter.Indentation = 1;

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("MyContacts");
            xmlWriter.WriteStartElement("Contact");
            xmlWriter.WriteStartAttribute("TelephoneNumber");
            xmlWriter.WriteString("8093987620");
            xmlWriter.WriteEndAttribute();
            xmlWriter.WriteString("Alex");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Contact");
            xmlWriter.WriteStartAttribute("TelephoneNumber");
            xmlWriter.WriteString("7777777");
            xmlWriter.WriteEndAttribute();
            xmlWriter.WriteString("Ivan");
            xmlWriter.WriteEndElement();
            xmlWriter.Close();
        }
    }
}
