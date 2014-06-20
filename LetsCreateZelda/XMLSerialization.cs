//------------------------------------------------------
// 
// Copyright - (c) - 2014 - Mille Boström 
//
// Youtube channel - https://www.youtube.com/user/Maloooon
//------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using LetsCreateZelda.Map;
using Microsoft.Xna.Framework;

namespace LetsCreateZelda
{
    public static class XMLSerialization
    {
        public static bool LoadXML<T>(out T theObject, string path)
        {
            theObject = default(T);
            try
            {
                using(var stream = TitleContainer.OpenStream(path))
                {
                    var serializer = new XmlSerializer(typeof (T));
                    theObject = (T) serializer.Deserialize(stream);
                    return true; 
                }
            }
            catch (Exception)
            {        
                throw;
            }

            return false; 
        }

        public static bool SaveXML<T>(T theObject, string path)
        {
            FileStream stream = null;
            try
            {
                stream = new FileStream(path, FileMode.Create);
                var serialize = new XmlSerializer(typeof (T));
                serialize.Serialize(stream, theObject);
            }
            catch (Exception)
            {
                return false; 
            }
            finally
            {
                stream.Flush();
                stream.Close(); 
            }

            return true;
        }
    }

   
}


