using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime;
using System.Text;
using System.Web.Helpers;
using System.Xml;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace XML
{
    class Program
    {
        static void Main(string[] args)
        {
            string xml = "<root><first><second><color>blue</color><color>red</color><third><time>21.5</time></third></second><seila>valoraqui</seila></first></root>";
            string path = @"C:\Users\Desenvolvimento\Desktop\XML.xml";
            XDocument xDoc = XDocument
                .Parse(xml);
            //.Load(path);
            StringBuilder stringBuilder = new StringBuilder();
            //Loop(xDoc);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc
                .LoadXml(xml);
                //.Load(path);

            

            string jsonText = JsonConvert.SerializeXmlNode(xmlDoc);

            var jsonDictionary = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonText);
            Console.WriteLine(CreateBox(jsonDictionary));
            //foreach (var node in xDoc.Nodes())
            //{
            //    Console.WriteLine(node);
            //    var element = node.Document.Elements().;
            //    if (element.HasElements)
            //    {
            //        stringBuilder.AppendLine(element.Name.ToString())
            //            .Append("\t");
            //    }
            //    else
            //    {
            //        stringBuilder.AppendLine(element.Name.ToString());
            //        if (!element.IsEmpty)
            //            stringBuilder.AppendLine(element.Value);
            //    }
            //}
        }

        public static string CreateBox(IDictionary<string, dynamic> json)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var key in json.Keys)
            {
                if (!string.IsNullOrEmpty(key))
                {
                    stringBuilder.AppendLine();
                    stringBuilder.Append(key)
                        .Append(": ");
                    if(json[key] is JObject)
                    {
                        stringBuilder.AppendLine();
                        stringBuilder.AppendLine(
                            CreateBox(json[key].ToObject<Dictionary<string, dynamic>>()));
                        
                    }
                    else if (json[key] is JArray)
                    {
                        Dictionary<string, dynamic> dict = new Dictionary<string, dynamic>();
                        foreach (var item in json[key])
                        {
                            stringBuilder.Append(item.Value)
                                .Append(", ");
                        }
                        //stringBuilder.Append(CreateBox(dict));
                    }
                    else if (json[key] is string)
                    {
                        stringBuilder.Append(json[key]);
                    }
                    //if(json[key] is ICollection)
                    //{
                    //    Console.WriteLine("ok");
                    //}
                    //Type type = ((ObjectHandle)json[key]).Unwrap().GetType();
                    //Console.WriteLine(type);
                    //if (type == typeof(String))
                    //{
                    //    stringBuilder.Append(json[key]);
                    //}
                        
                }
            }

            return stringBuilder.ToString();
        }

        public static void Loop(XDocument xml)
        {

            var descendants = xml.Descendants();
            StringBuilder stringBuilder = new StringBuilder();
            string lastParentName = "";
            int tabCount = 0;
            foreach (var item in descendants)
            {
                stringBuilder.Append(item.Name.ToString());
                if (!item.HasElements)
                    stringBuilder.Append(": ")
                        .Append(item.Value);

                stringBuilder.AppendLine();

                if (item.Parent != null)
                {
                    string actualParentName = item.Parent.Name.ToString();

                    if (lastParentName == "")
                        lastParentName = actualParentName;

                    if (actualParentName != lastParentName)
                    {
                        tabCount--;
                        lastParentName = actualParentName;
                    }
                    else
                        tabCount++;
                }
                else
                    tabCount++;

                for (int i = 0; i < tabCount; i++)
                    stringBuilder.Append(" ");






            }
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
