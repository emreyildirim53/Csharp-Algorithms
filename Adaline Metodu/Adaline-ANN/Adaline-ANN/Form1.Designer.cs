namespace Adaline_ANN
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.dataGridDatas = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.labelOgrenmeKaysayısı = new System.Windows.Forms.Label();
            this.textBoxOgrenmeKatsayısı = new System.Windows.Forms.TextBox();
            this.textBoxEsilDegeri = new System.Windows.Forms.TextBox();
            this.labelEsikDegeri = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.comboBoxWeight = new System.Windows.Forms.ComboBox();
            this.noteList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxWeight = new System.Windows.Forms.TextBox();
            this.buttonKontrol = new System.Windows.Forms.Button();
            this.dataGridKontrol = new System.Windows.Forms.DataGridView();
            this.labelAccuary = new System.Windows.Forms.Label();
            this.buttonOpenSample = new System.Windows.Forms.Button();
            this.textBoxSampleURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOpenTestArea = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDatas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridKontrol)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dosya Yolu: ";
            // 
            // textBoxUrl
            // 
            this.textBoxUrl.Enabled = false;
            this.textBoxUrl.Location = new System.Drawing.Point(78, 10);
            this.textBoxUrl.Name = "textBoxUrl";
            this.textBoxUrl.Size = new System.Drawing.Size(399, 20);
            this.textBoxUrl.TabIndex = 1;
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Location = new System.Drawing.Point(483, 8);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(91, 23);
            this.buttonOpenFile.TabIndex = 2;
            this.buttonOpenFile.Text = "Dosyayı Aç";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // dataGridDatas
            // 
            this.dataGridDatas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDatas.Location = new System.Drawing.Point(14, 86);
            this.dataGridDatas.Name = "dataGridDatas";
            this.dataGridDatas.Size = new System.Drawing.Size(560, 327);
            this.dataGridDatas.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelOgrenmeKaysayısı
            // 
            this.labelOgrenmeKaysayısı.AutoSize = true;
            this.labelOgrenmeKaysayısı.Location = new System.Drawing.Point(10, 50);
            this.labelOgrenmeKaysayısı.Name = "labelOgrenmeKaysayısı";
            this.labelOgrenmeKaysayısı.Size = new System.Drawing.Size(100, 13);
            this.labelOgrenmeKaysayısı.TabIndex = 4;
            this.labelOgrenmeKaysayısı.Text = "Öğrenme Katsayısı :";
            // 
            // textBoxOgrenmeKatsayısı
            // 
            this.textBoxOgrenmeKatsayısı.Location = new System.Drawing.Point(112, 47);
            this.textBoxOgrenmeKatsayısı.Name = "textBoxOgrenmeKatsayısı";
            this.textBoxOgrenmeKatsayısı.Size = new System.Drawing.Size(90, 20);
            this.textBoxOgrenmeKatsayısı.TabIndex = 5;
            this.textBoxOgrenmeKatsayısı.Text = "Default : 0.5";
            this.textBoxOgrenmeKatsayısı.MouseEnter += new System.EventHandler(this.textBoxOgrenmeKatsayısı_MouseEnter);
            this.textBoxOgrenmeKatsayısı.MouseLeave += new System.EventHandler(this.textBoxOgrenmeKatsayısı_MouseLeave);
            // 
            // textBoxEsilDegeri
            // 
            this.textBoxEsilDegeri.Location = new System.Drawing.Point(275, 47);
            this.textBoxEsilDegeri.Name = "textBoxEsilDegeri";
            this.textBoxEsilDegeri.Size = new System.Drawing.Size(90, 20);
            this.textBoxEsilDegeri.TabIndex = 7;
            this.textBoxEsilDegeri.Text = "Default : 0.1";
            this.textBoxEsilDegeri.MouseEnter += new System.EventHandler(this.textBoxEsilDegeri_MouseEnter);
            this.textBoxEsilDegeri.MouseLeave += new System.EventHandler(this.textBoxEsilDegeri_MouseLeave);
            // 
            // labelEsikDegeri
            // 
            this.labelEsikDegeri.AutoSize = true;
            this.labelEsikDegeri.Location = new System.Drawing.Point(208, 50);
            this.labelEsikDegeri.Name = "labelEsikDegeri";
            this.labelEsikDegeri.Size = new System.Drawing.Size(64, 13);
            this.labelEsikDegeri.TabIndex = 6;
            this.labelEsikDegeri.Text = "Eşit Değeri :";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(483, 46);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(91, 23);
            this.buttonCalculate.TabIndex = 8;
            this.buttonCalculate.Text = "Çalıştır";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            // 
            // comboBoxWeight
            // 
            this.comboBoxWeight.FormattingEnabled = true;
            this.comboBoxWeight.Location = new System.Drawing.Point(372, 46);
            this.comboBoxWeight.Name = "comboBoxWeight";
            this.comboBoxWeight.Size = new System.Drawing.Size(105, 21);
            this.comboBoxWeight.TabIndex = 9;
            this.comboBoxWeight.Text = "Ağırlıklar";
            // 
            // noteList
            // 
            this.noteList.FormattingEnabled = true;
            this.noteList.Location = new System.Drawing.Point(580, 8);
            this.noteList.Name = "noteList";
            this.noteList.Size = new System.Drawing.Size(383, 407);
            this.noteList.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1003, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Bulunan Ağırlıklar :\r\n";
            // 
            // textBoxWeight
            // 
            this.textBoxWeight.Location = new System.Drawing.Point(1103, 33);
            this.textBoxWeight.Multiline = true;
            this.textBoxWeight.Name = "textBoxWeight";
            this.textBoxWeight.Size = new System.Drawing.Size(553, 34);
            this.textBoxWeight.TabIndex = 12;
            // 
            // buttonKontrol
            // 
            this.buttonKontrol.Location = new System.Drawing.Point(1103, 73);
            this.buttonKontrol.Name = "buttonKontrol";
            this.buttonKontrol.Size = new System.Drawing.Size(553, 23);
            this.buttonKontrol.TabIndex = 13;
            this.buttonKontrol.Text = "Test Et";
            this.buttonKontrol.UseVisualStyleBackColor = true;
            this.buttonKontrol.Click += new System.EventHandler(this.buttonKotrol_Click);
            // 
            // dataGridKontrol
            // 
            this.dataGridKontrol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridKontrol.Location = new System.Drawing.Point(1006, 102);
            this.dataGridKontrol.Name = "dataGridKontrol";
            this.dataGridKontrol.Size = new System.Drawing.Size(650, 313);
            this.dataGridKontrol.TabIndex = 14;
            // 
            // labelAccuary
            // 
            this.labelAccuary.AutoSize = true;
            this.labelAccuary.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelAccuary.Location = new System.Drawing.Point(1023, 59);
            this.labelAccuary.Name = "labelAccuary";
            this.labelAccuary.Size = new System.Drawing.Size(45, 29);
            this.labelAccuary.TabIndex = 15;
            this.labelAccuary.Text = "%-\r\n";
            // 
            // buttonOpenSample
            // 
            this.buttonOpenSample.Location = new System.Drawing.Point(1565, 4);
            this.buttonOpenSample.Name = "buttonOpenSample";
            this.buttonOpenSample.Size = new System.Drawing.Size(91, 23);
            this.buttonOpenSample.TabIndex = 18;
            this.buttonOpenSample.Text = "Dosyayı Aç";
            this.buttonOpenSample.UseVisualStyleBackColor = true;
            this.buttonOpenSample.Click += new System.EventHandler(this.buttonOpenSample_Click);
            // 
            // textBoxSampleURL
            // 
            this.textBoxSampleURL.Enabled = false;
            this.textBoxSampleURL.Location = new System.Drawing.Point(1103, 7);
            this.textBoxSampleURL.Name = "textBoxSampleURL";
            this.textBoxSampleURL.Size = new System.Drawing.Size(456, 20);
            this.textBoxSampleURL.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1030, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Dosya Yolu: ";
            // 
            // buttonOpenTestArea
            // 
            this.buttonOpenTestArea.Location = new System.Drawing.Point(969, 6);
            this.buttonOpenTestArea.Name = "buttonOpenTestArea";
            this.buttonOpenTestArea.Size = new System.Drawing.Size(29, 409);
            this.buttonOpenTestArea.TabIndex = 19;
            this.buttonOpenTestArea.Text = ">>";
            this.buttonOpenTestArea.UseVisualStyleBackColor = true;
            this.buttonOpenTestArea.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 425);
            this.Controls.Add(this.buttonOpenTestArea);
            this.Controls.Add(this.buttonOpenSample);
            this.Controls.Add(this.textBoxSampleURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelAccuary);
            this.Controls.Add(this.dataGridKontrol);
            this.Controls.Add(this.buttonKontrol);
            this.Controls.Add(this.textBoxWeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.noteList);
            this.Controls.Add(this.comboBoxWeight);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.textBoxEsilDegeri);
            this.Controls.Add(this.labelEsikDegeri);
            this.Controls.Add(this.textBoxOgrenmeKatsayısı);
            this.Controls.Add(this.labelOgrenmeKaysayısı);
            this.Controls.Add(this.dataGridDatas);
            this.Controls.Add(this.buttonOpenFile);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adaline-Artificial Neural Network";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDatas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridKontrol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.DataGridView dataGridDatas;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label labelOgrenmeKaysayısı;
        private System.Windows.Forms.TextBox textBoxOgrenmeKatsayısı;
        private System.Windows.Forms.TextBox textBoxEsilDegeri;
        private System.Windows.Forms.Label labelEsikDegeri;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.ComboBox comboBoxWeight;
        private System.Windows.Forms.ListBox noteList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxWeight;
        private System.Windows.Forms.Button buttonKontrol;
        private System.Windows.Forms.DataGridView dataGridKontrol;
        private System.Windows.Forms.Label labelAccuary;
        private System.Windows.Forms.Button buttonOpenSample;
        private System.Windows.Forms.TextBox textBoxSampleURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonOpenTestArea;
    }
}

