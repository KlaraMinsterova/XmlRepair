using NUnit.Framework;
using System.IO;
using System.Xml;
using static XmlRepair.XmlRepair;

namespace XmlRepair.Tests
{
    public class Tests
    {
        [Test]
        public void XmlIsValid_UsingRegex()
        {
            CompleteRepairProcess(RepairRegex);
            string xml = File.ReadAllText("test_repaired.xml");
            XmlConvert.VerifyXmlChars(xml);
            File.Delete("test_repaired.xml");
        }

        [Test]
        public void XmlIsValid_UsingStringBuilder()
        {
            CompleteRepairProcess(RepairStringBuilder);
            string xml = File.ReadAllText("test_repaired.xml");
            XmlConvert.VerifyXmlChars(xml);
            File.Delete("test_repaired.xml");
        }

        [Test]
        public void OutputIsTheSame_UsingTwoDifferentMethods()
        {
            string xml = ReadFile();
            string repairedRegex = RepairRegex(xml);
            string repairedStringBuilder = RepairStringBuilder(xml);

            Assert.That(repairedRegex, Is.EqualTo(repairedStringBuilder));
        }
    }
}