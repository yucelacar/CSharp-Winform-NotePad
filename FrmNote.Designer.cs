namespace NotePadSharp
{
    partial class FrmNote
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
            this.rchYazi = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kopyalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yapistirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yaziStiliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yaziRengiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rchYazi
            // 
            this.rchYazi.ContextMenuStrip = this.contextMenuStrip1;
            this.rchYazi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchYazi.Location = new System.Drawing.Point(0, 0);
            this.rchYazi.Name = "rchYazi";
            this.rchYazi.Size = new System.Drawing.Size(377, 292);
            this.rchYazi.TabIndex = 0;
            this.rchYazi.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kesToolStripMenuItem,
            this.kopyalaToolStripMenuItem,
            this.yapistirToolStripMenuItem,
            this.yaziStiliToolStripMenuItem,
            this.yaziRengiToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(129, 114);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // kesToolStripMenuItem
            // 
            this.kesToolStripMenuItem.Enabled = false;
            this.kesToolStripMenuItem.Name = "kesToolStripMenuItem";
            this.kesToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.kesToolStripMenuItem.Text = "Kes";
            this.kesToolStripMenuItem.Click += new System.EventHandler(this.kesToolStripMenuItem_Click);
            // 
            // kopyalaToolStripMenuItem
            // 
            this.kopyalaToolStripMenuItem.Enabled = false;
            this.kopyalaToolStripMenuItem.Name = "kopyalaToolStripMenuItem";
            this.kopyalaToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.kopyalaToolStripMenuItem.Text = "Kopyala";
            this.kopyalaToolStripMenuItem.Click += new System.EventHandler(this.kopyalaToolStripMenuItem_Click);
            // 
            // yapistirToolStripMenuItem
            // 
            this.yapistirToolStripMenuItem.Enabled = false;
            this.yapistirToolStripMenuItem.Name = "yapistirToolStripMenuItem";
            this.yapistirToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.yapistirToolStripMenuItem.Text = "Yapıştır";
            this.yapistirToolStripMenuItem.Click += new System.EventHandler(this.yapistirToolStripMenuItem_Click);
            // 
            // yaziStiliToolStripMenuItem
            // 
            this.yaziStiliToolStripMenuItem.Name = "yaziStiliToolStripMenuItem";
            this.yaziStiliToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.yaziStiliToolStripMenuItem.Text = "Yazı Stili";
            // 
            // yaziRengiToolStripMenuItem
            // 
            this.yaziRengiToolStripMenuItem.Name = "yaziRengiToolStripMenuItem";
            this.yaziRengiToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.yaziRengiToolStripMenuItem.Text = "Yazı Rengi";
            // 
            // FrmNote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 292);
            this.Controls.Add(this.rchYazi);
            this.Name = "FrmNote";
            this.Text = "FrmNote";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.ToolStripMenuItem kesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem kopyalaToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem yapistirToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem yaziStiliToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem yaziRengiToolStripMenuItem;
        public System.Windows.Forms.RichTextBox rchYazi;
    }
}