using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePadBymouloui
{
    public partial class FormRochercher : Form
    {
        public FormRochercher()
        {
            InitializeComponent();
        }

        private void FormRochercher_Load(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Entre Your text";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] tab = Form1.richTextBox1.Text.Split(' ');
            int x = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                x += tab[i].Length + 1;
                  if (tab[i] == textBox1.Text)
                    {
                        Form1.richTextBox1.Select(x - tab[i].Length - 1,tab[i].Length);
                        break;

                    }
            }
          
        }
    }
}
