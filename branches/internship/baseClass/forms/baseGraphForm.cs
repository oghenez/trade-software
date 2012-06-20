using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using application;

namespace baseClass.forms
{
    public partial class baseGraphForm : baseForm
    {
        public baseGraphForm()
        {
            try
            {
                InitializeComponent();
                FormReSize();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }

        public delegate void ChildPaneClosed(baseClass.controls.graphPanel sender);
        public event ChildPaneClosed myOnChildPaneClosed = null;

        public void SetMasterPane(Point p)
        {
            mainContainer.Location = p;
        }
        public void SetMasterPane(Size s)
        {
            mainContainer.Size = s;
        }


        public baseClass.controls.graphPanel CreatePane(string name, int weight)
        {
            return CreatePane(name, weight, null);
        }
        public baseClass.controls.graphPanel CreatePane(string name, int weight, string underPaneName)
        {
            baseClass.controls.graphPanel myPane = new baseClass.controls.graphPanel();
            myPane.Size = new Size(this.ClientRectangle.Width, this.ClientRectangle.Height);

            myPane.myWeight = weight;
            myPane.Name = name;
            myPane.myOnClosing += new common.controls.basePanel.OnClosing(PaneClosingdHandler);

            mainContainer.Controls.Add(myPane);
            myPane.myContainer = mainContainer;
            if (underPaneName == null) mainContainer.AddChild(myPane, myPane.Name);
            else mainContainer.InsertChild(underPaneName, myPane, myPane.Name);
            mainContainer.ArrangeChildren();

            return myPane;
        }
        public baseClass.controls.graphPanel GetPane(string name)
        {
            return (baseClass.controls.graphPanel)mainContainer.GetChild(name);
        }
        public void RemovePane(baseClass.controls.graphPanel myPane)
        {
            mainContainer.Controls.Remove(myPane);
            mainContainer.RemoveChild(myPane.Name);
            myPane.Dispose();
            ReArrangePanes();
        }
        public void ReArrangePanes()
        {
            mainContainer.ArrangeChildren();
        }

        protected void FormReSize()
        {
            mainContainer.Size = new Size(this.ClientRectangle.Width - mainContainer.Location.X, this.ClientRectangle.Height - mainContainer.Location.Y);
            mainContainer.ArrangeChildren();
        }

        protected virtual void RefreshForm() { }
        private bool PaneClosingdHandler(object sender)
        {
            RemovePane((baseClass.controls.graphPanel)sender);
            if (myOnChildPaneClosed != null) myOnChildPaneClosed((baseClass.controls.graphPanel)sender);
            return true;
        }

        #region event handler
        private void FormResizeHandler(object sender, EventArgs e)
        {
            try
            {
                FormReSize();
            }
            catch (Exception er)
            {
                this.ShowError(er);
            }
        }
        #endregion event handler
    }
}