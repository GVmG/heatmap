namespace heatmap
{
    partial class RangeBar
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

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelRange = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(0, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 5);
            this.panel1.TabIndex = 0;
            // 
            // panelRange
            // 
            this.panelRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRange.Location = new System.Drawing.Point(118, 10);
            this.panelRange.Name = "panelRange";
            this.panelRange.Size = new System.Drawing.Size(170, 20);
            this.panelRange.TabIndex = 1;
            this.panelRange.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_Click);
            this.panelRange.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoved);
            this.panelRange.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_UnClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(16, 40);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_Click);
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoved);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_UnClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(272, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(16, 40);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_Click);
            this.button2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMoved);
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button2_UnClick);
            // 
            // RangeBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panelRange);
            this.Controls.Add(this.panel1);
            this.Name = "RangeBar";
            this.Size = new System.Drawing.Size(700, 40);
            this.Load += new System.EventHandler(this.RangeBar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelRange;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
