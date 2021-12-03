
namespace LNConverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.tbxFilePath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbMoveHtml = new System.Windows.Forms.CheckBox();
            this.cbxAlignment = new System.Windows.Forms.ComboBox();
            this.cbTategaki = new System.Windows.Forms.CheckBox();
            this.lblTextAlignment = new System.Windows.Forms.Label();
            this.cbMoveCover = new System.Windows.Forms.CheckBox();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.tbxFontSize = new System.Windows.Forms.TextBox();
            this.lbPx = new System.Windows.Forms.Label();
            this.cbDarkMode = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(13, 5);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(127, 29);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select Epub";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // tbxFilePath
            // 
            this.tbxFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxFilePath.Location = new System.Drawing.Point(148, 6);
            this.tbxFilePath.Name = "tbxFilePath";
            this.tbxFilePath.Size = new System.Drawing.Size(607, 27);
            this.tbxFilePath.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(13, 41);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(127, 29);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(13, 89);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(742, 30);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "[title]";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.pictureBox1.Location = new System.Drawing.Point(13, 122);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 237);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // cbMoveHtml
            // 
            this.cbMoveHtml.AutoSize = true;
            this.cbMoveHtml.Checked = true;
            this.cbMoveHtml.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMoveHtml.Location = new System.Drawing.Point(204, 122);
            this.cbMoveHtml.Name = "cbMoveHtml";
            this.cbMoveHtml.Size = new System.Drawing.Size(244, 24);
            this.cbMoveHtml.TabIndex = 5;
            this.cbMoveHtml.Text = "Move .html inside images folder";
            this.cbMoveHtml.UseVisualStyleBackColor = true;
            // 
            // cbxAlignment
            // 
            this.cbxAlignment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbxAlignment.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAlignment.FormattingEnabled = true;
            this.cbxAlignment.Items.AddRange(new object[] {
            "Center",
            "Left",
            "Right"});
            this.cbxAlignment.Location = new System.Drawing.Point(312, 182);
            this.cbxAlignment.Name = "cbxAlignment";
            this.cbxAlignment.Size = new System.Drawing.Size(72, 28);
            this.cbxAlignment.TabIndex = 6;
            // 
            // cbTategaki
            // 
            this.cbTategaki.AutoSize = true;
            this.cbTategaki.Location = new System.Drawing.Point(204, 285);
            this.cbTategaki.Name = "cbTategaki";
            this.cbTategaki.Size = new System.Drawing.Size(109, 24);
            this.cbTategaki.TabIndex = 7;
            this.cbTategaki.Text = "Vertical text";
            this.cbTategaki.UseVisualStyleBackColor = true;
            // 
            // lblTextAlignment
            // 
            this.lblTextAlignment.AutoSize = true;
            this.lblTextAlignment.Location = new System.Drawing.Point(201, 185);
            this.lblTextAlignment.Name = "lblTextAlignment";
            this.lblTextAlignment.Size = new System.Drawing.Size(108, 20);
            this.lblTextAlignment.TabIndex = 8;
            this.lblTextAlignment.Text = "Text Alignment";
            // 
            // cbMoveCover
            // 
            this.cbMoveCover.AutoSize = true;
            this.cbMoveCover.Checked = true;
            this.cbMoveCover.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMoveCover.Location = new System.Drawing.Point(204, 152);
            this.cbMoveCover.Name = "cbMoveCover";
            this.cbMoveCover.Size = new System.Drawing.Size(247, 24);
            this.cbMoveCover.TabIndex = 5;
            this.cbMoveCover.Text = "Move cover inside images folder";
            this.cbMoveCover.UseVisualStyleBackColor = true;
            // 
            // lblFontSize
            // 
            this.lblFontSize.AutoSize = true;
            this.lblFontSize.Location = new System.Drawing.Point(201, 222);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(66, 20);
            this.lblFontSize.TabIndex = 8;
            this.lblFontSize.Text = "Font size";
            // 
            // tbxFontSize
            // 
            this.tbxFontSize.Location = new System.Drawing.Point(269, 219);
            this.tbxFontSize.Name = "tbxFontSize";
            this.tbxFontSize.Size = new System.Drawing.Size(29, 27);
            this.tbxFontSize.TabIndex = 9;
            // 
            // lbPx
            // 
            this.lbPx.AutoSize = true;
            this.lbPx.Location = new System.Drawing.Point(298, 222);
            this.lbPx.Name = "lbPx";
            this.lbPx.Size = new System.Drawing.Size(25, 20);
            this.lbPx.TabIndex = 8;
            this.lbPx.Text = "px";
            // 
            // cbDarkMode
            // 
            this.cbDarkMode.AutoSize = true;
            this.cbDarkMode.Location = new System.Drawing.Point(204, 255);
            this.cbDarkMode.Name = "cbDarkMode";
            this.cbDarkMode.Size = new System.Drawing.Size(105, 24);
            this.cbDarkMode.TabIndex = 7;
            this.cbDarkMode.Text = "Dark mode";
            this.cbDarkMode.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AcceptButton = this.btnConvert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 372);
            this.Controls.Add(this.cbxAlignment);
            this.Controls.Add(this.tbxFontSize);
            this.Controls.Add(this.lbPx);
            this.Controls.Add(this.lblFontSize);
            this.Controls.Add(this.lblTextAlignment);
            this.Controls.Add(this.cbDarkMode);
            this.Controls.Add(this.cbTategaki);
            this.Controls.Add(this.cbMoveCover);
            this.Controls.Add(this.cbMoveHtml);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.tbxFilePath);
            this.Controls.Add(this.btnSelectFile);
            this.MinimumSize = new System.Drawing.Size(517, 365);
            this.Name = "Form1";
            this.Text = "LNConverter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox tbxFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox cbMoveHtml;
        private System.Windows.Forms.ComboBox cbxAlignment;
        private System.Windows.Forms.CheckBox cbTategaki;
        private System.Windows.Forms.Label lblTextAlignment;
        private System.Windows.Forms.CheckBox cbMoveCover;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.TextBox tbxFontSize;
        private System.Windows.Forms.Label lbPx;
        private System.Windows.Forms.CheckBox cbDarkMode;
    }
}

