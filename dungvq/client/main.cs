using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace client
{
    //public partial class main : common.forms.baseApplication
    public partial class main : baseClass.forms.baseApplication
    {
        private baseClass.controls.formContainer myLeftPane = new baseClass.controls.formContainer();
        private baseClass.controls.formContainer myMidPane = new baseClass.controls.formContainer();
        private const string myPaneNameLeft = "_leftPane";
        private const string myPaneMiddle = "_middlePane";
        private const int myPaneLeftWidth = 200;

        public main()
        {
            try
            {
                InitializeComponent();
                myMidPane.myArrangeOptions = common.control.childArrangeOptions.Tiled; 
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
       
        protected override bool LoadAppConfig()
        {
            common.Consts.constValidCallString = common.Consts.constValidCallMarker;
            return base.LoadAppConfig();
        }
        protected override bool CheckValid()
        {
            return true;
        }

        private void ArrangForms()
        {
            if (myLeftPane.ChildCount <= 0) myMidPane.Location = new Point(0, 0);
            else myMidPane.Location = new Point(myLeftPane.Location.X + myLeftPane.Size.Width, myLeftPane.Location.Y);
            myMidPane.Size = new Size(this.ClientRectangle.Width - myMidPane.Location.X,
                                      this.ClientRectangle.Height - myMidPane.Location.Y - 2 * SystemInformation.CaptionHeight); 
        }

        private void ShowStockChart(data.baseDS.stockCodeExtRow stockRow)
        {
            try
            {
                string formName = myPaneMiddle + stockRow.code.Trim();
                forms.tradeAnalysis myForm = (forms.tradeAnalysis)common.formList.FindForm(formName);
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new forms.tradeAnalysis();
                    myForm.Name = formName;
                    myForm.MdiParent = this;
                    common.formList.AddForm(myForm);
                    myMidPane.AddChild(myForm, formName);
                    myForm.FormClosed += new FormClosedEventHandler(FormClosedHandler);

                    myForm.FormBorderStyle = FormBorderStyle.Sizable;
                    myForm.MinimizeBox = true;
                }
                myForm.ShowForm(stockRow);
                ArrangForms();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private client.forms.watchList GetWathListForm(bool createIfNotExisted)
        {
            string formName = myPaneNameLeft;
            forms.watchList myForm = (forms.watchList)common.formList.FindForm(formName);
            if (!createIfNotExisted)
            {
                if (myForm.IsDisposed) return null; 
                return myForm;
            }

            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new forms.watchList();
                myForm.MdiParent = this;
                //myForm.Parent = this;
                myForm.Name = formName;
                myLeftPane.Location = new Point(0, 0);
                myLeftPane.Size = new Size(myPaneLeftWidth, this.ClientRectangle.Height - 2 * SystemInformation.CaptionHeight);

                myForm.Location = new Point(0, 0);
                myForm.Size = new Size(myPaneLeftWidth, this.ClientRectangle.Height - 2 * SystemInformation.CaptionHeight);

                myForm.TopMost = true;
                myForm.myOnShowChart += new baseClass.forms.basePortfolioView.onShowChart(ShowStockChart);
                myForm.FormClosed += new FormClosedEventHandler(FormClosedHandler);
                common.formList.AddForm(myForm);
                myLeftPane.AddChild(myForm,formName);
                ArrangForms();
            }
            return myForm;
        }

        private stockTrade.forms.baseTradeAlertList GetTradeAlertListForm(bool createIfNotExisted)
        {
            stockTrade.forms.baseTradeAlertList myForm = (stockTrade.forms.baseTradeAlertList)common.formList.FindForm("TradeAlertList");
            if (!createIfNotExisted) return myForm;
            if (myForm == null || myForm.IsDisposed)
            {
                myForm = new stockTrade.forms.baseTradeAlertList();
                myForm.MdiParent = this;
                myForm.Name = "TradeAlertList";
                myForm.SetColumnVisible(stockTrade.forms.baseTradeAlertList.gridColumnName.Status.ToString(), false);
                myForm.Size = new Size(550,350);
                myForm.InitForm();
                myForm.StartPosition = FormStartPosition.CenterParent;
            }
            return myForm;
        }

        private void FormClosedHandler(object sender, FormClosedEventArgs e)
        {
            Form myForm = (Form)sender;
            if (myForm.Name.Trim().ToLower() == myPaneNameLeft.Trim().ToLower())
                myLeftPane.RemoveChild(((Form)sender).Name);
            else myMidPane.RemoveChild(((Form)sender).Name);
            ArrangForms();
        }

        #region event handler
        private void arrangeHorizontalMenuItem_Click(object sender, EventArgs e)
        {
            //Tile all child forms horizontally.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }

        private void arrangeIconsMenuItem_Click(object sender, EventArgs e)
        {
            //Arrange MDI child icons within the client region of the MDI parent form.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons);
        }

        private void cascadeMenuItem_Click(object sender, EventArgs e)
        {
            //Cascade all child forms.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void arrangeVerticalMenuItem_Click(object sender, EventArgs e)
        {
            //Tile all child forms horizontally.
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void maximizeAllMenuItem_Click(object sender, EventArgs e)
        {
            //Gets forms that represent the MDI child forms 
            //that are parented to this form in an array
            Form[] charr = this.MdiChildren;

            //for each child form set the window state to Maximized
            foreach (Form chform in charr)
                chform.WindowState = FormWindowState.Maximized;
        }

   
        private void backTestingMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form myForm = this.FindForm("backTesting");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new stock.forms.backTesting();
                    myForm.MdiParent = this;
                    myForm.Name = "backTesting";
                }
                this.ShowForm(myForm, false);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        private void loginMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.ShowLogin(); 
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void watchListMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form myForm = GetWathListForm(true);
                //AdjustMainForms();
                common.formList.ShowForm(myForm, false);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void tradeAlertMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                stockTrade.forms.baseTradeAlertList myForm = GetTradeAlertListForm(true);
                common.formList.ShowForm(myForm, false);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }

        }

        private void orderMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form myForm = this.FindForm("TradeOrderAddNew");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new stockTrade.forms.baseTradeOrderAddNew();
                    myForm.MdiParent = this;
                    myForm.Name = "TradeOrderAddNew";
                }
                ((stockTrade.forms.baseTradeOrderAddNew)myForm).ShowForm();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void companyListMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form myForm = this.FindForm("companyList");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new client.forms.companyList();
                    myForm.MdiParent = this;
                    myForm.Name = "companyList";
                }
                this.ShowForm(myForm, false);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void portfolioMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                stockTrade.forms.basePortfolioManagement myForm = (stockTrade.forms.basePortfolioManagement)this.FindForm("portfolioView");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new stockTrade.forms.basePortfolioManagement();
                    myForm.Name = "portfolioView";
                    myForm.MdiParent = this;
                    myForm.myOnShowChart += new stockTrade.forms.basePortfolioManagement.onShowChart(ShowStockChart);
                }
                this.ShowForm(myForm, false);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void strategyRankingMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                common.system.ShowMessage("Sorry, the function was not implemented!");
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form  myForm = this.FindForm("sysOptions");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new baseClass.forms.baseSysOptions();
                    myForm.MdiParent = this;
                    myForm.Name = "sysOptions";
                    myForm.MdiParent = this;
                }
                this.ShowForm(myForm, false);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void myInfoMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form myForm = this.FindForm("investorEdit");
                if (myForm == null || myForm.IsDisposed)
                {
                    myForm = new client.forms.investorEdit();
                    myForm.MdiParent = this;
                    myForm.Name = "investorEdit";
                }
                this.ShowForm(myForm, false);
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        private void main_Resize(object sender, EventArgs e)
        {
            try
            {
                ArrangForms();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion event handler
    }
}
