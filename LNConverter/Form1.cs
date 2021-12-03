using System;
using System.Drawing;
using System.Drawing.Imaging;
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
            tbxFilePath.Text = System.Environment.ExpandEnvironmentVariables("%userprofile%/downloads/");

            foreach (InputLanguage language in InputLanguage.InstalledInputLanguages)
            {
                if (language.LayoutName == "日本語") { btnSelectFile.Text = "ファイルを選択"; btnConvert.Text = "変換"; lblTextAlignment.Text = "文字揃え"; lblFontSize.Text = "フォントサイズ"; cbDarkMode.Text = "ダークモード"; cbTategaki.Text = "縦書き"; cbMoveHtml.Text = "imagesというフォルダに.htmlを移動"; cbMoveCover.Text = "imagesというフォルダに表紙を移動"; cbxAlignment.Location = new Point(270, 182); tbxFontSize.Location = new Point(287, 219); lbPx.Location = new Point(316, 222); } // :)
            }
        }

        String FilePath = "";
        EpubBook Epub;
        String HTMLConvert = "";
        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            OpenFile.Multiselect = true;
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
                if (coverImageContent == null && Epub.Content.Images.Count != 0)
                {
                    try
                    {
                        var contentFile = Epub.Content.Images["cover1.jpeg"];
                        coverImageContent = contentFile.Content;
                    }
                    catch {}
                    
                }

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
                pictureBox1.Image = null;
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

            String OutputLocation = System.Environment.ExpandEnvironmentVariables("%userprofile%/downloads/");

            Directory.CreateDirectory(OutputLocation + Epub.Title);
            Directory.CreateDirectory(OutputLocation + Epub.Title + "/images");
            foreach (var imageFile in Epub.Content.Images.Values)
            {
                byte[] coverImageContent = imageFile.Content;
                if (coverImageContent != null)
                {
                    using (MemoryStream coverImageStream = new MemoryStream(coverImageContent))
                    {
                        Image coverImage = Image.FromStream(coverImageStream);
                        //try
                        //{
                            coverImage.Save(imageFile.FileName.Replace("images/", ""), ImageFormat.Jpeg);
                        //} catch
                        //{
                        //    goto SkipSave;
                        //}
                        string imageMovePath = cbMoveCover.Checked && imageFile.FileName.ToLower().Contains("cover") ? OutputLocation + Epub.Title + "/images/" + imageFile.FileName : OutputLocation + Epub.Title + "/" + imageFile.FileName;
                        File.Move(imageFile.FileName.Replace("images/", ""), imageMovePath, true);
                        //SkipSave:;
                    }
                }   
            }

            HTMLConvert = HTMLConvert.Replace("\n", "");
            if (cbxAlignment.Text != "") {
                HTMLConvert = HTMLConvert.Replace("text-align: center;", cbxAlignment.Text.ToLower());
                HTMLConvert = HTMLConvert.Replace("text-align: left;", cbxAlignment.Text.ToLower());
                HTMLConvert = HTMLConvert.Replace("text-align: right;", cbxAlignment.Text.ToLower());
            }
            string fontSizeText = string.Empty;
            if (tbxFontSize.Text != "")
            {
                fontSizeText = "body {" + $"font-size: {tbxFontSize.Text}px; ";
                HTMLConvert = HTMLConvert.Replace("body {", fontSizeText);
            }

            string bodyReplacer = "<body style=\"";
            if (cbDarkMode.Checked == true) {
                bodyReplacer += "background-color:#181a1b; color:#FFFFFF;";
            }
            if (cbTategaki.Checked == true)
            {
                bodyReplacer += "-webkit-writing-mode: vertical-rl; -moz-writing-mode: vertical-rl; -ms-writing-mode: vertical-rl; writing-mode: vertical-rl;";
            }
            bodyReplacer += "\"";
            if (bodyReplacer == "<body style=\"\"") { bodyReplacer = string.Empty; }
            HTMLConvert = HTMLConvert.Replace("<body", bodyReplacer);

            string addImagesPath = string.Empty;
            if (cbMoveHtml.Checked == true) { addImagesPath = @"/images/"; }
            string htmlOutputPath = OutputLocation + Epub.Title + "/" + addImagesPath + Epub.Title + ".html";
            
            File.Create(htmlOutputPath).Dispose();
            using (StreamWriter writer = new StreamWriter(htmlOutputPath)) //System.Environment.ExpandEnvironmentVariables("%userprofile%/downloads/") + Epub.Title + ".html"
            {
                writer.WriteLine(HTMLConvert);
            }
            MessageBox.Show("New file named " + Epub.Title + ".html" + " has been created in the downloads folder", "Conversion Successful");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.Size.Height <= 410)
            {
                pictureBox1.Width = 123;
                pictureBox1.Height = 183;
            }
            else
            {
                pictureBox1.Width = 170;
                pictureBox1.Height = 237;
            }
        }


        
    }

}

