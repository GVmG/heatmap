namespace heatmap
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelBeatmapID = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.checkBoxShowCircles = new System.Windows.Forms.CheckBox();
            this.checkBoxShowSliders = new System.Windows.Forms.CheckBox();
            this.checkBoxShowSpinners = new System.Windows.Forms.CheckBox();
            this.checkBoxSliderbodies = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxRenderColoured = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxRenderType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelBeatmapInfo = new System.Windows.Forms.LinkLabel();
            this.labelBeatmapSetID = new System.Windows.Forms.LinkLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.rangeBar1 = new heatmap.RangeBar();
            this.linkLabelRangeBegin = new System.Windows.Forms.LinkLabel();
            this.linkLabelRangeEnd = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Beatmap file (.osu):";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(116, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(398, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_TextEnter);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(551, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Load The Map!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // labelBeatmapID
            // 
            this.labelBeatmapID.AutoSize = true;
            this.labelBeatmapID.LinkArea = new System.Windows.Forms.LinkArea(15, 6);
            this.labelBeatmapID.Location = new System.Drawing.Point(6, 188);
            this.labelBeatmapID.MaximumSize = new System.Drawing.Size(213, 0);
            this.labelBeatmapID.Name = "labelBeatmapID";
            this.labelBeatmapID.Size = new System.Drawing.Size(90, 17);
            this.labelBeatmapID.TabIndex = 5;
            this.labelBeatmapID.TabStop = true;
            this.labelBeatmapID.Text = "Difficulty ID: ------";
            this.labelBeatmapID.UseCompatibleTextRendering = true;
            this.labelBeatmapID.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelBeatmapPage_LinkClicked);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.InitialImage")));
            this.pictureBox2.Location = new System.Drawing.Point(658, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(227, 175);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // checkBoxShowCircles
            // 
            this.checkBoxShowCircles.AutoSize = true;
            this.checkBoxShowCircles.Checked = true;
            this.checkBoxShowCircles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowCircles.Location = new System.Drawing.Point(6, 19);
            this.checkBoxShowCircles.Name = "checkBoxShowCircles";
            this.checkBoxShowCircles.Size = new System.Drawing.Size(87, 17);
            this.checkBoxShowCircles.TabIndex = 0;
            this.checkBoxShowCircles.Text = "Show Circles";
            this.checkBoxShowCircles.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowSliders
            // 
            this.checkBoxShowSliders.AutoSize = true;
            this.checkBoxShowSliders.Checked = true;
            this.checkBoxShowSliders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowSliders.Location = new System.Drawing.Point(109, 19);
            this.checkBoxShowSliders.Name = "checkBoxShowSliders";
            this.checkBoxShowSliders.Size = new System.Drawing.Size(87, 17);
            this.checkBoxShowSliders.TabIndex = 1;
            this.checkBoxShowSliders.Text = "Show Sliders";
            this.checkBoxShowSliders.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowSpinners
            // 
            this.checkBoxShowSpinners.AutoSize = true;
            this.checkBoxShowSpinners.Location = new System.Drawing.Point(6, 42);
            this.checkBoxShowSpinners.Name = "checkBoxShowSpinners";
            this.checkBoxShowSpinners.Size = new System.Drawing.Size(97, 17);
            this.checkBoxShowSpinners.TabIndex = 2;
            this.checkBoxShowSpinners.Text = "Show Spinners";
            this.checkBoxShowSpinners.UseVisualStyleBackColor = true;
            // 
            // checkBoxSliderbodies
            // 
            this.checkBoxSliderbodies.AutoSize = true;
            this.checkBoxSliderbodies.Location = new System.Drawing.Point(109, 42);
            this.checkBoxSliderbodies.Name = "checkBoxSliderbodies";
            this.checkBoxSliderbodies.Size = new System.Drawing.Size(83, 17);
            this.checkBoxSliderbodies.TabIndex = 3;
            this.checkBoxSliderbodies.Text = "Sliderbodies";
            this.checkBoxSliderbodies.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxRenderColoured);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBoxRenderType);
            this.groupBox1.Controls.Add(this.checkBoxShowSliders);
            this.groupBox1.Controls.Add(this.checkBoxShowCircles);
            this.groupBox1.Controls.Add(this.checkBoxSliderbodies);
            this.groupBox1.Controls.Add(this.checkBoxShowSpinners);
            this.groupBox1.Location = new System.Drawing.Point(658, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 114);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // checkBoxRenderColoured
            // 
            this.checkBoxRenderColoured.AutoSize = true;
            this.checkBoxRenderColoured.Location = new System.Drawing.Point(6, 89);
            this.checkBoxRenderColoured.Name = "checkBoxRenderColoured";
            this.checkBoxRenderColoured.Size = new System.Drawing.Size(120, 17);
            this.checkBoxRenderColoured.TabIndex = 13;
            this.checkBoxRenderColoured.Text = "Coloured Rendering";
            this.checkBoxRenderColoured.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Render Method:";
            // 
            // comboBoxRenderType
            // 
            this.comboBoxRenderType.FormattingEnabled = true;
            this.comboBoxRenderType.Items.AddRange(new object[] {
            "Soft",
            "Circles",
            "Points"});
            this.comboBoxRenderType.Location = new System.Drawing.Point(96, 62);
            this.comboBoxRenderType.Name = "comboBoxRenderType";
            this.comboBoxRenderType.Size = new System.Drawing.Size(125, 21);
            this.comboBoxRenderType.TabIndex = 4;
            this.comboBoxRenderType.Text = "Soft";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelBeatmapInfo);
            this.groupBox2.Controls.Add(this.labelBeatmapSetID);
            this.groupBox2.Controls.Add(this.labelBeatmapID);
            this.groupBox2.Location = new System.Drawing.Point(658, 308);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 208);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Beatmap Info";
            // 
            // labelBeatmapInfo
            // 
            this.labelBeatmapInfo.AutoSize = true;
            this.labelBeatmapInfo.LinkArea = new System.Windows.Forms.LinkArea(0, 14);
            this.labelBeatmapInfo.Location = new System.Drawing.Point(6, 16);
            this.labelBeatmapInfo.MaximumSize = new System.Drawing.Size(213, 220);
            this.labelBeatmapInfo.Name = "labelBeatmapInfo";
            this.labelBeatmapInfo.Size = new System.Drawing.Size(74, 13);
            this.labelBeatmapInfo.TabIndex = 14;
            this.labelBeatmapInfo.TabStop = true;
            this.labelBeatmapInfo.Text = "(beatmap info)";
            this.labelBeatmapInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelBeatmapInfo_LinkClicked);
            // 
            // labelBeatmapSetID
            // 
            this.labelBeatmapSetID.AutoSize = true;
            this.labelBeatmapSetID.LinkArea = new System.Windows.Forms.LinkArea(11, 6);
            this.labelBeatmapSetID.Location = new System.Drawing.Point(6, 171);
            this.labelBeatmapSetID.MaximumSize = new System.Drawing.Size(213, 0);
            this.labelBeatmapSetID.Name = "labelBeatmapSetID";
            this.labelBeatmapSetID.Size = new System.Drawing.Size(84, 17);
            this.labelBeatmapSetID.TabIndex = 13;
            this.labelBeatmapSetID.TabStop = true;
            this.labelBeatmapSetID.Text = "Mapset ID: ------";
            this.labelBeatmapSetID.UseCompatibleTextRendering = true;
            this.labelBeatmapSetID.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.labelBeatmapSetID_LinkClicked);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "osu! Beatmap files (*.osu)|*.osu";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(520, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rangeBar1
            // 
            this.rangeBar1.Location = new System.Drawing.Point(12, 522);
            this.rangeBar1.Name = "rangeBar1";
            this.rangeBar1.Size = new System.Drawing.Size(772, 40);
            this.rangeBar1.TabIndex = 13;
            // 
            // linkLabelRangeBegin
            // 
            this.linkLabelRangeBegin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelRangeBegin.AutoSize = true;
            this.linkLabelRangeBegin.LinkArea = new System.Windows.Forms.LinkArea(7, 9);
            this.linkLabelRangeBegin.Location = new System.Drawing.Point(795, 522);
            this.linkLabelRangeBegin.MaximumSize = new System.Drawing.Size(213, 0);
            this.linkLabelRangeBegin.Name = "linkLabelRangeBegin";
            this.linkLabelRangeBegin.Size = new System.Drawing.Size(90, 17);
            this.linkLabelRangeBegin.TabIndex = 15;
            this.linkLabelRangeBegin.TabStop = true;
            this.linkLabelRangeBegin.Text = "Begin: 00:00:000";
            this.linkLabelRangeBegin.UseCompatibleTextRendering = true;
            this.linkLabelRangeBegin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRangeBegin_LinkClicked);
            // 
            // linkLabelRangeEnd
            // 
            this.linkLabelRangeEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelRangeEnd.AutoSize = true;
            this.linkLabelRangeEnd.LinkArea = new System.Windows.Forms.LinkArea(5, 9);
            this.linkLabelRangeEnd.Location = new System.Drawing.Point(804, 545);
            this.linkLabelRangeEnd.MaximumSize = new System.Drawing.Size(213, 0);
            this.linkLabelRangeEnd.Name = "linkLabelRangeEnd";
            this.linkLabelRangeEnd.Size = new System.Drawing.Size(81, 17);
            this.linkLabelRangeEnd.TabIndex = 16;
            this.linkLabelRangeEnd.TabStop = true;
            this.linkLabelRangeEnd.Text = "End: 00:00:000";
            this.linkLabelRangeEnd.UseCompatibleTextRendering = true;
            this.linkLabelRangeEnd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRangeEnd_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 567);
            this.Controls.Add(this.linkLabelRangeEnd);
            this.Controls.Add(this.linkLabelRangeBegin);
            this.Controls.Add(this.rangeBar1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BeatHeat <0.2b>";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel labelBeatmapID;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox checkBoxSliderbodies;
        private System.Windows.Forms.CheckBox checkBoxShowSpinners;
        private System.Windows.Forms.CheckBox checkBoxShowSliders;
        private System.Windows.Forms.CheckBox checkBoxShowCircles;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBoxRenderType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.LinkLabel labelBeatmapInfo;
        private System.Windows.Forms.LinkLabel labelBeatmapSetID;
        private System.Windows.Forms.ToolTip toolTipInfo;
        private RangeBar rangeBar1;
        private System.Windows.Forms.CheckBox checkBoxRenderColoured;
        private System.Windows.Forms.LinkLabel linkLabelRangeBegin;
        private System.Windows.Forms.LinkLabel linkLabelRangeEnd;
    }
}

