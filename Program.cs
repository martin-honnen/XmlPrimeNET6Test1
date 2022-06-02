using System.Xml;
using System.Xml.XPath;
using XmlPrime;

Console.WriteLine($"{Environment.Version} {Environment.OSVersion}");

var nameTable = new NameTable();

XdmDocument document = new XdmDocument("sample1.xml", XmlSpace.Preserve);

XsltSettings xsltSettings = new XsltSettings(nameTable);
xsltSettings.ContextItemType = XdmType.Node;
xsltSettings.XsltVersion = XsltVersion.Xslt30;

Xslt xslt = Xslt.Compile("sheet1.xsl", xsltSettings);

XPathNavigator contextItem = document.CreateNavigator();

xslt.ApplyTemplates(contextItem, Console.Out);