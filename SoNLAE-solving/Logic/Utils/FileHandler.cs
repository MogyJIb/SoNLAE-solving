using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SoNLAE_solving.Logic.Utils
{
    public class FileHandler
    {
        public static String Read(string path)
        {
            StringBuilder result = new StringBuilder("");
            using (StreamReader sr = new StreamReader(path))
            {
                result.Append(sr.ReadToEnd());
            }
            return result.ToString();
        }

        public static void Write(string path, string data)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.Write(data);
            }
        }

        public static string[] ReadIPs(string path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(string[]));

            using (FileStream fs = new FileStream("ips.xml", FileMode.OpenOrCreate))
            {
                return (string[])formatter.Deserialize(fs);
            }
        }

        public static void WriteIPs(string path, string[] ips)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(string[]));

            using (FileStream fs = new FileStream("ips.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, ips);
            }
        }
    }
}
