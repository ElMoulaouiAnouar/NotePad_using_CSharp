using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NotePadBymouloui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void statusStrip2_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = richTextBox1.Text.Length.ToString();
        }

        private void aboutNotePadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Create By moulaoui Anouar", "About NotePad#", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aboutNotePadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Black;
            richTextBox1.ForeColor = Color.White;
        }

        private void bleuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.White;
            richTextBox1.ForeColor = Color.Black;
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Red;
            richTextBox1.ForeColor = Color.Black;
        }

        private void aquaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Aqua;
            richTextBox1.ForeColor = Color.Black;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.BackColor = Color.Green;
            richTextBox1.ForeColor = Color.White;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog f = new FontDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectedText.Length > 0)
                {
                    richTextBox1.SelectionFont = f.Font;
                }
                else
                {
                    richTextBox1.Font = f.Font;
                }
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog co = new ColorDialog();
            if (co.ShowDialog() == DialogResult.OK)
            {
                if (richTextBox1.SelectedText.Length > 0)
                {
                    richTextBox1.SelectionColor = co.Color;
                }
                else
                {
                    richTextBox1.BackColor = co.Color;
                }
            }
        }
       
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
            richTextBox1.SelectedText = "";
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + Clipboard.GetText();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToShortDateString();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
            richTextBox1.SelectedText = "";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " +Clipboard.GetText();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
            richTextBox1.SelectedText = "";
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.SelectedText);
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += " " + Clipboard.GetText();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SaveFileDialog s = new SaveFileDialog();
        
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.Filter = "Fichier text(*.txt)|*.txt";
            if (richTextBox1.Text != "")
            {
                DialogResult d = MessageBox.Show("save File ?", "save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    if (s.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllLines(s.FileName,richTextBox1.Lines);
                        bool ver = true;
                        string pathver = s.FileName;
                    }
                   
                }
                else if (d == DialogResult.No)
                {
                    richTextBox1.Clear();
                }
            }
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Fichier text(*.txt)|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(open.FileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        richTextBox1.Text += line + Environment.NewLine;
                    }
                }
            }
        }
        bool ver = false;
        string pathver;
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.Filter = "Fichier text(*.txt)|*.txt";
            if (ver == true)
            {
               
                    File.WriteAllLines(pathver, richTextBox1.Lines);
                
            }
            else
            {
                if (s.ShowDialog() == DialogResult.OK)
                {

                    richTextBox1.SaveFile(s.FileName, RichTextBoxStreamType.PlainText);
                    
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            s.Filter = "Fichier text(*.txt)|*.txt";
            if (s.ShowDialog() == DialogResult.OK)
            {

                richTextBox1.SaveFile(s.FileName, RichTextBoxStreamType.PlainText);
                
            }

        }

        private void imprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog p = new PrintPreviewDialog();
            p.Document = printDocument1;
            p.ShowDialog();
        }
        float v = 1;
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            if (v < 20)
            {
               
                v++;
                richTextBox1.ZoomFactor = v;
            }
            else
            {
                v = 1;
            }
            
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (v > 0.90) {
                richTextBox1.ZoomFactor = v--;
            }
            else
            {
                v = 1;
            }
        }

        private void chercherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRochercher f = new FormRochercher();
            f.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            s.Filter = "Fichier text(*.txt)|*.txt";
            if (richTextBox1.Text != "")
            {
                DialogResult d = MessageBox.Show("save File ?", "save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    if (s.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllLines(s.FileName, richTextBox1.Lines);
                        bool ver = true;
                        string pathver = s.FileName;
                    }

                }
                else if (d == DialogResult.No)
                {
                    richTextBox1.Clear();
                }
            }
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            s.Filter = "Fichier text(*.txt)|*.txt";
            if (ver == true)
            {

                File.WriteAllLines(pathver, richTextBox1.Lines);

            }
            else
            {
                if (s.ShowDialog() == DialogResult.OK)
                {

                    richTextBox1.SaveFile(s.FileName, RichTextBoxStreamType.PlainText);

                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Fichier text(*.txt)|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(open.FileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        richTextBox1.Text += line + Environment.NewLine;
                    }
                }
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            
            PrintPreviewDialog p = new PrintPreviewDialog();
            p.Document = printDocument1;
            p.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox1.Text, richTextBox1.Font, Brushes.Black, new Point(90, 90));
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = richTextBox1.Text.Length.ToString();
            toolStripStatusLabel2.Text = richTextBox1.Lines.Length.ToString();

            string[] tab = richTextBox1.Text.Split(' ');
            string[] ver = new string[] { "nom", "Nom", "prenom", "Prenom", "Age", "age", "school", "School" };
            int x = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                x += tab[i].Length + 1;
                for (int s = 0; s < ver.Length; s++)
                {
                    if (tab[i] == ver[s])
                    {
                        richTextBox1.Select(x - tab[i].Length -1, tab[i].Length);
                       
                        richTextBox1.SelectionColor = Color.Red;
                        richTextBox1.DeselectAll();
                        richTextBox1.SelectionStart = richTextBox1.Text.Length;
                        richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Regular);
                        
                        
                    }
                }
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                FontDialog f=new FontDialog();
                richTextBox1.SelectionFont =new Font(richTextBox1.Font,FontStyle.Bold);
            }
            else
            {
                richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Bold);
            }

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
            }
            else
            {
                richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Italic);
            }
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font(richTextBox1.Font, FontStyle.Regular);
        }
    }

}