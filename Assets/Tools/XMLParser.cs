using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;


namespace Assets.Scripts.Misc
{
    public class XMLParser
    {
        public static void Save<T>(string pFilename, T pObject)
        {
            XmlSerializer XMLSerializer = new XmlSerializer(typeof(T));
            FileStream fileStream = new FileStream(pFilename, FileMode.Create);

            XmlTextWriter XMLWriter = new XmlTextWriter(fileStream, Encoding.UTF8);
            XMLWriter.Formatting = Formatting.Indented;
            XMLSerializer.Serialize(XMLWriter, pObject);
            fileStream.Close();
        }

        public static T Load<T>(string pFilename)
        {
            /*if(!File.Exists(pFilename)) {
                //dbg.Out("No such file or directory");
                return default(T);
            }*/

            XmlSerializer XMLSerializer = new XmlSerializer(typeof(T));
            FileStream fileStream = new FileStream(pFilename, FileMode.OpenOrCreate);
            T retObject = (T)XMLSerializer.Deserialize(fileStream);
            fileStream.Close();

            return retObject;
        }

        public static bool Load<T>(string pFilename, out T pObject)
        {
            if (!File.Exists(pFilename))
            {
                pObject = default(T);
                return false;
            }

            XmlSerializer XMLSerializer = new XmlSerializer(typeof(T));
            FileStream fileStream = new FileStream(pFilename, FileMode.Open);
            pObject = (T)XMLSerializer.Deserialize(fileStream);
            fileStream.Close();

            return true;
        }
    }
}
