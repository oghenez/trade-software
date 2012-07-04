using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Windows.Forms;

namespace test
{
    public partial class mthread : Form
    {
        public mthread()
        {
            InitializeComponent();
        }

        // This delegate enables asynchronous calls for setting
		// the text property on a TextBox control.
		delegate void SetTextCallback(string text);

		// This thread is used to demonstrate both thread-safe and
		// unsafe ways to call a Windows Forms control.
		private Thread demoThread = null;


		// This method is executed on the worker thread and makes
		// an unsafe call on the TextBox control.
		private void ThreadProcUnsafe()
		{
			this.textBox1.Text = "This text was set unsafely.";
		}

		// This method is executed on the worker thread and makes
		// a thread-safe call on the TextBox control.
		private void ThreadProcSafe()
		{
			this.SetText("This text was set safely.");
		}

		// This method demonstrates a pattern for making thread-safe
		// calls on a Windows Forms control. 
		//
		// If the calling thread is different from the thread that
		// created the TextBox control, this method creates a
		// SetTextCallback and calls itself asynchronously using the
		// Invoke method.
		//
		// If the calling thread is the same as the thread that created
		// the TextBox control, the Text property is set directly. 

		private void SetText(string text)
		{
			// InvokeRequired required compares the thread ID of the
			// calling thread to the thread ID of the creating thread.
			// If these threads are different, it returns true.
			if (this.textBox1.InvokeRequired)
			{	
				SetTextCallback d = new SetTextCallback(SetText);
				this.Invoke(d, new object[] { text });
			}
			else
			{
				this.textBox1.Text = text;
			}
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
            testCB.SelectedIndex = 1;
			this.textBox1.Text = 
				"This text was set safely by BackgroundWorker.";
            testCB.SelectedIndex = 1;
		}

        // This event handler creates a thread that calls a 
        // Windows Forms control in an unsafe way.
        private void unSafe_Click(object sender, EventArgs e)
        {
            this.demoThread =
                new Thread(new ThreadStart(this.ThreadProcUnsafe));

            this.demoThread.Start();
        }

        // This event handler creates a thread that calls a 
        // Windows Forms control in a thread-safe way.
        private void Safe_Click(object sender, EventArgs e)
        {
            this.demoThread =
                new Thread(new ThreadStart(this.ThreadProcSafe));
            this.demoThread.Start();
        }

        // This event handler starts the form's 
        // BackgroundWorker by calling RunWorkerAsync.
        //
        // The Text property of the TextBox control is set
        // when the BackgroundWorker raises the RunWorkerCompleted
        // event.
        private void backGroundBtn_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.RunWorkerAsync();
        }
    }
}
