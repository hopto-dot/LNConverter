using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VersOne.Epub;

namespace LNConverter
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "";
        }

        String FilePath = "";
        EpubBook Epub;
        String HTMLConvert = "";
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.RestoreDirectory = true;
            OpenFile.Filter = "Epub Files|*.epub";
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                FilePath = OpenFile.FileName;
                tbxFilePath.Text = FilePath;
                //Epub = EpubReader.ReadBook(FilePath);
                try
                {
                    Epub = EpubReader.ReadBook(FilePath);
                    
                } catch
                {
                    MessageBox.Show("File \"kobo.js\" was not found in the archive.", "EPUB parsing error");
                    return;
                    //EpubBookRef epubBook = EpubReader.OpenBook(FilePath);
                }
                
                lblTitle.Text = Epub.Title;

                byte[] coverImageContent = Epub.CoverImage;
                if (coverImageContent != null)
                {
                    using (MemoryStream coverImageStream = new MemoryStream(coverImageContent))
                    {
                        Image coverImage = Image.FromStream(coverImageStream);
                        pictureBox1.Image = coverImage;
                    }
                }
            }
            else
            {
                return;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            FilePath = tbxFilePath.Text;
            try
            {
                Epub = EpubReader.ReadBook(FilePath);
            } catch
            {
                MessageBox.Show("Failed to convert EPUB to HTML", "Conversion Failed");
                return;
            }

            int Index = 0;
            foreach (EpubTextContentFile htmlContent in Epub.ReadingOrder)
            {
                string HTML = htmlContent.Content;
                if (Index == 0)
                {
                    HTMLConvert = HTML;
                }
                else if (Index == Epub.ReadingOrder.Count - 1)
                {
                    int SnipIndex = HTML.IndexOf("<html");
                    HTML = HTML.Substring(SnipIndex);
                    SnipIndex = HTML.IndexOf(">") + 4;
                    HTML = HTML.Substring(SnipIndex);
                }
                else
                {
                    int SnipIndex = HTML.IndexOf("<html");
                    HTML = HTML.Substring(SnipIndex);
                    SnipIndex = HTML.IndexOf(">") + 4;
                    HTML = HTML.Substring(SnipIndex);

                    HTML = HTML.Replace("</html>", "");
                    HTML = HTML.Trim();

                    HTMLConvert += HTML;
                }
                
                Index++;
            }
            HTMLConvert = HTMLConvert.Replace("\n", "");
            File.Create(System.Environment.ExpandEnvironmentVariables("%userprofile%/downloads/") + Epub.Title + ".html").Dispose();
            using (StreamWriter writer = new StreamWriter(System.Environment.ExpandEnvironmentVariables("%userprofile%/downloads/") + Epub.Title + ".html"))
            {
                writer.WriteLine(HTMLConvert);
            }
            MessageBox.Show("New file named " + Epub.Title + ".html" + " has been created in the downloads folder", "Conversion Successful");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.Size.Height >= 650)
            {
                pictureBox1.Width = 340;
                pictureBox1.Height = 474;
            }
            else if (this.Size.Height <= 400)
            {
                pictureBox1.Width = 170 / 2;
                pictureBox1.Height = 237 / 2;
            }
            else
            {
                pictureBox1.Width = 170;
                pictureBox1.Height = 237;
            }
        }
    }
}

