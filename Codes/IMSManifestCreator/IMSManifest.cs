using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;

namespace WindowsFormsApplication1
{
    class IMSManifest
    {
        public void AddNode_imsmanifest(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode = new TreeNode();
            XmlNodeList nodeList;
            int i;
            string node_name = "";
            int count = 0;
            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    if (xNode.Name != "title" && xNode.Name != "item" && xNode.Name != "metadata" && xNode.Name != "file" && xNode.Name != "resource" && xNode.Name != "resources" && xNode.Name != "schema" && xNode.Name != "schemaversion" && xNode.Name != "adlcp:location")
                    {
                        node_name = xNode.Name;
                        if (xNode.Name == "organization")
                        {
                            XmlNodeList organization_list = xNode.ChildNodes;
                            for (int j = 0; j < organization_list.Count; j++)
                            {
                                if (organization_list[j].Name == "title")
                                {
                                    node_name = organization_list[j].InnerText;
                                }
                            }
                        }
                        if (node_name == "organizations")
                        {
                            inTreeNode.Nodes.Add(new TreeNode("教材章節"));
                            tNode = inTreeNode.Nodes[count++];
                            AddNode_imsmanifest(xNode, tNode);
                        }
                        else
                        {
                            inTreeNode.Nodes.Add(new TreeNode(node_name));
                            tNode = inTreeNode.Nodes[count++];
                            AddNode_imsmanifest(xNode, tNode);
                        }
                    }
                    if (xNode.Name == "item")
                    {
                        XmlNodeList organization_list = xNode.ChildNodes;
                        for (int j = 0; j < organization_list.Count; j++)
                        {
                            if (organization_list[j].Name == "title")
                            {
                                node_name = organization_list[j].InnerText;
                                inTreeNode.Nodes.Add(new TreeNode(node_name));
                                //count++;
                            }
                        }
                        AddNode_imsmanifest(xNode, tNode);
                    }
                    //if (xNode.Name == "metadata")
                    //{
                    //    inTreeNode.Nodes.Add(new TreeNode("metadata"));
                    //}
                }
            }
            else
            {
                // Here you need to pull the data from the XmlNode based on the
                // type of node, whether attribute values are required, and so forth.
                if (inXmlNode.Name == "organizations")
                    inTreeNode.Text = "教材章節";
            }
        }

        public void AddNode_resource(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode = new TreeNode();
            XmlNodeList nodeList;
            int i;
            int count = 0;
            string node_name = "";
            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i < nodeList.Count; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    if (xNode.Name != "organizations")
                    {
                        node_name = xNode.Name;
                        if (xNode.Name == "resources")
                        {
                            XmlNodeList organization_list = xNode.ChildNodes;
                            for (int j = 0; j < organization_list.Count; j++)
                            {
                                XNamespace adlcp = "http://www.adlnet.org/xsd/adlcp_rootv1p2";
                                int index = organization_list[j].OuterXml.IndexOf("scormtype");
                                if (index == -1)
                                {
                                    XmlNodeList organization_list1 = organization_list[j].ChildNodes;
                                    for (int k = 0; k < organization_list1.Count; k++)
                                    {
                                        if (organization_list1[k].Name == "file")
                                        {
                                            index = organization_list1[k].OuterXml.IndexOf("href");
                                            int index1 = organization_list1[k].OuterXml.IndexOf("\"", index + 6);
                                            int length = index1 - (index + 6);
                                            node_name = organization_list1[k].OuterXml.Substring(index + 6, length).ToString();
                                            int check = 0;
                                            for (int q = 0; q < Now_Add_Resource.Count; q++)
                                                if (Now_Add_Resource[q] == node_name)
                                                {
                                                    TreeNode temp = new TreeNode();
                                                    temp.Text = node_name;
                                                    temp.ForeColor = System.Drawing.Color.Blue;
                                                    inTreeNode.Nodes.Add(temp);
                                                    check = 1;
                                                }
                                            if (check == 0)
                                                inTreeNode.Nodes.Add(new TreeNode(node_name));
                                        }
                                    }
                                    tNode = inTreeNode.Nodes[count++];
                                }
                            }
                        }
                    }
                    AddNode_resource(xNode, tNode);
                }
            }
        }

        public void AddNode_test(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode = new TreeNode();
            XmlNodeList nodeList;
            int i;
            string node_name = "";
            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i < nodeList.Count; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    if (xNode.Name != "Test_Count")
                    {
                        node_name = xNode.Name;
                        if (xNode.Name == "Test_Content")
                        {
                            XmlNodeList organization_list = xNode.ChildNodes;
                            for (int j = 0; j < organization_list.Count; j++)
                            {
                                XmlNodeList organization_list1 = organization_list[j].ChildNodes;
                                for (int k = 0; k < organization_list1.Count; k++)
                                {
                                    if (organization_list1[k].Name == "Question")
                                    {
                                        node_name = organization_list1[k].InnerText;
                                        inTreeNode.Nodes.Add(new TreeNode(node_name));
                                    }
                                }
                                tNode = inTreeNode.Nodes[i - 1];
                            }
                        }
                    }
                    AddNode_test(xNode, tNode);
                }
            }
        }


    }
}
