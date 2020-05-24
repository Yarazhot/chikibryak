using System;
using System.IO;
using System.Linq;
using System.Text;
using Wiry.Base32;
using PluginBase;

namespace Plugin2
{
    public class Plugin2: IPlagin
    {
        public string Name
        {
            get { return "Plugin2_Base32"; }
        }
        private static string TextInBase32(string iText)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(iText);
            string base32 = Base32Encoding.Standard.GetString(inputBytes);
            return base32;
        }

        private static string Base32InText(string iTestBase32)
        {
            byte[] decodedBase32 = Base32Encoding.Standard.ToBytes(iTestBase32);
            string result = Encoding.ASCII.GetString(decodedBase32);
            return result;
        }

        private static string[] ReadLines(string path)
        {
            string[] result = new string[0];
            using (StreamReader sr = new StreamReader(path))
            {
                string buf;
                while ((buf = sr.ReadLine()) != null)
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = buf;
                }
            }
            return result;
        }

        private static void WriteLines(string path, string[] lines)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                for (int i = 0; i < lines.Length; i++)
                    sw.WriteLine(lines[i]);
            }
        }

        public void EncodeFile(string path)
        {
            string[] lines = ReadLines(path);
            string[] result = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
                result[i] = TextInBase32(lines[i]);
            WriteLines(path, result);
        }

        public void DecodeFile(string path)
        {
            string[] lines = ReadLines(path);
            string[] result = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
                result[i] = Base32InText(lines[i]);
            WriteLines(path, result);
        }
    }
}
