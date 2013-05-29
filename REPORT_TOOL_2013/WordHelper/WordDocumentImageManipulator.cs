using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


namespace WordHelper
{
    public class WordDocumentImageManipulator : IDisposable
    {
        bool disposed = false;

        // Occured when an image is deleted or replaced.
        public event EventHandler ImagesChanged;

        // The WordprocessingDocument instance.
        public WordprocessingDocument Document { get; private set; }

        /// <summary>
        /// Initialize the WordDocumentImageManipulator instance.
        /// </summary>
        /// <param name="path">
        /// The document file path.
        /// </param>
        public WordDocumentImageManipulator(FileInfo path)
        {

            // Open the document as editable.
            Document = WordprocessingDocument.Open(path.FullName, true);

        }
        public WordDocumentImageManipulator(WordprocessingDocument doc)
        {

            // Open the document as editable.
            Document = doc;

        }

        /// <summary>
        /// Get all images in the documents.
        /// The image in a document is stored as a Blip element.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Blip> GetAllImages()
        {

            // Get the drawing elements in the document.
            var drawingElements = from run in Document.MainDocumentPart.Document.Descendants<DocumentFormat.OpenXml.Wordprocessing.Run>()
                                  where run.Descendants<Drawing>().Count() != 0
                                  select run.Descendants<Drawing>().First();

            // Get the blip elements in the drawing elements.
            var blipElements = from drawing in drawingElements
                               where drawing.Descendants<Blip>().Count() > 0
                               select drawing.Descendants<Blip>().First();

            return blipElements;
        }

        /// <summary>
        /// Get the image from the Blip element.
        /// </summary>
        public Image GetImageInBlip(Blip blipElement)
        {

            // Get the ImagePart referred by the Blip element.
            var imagePart = Document.MainDocumentPart.GetPartById(blipElement.Embed.Value)
                as ImagePart;

            if (imagePart != null)
            {
                using (Stream imageStream = imagePart.GetStream())
                {
                    Bitmap img = new Bitmap(imageStream);
                    return img;
                }
            }
            else
            {
                throw new ApplicationException("Can not find image part : "
                    + blipElement.Embed.Value);
            }
        }

        /// <summary>
        /// Get the DocumentFormat.OpenXml.Wordprocessing.Table from the tag
        /// </summary>
        public DocumentFormat.OpenXml.Wordprocessing.Table GetTable(string tag)
        {
            string tblTag = "StockTableTag";
            MainDocumentPart mainPart = Document.MainDocumentPart;
            //StockService.baseDS.stockCodeDataTable tbl = Gateway.PriceData.getPriceDataToDay();
            SdtBlock ccWithTable = mainPart.Document.Body.Descendants<SdtBlock>().Where
            (r => r.SdtProperties.GetFirstChild<Tag>().Val == tblTag).Single();

            // This should return only one table.
            DocumentFormat.OpenXml.Wordprocessing.Table theTable = ccWithTable.Descendants<DocumentFormat.OpenXml.Wordprocessing.Table>().Single();
            return theTable;
        }

        /// <summary>
        /// Delete the Drawing element that contains the Blip element.
        /// </summary>
        /// <param name="blipElement"></param>
        public void DeleteImage(Blip blipElement)
        {
            OpenXmlElement parent = blipElement.Parent;
            while (parent != null &&
                !(parent is DocumentFormat.OpenXml.Wordprocessing.Drawing))
            {
                parent = parent.Parent;
            }

            if (parent != null)
            {
                Drawing drawing = parent as Drawing;
                drawing.Parent.RemoveChild<Drawing>(drawing);

                // Raise the ImagesChanged event.
                this.OnImagesChanged();

            }
        }

        /// <summary>
        /// To replace an image in a document
        /// 1. Add an ImagePart to the document.
        /// 2. Edit the Blip element to refer to the new ImagePart.
        /// </summary>
        /// <param name="blipElement"></param>
        /// <param name="newImg"></param>
        public void ReplaceImage(Blip blipElement, FileInfo newImg)
        {
            string rid = AddImagePart(newImg);
            blipElement.Embed.Value = rid;
            this.OnImagesChanged();
        }

        /// <summary>
        /// Add ImagePart to the document.
        /// </summary>
        string AddImagePart(FileInfo newImg)
        {
            ImagePartType type = ImagePartType.Bmp;
            switch (newImg.Extension.ToLower())
            {
                case ".jpeg":
                case ".jpg":
                    type = ImagePartType.Jpeg;
                    break;
                case ".png":
                    type = ImagePartType.Png;
                    break;
                default:
                    type = ImagePartType.Bmp;
                    break;
            }

            ImagePart newImgPart = Document.MainDocumentPart.AddImagePart(type);
            using (FileStream stream = newImg.OpenRead())
            {
                newImgPart.FeedData(stream);
            }

            string rId = Document.MainDocumentPart.GetIdOfPart(newImgPart);
            return rId;
        }


        /// <summary>
        ///  Raise the ImagesChanged event.
        /// </summary>
        protected virtual void OnImagesChanged()
        {
            if (this.ImagesChanged != null)
            {
                this.ImagesChanged(this, EventArgs.Empty);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Protect from being called multiple times.
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                if (Document != null)
                {
                    Document.Dispose();
                }
                disposed = true;
            }
        }
    }
}
