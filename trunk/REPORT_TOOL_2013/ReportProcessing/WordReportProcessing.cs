using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using System.IO;

namespace ReportProcessing
{
    public class WordReportProcessing
    {
        public WordReportProcessing()
        {         

        }
        public void executeDocument(string fileName)
        {
            if (File.Exists("template_output.docx"))
            {
                File.Delete("template_output.docx");
            }
            File.Copy(fileName, "template_output.docx");
            using (WordprocessingDocument doc =
           WordprocessingDocument.Open("template_output.docx", true))
            {
              
                //SearchAndReplacer.SearchAndReplace(doc, "", "", true);
                WordAnalysis wordAnalysis = new WordAnalysis();
                wordAnalysis.AnalyseReport(doc);                
                doc.MainDocumentPart.Document.Save();
            }
        }
    }
}
