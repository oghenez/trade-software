namespace baseClass.forms
{
    partial class employeeEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(employeeEdit));
            this.employeeSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pageInfo = new System.Windows.Forms.TabPage();
            this.xpGroup_Info = new UIComponents.XPPanelGroup();
            this.xpPanel_Emergency = new UIComponents.XPPanel(304);
            this.emEmergency = new baseClass.controls.emEmergency();
            this.xpPanel_Private = new UIComponents.XPPanel(384);
            this.emPrivate = new baseClass.controls.emPrivate();
            this.xpPanel_Work = new UIComponents.XPPanel(201);
            this.emWork = new baseClass.controls.emWorkInfo();
            this.xpPanel_Identity = new UIComponents.XPPanel(420);
            this.emIdentity = new baseClass.controls.emIdentity();
            this.xpPanel_General = new UIComponents.XPPanel(322);
            this.emGeneral = new baseClass.controls.emGeneral();
            this.pageProfile = new System.Windows.Forms.TabPage();
            this.xpGroup_Profile = new UIComponents.XPPanelGroup();
            this.xpPanel_emDocFile = new UIComponents.XPPanel(418);
            this.emDocFile = new baseClass.controls.emDocFile();
            this.xpPanel_WorkHistory = new UIComponents.XPPanel(506);
            this.emWorkHistory = new baseClass.controls.emWorkHistory();
            this.xpPanel_Relatives = new UIComponents.XPPanel(378);
            this.emRelatives = new baseClass.controls.emRelative();
            this.pageEducation = new System.Windows.Forms.TabPage();
            this.xpGroup_Education = new UIComponents.XPPanelGroup();
            this.xpPanel_Edu_Language = new UIComponents.XPPanel(318);
            this.emLanguage = new baseClass.controls.emLanguage();
            this.xpPanel_Edu_Cerificate = new UIComponents.XPPanel(453);
            this.emEducation = new baseClass.controls.emEducation();
            this.pageProject = new System.Windows.Forms.TabPage();
            this.emProject = new baseClass.controls.emProject();
            this.leavePg = new System.Windows.Forms.TabPage();
            this.xpGroup_Leave = new UIComponents.XPPanelGroup();
            this.xpPanel_Leave = new UIComponents.XPPanel(517);
            this.emWorkLeave = new baseClass.controls.emLeave();
            this.pageWorkReward = new System.Windows.Forms.TabPage();
            this.xpGroup_WorkReward = new UIComponents.XPPanelGroup();
            this.xpPanel_Punishment = new UIComponents.XPPanel(494);
            this.emWorkPunishment = new baseClass.controls.emWorkPunishment();
            this.xpPanel_Reward = new UIComponents.XPPanel(509);
            this.emWorkRewards = new baseClass.controls.emWorkRewards();
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).BeginInit();
            this.toolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeSource)).BeginInit();
            this.tabMain.SuspendLayout();
            this.pageInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Info)).BeginInit();
            this.xpGroup_Info.SuspendLayout();
            this.xpPanel_Emergency.SuspendLayout();
            this.xpPanel_Private.SuspendLayout();
            this.xpPanel_Work.SuspendLayout();
            this.xpPanel_Identity.SuspendLayout();
            this.xpPanel_General.SuspendLayout();
            this.pageProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Profile)).BeginInit();
            this.xpGroup_Profile.SuspendLayout();
            this.xpPanel_emDocFile.SuspendLayout();
            this.xpPanel_WorkHistory.SuspendLayout();
            this.xpPanel_Relatives.SuspendLayout();
            this.pageEducation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Education)).BeginInit();
            this.xpGroup_Education.SuspendLayout();
            this.xpPanel_Edu_Language.SuspendLayout();
            this.xpPanel_Edu_Cerificate.SuspendLayout();
            this.pageProject.SuspendLayout();
            this.leavePg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Leave)).BeginInit();
            this.xpGroup_Leave.SuspendLayout();
            this.xpPanel_Leave.SuspendLayout();
            this.pageWorkReward.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_WorkReward)).BeginInit();
            this.xpGroup_WorkReward.SuspendLayout();
            this.xpPanel_Punishment.SuspendLayout();
            this.xpPanel_Reward.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBox
            // 
            this.toolBox.Location = new System.Drawing.Point(-12, -10);
            this.toolBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toolBox.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toolBox.Size = new System.Drawing.Size(566, 57);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(458, 10);
            this.exitBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(10, 10);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.saveBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(768, 10);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.deleteBtn.Size = new System.Drawing.Size(64, 39);
            this.deleteBtn.Visible = false;
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(138, 10);
            this.editBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.editBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // addNewBtn
            // 
            this.addNewBtn.Location = new System.Drawing.Point(74, 10);
            this.addNewBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.addNewBtn.Size = new System.Drawing.Size(64, 39);
            this.addNewBtn.Visible = false;
            // 
            // toExcelBtn
            // 
            this.toExcelBtn.Location = new System.Drawing.Point(394, 10);
            this.toExcelBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.toExcelBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // findBtn
            // 
            this.findBtn.Location = new System.Drawing.Point(202, 10);
            this.findBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Location = new System.Drawing.Point(266, 10);
            this.reloadBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.reloadBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // printBtn
            // 
            this.printBtn.Location = new System.Drawing.Point(330, 10);
            this.printBtn.Size = new System.Drawing.Size(64, 39);
            // 
            // unLockBtn
            // 
            this.unLockBtn.Location = new System.Drawing.Point(1261, 414);
            this.unLockBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.unLockBtn.Size = new System.Drawing.Size(50, 42);
            // 
            // lockBtn
            // 
            this.lockBtn.Location = new System.Drawing.Point(1261, 373);
            this.lockBtn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.lockBtn.Size = new System.Drawing.Size(50, 42);
            // 
            // TitleLbl
            // 
            this.TitleLbl.Location = new System.Drawing.Point(1256, 99);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TitleLbl.Size = new System.Drawing.Size(146, 24);
            this.TitleLbl.TabIndex = 149;
            this.TitleLbl.Text = "THÔNG TIN CHUYÊN  GIA";
            // 
            // employeeSource
            // 
            this.employeeSource.DataMember = "employee";
            this.employeeSource.DataSource = this.myDataSet;
            this.employeeSource.CurrentChanged += new System.EventHandler(this.employeeSource_CurrentChanged);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pageInfo);
            this.tabMain.Controls.Add(this.pageProfile);
            this.tabMain.Controls.Add(this.pageEducation);
            this.tabMain.Controls.Add(this.pageProject);
            this.tabMain.Controls.Add(this.leavePg);
            this.tabMain.Controls.Add(this.pageWorkReward);
            this.tabMain.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(-4, 46);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(515, 557);
            this.tabMain.TabIndex = 154;
            // 
            // pageInfo
            // 
            this.pageInfo.Controls.Add(this.xpGroup_Info);
            this.pageInfo.Location = new System.Drawing.Point(4, 25);
            this.pageInfo.Name = "pageInfo";
            this.pageInfo.Size = new System.Drawing.Size(507, 528);
            this.pageInfo.TabIndex = 0;
            this.pageInfo.Text = "Hồ sơ";
            this.pageInfo.UseVisualStyleBackColor = true;
            // 
            // xpGroup_Info
            // 
            this.xpGroup_Info.AutoScroll = true;
            this.xpGroup_Info.BackColor = System.Drawing.Color.Transparent;
            this.xpGroup_Info.BorderMargin = new System.Drawing.Size(0, 0);
            this.xpGroup_Info.Controls.Add(this.xpPanel_Emergency);
            this.xpGroup_Info.Controls.Add(this.xpPanel_Private);
            this.xpGroup_Info.Controls.Add(this.xpPanel_Work);
            this.xpGroup_Info.Controls.Add(this.xpPanel_Identity);
            this.xpGroup_Info.Controls.Add(this.xpPanel_General);
            this.xpGroup_Info.Location = new System.Drawing.Point(0, 0);
            this.xpGroup_Info.Name = "xpGroup_Info";
            this.xpGroup_Info.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpGroup_Info.PanelGradient")));
            this.xpGroup_Info.PanelSpacing = 2;
            this.xpGroup_Info.Size = new System.Drawing.Size(510, 520);
            this.xpGroup_Info.TabIndex = 1;
            // 
            // xpPanel_Emergency
            // 
            this.xpPanel_Emergency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_Emergency.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_Emergency.Caption = "Thông tin khẩn cấp";
            this.xpPanel_Emergency.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_Emergency.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Emergency.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Emergency.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Emergency.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_Emergency.Controls.Add(this.emEmergency);
            this.xpPanel_Emergency.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_Emergency.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_Emergency.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_Emergency.ImageItems.ImageSet = null;
            this.xpPanel_Emergency.Location = new System.Drawing.Point(0, 1335);
            this.xpPanel_Emergency.Name = "xpPanel_Emergency";
            this.xpPanel_Emergency.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_Emergency.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_Emergency.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Emergency.Size = new System.Drawing.Size(493, 304);
            this.xpPanel_Emergency.TabIndex = 10;
            this.xpPanel_Emergency.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_Emergency.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_Emergency.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_Emergency.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // emEmergency
            // 
            this.emEmergency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emEmergency.Location = new System.Drawing.Point(30, 38);
            this.emEmergency.Name = "emEmergency";
            this.emEmergency.Size = new System.Drawing.Size(450, 259);
            this.emEmergency.TabIndex = 0;
            this.emEmergency.myOnError += new System.EventHandler(this.myOnError);
            // 
            // xpPanel_Private
            // 
            this.xpPanel_Private.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_Private.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_Private.Caption = "Thông tin cá nhân";
            this.xpPanel_Private.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_Private.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Private.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Private.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Private.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_Private.Controls.Add(this.emPrivate);
            this.xpPanel_Private.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_Private.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_Private.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_Private.ImageItems.ImageSet = null;
            this.xpPanel_Private.Location = new System.Drawing.Point(0, 949);
            this.xpPanel_Private.Name = "xpPanel_Private";
            this.xpPanel_Private.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_Private.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_Private.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Private.Size = new System.Drawing.Size(493, 384);
            this.xpPanel_Private.TabIndex = 9;
            this.xpPanel_Private.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_Private.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_Private.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_Private.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // emPrivate
            // 
            this.emPrivate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emPrivate.Location = new System.Drawing.Point(30, 35);
            this.emPrivate.Margin = new System.Windows.Forms.Padding(2);
            this.emPrivate.Name = "emPrivate";
            this.emPrivate.Size = new System.Drawing.Size(450, 344);
            this.emPrivate.TabIndex = 0;
            this.emPrivate.myOnError += new System.EventHandler(this.myOnError);
            // 
            // xpPanel_Work
            // 
            this.xpPanel_Work.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_Work.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_Work.Caption = "Công việc";
            this.xpPanel_Work.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_Work.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Work.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Work.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Work.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_Work.Controls.Add(this.emWork);
            this.xpPanel_Work.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_Work.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_Work.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_Work.ImageItems.ImageSet = null;
            this.xpPanel_Work.Location = new System.Drawing.Point(0, 746);
            this.xpPanel_Work.Name = "xpPanel_Work";
            this.xpPanel_Work.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_Work.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_Work.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Work.Size = new System.Drawing.Size(493, 201);
            this.xpPanel_Work.TabIndex = 8;
            this.xpPanel_Work.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_Work.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_Work.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_Work.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // emWork
            // 
            this.emWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emWork.Location = new System.Drawing.Point(30, 36);
            this.emWork.Name = "emWork";
            this.emWork.Size = new System.Drawing.Size(450, 152);
            this.emWork.TabIndex = 0;
            this.emWork.myOnError += new System.EventHandler(this.myOnError);
            // 
            // xpPanel_Identity
            // 
            this.xpPanel_Identity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_Identity.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_Identity.Caption = "Giấy tờ";
            this.xpPanel_Identity.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_Identity.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Identity.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Identity.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Identity.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_Identity.Controls.Add(this.emIdentity);
            this.xpPanel_Identity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_Identity.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_Identity.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_Identity.ImageItems.ImageSet = null;
            this.xpPanel_Identity.Location = new System.Drawing.Point(0, 324);
            this.xpPanel_Identity.Name = "xpPanel_Identity";
            this.xpPanel_Identity.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_Identity.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_Identity.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Identity.Size = new System.Drawing.Size(493, 420);
            this.xpPanel_Identity.TabIndex = 7;
            this.xpPanel_Identity.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_Identity.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_Identity.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_Identity.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // emIdentity
            // 
            this.emIdentity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emIdentity.Location = new System.Drawing.Point(30, 35);
            this.emIdentity.Name = "emIdentity";
            this.emIdentity.Size = new System.Drawing.Size(450, 381);
            this.emIdentity.TabIndex = 0;
            this.emIdentity.myOnError += new System.EventHandler(this.myOnError);
            // 
            // xpPanel_General
            // 
            this.xpPanel_General.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_General.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_General.Caption = "Thông tin chung";
            this.xpPanel_General.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_General.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_General.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_General.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_General.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_General.Controls.Add(this.emGeneral);
            this.xpPanel_General.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_General.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_General.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_General.ImageItems.ImageSet = null;
            this.xpPanel_General.Location = new System.Drawing.Point(0, 0);
            this.xpPanel_General.Name = "xpPanel_General";
            this.xpPanel_General.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_General.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_General.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_General.Size = new System.Drawing.Size(493, 322);
            this.xpPanel_General.TabIndex = 6;
            this.xpPanel_General.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_General.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_General.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_General.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // emGeneral
            // 
            this.emGeneral.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emGeneral.Location = new System.Drawing.Point(30, 35);
            this.emGeneral.Name = "emGeneral";
            this.emGeneral.Size = new System.Drawing.Size(450, 281);
            this.emGeneral.TabIndex = 0;
            this.emGeneral.myOnError += new System.EventHandler(this.myOnError);
            // 
            // pageProfile
            // 
            this.pageProfile.Controls.Add(this.xpGroup_Profile);
            this.pageProfile.Location = new System.Drawing.Point(4, 25);
            this.pageProfile.Name = "pageProfile";
            this.pageProfile.Padding = new System.Windows.Forms.Padding(3);
            this.pageProfile.Size = new System.Drawing.Size(507, 528);
            this.pageProfile.TabIndex = 1;
            this.pageProfile.Text = "Lý lịch";
            this.pageProfile.UseVisualStyleBackColor = true;
            // 
            // xpGroup_Profile
            // 
            this.xpGroup_Profile.AutoScroll = true;
            this.xpGroup_Profile.BackColor = System.Drawing.Color.Transparent;
            this.xpGroup_Profile.BorderMargin = new System.Drawing.Size(0, 0);
            this.xpGroup_Profile.Controls.Add(this.xpPanel_emDocFile);
            this.xpGroup_Profile.Controls.Add(this.xpPanel_WorkHistory);
            this.xpGroup_Profile.Controls.Add(this.xpPanel_Relatives);
            this.xpGroup_Profile.Location = new System.Drawing.Point(0, 0);
            this.xpGroup_Profile.Name = "xpGroup_Profile";
            this.xpGroup_Profile.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpGroup_Profile.PanelGradient")));
            this.xpGroup_Profile.PanelSpacing = 2;
            this.xpGroup_Profile.Size = new System.Drawing.Size(510, 520);
            this.xpGroup_Profile.TabIndex = 1;
            // 
            // xpPanel_emDocFile
            // 
            this.xpPanel_emDocFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_emDocFile.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_emDocFile.Caption = "Hồ sơ gốc";
            this.xpPanel_emDocFile.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_emDocFile.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_emDocFile.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_emDocFile.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_emDocFile.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_emDocFile.Controls.Add(this.emDocFile);
            this.xpPanel_emDocFile.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_emDocFile.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_emDocFile.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_emDocFile.ImageItems.ImageSet = null;
            this.xpPanel_emDocFile.Location = new System.Drawing.Point(0, 888);
            this.xpPanel_emDocFile.Name = "xpPanel_emDocFile";
            this.xpPanel_emDocFile.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_emDocFile.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_emDocFile.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_emDocFile.Size = new System.Drawing.Size(493, 418);
            this.xpPanel_emDocFile.TabIndex = 4;
            this.xpPanel_emDocFile.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_emDocFile.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_emDocFile.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_emDocFile.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // emDocFile
            // 
            this.emDocFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emDocFile.Location = new System.Drawing.Point(30, 36);
            this.emDocFile.Margin = new System.Windows.Forms.Padding(2);
            this.emDocFile.Name = "emDocFile";
            this.emDocFile.Size = new System.Drawing.Size(461, 366);
            this.emDocFile.TabIndex = 0;
            this.emDocFile.myOnError += new System.EventHandler(this.myOnError);
            // 
            // xpPanel_WorkHistory
            // 
            this.xpPanel_WorkHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_WorkHistory.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_WorkHistory.Caption = "Quá trình công tác";
            this.xpPanel_WorkHistory.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_WorkHistory.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_WorkHistory.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_WorkHistory.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_WorkHistory.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_WorkHistory.Controls.Add(this.emWorkHistory);
            this.xpPanel_WorkHistory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_WorkHistory.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_WorkHistory.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_WorkHistory.ImageItems.ImageSet = null;
            this.xpPanel_WorkHistory.Location = new System.Drawing.Point(0, 380);
            this.xpPanel_WorkHistory.Name = "xpPanel_WorkHistory";
            this.xpPanel_WorkHistory.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_WorkHistory.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_WorkHistory.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_WorkHistory.Size = new System.Drawing.Size(493, 506);
            this.xpPanel_WorkHistory.TabIndex = 2;
            this.xpPanel_WorkHistory.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_WorkHistory.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_WorkHistory.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_WorkHistory.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // emWorkHistory
            // 
            this.emWorkHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emWorkHistory.Location = new System.Drawing.Point(30, 35);
            this.emWorkHistory.Margin = new System.Windows.Forms.Padding(2);
            this.emWorkHistory.Name = "emWorkHistory";
            this.emWorkHistory.Size = new System.Drawing.Size(470, 455);
            this.emWorkHistory.TabIndex = 0;
            this.emWorkHistory.myOnError += new System.EventHandler(this.myOnError);
            // 
            // xpPanel_Relatives
            // 
            this.xpPanel_Relatives.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_Relatives.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_Relatives.Caption = "Quan hệ gia đình";
            this.xpPanel_Relatives.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_Relatives.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Relatives.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Relatives.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Relatives.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_Relatives.Controls.Add(this.emRelatives);
            this.xpPanel_Relatives.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_Relatives.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_Relatives.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_Relatives.ImageItems.ImageSet = null;
            this.xpPanel_Relatives.Location = new System.Drawing.Point(0, 0);
            this.xpPanel_Relatives.Name = "xpPanel_Relatives";
            this.xpPanel_Relatives.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_Relatives.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_Relatives.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Relatives.Size = new System.Drawing.Size(493, 378);
            this.xpPanel_Relatives.TabIndex = 1;
            this.xpPanel_Relatives.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_Relatives.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_Relatives.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_Relatives.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // emRelatives
            // 
            this.emRelatives.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emRelatives.Location = new System.Drawing.Point(30, 37);
            this.emRelatives.Margin = new System.Windows.Forms.Padding(2);
            this.emRelatives.Name = "emRelatives";
            this.emRelatives.Size = new System.Drawing.Size(460, 325);
            this.emRelatives.TabIndex = 0;
            this.emRelatives.myOnError += new System.EventHandler(this.myOnError);
            // 
            // pageEducation
            // 
            this.pageEducation.Controls.Add(this.xpGroup_Education);
            this.pageEducation.Location = new System.Drawing.Point(4, 25);
            this.pageEducation.Name = "pageEducation";
            this.pageEducation.Padding = new System.Windows.Forms.Padding(3);
            this.pageEducation.Size = new System.Drawing.Size(507, 528);
            this.pageEducation.TabIndex = 2;
            this.pageEducation.Text = "Học vấn";
            this.pageEducation.UseVisualStyleBackColor = true;
            // 
            // xpGroup_Education
            // 
            this.xpGroup_Education.AutoScroll = true;
            this.xpGroup_Education.BackColor = System.Drawing.Color.Transparent;
            this.xpGroup_Education.BorderMargin = new System.Drawing.Size(0, 0);
            this.xpGroup_Education.Controls.Add(this.xpPanel_Edu_Language);
            this.xpGroup_Education.Controls.Add(this.xpPanel_Edu_Cerificate);
            this.xpGroup_Education.Location = new System.Drawing.Point(0, 0);
            this.xpGroup_Education.Name = "xpGroup_Education";
            this.xpGroup_Education.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpGroup_Education.PanelGradient")));
            this.xpGroup_Education.PanelSpacing = 2;
            this.xpGroup_Education.Size = new System.Drawing.Size(510, 520);
            this.xpGroup_Education.TabIndex = 1;
            // 
            // xpPanel_Edu_Language
            // 
            this.xpPanel_Edu_Language.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_Edu_Language.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_Edu_Language.Caption = "Ngọai ngữ";
            this.xpPanel_Edu_Language.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_Edu_Language.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Edu_Language.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Edu_Language.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Edu_Language.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_Edu_Language.Controls.Add(this.emLanguage);
            this.xpPanel_Edu_Language.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_Edu_Language.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_Edu_Language.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_Edu_Language.ImageItems.ImageSet = null;
            this.xpPanel_Edu_Language.Location = new System.Drawing.Point(0, 455);
            this.xpPanel_Edu_Language.Name = "xpPanel_Edu_Language";
            this.xpPanel_Edu_Language.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_Edu_Language.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_Edu_Language.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Edu_Language.Size = new System.Drawing.Size(493, 318);
            this.xpPanel_Edu_Language.TabIndex = 1;
            this.xpPanel_Edu_Language.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_Edu_Language.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_Edu_Language.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_Edu_Language.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // emLanguage
            // 
            this.emLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emLanguage.Location = new System.Drawing.Point(30, 35);
            this.emLanguage.Margin = new System.Windows.Forms.Padding(2);
            this.emLanguage.Name = "emLanguage";
            this.emLanguage.Size = new System.Drawing.Size(459, 273);
            this.emLanguage.TabIndex = 2;
            this.emLanguage.myOnError += new System.EventHandler(this.myOnError);
            // 
            // xpPanel_Edu_Cerificate
            // 
            this.xpPanel_Edu_Cerificate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_Edu_Cerificate.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_Edu_Cerificate.Caption = "Bằng cấp";
            this.xpPanel_Edu_Cerificate.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_Edu_Cerificate.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Edu_Cerificate.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Edu_Cerificate.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Edu_Cerificate.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_Edu_Cerificate.Controls.Add(this.emEducation);
            this.xpPanel_Edu_Cerificate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_Edu_Cerificate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_Edu_Cerificate.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_Edu_Cerificate.ImageItems.ImageSet = null;
            this.xpPanel_Edu_Cerificate.Location = new System.Drawing.Point(0, 0);
            this.xpPanel_Edu_Cerificate.Name = "xpPanel_Edu_Cerificate";
            this.xpPanel_Edu_Cerificate.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_Edu_Cerificate.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_Edu_Cerificate.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Edu_Cerificate.Size = new System.Drawing.Size(493, 453);
            this.xpPanel_Edu_Cerificate.TabIndex = 0;
            this.xpPanel_Edu_Cerificate.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_Edu_Cerificate.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_Edu_Cerificate.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_Edu_Cerificate.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // emEducation
            // 
            this.emEducation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emEducation.Location = new System.Drawing.Point(30, 35);
            this.emEducation.Margin = new System.Windows.Forms.Padding(2);
            this.emEducation.Name = "emEducation";
            this.emEducation.Size = new System.Drawing.Size(463, 408);
            this.emEducation.TabIndex = 2;
            this.emEducation.myOnError += new System.EventHandler(this.myOnError);
            // 
            // pageProject
            // 
            this.pageProject.Controls.Add(this.emProject);
            this.pageProject.Location = new System.Drawing.Point(4, 25);
            this.pageProject.Name = "pageProject";
            this.pageProject.Padding = new System.Windows.Forms.Padding(3);
            this.pageProject.Size = new System.Drawing.Size(507, 528);
            this.pageProject.TabIndex = 3;
            this.pageProject.Text = "Dự án";
            this.pageProject.UseVisualStyleBackColor = true;
            // 
            // emProject
            // 
            this.emProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emProject.Location = new System.Drawing.Point(30, 6);
            this.emProject.Margin = new System.Windows.Forms.Padding(2);
            this.emProject.Name = "emProject";
            this.emProject.Size = new System.Drawing.Size(459, 505);
            this.emProject.TabIndex = 1;
            this.emProject.myOnError += new System.EventHandler(this.myOnError);
            // 
            // leavePg
            // 
            this.leavePg.Controls.Add(this.xpGroup_Leave);
            this.leavePg.Location = new System.Drawing.Point(4, 25);
            this.leavePg.Name = "leavePg";
            this.leavePg.Padding = new System.Windows.Forms.Padding(3);
            this.leavePg.Size = new System.Drawing.Size(507, 528);
            this.leavePg.TabIndex = 5;
            this.leavePg.Text = "Nghỉ phép";
            this.leavePg.UseVisualStyleBackColor = true;
            // 
            // xpGroup_Leave
            // 
            this.xpGroup_Leave.AutoScroll = true;
            this.xpGroup_Leave.BackColor = System.Drawing.Color.Transparent;
            this.xpGroup_Leave.BorderMargin = new System.Drawing.Size(0, 0);
            this.xpGroup_Leave.Controls.Add(this.xpPanel_Leave);
            this.xpGroup_Leave.Location = new System.Drawing.Point(0, 0);
            this.xpGroup_Leave.Name = "xpGroup_Leave";
            this.xpGroup_Leave.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpGroup_Leave.PanelGradient")));
            this.xpGroup_Leave.PanelSpacing = 0;
            this.xpGroup_Leave.Size = new System.Drawing.Size(510, 528);
            this.xpGroup_Leave.TabIndex = 1;
            // 
            // xpPanel_Leave
            // 
            this.xpPanel_Leave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_Leave.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_Leave.Caption = "Nghỉ phép";
            this.xpPanel_Leave.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_Leave.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Leave.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Leave.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Leave.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_Leave.Controls.Add(this.emWorkLeave);
            this.xpPanel_Leave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_Leave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_Leave.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_Leave.ImageItems.ImageSet = null;
            this.xpPanel_Leave.Location = new System.Drawing.Point(0, 0);
            this.xpPanel_Leave.Name = "xpPanel_Leave";
            this.xpPanel_Leave.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_Leave.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_Leave.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Leave.Size = new System.Drawing.Size(510, 517);
            this.xpPanel_Leave.TabIndex = 3;
            this.xpPanel_Leave.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_Leave.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_Leave.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_Leave.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // emWorkLeave
            // 
            this.emWorkLeave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emWorkLeave.Location = new System.Drawing.Point(30, 35);
            this.emWorkLeave.Margin = new System.Windows.Forms.Padding(2);
            this.emWorkLeave.Name = "emWorkLeave";
            this.emWorkLeave.Size = new System.Drawing.Size(462, 469);
            this.emWorkLeave.TabIndex = 1;
            // 
            // pageWorkReward
            // 
            this.pageWorkReward.Controls.Add(this.xpGroup_WorkReward);
            this.pageWorkReward.Location = new System.Drawing.Point(4, 25);
            this.pageWorkReward.Name = "pageWorkReward";
            this.pageWorkReward.Padding = new System.Windows.Forms.Padding(3);
            this.pageWorkReward.Size = new System.Drawing.Size(507, 528);
            this.pageWorkReward.TabIndex = 4;
            this.pageWorkReward.Text = "Khen thưởng/Kỷ luật";
            this.pageWorkReward.UseVisualStyleBackColor = true;
            // 
            // xpGroup_WorkReward
            // 
            this.xpGroup_WorkReward.AutoScroll = true;
            this.xpGroup_WorkReward.BackColor = System.Drawing.Color.Transparent;
            this.xpGroup_WorkReward.BorderMargin = new System.Drawing.Size(0, 0);
            this.xpGroup_WorkReward.Controls.Add(this.xpPanel_Punishment);
            this.xpGroup_WorkReward.Controls.Add(this.xpPanel_Reward);
            this.xpGroup_WorkReward.Location = new System.Drawing.Point(0, 0);
            this.xpGroup_WorkReward.Name = "xpGroup_WorkReward";
            this.xpGroup_WorkReward.PanelGradient = ((UIComponents.GradientColor)(resources.GetObject("xpGroup_WorkReward.PanelGradient")));
            this.xpGroup_WorkReward.PanelSpacing = 2;
            this.xpGroup_WorkReward.Size = new System.Drawing.Size(510, 520);
            this.xpGroup_WorkReward.TabIndex = 0;
            // 
            // xpPanel_Punishment
            // 
            this.xpPanel_Punishment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_Punishment.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_Punishment.Caption = "Kỷ luật";
            this.xpPanel_Punishment.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_Punishment.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Punishment.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Punishment.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Punishment.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_Punishment.Controls.Add(this.emWorkPunishment);
            this.xpPanel_Punishment.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_Punishment.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_Punishment.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_Punishment.ImageItems.ImageSet = null;
            this.xpPanel_Punishment.Location = new System.Drawing.Point(0, 511);
            this.xpPanel_Punishment.Name = "xpPanel_Punishment";
            this.xpPanel_Punishment.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_Punishment.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_Punishment.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Punishment.Size = new System.Drawing.Size(493, 494);
            this.xpPanel_Punishment.TabIndex = 3;
            this.xpPanel_Punishment.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_Punishment.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_Punishment.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_Punishment.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // emWorkPunishment
            // 
            this.emWorkPunishment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emWorkPunishment.Location = new System.Drawing.Point(30, 35);
            this.emWorkPunishment.Margin = new System.Windows.Forms.Padding(2);
            this.emWorkPunishment.Name = "emWorkPunishment";
            this.emWorkPunishment.Size = new System.Drawing.Size(462, 446);
            this.emWorkPunishment.TabIndex = 0;
            this.emWorkPunishment.myOnError += new System.EventHandler(this.myOnError);
            // 
            // xpPanel_Reward
            // 
            this.xpPanel_Reward.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xpPanel_Reward.BackColor = System.Drawing.Color.Transparent;
            this.xpPanel_Reward.Caption = "Khen thưởng / Giải thưởng";
            this.xpPanel_Reward.CaptionCornerType = ((UIComponents.CornerType)((UIComponents.CornerType.TopLeft | UIComponents.CornerType.TopRight)));
            this.xpPanel_Reward.CaptionGradient.End = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Reward.CaptionGradient.Start = System.Drawing.SystemColors.MenuHighlight;
            this.xpPanel_Reward.CaptionGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Reward.CaptionUnderline = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.xpPanel_Reward.Controls.Add(this.emWorkRewards);
            this.xpPanel_Reward.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xpPanel_Reward.ForeColor = System.Drawing.SystemColors.WindowText;
            this.xpPanel_Reward.HorzAlignment = System.Drawing.StringAlignment.Near;
            this.xpPanel_Reward.ImageItems.ImageSet = null;
            this.xpPanel_Reward.Location = new System.Drawing.Point(0, 0);
            this.xpPanel_Reward.Name = "xpPanel_Reward";
            this.xpPanel_Reward.PanelGradient.End = System.Drawing.SystemColors.Control;
            this.xpPanel_Reward.PanelGradient.Start = System.Drawing.SystemColors.Control;
            this.xpPanel_Reward.PanelGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.xpPanel_Reward.Size = new System.Drawing.Size(493, 509);
            this.xpPanel_Reward.TabIndex = 1;
            this.xpPanel_Reward.TextColors.Foreground = System.Drawing.SystemColors.Control;
            this.xpPanel_Reward.TextHighlightColors.Foreground = System.Drawing.SystemColors.ActiveCaptionText;
            this.xpPanel_Reward.VertAlignment = System.Drawing.StringAlignment.Center;
            this.xpPanel_Reward.XPPanelStyle = UIComponents.XPPanelStyle.WindowsXP;
            // 
            // emWorkRewards
            // 
            this.emWorkRewards.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emWorkRewards.Location = new System.Drawing.Point(30, 35);
            this.emWorkRewards.Margin = new System.Windows.Forms.Padding(2);
            this.emWorkRewards.Name = "emWorkRewards";
            this.emWorkRewards.Size = new System.Drawing.Size(462, 460);
            this.emWorkRewards.TabIndex = 0;
            this.emWorkRewards.myOnError += new System.EventHandler(this.myOnError);
            // 
            // employeeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(511, 628);
            this.Controls.Add(this.tabMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "employeeEdit";
            this.Text = "Nhân viên";
            this.Controls.SetChildIndex(this.toolBox, 0);
            this.Controls.SetChildIndex(this.tabMain, 0);
            this.Controls.SetChildIndex(this.unLockBtn, 0);
            this.Controls.SetChildIndex(this.lockBtn, 0);
            this.Controls.SetChildIndex(this.TitleLbl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.myDataSet)).EndInit();
            this.toolBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeeSource)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.pageInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Info)).EndInit();
            this.xpGroup_Info.ResumeLayout(false);
            this.xpPanel_Emergency.ResumeLayout(false);
            this.xpPanel_Private.ResumeLayout(false);
            this.xpPanel_Work.ResumeLayout(false);
            this.xpPanel_Identity.ResumeLayout(false);
            this.xpPanel_General.ResumeLayout(false);
            this.pageProfile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Profile)).EndInit();
            this.xpGroup_Profile.ResumeLayout(false);
            this.xpPanel_emDocFile.ResumeLayout(false);
            this.xpPanel_WorkHistory.ResumeLayout(false);
            this.xpPanel_Relatives.ResumeLayout(false);
            this.pageEducation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Education)).EndInit();
            this.xpGroup_Education.ResumeLayout(false);
            this.xpPanel_Edu_Language.ResumeLayout(false);
            this.xpPanel_Edu_Cerificate.ResumeLayout(false);
            this.pageProject.ResumeLayout(false);
            this.leavePg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_Leave)).EndInit();
            this.xpGroup_Leave.ResumeLayout(false);
            this.xpPanel_Leave.ResumeLayout(false);
            this.pageWorkReward.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xpGroup_WorkReward)).EndInit();
            this.xpGroup_WorkReward.ResumeLayout(false);
            this.xpPanel_Punishment.ResumeLayout(false);
            this.xpPanel_Reward.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected baseClass.controls.baseButton checkIdCardBtn;
        protected System.Windows.Forms.BindingSource employeeSource;
        private System.Windows.Forms.TabPage pageInfo;
        private System.Windows.Forms.TabPage pageProfile;
        private System.Windows.Forms.TabPage pageEducation;
        private System.Windows.Forms.TabPage pageProject;
        private System.Windows.Forms.TabPage pageWorkReward;
        protected System.Windows.Forms.TabControl tabMain;
        protected UIComponents.XPPanelGroup xpGroup_Info;
        protected baseClass.controls.emProject emProject;
        protected UIComponents.XPPanelGroup xpGroup_Education;
        protected baseClass.controls.emLanguage emLanguage;
        protected UIComponents.XPPanel xpPanel_General;
        protected UIComponents.XPPanel xpPanel_Private;
        protected baseClass.controls.emPrivate emPrivate;
        protected UIComponents.XPPanel xpPanel_Work;
        protected baseClass.controls.emWorkInfo emWork;
        protected UIComponents.XPPanel xpPanel_Identity;
        protected baseClass.controls.emIdentity emIdentity;
        protected baseClass.controls.emGeneral emGeneral;
        protected UIComponents.XPPanel xpPanel_Edu_Cerificate;
        protected UIComponents.XPPanel xpPanel_Edu_Language;
        protected baseClass.controls.emEducation emEducation;
        protected UIComponents.XPPanelGroup xpGroup_Profile;
        protected UIComponents.XPPanel xpPanel_WorkHistory;
        protected UIComponents.XPPanel xpPanel_Relatives;
        protected UIComponents.XPPanelGroup xpGroup_WorkReward;
        protected UIComponents.XPPanel xpPanel_Reward;
        protected UIComponents.XPPanel xpPanel_Punishment;
        protected UIComponents.XPPanel xpPanel_Emergency;
        protected baseClass.controls.emEmergency emEmergency;
        protected baseClass.controls.emWorkHistory emWorkHistory;
        protected baseClass.controls.emRelative emRelatives;
        protected baseClass.controls.emWorkRewards emWorkRewards;
        protected baseClass.controls.emWorkPunishment emWorkPunishment;
        protected UIComponents.XPPanel xpPanel_emDocFile;
        protected baseClass.controls.emDocFile emDocFile;
        protected UIComponents.XPPanelGroup xpGroup_Leave;
        protected UIComponents.XPPanel xpPanel_Leave;
        protected System.Windows.Forms.TabPage leavePg;
        protected baseClass.controls.emLeave emWorkLeave;
    }
}