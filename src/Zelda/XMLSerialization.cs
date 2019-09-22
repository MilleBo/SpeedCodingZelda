using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;

namespace Zelda
{
    public static class XMLSerialization
    {
        public static bool LoadXML<T>(out T theObject, string path)
        {
            theObject = default(T);
            using (var stream = TitleContainer.OpenStream(path))
            {
                var serializer = new XmlSerializer(typeof(T));
                theObject = (T)serializer.Deserialize(stream);
                return true;
            }
        }

        public static bool SaveXML<T>(T theObject, string path)
        {
            FileStream stream = null;
            try
            {
                stream = new FileStream(path, FileMode.Create);
                var serialize = new XmlSerializer(typeof(T));
                serialize.Serialize(stream, theObject);
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                stream.Flush();
            }

            return true;
        }
    }
}