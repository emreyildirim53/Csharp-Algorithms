namespace Naive_Bayes_Classification
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.model = new System.Windows.Forms.Button();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dosyaYolu = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.countDataList = new System.Windows.Forms.ListBox();
            this.infoDataList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.SuspendLayout();
            // 
            // model
            // 
            this.model.Enabled = false;
            this.model.Location = new System.Drawing.Point(460, 315);
            this.model.Name = "model";
            this.model.Size = new System.Drawing.Size(116, 148);
            this.model.TabIndex = 13;
            this.model.Text = "Model Kur";
            this.model.UseVisualStyleBackColor = true;
            this.model.Click += new System.EventHandler(this.model_Click);
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(484, 4);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(91, 23);
            this.buttonOpen.TabIndex = 11;
            this.buttonOpen.Text = "Aç";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // dataView
            // 
            this.dataView.AllowUserToAddRows = false;
            this.dataView.AllowUserToDeleteRows = false;
            this.dataView.AllowUserToResizeColumns = false;
            this.dataView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataView.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataView.EnableHeadersVisualStyles = false;
            this.dataView.Location = new System.Drawing.Point(12, 32);
            this.dataView.Name = "dataView";
            this.dataView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataView.Size = new System.Drawing.Size(563, 277);
            this.dataView.TabIndex = 10;
            this.dataView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataView_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dosya Yolu:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dosyaYolu
            // 
            this.dosyaYolu.Enabled = false;
            this.dosyaYolu.Location = new System.Drawing.Point(79, 6);
            this.dosyaYolu.Name = "dosyaYolu";
            this.dosyaYolu.Size = new System.Drawing.Size(399, 20);
            this.dosyaYolu.TabIndex = 8;
            this.dosyaYolu.TextChanged += new System.EventHandler(this.dosyaYolu_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // countDataList
            // 
            this.countDataList.FormattingEnabled = true;
            this.countDataList.Location = new System.Drawing.Point(581, 4);
            this.countDataList.Name = "countDataList";
            this.countDataList.Size = new System.Drawing.Size(123, 459);
            this.countDataList.TabIndex = 23;
            // 
            // infoDataList
            // 
            this.infoDataList.FormattingEnabled = true;
            this.infoDataList.Location = new System.Drawing.Point(710, 5);
            this.infoDataList.Name = "infoDataList";
            this.infoDataList.Size = new System.Drawing.Size(375, 459);
            this.infoDataList.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 148);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Girdiler";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 468);
            this.Controls.Add(this.model);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.infoDataList);
            this.Controls.Add(this.countDataList);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.dataView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dosyaYolu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Naive Bayes Classification";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button model;
        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox dosyaYolu;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox countDataList;
        private System.Windows.Forms.ListBox infoDataList;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

