using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FlowFilter.Models
{
    public class ToolClass
    {
        public static string XmlSerialize<T>(T obj, bool omitXmlDeclaration = false)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (var xw = XmlWriter.Create(ms, new XmlWriterSettings()
                {
                    OmitXmlDeclaration = omitXmlDeclaration,
                    ConformanceLevel = ConformanceLevel.Auto,
                    Indent = true,
                    Encoding = new UTF8Encoding(false),
                }))
                {
                    var xs = new XmlSerializer(obj.GetType());
                    XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                    namespaces.Add(string.Empty, string.Empty);
                    xs.Serialize(xw, obj, namespaces);
                }
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }

        public static T XmlDeserialize<T>(string data) where T : class
        {
            if (string.IsNullOrEmpty(data))
            {
                return default(T);
            }
            using (MemoryStream ms = new MemoryStream())
            {
                StreamWriter sw = new StreamWriter(ms, new System.Text.UTF8Encoding(false));
                sw.Write(data);
                sw.Flush();
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                var xs = new XmlSerializer(typeof(T));
                var obj = xs.Deserialize(sr);
                if (obj is T variable)
                {
                    return variable;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
