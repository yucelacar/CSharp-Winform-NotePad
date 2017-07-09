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
    public partial class FrmAra : Form
    {
        public FrmAra()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           if(string.IsNullOrWhiteSpace( textBox1.Text))
            {
                
                //FrmNote frm = (FrmNote) ActiveMdiChild;
                //frm.rchYazi.ForeColor = frm.rchYazi.ForeColor;
            }
        }

        //private void FrmAra_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    FrmAna ds = new FrmAna();
        //    Form[] formlarım = ds.MdiChildren;

        //        foreach (Form item in formlarım)
        //        {
        //            if (item is FrmNote)
        //            {
        //                FrmNote formum = (FrmNote)item;
        //                formum.rchYazi.ForeColor = formum.rchYazi.ForeColor;                      
        //            }
        //        }            
        //}
    }
}
