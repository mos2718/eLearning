using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
namespace WindowsFormsApplication1
{
    class LOMGenerator
    {
        public XElement Add_Metadata()
        {
            XNamespace ns = "http://www.imsglobal.org/xsd/imsmd_rootv1p2p1";
            XNamespace x = "http://www.w3.org/XML/1998/namespace";
            XNamespace xmlns = @"http://www.imsproject.org/xsd/imscp_rootv1p1p2";
            XElement element = new XElement(xmlns + "metadata",
                new XElement(ns + "lom",
                    new XElement(ns + "general",
                        new XElement(ns + "title",
                            new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), textBox3.Text.Trim().ToString())),
                        new XElement(ns + "catalogentry",
                            new XElement(ns + "catalog"),
                            new XElement(ns + "entry",
                                new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), "ID"))),
                        new XElement(ns + "description",
                            new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), textBox4.Text.Trim().ToString())),
                        new XElement(ns + "keyword",
                            new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), textBox5.Text.Trim().ToString())),
                        new XElement(ns + "coverage",
                            new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), comboBox5.Text.Trim().ToString() + " - " + comboBox6.Text.Trim().ToString()))),
                    new XElement(ns + "lifecycle",
                        new XElement(ns + "version",
                            new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), "version")),
                        new XElement(ns + "status",
                            new XElement(ns + "source",
                                new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), "LOMv1")),
                            new XElement(ns + "value",
                                new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), comboBox1.Text.Trim().ToString()))),
                        new XElement(ns + "contribute",
                            new XElement(ns + "role",
                                new XElement(ns + "source",
                                    new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), "LOMv1.0")),
                                new XElement(ns + "value",
                                    new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), comboBox7.Text.ToString()))),
                            new XElement(ns + "centity",
                                new XElement(ns + "vcard", ConfigurationManager.AppSettings["User_name"].ToString() + "/" + ConfigurationManager.AppSettings["Centers"].ToString() + "/" + ConfigurationManager.AppSettings["Email"].ToString())),
                            new XElement(ns + "date",
                                new XElement(ns + "datetime", DateTime.Now.ToString("yyyy-MM-dd"))))),
                    new XElement(ns + "metametadata",
                        new XElement(ns + "catalogentry",
                            new XElement(ns + "catalog"),
                            new XElement(ns + "entry",
                                new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), "Metadata_ID"))),
                        new XElement(ns + "metadatascheme", "LOMv1.0")),
                    new XElement(ns + "technical",
                        new XElement(ns + "format", comboBox2.Text.Trim().ToString())),
                    new XElement(ns + "rights",
                        new XElement(ns + "cost",
                            new XElement(ns + "source",
                                new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), "LOMv1.0")),
                            new XElement(ns + "value",
                                new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), comboBox3.Text.Trim().ToString()))),
                        new XElement(ns + "copyrightandotherrestrictions",
                            new XElement(ns + "source",
                                new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), "LOMv1.0")),
                            new XElement(ns + "value",
                                new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), comboBox4.Text.Trim().ToString())))),
                    new XElement(ns + "classification",
                        new XElement(ns + "taxonpath",
                            new XElement(ns + "source",
                                new XElement(ns + "langstring", new XAttribute(x + "lang", "en"), "放射線治療癌別-期別分類法"))))));
            return element;
        }


    }
}
