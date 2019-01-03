using SoNLAE_solving.Logic.Models;
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

        public static string[] ReadIPs()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(string[]));

            using (FileStream fs = new FileStream("ips.xml", FileMode.OpenOrCreate))
            {
                return (string[])formatter.Deserialize(fs);
            }
        }

        public static void WriteIPs(string[] ips)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(string[]));

            using (FileStream fs = new FileStream("ips.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, ips);
            }
        }

        public static void WriteMatrix(MatrixInterface<double> doubleMatrix)
        {
            VectorInterface<Double>[] matrix = doubleMatrix.Vectors;
            StringBuilder data = new StringBuilder();
            StringBuilder b = new StringBuilder();
            for (int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j < matrix[i].Count - 1; j++)
                {
                    data.Append(matrix[i][j]);
                    if (j != matrix[i].Count - 2) data.Append(' ');
                }
                b.Append(matrix[i][matrix[i].Count - 1]);
                if (i != matrix.Length - 1)
                {
                    data.Append('\n');
                    b.Append('\n');
                }
            }

            Write("matrix.txt", data.ToString());
            Write("b.txt", b.ToString());
        }

        public static void WriteSolution(VectorInterface<double> solution)
        {
            StringBuilder data = new StringBuilder();
                for (int j = 0; j < solution.Count; j++)
                {
                    data.Append(solution[j]);
                    if (j != solution.Count - 1) data.Append('\n');
                }

            Write("solution.txt", data.ToString());
        }
    }
}
