using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Synchronization;
using Microsoft.Synchronization.Files;

namespace SyncApplication130702
{
    public partial class Form1 : Form
    {
        Guid sourceReplicaID;
        Guid destReplicaID;
        String sourceFolder = "D:\\Temp\\Source";
        String destFolder = "D:\\Temp\\Dest";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSyncFiles_Click(object sender, EventArgs e)
        {
            btnSyncFiles.Enabled = false;
            lblStatus.Text="Starting...";
            FileSyncProvider sourceProvider=new FileSyncProvider(sourceReplicaID,@sourceFolder);
            FileSyncProvider destProvider=new FileSyncProvider(destReplicaID,@destFolder);

            //sync agent
            SyncOrchestrator synAgent=new SyncOrchestrator();
            synAgent.LocalProvider=sourceProvider;
            synAgent.RemoteProvider=destProvider;
            synAgent.Synchronize();
            lblStatus.Text="Finish...";
            btnSyncFiles.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sourceReplicaID = Guid.NewGuid();
            destReplicaID = Guid.NewGuid();
        }
    }
}
