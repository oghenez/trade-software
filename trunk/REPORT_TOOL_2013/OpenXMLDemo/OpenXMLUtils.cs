using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using System.IO;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml;
using System.Text.RegularExpressions;

namespace OpenXMLDemo
{
    public class OpenXMLUtils
    {
        public static void replacePicture(string filePath)
        {

            using (WordprocessingDocument doc =
           WordprocessingDocument.Open(filePath, true))
            {

                SdtBlock cc = doc.MainDocumentPart.Document.Body.Descendants<SdtBlock>()
                    .FirstOrDefault(c =>
                    {
                        SdtProperties p = c.Elements<SdtProperties>().FirstOrDefault();
                        if (p != null)
                        {
                            // Is it a picture content control?
                            SdtContentPicture pict =
                                p.Elements<SdtContentPicture>().FirstOrDefault();
                            // Get the alias.
                            SdtAlias a = p.Elements<SdtAlias>().FirstOrDefault();
                            if (pict != null)
                                return true;
                        }
                        return false;
                    });
                string embed = null;
                if (cc != null)
                {
                    Drawing dr = cc.Descendants<Drawing>().FirstOrDefault();
                    if (dr != null)
                    {
                        Blip blip = dr.Descendants<Blip>().FirstOrDefault();
                        if (blip != null)
                            embed = blip.Embed;
                    }
                }
                if (embed != null)
                {
                    IdPartPair idpp = doc.MainDocumentPart.Parts
                        .Where(pa => pa.RelationshipId == embed).FirstOrDefault();
                    if (idpp != null)
                    {
                        ImagePart ip = (ImagePart)idpp.OpenXmlPart;
                        using (FileStream fileStream =
                            File.Open("test.png", FileMode.Open))
                            ip.FeedData(fileStream);                        
                    }
                }

            }
        }
        public static void createDocument(string filepath)
        {
            // Create a document by supplying the filepath. 
            using (WordprocessingDocument wordDocument =
                WordprocessingDocument.Create(filepath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                // Create the document structure and add some text.
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                DocumentFormat.OpenXml.Wordprocessing.Paragraph para = body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph());
                DocumentFormat.OpenXml.Wordprocessing.Run run = para.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Run());
                run.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Text("HQ - QUANTUM 2012"));
            }

        }

        public static void InsertAPicture(string document, string fileName)
        {
            using (WordprocessingDocument wordprocessingDocument =
                WordprocessingDocument.Open(document, true))
            {
                MainDocumentPart mainPart = wordprocessingDocument.MainDocumentPart;

                ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);

                using (FileStream stream = new FileStream(fileName, FileMode.Open))
                {
                    imagePart.FeedData(stream);
                }

                AddImageToBody(wordprocessingDocument, mainPart.GetIdOfPart(imagePart));
            }
        }
        private static void AddImageToBody(DocumentFormat.OpenXml.Packaging.WordprocessingDocument wordDoc, string relationshipId)
        {
            //Define the reference of the image.
            var element =
                 new Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = 990000L, Cy = 792000L },
                         new DW.EffectExtent()
                         {
                             LeftEdge = 0L,
                             TopEdge = 0L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new DW.DocProperties()
                         {
                             Id = (UInt32Value)1U,
                             Name = "Picture 1"
                         },
                         new DW.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new PIC.Picture(
                                     new PIC.NonVisualPictureProperties(
                                         new PIC.NonVisualDrawingProperties()
                                         {
                                             Id = (UInt32Value)0U,
                                             Name = "New Bitmap Image.jpg"
                                         },
                                         new PIC.NonVisualPictureDrawingProperties()),
                                     new PIC.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension()
                                                 {
                                                     Uri =
                                                       "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                 })
                                         )
                                         {
                                             Embed = relationshipId,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = 990000L, Cy = 792000L }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         ) { Preset = A.ShapeTypeValues.Rectangle }))
                             ) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = (UInt32Value)0U,
                         DistanceFromBottom = (UInt32Value)0U,
                         DistanceFromLeft = (UInt32Value)0U,
                         DistanceFromRight = (UInt32Value)0U,
                         EditId = "50D07946"
                     });

            //Append the reference to body, the element should be in a Run.
            wordDoc.MainDocumentPart.Document.Body.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(element)));
        }
        // Insert a table into a word processing document.
        public static void CreateTable(string fileName)
        {
            // Use the file name and path passed in as an argument 
            // to open an existing Word 2007 document.

            using (WordprocessingDocument doc
                = WordprocessingDocument.Open(fileName, true))
            {
                // Create an empty table.
                DocumentFormat.OpenXml.Wordprocessing.Table table = new DocumentFormat.OpenXml.Wordprocessing.Table();

                // Create a TableProperties object and specify its border information.
                DocumentFormat.OpenXml.Wordprocessing.TableProperties tblProp = new DocumentFormat.OpenXml.Wordprocessing.TableProperties(
                    new TableBorders(
                        new DocumentFormat.OpenXml.Wordprocessing.TopBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Dashed),
                            Size = 24
                        },
                        new DocumentFormat.OpenXml.Wordprocessing.BottomBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Dashed),
                            Size = 24
                        },
                        new DocumentFormat.OpenXml.Wordprocessing.LeftBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Dashed),
                            Size = 24
                        },
                        new DocumentFormat.OpenXml.Wordprocessing.RightBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Dashed),
                            Size = 24
                        },
                        new DocumentFormat.OpenXml.Wordprocessing.InsideHorizontalBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Dashed),
                            Size = 24
                        },
                        new DocumentFormat.OpenXml.Wordprocessing.InsideVerticalBorder()
                        {
                            Val =
                                new EnumValue<BorderValues>(BorderValues.Dashed),
                            Size = 24
                        }
                    )
                );

                // Append the TableProperties object to the empty table.
                table.AppendChild<DocumentFormat.OpenXml.Wordprocessing.TableProperties>(tblProp);

                // Create a row.
                DocumentFormat.OpenXml.Wordprocessing.TableRow tr = new  DocumentFormat.OpenXml.Wordprocessing.TableRow();

                // Create a cell.
                DocumentFormat.OpenXml.Wordprocessing.TableCell tc1 = new DocumentFormat.OpenXml.Wordprocessing.TableCell();

                // Specify the width property of the table cell.
                tc1.Append(new DocumentFormat.OpenXml.Wordprocessing.TableCellProperties(
                    new TableCellWidth() { Type = TableWidthUnitValues.Dxa, Width = "2400" }));

                // Specify the table cell content.
                tc1.Append(new DocumentFormat.OpenXml.Wordprocessing.Paragraph(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text("some text"))));

                // Append the table cell to the table row.
                tr.Append(tc1);

                // Create a second table cell by copying the OuterXml value of the first table cell.
                DocumentFormat.OpenXml.Wordprocessing.TableCell tc2 = new DocumentFormat.OpenXml.Wordprocessing.TableCell(tc1.OuterXml);

                // Append the table cell to the table row.
                tr.Append(tc2);

                // Append the table row to the table.
                table.Append(tr);

                // Append the table to the document.
                doc.MainDocumentPart.Document.Body.Append(table);
            }
        }
        public static void SearchAndReplace(string document)
        {
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(document, true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }

                Regex regexText = new Regex("[Market Overview]");
                docText = regexText.Replace(docText,DateTime.Now.ToShortDateString());

                using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    sw.Write(docText);
                }
            }
        }
    }

}
