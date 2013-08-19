using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using System.Xml;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;
using System.Windows.Forms.DataVisualization.Charting;
using OpenXMLDemo.StockService;
using OpenXMLDemo.Gateway;


namespace OpenXMLDemo
{
    public partial class Form1 : Form
    {
        //http://msdn.microsoft.com/en-us/library/cc850833.aspx
        WordDocumentImageManipulator documentManipulator;
        List<String> lstStockCodes = new List<string> { "VBC", "TCT", "HGM", "HLY", "FDT","BVH", "MSN" };
        public Form1()
        {
            InitializeComponent();
            //pieChart1.Load += new EventHandler(pieChart3D1_Load);
            lineCurvesChartType1.Load += new EventHandler(customChart1_Load); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PriceData.getPriceDataToDay("ACB");
            if (File.Exists("template_output.docx"))
            {
                File.Delete("template_output.docx");
            }
            File.Copy("template_input.docx", "template_output.docx");
            //OpenXMLUtils.createDocument("t.docx");
            //OpenXMLUtils.CreateTable("t.docx");
            //OpenXMLUtils.replacePicture("template.docx");            
            using (WordprocessingDocument doc =
               WordprocessingDocument.Open("template_output.docx", true))
            {
                SearchAndReplacer.SearchAndReplace(doc, "[date]", DateTime.Now.ToShortDateString(), true);
                SearchAndReplacer.SearchAndReplace(doc, "[Market Overview]", "Với  một phiên tăng giá tiếp  tục  trên  cả 2  sàn  trong  ngày  10/1,  các  tín hiệu xác nhận sự đảo chiều giảm điểm đã không xuất hiện, đà tăng giá vẫn chưa có dấu hiệu dừng lại. ", true);
                SearchAndReplacer.SearchAndReplace(doc, "[change1]", "+2.53%", true);
                SearchAndReplacer.SearchAndReplace(doc, "[change2]", "+1.54%", true);
                SearchAndReplacer.SearchAndReplace(doc, "[gtdc1]", "460.12", true);
                SearchAndReplacer.SearchAndReplace(doc, "[gtdc2]", "60.53", true);
                SearchAndReplacer.SearchAndReplace(doc, "[klgd1]", "79.394.580", true);
                SearchAndReplacer.SearchAndReplace(doc, "[klgd2]", "67.007.880", true);
                SearchAndReplacer.SearchAndReplace(doc, "[gtgd1]", "1.523,346", true);
                SearchAndReplacer.SearchAndReplace(doc, "[gtgd2]", "470,871", true);

                // Dispose the previous instance.
                if (documentManipulator != null)
                {
                    documentManipulator.Dispose();
                }

                documentManipulator = new WordDocumentImageManipulator(doc);
             
                int i = 1;
                foreach (var blip in documentManipulator.GetAllImages())
                {                    
                    if (i == 1)
                    {                        
                        documentManipulator.ReplaceImage(
                              blip,
                              new FileInfo("lineChart.jpg"));
                        i++;
                        continue;
                    }
                    documentManipulator.ReplaceImage(
                                  blip,
                                  new FileInfo("ck" + (i-1) + ".png"));
                    i++;
                }
                string tblTag = "StockTableTag";
                MainDocumentPart mainPart = doc.MainDocumentPart;
                //StockService.baseDS.stockCodeDataTable tbl = Gateway.PriceData.getPriceDataToDay();
                SdtBlock ccWithTable = mainPart.Document.Body.Descendants<SdtBlock>().Where
                (r => r.SdtProperties.GetFirstChild<Tag>().Val == tblTag).Single();

                // This should return only one table.
                Table theTable = ccWithTable.Descendants<Table>().Single();
                // Get the last row in the table.
                TableRow theRow = theTable.Elements<TableRow>().Last();
                foreach (var item in lstStockCodes)
                {
                    try
                    {
                        StockService.baseDS.priceDataRow row = Gateway.PriceData.getPriceDataToDay(item);
                        TableRow rowCopy = (TableRow)theRow.CloneNode(true);
                        rowCopy.Descendants<TableCell>().ElementAt(0).Append(new Paragraph
                            (new Run(new Text(row.stockCode.ToString()))));
                        rowCopy.Descendants<TableCell>().ElementAt(1).Append(new Paragraph
                            (new Run(new Text(row.openPrice.ToString()))));
                        rowCopy.Descendants<TableCell>().ElementAt(2).Append(new Paragraph
                            (new Run(new Text(row.closePrice.ToString()))));
                        rowCopy.Descendants<TableCell>().ElementAt(3).Append(new Paragraph
                        (new Run(new Text(row.volume.ToString()))));
                        theTable.AppendChild(rowCopy);
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }                    
                }
                // Remove the empty placeholder row from the table.
                theTable.RemoveChild(theRow);

                // Save the changes to the table back into the document.
                mainPart.Document.Save();                                
            }
            MessageBox.Show("Input->template_input.docx and Ouput->template_output.docx. Success!!! The program will be closed!!!");
            this.Close();
        }
        private void InitAndDrawIndexes()
        {
            baseDS.priceDataDataTable tbl1 = Gateway.PriceData.GetPriceData("VN-IDX", "D1", DateTime.Now.AddDays(-20), DateTime.Now);
            baseDS.priceDataDataTable tbl2 = Gateway.PriceData.GetPriceData("HNX-IDX", "D1", DateTime.Now.AddDays(-20), DateTime.Now);
            #region VNINDEX
            decimal[] yValues = new decimal[tbl1.Count];
            string[] xValues = new string[tbl1.Count];
            for (int idx = 0; idx < tbl1.Count; idx++)
            {
                yValues[idx] = tbl1[idx].closePrice;
                xValues[idx] = tbl1[idx].onDate.ToShortDateString();
            }
            Chart lineChart = lineCurvesChartType1.getChart();
            lineChart.Series["Series1"].LegendText = "VN-Index";
            lineChart.Series["Series1"].XValueType = ChartValueType.Date;
            lineChart.Series["Series1"].YValueType = ChartValueType.Int32;
            //lineChart.Legends["Series1"].Title = "VN-Index";
            //lineChart.Legends["Series1"].DockedToChartArea = "Default";
            lineChart.Series["Series1"].MarkerStyle = MarkerStyle.None;
            lineChart.Series["Series1"].Points.DataBindXY(xValues, yValues);
            lineChart.Series["Series1"].Color = System.Drawing.Color.Red;
            lineChart.Series["Series1"].IsValueShownAsLabel = true;

            // Set Doughnut chart type
            lineChart.Series["Series1"].ChartType = SeriesChartType.Line;

            // Set labels style
            lineChart.Series["Series1"]["PieLabelStyle"] = "Inside";

            // Set Doughnut radius percentage
            lineChart.Series["Series1"]["DoughnutRadius"] = "99";

            // Explode data point with label "Italy"
            lineChart.Series["Series1"].Points[yValues.Length - 1]["Exploded"] = "true";

            // Enable 3D
            lineChart.ChartAreas["Default"].Area3DStyle.Enable3D = false;
            lineChart.ChartAreas["Default"].AxisX.IsMarginVisible = true;

            // Set drawing style
            lineChart.Series["Series1"]["PieDrawingStyle"] = "SoftEdge";
            #endregion VNINDEX
            //HNX series
            #region HNX
            //decimal[] yValues2 = new decimal[tbl2.Count];
            //string[] xValues2 = new string[tbl2.Count];
            //for (int idx = 0; idx < tbl2.Count; idx++)
            //{
            //    yValues2[idx] = tbl2[idx].closePrice;
            //    xValues2[idx] = tbl2[idx].onDate.ToShortDateString();
            //}
            //lineChart.Series["Series2"].XValueType = ChartValueType.Date;
            //lineChart.Series["Series2"].YValueType = ChartValueType.Int32;            
            //lineChart.Series["Series2"].Points.DataBindXY(xValues2, yValues2);
            //lineChart.Series["Series2"].Color = Color.Green;
            //lineChart.Series["Series2"].IsValueShownAsLabel = true;
            //lineChart.Series["Series2"].LegendText = "HNX-Index";

            ////lineChart.Series["Series2"].Label =                

            //// Set Doughnut chart type
            //lineChart.Series["Series2"].ChartType = SeriesChartType.Line;

            //// Set labels style
            //lineChart.Series["Series2"]["PieLabelStyle"] = "Inside";


            //// Explode data point with label "Italy"
            //lineChart.Series["Series2"].Points[yValues2.Length - 1]["Exploded"] = "true";


            #endregion HNX
            //END HNX series
            Title title4 = new Title();
            title4.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold);
            title4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            title4.Name = "Title1";
            title4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title4.ShadowOffset = 1;
            title4.Text = "BIỂU ĐỒ CHỈ SỐ VN-INDEX TUẦN QUA";
            lineChart.Titles.Clear();
            lineChart.Titles.Add(title4);
        }
        //void pieChart3D1_Load(object sender, EventArgs e)
        //{
        //    InitAndDrawPieChart();
        //}
        void customChart1_Load(object sender, EventArgs e)
        {
            InitAndDrawIndexes();
            lineCurvesChartType1.getChart().SaveImage("lineChart.jpg", ChartImageFormat.Jpeg);
        }
        //private void InitAndDrawPieChart()
        //{
        //    //databases.tmpDS.dataVarrianceDataTable tbl = DataAccess.Libs.GetPriceVarrianceWeekly(4);
        //    Chart pieChart = pieChart1.pieChart;
        //    tmpDS.dataVarrianceDataTable tbl = new tmpDS.dataVarrianceDataTable();
        //    tbl.AdddataVarrianceRow("ACB", 100, 30);
        //    tbl.AdddataVarrianceRow("MSN", 120, 20);
        //    tbl.AdddataVarrianceRow("AAA", 25, 15);
        //    tbl.AdddataVarrianceRow("SSI", 35, 35);
        //    tbl.AdddataVarrianceRow(
        //    decimal[] yValues = new decimal[tbl.Count];
        //    string[] xValues = new string[tbl.Count];
        //    for (int idx = 0; idx < tbl.Count; idx++)
        //    {
        //        yValues[idx] = tbl[idx].percent;
        //        xValues[idx] = tbl[idx].code;
        //    }

        //    // Populate series data
        //    pieChart.Series["Default"].Points.DataBindXY(xValues, yValues);

        //    // Set Doughnut chart type
        //    pieChart.Series["Default"].ChartType = SeriesChartType.Pie;

        //    // Set labels style
        //    pieChart.Series["Default"]["PieLabelStyle"] = "Inside";

        //    // Set Doughnut radius percentage
        //    pieChart.Series["Default"]["DoughnutRadius"] = "99";

        //    // Explode data point with label "Italy"
        //    pieChart.Series["Default"].Points[yValues.Length - 1]["Exploded"] = "true";

        //    // Enable 3D
        //    pieChart.ChartAreas["Default"].Area3DStyle.Enable3D = true;

        //    // Set drawing style
        //    pieChart.Series["Default"]["PieDrawingStyle"] = "SoftEdge";
        //    Title title4 = new Title();
        //    title4.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold);
        //    title4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
        //    title4.Name = "Title1";
        //    title4.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        //    title4.ShadowOffset = 3;
        //    title4.Text = "Price Varriance Weekly";
        //    pieChart.Titles.Clear();
        //    pieChart.Titles.Add(title4);
        //}
    }
}
