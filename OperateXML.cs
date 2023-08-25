using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace RepeatStudy
{
    class OperateXML
    {
        static void Main(string[] args)
        {
			//Generate();

			XmlDocument x = new XmlDocument();
			x.Load("data.xml");
			XmlNode root = x.DocumentElement;
			//XmlNode e = root.SelectSingleNode("TotalTick");
			//Console.WriteLine(e.InnerText);
			XmlNode e = root.SelectSingleNode("TickLine/Tick[@Value = '1']");
			
        }

		public static void Generate()
		{
			try
			{
				XmlDocument tDoc = new XmlDocument();

				//声明信息
				XmlDeclaration xmlDecl = tDoc.CreateXmlDeclaration("1.0", "utf-8", null);
				tDoc.AppendChild(xmlDecl);

				//新建根节点
				XmlElement root = tDoc.CreateElement("root");
				tDoc.AppendChild(root);

				//root下的子节点
				XmlElement toTalTick = tDoc.CreateElement("TotalTick");
				toTalTick.InnerText = "10";
				root.AppendChild(toTalTick);//注意这里是 root.AppendChild

				//root下的子节点
				XmlElement demension = tDoc.CreateElement("Demension");
				demension.InnerText = "2";
				root.AppendChild(demension);

				//
				XmlElement tickline = tDoc.CreateElement("TickLine");
				root.AppendChild(tickline);

				for (int i = 0; i < 10; i++)
				{
					//TickLinex 下的子节点Tick
					XmlElement tick = tDoc.CreateElement("Tick");

					//给Tick增加属性
					XmlAttribute attr = tDoc.CreateAttribute("Value");
					attr.Value = i.ToString();
					tick.Attributes.Append(attr);
					tickline.AppendChild(tick);
				}

				XmlWriterSettings settings = new XmlWriterSettings();
				settings.Encoding = System.Text.Encoding.UTF8;
				settings.Indent = true;
				settings.IndentChars = "    ";

				XmlWriter writer = XmlWriter.Create("data.xml", settings);
				//tDoc.Save("D:/MyComputer.xml");
				tDoc.Save(writer);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());

			}
		}

		
    }
}
