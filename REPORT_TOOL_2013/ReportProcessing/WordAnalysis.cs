using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Packaging;
using ServiceConsumer.Gateway;
using DocumentFormat.OpenXml.Wordprocessing;


namespace ReportProcessing
{
    public class WordAnalysis
    {
        public int countKeyword { get; set; }
        public WordprocessingDocument wDoc;
        public WordAnalysis()
        {
            countKeyword = 0;            
        }
        public void AnalyseReport(WordprocessingDocument wordDoc)
        {
            wDoc = wordDoc;
            //PROCESSING STRING EXPRESSION IN WORD
            this.SearchAndReplace(wordDoc, "", "", true);

            //PROCESSING StockTable_Tag
            string tblTag = "StockTable_Tag";
            MainDocumentPart mainPart = wordDoc.MainDocumentPart;
                //StockService.baseDS.stockCodeDataTable tbl = Gateway.PriceData.getPriceDataToDay();
                SdtBlock ccWithTable = mainPart.Document.Body.Descendants<SdtBlock>().Where
                (r => r.SdtProperties.GetFirstChild<Tag>().Val == tblTag).Single();

                // This should return only one table.
                Table theTable = ccWithTable.Descendants<Table>().Single();
                // Get the last row in the table.
                TableRow theRow = theTable.Elements<TableRow>().Last();

                StockReport stockReport = StockReport.getInstance();
                databases.tmpDS.dataVarrianceDataTable tbl =  stockReport.TopBiggestChangeTable();
                foreach (databases.tmpDS.dataVarrianceRow item in tbl.Rows)
                {
                    try
                    {                        
                        TableRow rowCopy = (TableRow)theRow.CloneNode(true);
                        rowCopy.Descendants<TableCell>().ElementAt(0).Append(new Paragraph
                            (new Run(new Text(item.code.ToString()))));
                        rowCopy.Descendants<TableCell>().ElementAt(1).Append(new Paragraph
                            (new Run(new Text(String.Format("{0:0,0}", item.val1*1000)+" VNĐ"))));
                        rowCopy.Descendants<TableCell>().ElementAt(2).Append(new Paragraph
                            (new Run(new Text(String.Format("{0:0,0}", item.val2 * 1000) + " VNĐ"))));
                        rowCopy.Descendants<TableCell>().ElementAt(3).Append(new Paragraph
                        (new Run(new Text(String.Format("{0:0,0}", item.value * 1000) + " VNĐ"))));
                        rowCopy.Descendants<TableCell>().ElementAt(4).Append(new Paragraph
                        (new Run(new Text((item.percent / 100).ToString("P")))));
                        theTable.AppendChild(rowCopy);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }                    
                }
                theTable.RemoveChild(theRow);                
        }
        public XmlDocument GetXmlDocument(OpenXmlPart part)
        {
            XmlDocument xmlDoc = new XmlDocument();
            using (Stream partStream = part.GetStream())
            using (XmlReader partXmlReader = XmlReader.Create(partStream))
                xmlDoc.Load(partXmlReader);
            return xmlDoc;
        }
        public void PutXmlDocument(OpenXmlPart part, XmlDocument xmlDoc)
        {
            using (Stream partStream = part.GetStream(FileMode.Create, FileAccess.Write))
            using (XmlWriter partXmlWriter = XmlWriter.Create(partStream))
                xmlDoc.Save(partXmlWriter);
        }
        public bool PartHasTrackedRevisions(OpenXmlPart part)
        {
            XmlDocument doc = GetXmlDocument(part);
            string wordNamespace =
                "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
            XmlNamespaceManager nsmgr =
                new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("w", wordNamespace);
            string xpathExpression =
                "descendant::w:cellDel|" +
                "descendant::w:cellIns|" +
                "descendant::w:cellMerge|" +
                "descendant::w:customXmlDelRangeEnd|" +
                "descendant::w:customXmlDelRangeStart|" +
                "descendant::w:customXmlInsRangeEnd|" +
                "descendant::w:customXmlInsRangeStart|" +
                "descendant::w:del|" +
                "descendant::w:delInstrText|" +
                "descendant::w:delText|" +
                "descendant::w:ins|" +
                "descendant::w:moveFrom|" +
                "descendant::w:moveFromRangeEnd|" +
                "descendant::w:moveFromRangeStart|" +
                "descendant::w:moveTo|" +
                "descendant::w:moveToRangeEnd|" +
                "descendant::w:moveToRangeStart|" +
                "descendant::w:moveTo|" +
                "descendant::w:numberingChange|" +
                "descendant::w:rPrChange|" +
                "descendant::w:pPrChange|" +
                "descendant::w:rPrChange|" +
                "descendant::w:sectPrChange|" +
                "descendant::w:tcPrChange|" +
                "descendant::w:tblGridChange|" +
                "descendant::w:tblPrChange|" +
                "descendant::w:tblPrExChange|" +
                "descendant::w:trPrChange";
            XmlNodeList descendants = doc.SelectNodes(xpathExpression, nsmgr);
            return descendants.Count > 0;
        }
        public bool HasTrackedRevisions(WordprocessingDocument doc)
        {
            if (PartHasTrackedRevisions(doc.MainDocumentPart))
                return true;
            foreach (var part in doc.MainDocumentPart.HeaderParts)
                if (PartHasTrackedRevisions(part))
                    return true;
            foreach (var part in doc.MainDocumentPart.FooterParts)
                if (PartHasTrackedRevisions(part))
                    return true;
            if (doc.MainDocumentPart.EndnotesPart != null)
                if (PartHasTrackedRevisions(doc.MainDocumentPart.EndnotesPart))
                    return true;
            if (doc.MainDocumentPart.FootnotesPart != null)
                if (PartHasTrackedRevisions(doc.MainDocumentPart.FootnotesPart))
                    return true;
            return false;
        }

        private void SearchAndReplaceInXmlDocument(XmlDocument xmlDocument, string search,
            string replace, bool matchCase)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
            nsmgr.AddNamespace("w",
                "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            var paragraphs = xmlDocument.SelectNodes("descendant::w:p", nsmgr);
            foreach (var paragraph in paragraphs)
                SearchAndReplaceInParagraph((XmlElement)paragraph, search, replace, matchCase);
        }
        public void SearchAndReplace(WordprocessingDocument wordDoc, string search,
            string replace, bool matchCase)
        {
            if (this.HasTrackedRevisions(wordDoc))
                throw new SearchAndReplaceException(
                    "Search and replace will not work with documents " +
                    "that contain revision tracking.");

            XmlDocument xmlDoc;
            xmlDoc = this.GetXmlDocument(wordDoc.MainDocumentPart.DocumentSettingsPart);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("w",
                "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
            XmlNodeList trackedRevisions =
                xmlDoc.SelectNodes("descendant::w:trackRevisions", nsmgr);
            if (trackedRevisions.Count > 0)
                throw new SearchAndReplaceException(
                    "Revision tracking is turned on for document.");

            xmlDoc = this.GetXmlDocument(wordDoc.MainDocumentPart);
            SearchAndReplaceInXmlDocument(xmlDoc, search, replace, matchCase);
            this.PutXmlDocument(wordDoc.MainDocumentPart, xmlDoc);
            foreach (var part in wordDoc.MainDocumentPart.HeaderParts)
            {
                xmlDoc = this.GetXmlDocument(part);
                SearchAndReplaceInXmlDocument(xmlDoc, search, replace, matchCase);
                this.PutXmlDocument(part, xmlDoc);
            }
            foreach (var part in wordDoc.MainDocumentPart.FooterParts)
            {
                xmlDoc = this.GetXmlDocument(part);
                SearchAndReplaceInXmlDocument(xmlDoc, search, replace, matchCase);
                this.PutXmlDocument(part, xmlDoc);
            }
            if (wordDoc.MainDocumentPart.EndnotesPart != null)
            {
                xmlDoc = this.GetXmlDocument(wordDoc.MainDocumentPart.EndnotesPart);
                SearchAndReplaceInXmlDocument(xmlDoc, search, replace, matchCase);
                this.PutXmlDocument(wordDoc.MainDocumentPart.EndnotesPart, xmlDoc);
            }
            if (wordDoc.MainDocumentPart.FootnotesPart != null)
            {
                xmlDoc = this.GetXmlDocument(wordDoc.MainDocumentPart.FootnotesPart);
                SearchAndReplaceInXmlDocument(xmlDoc, search, replace, matchCase);
                this.PutXmlDocument(wordDoc.MainDocumentPart.FootnotesPart, xmlDoc);
            }
        }
        void SearchAndReplaceInParagraph(XmlElement paragraph, string search,
           string replace, bool matchCase)
        {
            XmlDocument xmlDoc = paragraph.OwnerDocument;
            string wordNamespace =
                "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
            XmlNamespaceManager nsmgr =
                new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("w", wordNamespace);
            XmlNodeList paragraphText = paragraph.SelectNodes("descendant::w:t", nsmgr);
            StringBuilder sb = new StringBuilder();
            foreach (XmlNode text in paragraphText)
                sb.Append(((XmlElement)text).InnerText);

            if (search.Length == 0)
            {
                Regex _regex = new Regex(@"\[.*?\]");
                MatchCollection m = _regex.Matches(sb.ToString());
                foreach (Match item in m)
                {
                    string value = item.Groups[0].Value;
                    value = value.Remove(0,1);
                    value = value.Remove(value.Length - 1);
                    string text = ReportResult.processString(value);
                    this.SearchAndReplaceInParagraph(paragraph, item.Groups[0].Value, text, true);                    
                }
                return;
            }
            if (sb.ToString().Contains(search) ||
                (!matchCase && sb.ToString().ToUpper().Contains(search.ToUpper())))
            {
                XmlNodeList runs = paragraph.SelectNodes("child::w:r", nsmgr);
                foreach (XmlElement run in runs)
                {
                    XmlNodeList childElements = run.SelectNodes("child::*", nsmgr);
                    if (childElements.Count > 0)
                    {
                        XmlElement last = (XmlElement)childElements[childElements.Count - 1];
                        for (int c = childElements.Count - 1; c >= 0; --c)
                        {
                            if (childElements[c].Name == "w:rPr")
                                continue;
                            if (childElements[c].Name == "w:t")
                            {
                                string textElementString = childElements[c].InnerText;
                                for (int i = textElementString.Length - 1; i >= 0; --i)
                                {
                                    XmlElement newRun =
                                        xmlDoc.CreateElement("w:r", wordNamespace);
                                    XmlElement runProps =
                                        (XmlElement)run.SelectSingleNode("child::w:rPr", nsmgr);
                                    if (runProps != null)
                                    {
                                        XmlElement newRunProps =
                                            (XmlElement)runProps.CloneNode(true);
                                        newRun.AppendChild(newRunProps);
                                    }
                                    XmlElement newTextElement =
                                        xmlDoc.CreateElement("w:t", wordNamespace);
                                    XmlText newText =
                                        xmlDoc.CreateTextNode(textElementString[i].ToString());
                                    newTextElement.AppendChild(newText);
                                    if (textElementString[i] == ' ')
                                    {
                                        XmlAttribute xmlSpace = xmlDoc.CreateAttribute(
                                            "xml", "space",
                                            "http://www.w3.org/XML/1998/namespace");
                                        xmlSpace.Value = "preserve";
                                        newTextElement.Attributes.Append(xmlSpace);
                                    }
                                    newRun.AppendChild(newTextElement);
                                    paragraph.InsertAfter(newRun, run);
                                }
                            }
                            else
                            {
                                XmlElement newRun = xmlDoc.CreateElement("w:r", wordNamespace);
                                XmlElement runProps =
                                    (XmlElement)run.SelectSingleNode("child::w:rPr", nsmgr);
                                if (runProps != null)
                                {
                                    XmlElement newRunProps =
                                        (XmlElement)runProps.CloneNode(true);
                                    newRun.AppendChild(newRunProps);
                                }
                                XmlElement newChildElement =
                                    (XmlElement)childElements[c].CloneNode(true);
                                newRun.AppendChild(newChildElement);
                                paragraph.InsertAfter(newRun, run);
                            }
                        }
                        paragraph.RemoveChild(run);
                    }
                }

                while (true)
                {
                    bool cont = false;
                    runs = paragraph.SelectNodes("child::w:r", nsmgr);
                    for (int i = 0; i <= runs.Count - search.Length; ++i)
                    {
                        bool match = true;
                        for (int c = 0; c < search.Length; ++c)
                        {
                            XmlElement textElement =
                                (XmlElement)runs[i + c].SelectSingleNode("child::w:t", nsmgr);
                            if (textElement == null)
                            {
                                match = false;
                                break;
                            }
                            if (textElement.InnerText == search[c].ToString())
                                continue;
                            if (!matchCase &&
                                textElement.InnerText.ToUpper() == search[c].ToString().ToUpper())
                                continue;
                            match = false;
                            break;
                        }
                        if (match)
                        {
                            XmlElement runProps =
                                (XmlElement)runs[i].SelectSingleNode("descendant::w:rPr", nsmgr);
                            XmlElement newRun = xmlDoc.CreateElement("w:r", wordNamespace);
                            if (runProps != null)
                            {
                                XmlElement newRunProps = (XmlElement)runProps.CloneNode(true);
                                newRun.AppendChild(newRunProps);
                            }
                            XmlElement newTextElement =
                                xmlDoc.CreateElement("w:t", wordNamespace);
                            XmlText newText = xmlDoc.CreateTextNode(replace);
                            newTextElement.AppendChild(newText);
                            if (replace[0] == ' ' || replace[replace.Length - 1] == ' ')
                            {
                                XmlAttribute xmlSpace = xmlDoc.CreateAttribute("xml", "space",
                                    "http://www.w3.org/XML/1998/namespace");
                                xmlSpace.Value = "preserve";
                                newTextElement.Attributes.Append(xmlSpace);
                            }
                            newRun.AppendChild(newTextElement);
                            paragraph.InsertAfter(newRun, (XmlNode)runs[i]);
                            for (int c = 0; c < search.Length; ++c)
                                paragraph.RemoveChild(runs[i + c]);
                            cont = true;
                            break;
                        }
                    }
                    if (!cont)
                        break;
                }

                // Consolidate adjacent runs that have only text elements, and have the
                // same run properties. This isn't necessary to create a valid document,
                // however, having the split runs is a bit messy.
                XmlNodeList children = paragraph.SelectNodes("child::*", nsmgr);
                List<int> matchId = new List<int>();
                int id = 0;
                for (int c = 0; c < children.Count; ++c)
                {
                    if (c == 0)
                    {
                        matchId.Add(id);
                        continue;
                    }
                    if (children[c].Name == "w:r" &&
                        children[c - 1].Name == "w:r" &&
                        children[c].SelectSingleNode("w:t", nsmgr) != null &&
                        children[c - 1].SelectSingleNode("w:t", nsmgr) != null)
                    {
                        XmlElement runProps =
                            (XmlElement)children[c].SelectSingleNode("w:rPr", nsmgr);
                        XmlElement lastRunProps =
                            (XmlElement)children[c - 1].SelectSingleNode("w:rPr", nsmgr);
                        if ((runProps == null && lastRunProps != null) ||
                            (runProps != null && lastRunProps == null))
                        {
                            matchId.Add(++id);
                            continue;
                        }
                        if (runProps != null && runProps.InnerXml != lastRunProps.InnerXml)
                        {
                            matchId.Add(++id);
                            continue;
                        }
                        matchId.Add(id);
                        continue;
                    }
                    matchId.Add(++id);
                }

                for (int i = 0; i <= id; ++i)
                {
                    var x1 = matchId.IndexOf(i);
                    var x2 = matchId.LastIndexOf(i);
                    if (x1 == x2)
                        continue;
                    StringBuilder sb2 = new StringBuilder();
                    for (int z = x1; z <= x2; ++z)
                        sb2.Append(((XmlElement)children[z]
                            .SelectSingleNode("w:t", nsmgr)).InnerText);
                    XmlElement newRun = xmlDoc.CreateElement("w:r", wordNamespace);
                    XmlElement runProps =
                        (XmlElement)children[x1].SelectSingleNode("child::w:rPr", nsmgr);
                    if (runProps != null)
                    {
                        XmlElement newRunProps = (XmlElement)runProps.CloneNode(true);
                        newRun.AppendChild(newRunProps);
                    }
                    XmlElement newTextElement = xmlDoc.CreateElement("w:t", wordNamespace);
                    XmlText newText = xmlDoc.CreateTextNode(sb2.ToString());
                    newTextElement.AppendChild(newText);
                    if (sb2[0] == ' ' || sb2[sb2.Length - 1] == ' ')
                    {
                        XmlAttribute xmlSpace = xmlDoc.CreateAttribute(
                            "xml", "space", "http://www.w3.org/XML/1998/namespace");
                        xmlSpace.Value = "preserve";
                        newTextElement.Attributes.Append(xmlSpace);
                    }
                    newRun.AppendChild(newTextElement);
                    paragraph.InsertAfter(newRun, children[x2]);
                    for (int z = x1; z <= x2; ++z)
                        paragraph.RemoveChild(children[z]);
                }

                var txbxParagraphs = paragraph.SelectNodes("descendant::w:p", nsmgr);
                foreach (XmlElement p in txbxParagraphs)
                    SearchAndReplaceInParagraph((XmlElement)p, search, replace, matchCase);
            }
        }       
    }
    public class SearchAndReplaceException : Exception
    {
        public SearchAndReplaceException(string message) : base(message) { }
    }

    public static class Extensions
    {
        public static string ToStringAlignAttributes(this XContainer xContainer)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = true;
            StringBuilder sb = new StringBuilder();
            using (XmlWriter xmlWriter = XmlWriter.Create(sb, settings))
                xContainer.WriteTo(xmlWriter);
            return sb.ToString();
        }

        public static XDocument GetXDocument(this XmlDocument document)
        {
            XDocument xDoc = new XDocument();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                document.WriteTo(xmlWriter);
            XmlDeclaration decl =
                document.ChildNodes.OfType<XmlDeclaration>().FirstOrDefault();
            if (decl != null)
                xDoc.Declaration = new XDeclaration(decl.Version, decl.Encoding,
                    decl.Standalone);
            return xDoc;
        }

        public static XElement GetXElement(this XmlNode node)
        {
            XDocument xDoc = new XDocument();
            using (XmlWriter xmlWriter = xDoc.CreateWriter())
                node.WriteTo(xmlWriter);
            return xDoc.Root;
        }
    }
}
