using System;
using System.Text;
using System.IO;
using PluginBase;

namespace Plugin
{
    public class Plugin1: IPlagin
    {
        public string Name
        {
            get { return "Plugin1_Base64"; }
        }
        private static string TextInBase64(string iText)
        {
            var iTextBytes = Encoding.UTF8.GetBytes(iText);
            return Convert.ToBase64String(iTextBytes);
        }

        private static string Base64InText(string iTestBase64)
        {
            var iTestBase64Bytes = System.Convert.FromBase64String(iTestBase64);
            return System.Text.Encoding.UTF8.GetString(iTestBase64Bytes);
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
                result[i] = TextInBase64(lines[i]);
            WriteLines(path, result);
        }

        public void DecodeFile(string path)
        {
            string[] lines = ReadLines(path);
            string[] result = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
                result[i] = Base64InText(lines[i]);
            WriteLines(path, result);
        }
    }
}
