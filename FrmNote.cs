using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePadSharp
{
    public partial class FrmNote : Form
    {
        public FrmNote()
        {
            InitializeComponent();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rchYazi.SelectedText.Length > 0)
            {
            //    Clipboard.SetText(rchYazi.SelectedText);     
            //    rchYazi.SelectedText = "";
                rchYazi.Cut(); //ile yapılabılır.
            }
        }

      
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (rchYazi.SelectedText.Length > 0)
            {             
                kesToolStripMenuItem.Enabled = true;
                kopyalaToolStripMenuItem.Enabled = true;

            }
            else
            {
                kopyalaToolStripMenuItem.Enabled = false;
                kesToolStripMenuItem.Enabled = false;   
            }
            if (Clipboard.GetText().Length>0)
            {
                yapistirToolStripMenuItem.Enabled = true;
            }
            else
            {
                yapistirToolStripMenuItem.Enabled = false;                
            }
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rchYazi.Copy();
        }

        private void yapistirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rchYazi.Paste();
        }
    }
}
