namespace K_Nearest_Neighbors_Algorithm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataView = new System.Windows.Forms.DataGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxDistance = new System.Windows.Forms.ListBox();
            this.listBoxClasses = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkKValue = new System.Windows.Forms.CheckBox();
            this.textKvalue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.totalTestRowCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.totalModelRowCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.createDataSet = new System.Windows.Forms.Button();
            this.totalRowCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackValue = new System.Windows.Forms.Label();
            this.rndTrack = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataModelView = new System.Windows.Forms.DataGridView();
            this.dataDefClass = new System.Windows.Forms.DataGridView();
            this.confMatrix = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.labelAccuracy = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.listBoxSensitivity = new System.Windows.Forms.ListBox();
            this.listBoxSpecificity = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.listBoxFMeasure = new System.Windows.Forms.ListBox();
            this.listBoxBestK = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rndTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataModelView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDefClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.confMatrix)).BeginInit();
            this.SuspendLayout();
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
            this.dataView.Location = new System.Drawing.Point(12, 12);
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
            this.dataView.Size = new System.Drawing.Size(664, 250);
            this.dataView.TabIndex = 14;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxDistance);
            this.groupBox1.Controls.Add(this.listBoxClasses);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.checkKValue);
            this.groupBox1.Controls.Add(this.textKvalue);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.totalTestRowCount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.totalModelRowCount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.createDataSet);
            this.groupBox1.Controls.Add(this.totalRowCount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.trackValue);
            this.groupBox1.Controls.Add(this.rndTrack);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(682, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 524);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Örnekleme Yöntemleri";
            // 
            // listBoxDistance
            // 
            this.listBoxDistance.FormattingEnabled = true;
            this.listBoxDistance.Location = new System.Drawing.Point(25, 343);
            this.listBoxDistance.Name = "listBoxDistance";
            this.listBoxDistance.Size = new System.Drawing.Size(204, 160);
            this.listBoxDistance.TabIndex = 19;
            this.listBoxDistance.SelectedIndexChanged += new System.EventHandler(this.listBoxDistance_SelectedIndexChanged);
            // 
            // listBoxClasses
            // 
            this.listBoxClasses.FormattingEnabled = true;
            this.listBoxClasses.Location = new System.Drawing.Point(235, 343);
            this.listBoxClasses.Name = "listBoxClasses";
            this.listBoxClasses.Size = new System.Drawing.Size(204, 160);
            this.listBoxClasses.TabIndex = 18;
            this.listBoxClasses.SelectedIndexChanged += new System.EventHandler(this.listBoxClasses_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(25, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(414, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Başlat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkKValue
            // 
            this.checkKValue.AutoSize = true;
            this.checkKValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkKValue.Location = new System.Drawing.Point(280, 258);
            this.checkKValue.Name = "checkKValue";
            this.checkKValue.Size = new System.Drawing.Size(159, 20);
            this.checkKValue.TabIndex = 14;
            this.checkKValue.Text = "K Değerini Optimize Et";
            this.checkKValue.UseVisualStyleBackColor = true;
            this.checkKValue.CheckedChanged += new System.EventHandler(this.checkKValue_CheckedChanged);
            // 
            // textKvalue
            // 
            this.textKvalue.Location = new System.Drawing.Point(121, 258);
            this.textKvalue.Name = "textKvalue";
            this.textKvalue.Size = new System.Drawing.Size(153, 20);
            this.textKvalue.TabIndex = 13;
            this.textKvalue.Text = "Default: 3";
            this.textKvalue.Click += new System.EventHandler(this.textKvalue_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(22, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "K Değerini Gir:\r\n";
            // 
            // totalTestRowCount
            // 
            this.totalTestRowCount.AutoSize = true;
            this.totalTestRowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.totalTestRowCount.Location = new System.Drawing.Point(240, 220);
            this.totalTestRowCount.Name = "totalTestRowCount";
            this.totalTestRowCount.Size = new System.Drawing.Size(15, 16);
            this.totalTestRowCount.TabIndex = 11;
            this.totalTestRowCount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(22, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Test Verisindeki Kayıt Sayısı :";
            // 
            // totalModelRowCount
            // 
            this.totalModelRowCount.AutoSize = true;
            this.totalModelRowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.totalModelRowCount.Location = new System.Drawing.Point(240, 187);
            this.totalModelRowCount.Name = "totalModelRowCount";
            this.totalModelRowCount.Size = new System.Drawing.Size(15, 16);
            this.totalModelRowCount.TabIndex = 9;
            this.totalModelRowCount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(22, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Model Verisindeki Kayıt Sayısı :";
            // 
            // createDataSet
            // 
            this.createDataSet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createDataSet.Location = new System.Drawing.Point(25, 138);
            this.createDataSet.Name = "createDataSet";
            this.createDataSet.Size = new System.Drawing.Size(402, 23);
            this.createDataSet.TabIndex = 7;
            this.createDataSet.Text = "Model Veri Setini Oluştur";
            this.createDataSet.UseVisualStyleBackColor = true;
            this.createDataSet.Click += new System.EventHandler(this.createDataSet_Click);
            // 
            // totalRowCount
            // 
            this.totalRowCount.AutoSize = true;
            this.totalRowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.totalRowCount.Location = new System.Drawing.Point(216, 28);
            this.totalRowCount.Name = "totalRowCount";
            this.totalRowCount.Size = new System.Drawing.Size(0, 16);
            this.totalRowCount.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(22, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(186, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Verideki Toplam Kayıt Sayısı :";
            // 
            // trackValue
            // 
            this.trackValue.AutoSize = true;
            this.trackValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.trackValue.Location = new System.Drawing.Point(412, 94);
            this.trackValue.Name = "trackValue";
            this.trackValue.Size = new System.Drawing.Size(15, 16);
            this.trackValue.TabIndex = 4;
            this.trackValue.Text = "1";
            // 
            // rndTrack
            // 
            this.rndTrack.Location = new System.Drawing.Point(174, 97);
            this.rndTrack.Maximum = 100;
            this.rndTrack.Minimum = 1;
            this.rndTrack.Name = "rndTrack";
            this.rndTrack.Size = new System.Drawing.Size(233, 45);
            this.rndTrack.TabIndex = 3;
            this.rndTrack.Value = 1;
            this.rndTrack.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(22, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Rasgele Veri Seti Seç :";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Gerçek Veriller",
            "Normalleştirilmiş Veriler"});
            this.comboBox1.Location = new System.Drawing.Point(193, 61);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(234, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(22, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Verilerin Durumunu Göster :";
            // 
            // dataModelView
            // 
            this.dataModelView.AllowUserToAddRows = false;
            this.dataModelView.AllowUserToDeleteRows = false;
            this.dataModelView.AllowUserToResizeColumns = false;
            this.dataModelView.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataModelView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataModelView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataModelView.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataModelView.EnableHeadersVisualStyles = false;
            this.dataModelView.Location = new System.Drawing.Point(12, 268);
            this.dataModelView.Name = "dataModelView";
            this.dataModelView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataModelView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataModelView.Size = new System.Drawing.Size(664, 262);
            this.dataModelView.TabIndex = 17;
            // 
            // dataDefClass
            // 
            this.dataDefClass.AllowUserToAddRows = false;
            this.dataDefClass.AllowUserToDeleteRows = false;
            this.dataDefClass.AllowUserToResizeColumns = false;
            this.dataDefClass.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataDefClass.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataDefClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDefClass.Cursor = System.Windows.Forms.Cursors.Default;
            this.dataDefClass.EnableHeadersVisualStyles = false;
            this.dataDefClass.Location = new System.Drawing.Point(1139, 6);
            this.dataDefClass.Name = "dataDefClass";
            this.dataDefClass.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataDefClass.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataDefClass.Size = new System.Drawing.Size(664, 256);
            this.dataDefClass.TabIndex = 18;
            // 
            // confMatrix
            // 
            this.confMatrix.AllowUserToAddRows = false;
            this.confMatrix.AllowUserToDeleteRows = false;
            this.confMatrix.AllowUserToResizeColumns = false;
            this.confMatrix.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.confMatrix.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.confMatrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.confMatrix.Cursor = System.Windows.Forms.Cursors.Default;
            this.confMatrix.EnableHeadersVisualStyles = false;
            this.confMatrix.Location = new System.Drawing.Point(1139, 268);
            this.confMatrix.Name = "confMatrix";
            this.confMatrix.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.confMatrix.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.confMatrix.Size = new System.Drawing.Size(664, 100);
            this.confMatrix.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(1149, 384);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Doğruluk Oranı :";
            // 
            // labelAccuracy
            // 
            this.labelAccuracy.AutoSize = true;
            this.labelAccuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelAccuracy.ForeColor = System.Drawing.Color.Lime;
            this.labelAccuracy.Location = new System.Drawing.Point(1154, 416);
            this.labelAccuracy.Name = "labelAccuracy";
            this.labelAccuracy.Size = new System.Drawing.Size(21, 24);
            this.labelAccuracy.TabIndex = 21;
            this.labelAccuracy.Text = "0";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelError.ForeColor = System.Drawing.Color.Red;
            this.labelError.Location = new System.Drawing.Point(1155, 485);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(21, 24);
            this.labelError.TabIndex = 23;
            this.labelError.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(1149, 457);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "Hata Oranı :";
            // 
            // listBoxSensitivity
            // 
            this.listBoxSensitivity.FormattingEnabled = true;
            this.listBoxSensitivity.Location = new System.Drawing.Point(1271, 405);
            this.listBoxSensitivity.Name = "listBoxSensitivity";
            this.listBoxSensitivity.Size = new System.Drawing.Size(120, 121);
            this.listBoxSensitivity.TabIndex = 24;
            // 
            // listBoxSpecificity
            // 
            this.listBoxSpecificity.FormattingEnabled = true;
            this.listBoxSpecificity.Location = new System.Drawing.Point(1397, 405);
            this.listBoxSpecificity.Name = "listBoxSpecificity";
            this.listBoxSpecificity.Size = new System.Drawing.Size(120, 121);
            this.listBoxSpecificity.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(1268, 382);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "Sensitivity :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(1398, 382);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 16);
            this.label10.TabIndex = 26;
            this.label10.Text = "Specificity :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(1524, 382);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 16);
            this.label11.TabIndex = 28;
            this.label11.Text = "F-Ölçüm :";
            // 
            // listBoxFMeasure
            // 
            this.listBoxFMeasure.FormattingEnabled = true;
            this.listBoxFMeasure.Location = new System.Drawing.Point(1523, 405);
            this.listBoxFMeasure.Name = "listBoxFMeasure";
            this.listBoxFMeasure.Size = new System.Drawing.Size(120, 121);
            this.listBoxFMeasure.TabIndex = 27;
            // 
            // listBoxBestK
            // 
            this.listBoxBestK.FormattingEnabled = true;
            this.listBoxBestK.Location = new System.Drawing.Point(1649, 405);
            this.listBoxBestK.Name = "listBoxBestK";
            this.listBoxBestK.Size = new System.Drawing.Size(120, 121);
            this.listBoxBestK.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label12.Location = new System.Drawing.Point(1650, 382);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 16);
            this.label12.TabIndex = 28;
            this.label12.Text = "K Değerleri :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1813, 538);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.listBoxBestK);
            this.Controls.Add(this.listBoxFMeasure);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.listBoxSpecificity);
            this.Controls.Add(this.listBoxSensitivity);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelAccuracy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.confMatrix);
            this.Controls.Add(this.dataDefClass);
            this.Controls.Add(this.dataModelView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "K Nearest Neighbors";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rndTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataModelView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDefClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.confMatrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataView;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label trackValue;
        private System.Windows.Forms.TrackBar rndTrack;
        private System.Windows.Forms.Label totalRowCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button createDataSet;
        private System.Windows.Forms.DataGridView dataModelView;
        private System.Windows.Forms.Label totalModelRowCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label totalTestRowCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkKValue;
        private System.Windows.Forms.TextBox textKvalue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataDefClass;
        private System.Windows.Forms.ListBox listBoxDistance;
        private System.Windows.Forms.ListBox listBoxClasses;
        private System.Windows.Forms.DataGridView confMatrix;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelAccuracy;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listBoxSensitivity;
        private System.Windows.Forms.ListBox listBoxSpecificity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox listBoxFMeasure;
        private System.Windows.Forms.ListBox listBoxBestK;
        private System.Windows.Forms.Label label12;
    }
}

