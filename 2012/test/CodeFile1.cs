using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CrossThreadDemo
{
    public class Form1 : Form
    {
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);

        // This BackgroundWorker is used to demonstrate the 
        // preferred way of performing asynchronous operations.
        private BackgroundWorker backgroundWorker1;

        private TextBox textBox1;
        private Button setTextBackgroundWorkerBtn;

        private System.ComponentModel.IContainer components = null;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // This event handler starts the form's 
        // BackgroundWorker by calling RunWorkerAsync.
        //
        // The Text property of the TextBox control is set
        // when the BackgroundWorker raises the RunWorkerCompleted
        // event.
        private void setTextBackgroundWorkerBtn_Click(
            object sender,
            EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync();
        }

        // This event handler sets the Text property of the TextBox
        // control. It is called on the thread that created the 
        // TextBox control, so the call is thread-safe.
        //
        // BackgroundWorker is the preferred way to perform asynchronous
        // operations.

        private void backgroundWorker1_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            this.textBox1.Text =
                "This text was set safely by BackgroundWorker.";
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.setTextBackgroundWorkerBtn = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(240, 20);
            this.textBox1.TabIndex = 0;
            // 
            // setTextBackgroundWorkerBtn
            // 
            this.setTextBackgroundWorkerBtn.Location = new System.Drawing.Point(177, 55);
            this.setTextBackgroundWorkerBtn.Name = "setTextBackgroundWorkerBtn";
            this.setTextBackgroundWorkerBtn.Size = new System.Drawing.Size(75, 23);
            this.setTextBackgroundWorkerBtn.TabIndex = 3;
            this.setTextBackgroundWorkerBtn.Text = "Safe BW Call";
            this.setTextBackgroundWorkerBtn.Click += new System.EventHandler(this.setTextBackgroundWorkerBtn_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(268, 96);
            this.Controls.Add(this.setTextBackgroundWorkerBtn);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

    }
}
