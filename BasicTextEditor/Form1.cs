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

namespace BasicTextEditor
{
    public partial class Form1 : Form
    {
        static string fileName;
        static string sFileName;
        public Form1()
        {
            InitializeComponent();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName != null)
            {
                richTextBox1.SaveFile(fileName);
                this.Text = sFileName;
            }
            else
            {
                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "Rich Text Files | *.rtf";
                sd.DefaultExt = "rtf";
                DialogResult result = sd.ShowDialog();
                if (result != DialogResult.Cancel)
                {
                    fileName = sd.FileName;
                    richTextBox1.SaveFile(fileName);
                    this.Text = sFileName = Path.GetFileName(fileName);
                }
            }

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Rich Text Files | *.rtf";
            od.DefaultExt = "rtf";
            DialogResult result = od.ShowDialog();
            if(result != DialogResult.Cancel)
            {
                fileName = od.FileName;
                richTextBox1.LoadFile(fileName);
                this.Text = sFileName = od.SafeFileName;

            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "Rich Text Files | *.rtf";
            sd.DefaultExt = "rtf";
            DialogResult result = sd.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                fileName = sd.FileName;
                richTextBox1.SaveFile(fileName);
                this.Text = sFileName = Path.GetFileName(fileName);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            fileName = null;
            sFileName = null;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to save your file?", "Important Question", MessageBoxButtons.YesNoCancel);
            if(result == DialogResult.Cancel)
            {
                return;
            }
            else if(result == DialogResult.Yes)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            Application.Exit();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(sFileName != null)
            {
                this.Text = sFileName + "*";
            }
            else
            {
                this.Text = "New File*";
            }
        }

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ FontStyle.Italic);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ FontStyle.Underline);
        }

        private void strikeoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ FontStyle.Strikeout);
        }
    }
}
