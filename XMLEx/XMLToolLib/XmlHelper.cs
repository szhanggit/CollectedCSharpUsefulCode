using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLToolLib
{
    public sealed class XmlHelper
    {
        private XmlHelper() { }

        public static List<string> GetPreviousNodeNameList(XmlDocument xdoc, string nodesPath, string nodeName)
        {
            try
            {
                List<string> namelist = null;
                IList<XmlNode> nodelist = GetPreviousNodeList(xdoc, nodesPath, nodeName);
                if (nodelist != null && nodelist.Count > 0)
                {
                    namelist = new List<string>() { };
                    foreach (var node in nodelist)
                    {
                        namelist.Add(node.Attributes["name"].Value);
                    }
                }
                return namelist;
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        //根据当前的给点的路径（node），获取其前面所有的node 
        // NodesPath /root/step
        //NodePath /root/step[name='basic']
        //NodeName basic
        public static IList<XmlNode> GetPreviousNodeList(XmlDocument xdoc, string nodesPath, string nodeName)
        {
            try
            {
                IList<XmlNode> result = null;

                XmlNodeList nodelist = GetXmlNodesByXmlPath(xdoc, nodesPath);

                XmlNode currentNode = null;
                if (nodelist != null && nodelist.Count > 0)
                {
                    string nodePath = string.Format("{0}[@name='{1}']", nodesPath, nodeName);
                    currentNode = xdoc.SelectSingleNode(nodePath);
                    var previous = currentNode.Attributes["previous"].Value;

                    if (previous != "")
                    {
                        result = new List<XmlNode>();
                        do
                        {
                            nodePath = string.Format("{0}[@name='{1}']", nodesPath, previous);
                            var previousNode = GetXmlNodeByXmlPath(xdoc, nodePath);
                            if (previousNode != null)
                            {
                                result.Add(previousNode);
                                previous = previousNode.Attributes["previous"].Value;
                            }
                        } while (!string.IsNullOrEmpty(previous));
                    }

                }
                return result;

            }
            catch (Exception)
            {

                throw;
            }

        }


        //public static XmlNode GetPreviousNode(XmlDocument xdoc, string nodesPath, string nodeName)
        //{ 
        //    string nodePath = string.Format("{0}/[name='{1}']",nodesPath,nodeName);

        //    return  xdoc.SelectSingleNode(nodePath);
        //}


        /// <summary>
        /// 载入xml文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static XmlDocument LoadXml(string filePath)
        {
            try
            {
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(filePath);
                return xdoc;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public static XmlNode GetXmlNodeByXmlPath(XmlDocument xdoc, string nodePath)
        {
            try
            {
                return xdoc.SelectSingleNode(nodePath);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static XmlNodeList GetXmlNodesByXmlPath(XmlDocument xdoc, string nodesPath)
        {
            try
            {
                return xdoc.SelectNodes(nodesPath);
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public static string GetAttributeFromXmlDocument(string filePath, string nodePath, string propertyName, string defaultValue)
        {
            try
            {
                XmlDocument xdoc = LoadXml(filePath);
                XmlNode node = GetXmlNodeByXmlPath(xdoc, nodePath);
                return GetAttribute(node, propertyName, defaultValue);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static string GetAttributeFromXmlDocument(XmlDocument xdoc, string nodePath, string propertyName, string defaultValue)
        {
            try
            {
                XmlNode node = GetXmlNodeByXmlPath(xdoc, nodePath);
                return GetAttribute(node, propertyName, defaultValue);
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        /// <summary>
        /// 创建节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newElementName"></param>
        /// <returns></returns>
        public static XmlNode AppendElement(XmlNode node, string newElementName)
        {
            return AppendElement(node, newElementName, null);
        }

        /// <summary>
        /// 创建节点
        /// </summary>
        /// <param name="node"></param>
        /// <param name="newElementName"></param>
        /// <param name="innerValue"></param>
        /// <returns></returns>
        public static XmlNode AppendElement(XmlNode node, string newElementName, string innerValue)
        {
            XmlNode oNode;
            if (node is XmlDocument)
            {
                oNode = node.AppendChild(((XmlDocument)node).CreateElement(newElementName));
            }
            else
            {
                oNode = node.AppendChild(node.OwnerDocument.CreateElement(newElementName));
            }

            if (innerValue != null)
            {
                oNode.AppendChild(node.OwnerDocument.CreateTextNode(innerValue));
            }
            return oNode;
        }

        /// <summary>
        /// 创建属性
        /// </summary>
        /// <param name="xmlDocument"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static XmlAttribute CreateAttribute(XmlDocument xmlDocument, string name, string value)
        {
            XmlAttribute oAtt = xmlDocument.CreateAttribute(name);
            oAtt.Value = value;
            return oAtt;
        }

        /// <summary>
        /// 设置属性的值
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName"></param>
        /// <param name="attributeValue"></param>
        public static void SetAttribute(XmlNode node, string attributeName, string attributeValue)
        {
            if (node.Attributes[attributeName] != null)
            {
                node.Attributes[attributeName].Value = attributeValue;
            }
            else
            {
                node.Attributes.Append(CreateAttribute(node.OwnerDocument, attributeName, attributeValue));
            }
        }

        /// <summary>
        /// 获取属性的值
        /// </summary>
        /// <param name="node"></param>
        /// <param name="attributeName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetAttribute(XmlNode node, string attributeName, string defaultValue)
        {
            XmlAttribute att = node.Attributes[attributeName];
            if (att != null)
            {
                return att.Value;
            }
            else
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// 获取节点的值
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="nodeXPath"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetNodeValue(XmlNode parentNode, string nodeXPath, string defaultValue)
        {
            XmlNode node = parentNode.SelectSingleNode(nodeXPath);
            if (node.FirstChild != null)
            {
                return node.FirstChild.Value;
            }
            else if (node != null)
            {
                return node.Value;
            }
            else
            {
                return defaultValue;
            }
        }


    }
}
