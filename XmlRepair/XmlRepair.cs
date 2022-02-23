using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using XmlRepair.Properties;

namespace XmlRepair
{
    public static class XmlRepair
    {
        /// <summary>
        /// Repairs content of xml file by removing invalid characters using regex.
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        public static string RepairRegex(string xmlContent)
        {
            return XmlRepairRegex.Replace(xmlContent, "");
        }

        private static Regex XmlRepairRegex = new Regex(@"[^\x09\x0A\x0D\x20-\uD7FF\uE000-\uFFFD\u10000-\u10FFFF]", RegexOptions.Compiled);

        /// <summary>
        /// Repairs content of xml file by copying only valid characters using string builder.
        /// </summary>
        /// <param name="xmlContent"></param>
        /// <returns></returns>
        public static string RepairStringBuilder(string xmlContent)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char character in xmlContent)
            {
                if (XmlConvert.IsXmlChar(character))
                {
                    stringBuilder.Append(character);
                }
            }

            return stringBuilder.ToString();
        }

        public static string ReadFile()
        {
            return Resources.test;
        }

        public static void SaveFile(string xmlContent)
        {
            File.WriteAllText("test_repaired.xml", xmlContent);
        }

        /// <summary>
        /// Complete process of reading, repairing and saving file.
        /// </summary>
        /// <param name="repairFunction"></param>
        public static void CompleteRepairProcess(Func<string, string> repairFunction)
        {
            string xmlContent = ReadFile();
            string repairedXmlContent = repairFunction(xmlContent);
            SaveFile(repairedXmlContent);
        }
    }
}

