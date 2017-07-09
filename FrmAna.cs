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
    public partial class FrmAna : Form
    {
        public FrmAna()
        {
            InitializeComponent();
        }

        bool _degistiMi = false;
        //Yeni Dosya açma işlemleri
        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YeniDosya();
        }
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            YeniDosya();
        }
        internal void YeniDosya()
        {
            toolStriptEnabled(true, bicimlendirmeToolStripMenuItem, harfİslemleriToolStripMenuItem, araToolStripMenuItem);
            FrmNote FrmNote = new FrmNote();
            FrmNote.MdiParent = this;
            FrmNote.Show();
            FrmNote.yaziRengiToolStripMenuItem.Click += yaziRengiToolStripMenuItem_Click;   //anadaki toolstripmenüitem event calısıcak buna bastıgımızda.
            FrmNote.yaziStiliToolStripMenuItem.Click += yaziStiliToolStripMenuItem_Click;
            FrmNote.FormClosing += FrmNote_FormClosing;                 //form kapandıgında 
            FrmNote.rchYazi.TextChanged += rchYazi_TextChanged;     //text degisdimi
        }

        void rchYazi_TextChanged(object sender, EventArgs e)
        {
            _degistiMi = true;
        }

        //Dosya Kapatıldıgında..
        void FrmNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_degistiMi)
            {
                DialogResult sonuc = MessageBox.Show("Kaydetmek istiyor musunuz?", "Kaydet", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (sonuc == DialogResult.Yes)
                {
                    kaydetToolStripMenuItem.PerformClick(); //kaydetme islemi gerçeklesiyor.
                    _degistiMi = false;
                }
                else if (sonuc == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                {
                    _degistiMi = false;
                }

            }
            if (this.MdiChildren.Length == 1)
            {
                toolStriptEnabled(false, bicimlendirmeToolStripMenuItem, harfİslemleriToolStripMenuItem, araToolStripMenuItem);
            }
        }
        void toolStriptEnabled(bool baslangıMı, params ToolStripMenuItem[] item)
        {
            for (int i = 0; i < item.Length; i++)
            {
                if (baslangıMı)
                {
                    item[i].Enabled = true;
                }
                else
                {
                    item[i].Enabled = false;
                }
            }
        }


        //Yazı rengi ve yazi tipi blogu
        void yaziStiliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YaziStiliDegis();
        }

        internal void YaziStiliDegis()
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font secilenYaziTipi = fontDialog1.Font;
                FrmNote frmAktifNote = (FrmNote)this.ActiveMdiChild;
                if (frmAktifNote.rchYazi.SelectedText.Length > 0)
                {
                    frmAktifNote.rchYazi.SelectionFont = secilenYaziTipi;
                }
                else
                {
                    frmAktifNote.rchYazi.Font = secilenYaziTipi;
                }
            }
        }

        void yaziRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YaziRengiDegis();
        }
        private void YaziRengiDegis()
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color secilenRenk = colorDialog1.Color;
                FrmNote frmAktifNote = (FrmNote)this.ActiveMdiChild; //aktif olan mdı child atıyorz.

                if (frmAktifNote.rchYazi.SelectedText.Length > 0)
                {
                    frmAktifNote.rchYazi.SelectionColor = secilenRenk;  //secili rengi secilen renk atıyor.
                }
                else
                {
                    frmAktifNote.rchYazi.ForeColor = secilenRenk;   //secilmediyse komple yapıyor.
                }
            }
        }

        private void yazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YaziStiliDegis();
        }

        private void yaziRengiToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            YaziRengiDegis();
        }




        //Dosya kaydetme blogu
        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DosyaKaydet();
        }
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            DosyaKaydet();
        }
        internal void DosyaKaydet()
        {
            if (this.MdiChildren.Count() < 1)
            {
                MessageBox.Show("Kaydelicek dosya yok");
            }
            else
            {
                saveFileDialog1.Filter = @"Zengin Metin Belgesi (*.rtf)|*.rtf";   //açıklama----kullanıcagım tıp 
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    _degistiMi = false;
                    var dosyaAdi = saveFileDialog1.FileName;
                    FrmNote frmAktif = (FrmNote)this.ActiveMdiChild;

                    saveFileDialog1.RestoreDirectory = true;
                    frmAktif.rchYazi.SaveFile(dosyaAdi);

                }
            }

        }

        //Dosya Acma Blogu
        private void acToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DosyaAc();
        }
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            DosyaAc();
        }
        internal void DosyaAc()
        {
            //sadece açabileceği dosyaları açmak için filter propertisine değer giriyoruz.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog1.FileName;
                string dosyaAdi = openFileDialog1.SafeFileName;
                FrmNote frmAcilacak = new FrmNote();
                frmAcilacak.MdiParent = this;
                frmAcilacak.rchYazi.LoadFile(dosyaYolu);
                frmAcilacak.Text = dosyaAdi;
                frmAcilacak.rchYazi.TextChanged += rchYazi_TextChanged;
                frmAcilacak.FormClosing += FrmNote_FormClosing;
                frmAcilacak.Show();
            }

        }



        private void hakkimizdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHakkimizda frm = new FrmHakkimizda();
            frm.MdiParent = this;
            frm.Show();
        }

        //Kes kopyala yapıstır.
        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            FrmNote frmAktif = (FrmNote)this.ActiveMdiChild;
            frmAktif.rchYazi.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            FrmNote frmAktif = (FrmNote)this.ActiveMdiChild;
            frmAktif.rchYazi.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            FrmNote frmAktif = (FrmNote)this.ActiveMdiChild;
            frmAktif.rchYazi.Paste();

        }

        //print dialog ve print document ekledım ana tabloya.
        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            DialogResult yazdirmaIslemi;
            yazdirmaIslemi = printDialog1.ShowDialog();
            if (yazdirmaIslemi == DialogResult.OK)
            {
                printDocument1.Print();
                // Bu konrol ile aslında yapılan şu uygulamalarımızda Print dediğimizde arka planda yazdırılacak alanı belirleyip sistemde çizen yani oluşturan bir kontroldür.
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            FrmNote frm = new FrmNote();
            Font yazisitili = new Font("Arial", 13);
            e.Graphics.DrawString(frm.rchYazi.Text, yazisitili, Brushes.Black, 150, 50);
        }



        private void araToolStripMenuItem_Click(object sender, EventArgs e) //clik eventi atıyoruz. Ara formundaki  butuna
        {
            FrmAra frmAra = new FrmAra();
            frmAra.MdiParent = this;
            frmAra.Controls["btnAra"].Click += FrmAna_btnAra_Click;
            frmAra.Controls["textBox1"].TextChanged += FrmAna_TextChanged;
            frmAra.Show();
            //frmAra_BtnAra_Click(new FrmAra(), EventArgs.Empty); burda event cagırıyoruz tetikliyoruz.

        }

        private void FrmAna_TextChanged(object sender, EventArgs e)  //text change eventinden textbox bos oldugunda bulunan degerlerı eski rengine cevirecektim.
        {
            Form[] formlarım = this.MdiChildren;
            foreach (Form item in formlarım)
            {
                if (item is FrmAra)
                {
                    FrmAra frmAra = (FrmAra)item;
                }
                if (item is FrmNote)
                {
                    FrmNote frmyeniNote = (FrmNote)item;
                    
                }
            }
            FrmAra frm = (FrmAra)this.ActiveMdiChild;
            FrmNote frmNote = (FrmNote)this.ActiveMdiChild;
            if (string.IsNullOrWhiteSpace(frm.Controls["textBox1"].Text))
            {
                frmNote.rchYazi.ForeColor = frmNote.rchYazi.ForeColor;
            }
           
        }

        void FrmAna_btnAra_Click(object sender, EventArgs e)
        {
            string aranan = ((this.ActiveMdiChild) as FrmAra).Controls["textBox1"].Text;   //btn ara clickledigimde ara formunu activeMdiChild dan yakaladık.

            Form[] formlarım = this.MdiChildren;
            if (!string.IsNullOrWhiteSpace(aranan)) //text içi bos olma durumu kontrol ediliyor.
            {
                foreach (Form item in formlarım)
                {
                    if (item is FrmNote)
                    {
                        int sayi=0;
                        FrmNote formum = (FrmNote)item;
                        for (int i = 0; i < formum.rchYazi.TextLength; i++)
                        {
                            sayi = formum.rchYazi.Find(aranan, 0, formum.rchYazi.TextLength, RichTextBoxFinds.None); //bulamadıgı durumda -1 dondurcek.
                            formum.rchYazi.SelectionBackColor = Color.Yellow;
                        

                        }
                        if (aranan == string.Empty||aranan.Length<1)
                        {
                            formum.rchYazi.SelectAll();
                            formum.rchYazi.SelectionBackColor = Color.Black;
                        }
                        if (sayi < 1)
                        {
                            MessageBox.Show("Aradığınız kelime bulunamadı!");
                        }
                      
                    }
                }
            }
            else
            {
                MessageBox.Show("Aranacak kelimeyi giriniz!");
            }

        }

        private void hepsiBuyukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNote frmAktif = (FrmNote)this.ActiveMdiChild;
            if (frmAktif.rchYazi.SelectedText.Length > 0)
            {
                frmAktif.rchYazi.SelectedText = frmAktif.rchYazi.SelectedText.ToUpper();    //secili yeri buyuk yapıyor.
            }
            else
            {
                MessageBox.Show("Büyük harf çevirmek için metin bölümü seciniz.");
            }
        }

        private void hepsiKucukToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmNote frmAktif = (FrmNote)this.ActiveMdiChild;
            if (frmAktif.rchYazi.SelectedText.Length > 0)
            {
                frmAktif.rchYazi.SelectedText = frmAktif.rchYazi.SelectedText.ToLower();    //secili yeri buyuk yapıyor.
            }
            else
            {
                MessageBox.Show("Büyük harf çevirmek için metin bölümü seciniz.");
            }

        }
    }
}
