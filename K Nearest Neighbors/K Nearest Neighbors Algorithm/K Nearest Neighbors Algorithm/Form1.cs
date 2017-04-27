using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections;
using Microsoft.VisualBasic;
using System.IO;
using System.Globalization;
using System.Threading;


namespace K_Nearest_Neighbors_Algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Excel.Application ExcelUygulama;
        Excel.Workbook ExcelProje;
        Excel.Worksheet ExcelSayfa;
        object Missing = System.Reflection.Missing.Value;
        Excel.Range ExcelRange;
        int rowCount = 0;
        int columnCount = 0;
        Hashtable attributes = new Hashtable();
        Hashtable modelData = new Hashtable();
        Hashtable testData = new Hashtable();
        Hashtable testResultClass = new Hashtable();
        List<string> classes = new List<string>();
        List<string> modelClasses = new List<string>();
        List<string> testClasses = new List<string>();
        List<double> listDistance = new List<double>();
        List<string> listClasses = new List<string>();
        int kValue = 1;

        private void Form1_Load(object sender, EventArgs e)
        {
            ////// Cleaning Yeniden Çalıştırma İçin Temizlik Kısmı \\\\\\\\\\
            attributes.Clear();
            dataView.Rows.Clear();
            dataDefClass.Rows.Clear();
            dataModelView.Rows.Clear();
            listBoxClasses.Items.Clear();
            listBoxDistance.Items.Clear();
            attributes.Clear();
            dataModelView.Columns.Clear();
            classes.Clear();
            testData.Clear();
            modelData.Clear();
            testClasses.Clear();
            modelClasses.Clear();
            dataDefClass.Columns.Clear();
            classes.Clear();
            /////////// Excellden Veri Çekme ve Datagridviewa Aktarma\\\\\\\\\
            ExcelUygulama = new Excel.Application();
            ExcelProje = ExcelUygulama.Workbooks.Open(Path.GetDirectoryName(Application.ExecutablePath) + "\\iris.xlsx");
            ExcelSayfa = (Excel.Worksheet)ExcelProje.Worksheets.get_Item(1);
            ExcelRange = ExcelSayfa.UsedRange;
            ExcelSayfa = (Excel.Worksheet)ExcelUygulama.ActiveSheet;
            ExcelUygulama.Visible = false;
            ExcelUygulama.AlertBeforeOverwriting = false;
            rowCount = ExcelRange.Rows.Count + 1;
            columnCount = ExcelRange.Columns.Count + 1;
            String sdbconnection = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Path.GetDirectoryName(Application.ExecutablePath) + "\\iris.xlsx; Extended Properties='Excel 12.0; TypeGuessRows=0; HDR=YES; IMEX=1'";
            OleDbConnection dbconnection = new OleDbConnection(sdbconnection);
            dbconnection.Open();
            OleDbDataAdapter dbadapter = new OleDbDataAdapter("Select * from [Sayfa1$]", dbconnection);
            DataTable dtable = new DataTable();
            dbadapter.Fill(dtable);
            dataView.DataSource = dtable;

           ////////// Excellden Çekilen Veriler Veri Yapısında da Tutuldu. \\\\\\\\\\
            for (int i = 1; i < columnCount - 1; i++)
            {
                dataModelView.Columns.Add((DataGridViewColumn)(dataView.Columns[i - 1].Clone()));
                dataDefClass.Columns.Add((DataGridViewColumn)(dataView.Columns[i - 1].Clone()));             
                List<double> attribute = new List<double>();
                for (int j = 2; j < rowCount; j++)
                {
                    object hucre = ExcelSayfa.Cells[j, i];
                    Excel.Range bolge = ExcelSayfa.get_Range(hucre, hucre);
                    if (bolge.Value2 != null)
                        attribute.Add(Convert.ToDouble(bolge.Value2));
                }
                if (!attributes.ContainsKey(i - 1))
                    attributes.Add(i - 1, attribute);

            }
            dataModelView.Columns.Add((DataGridViewColumn)(dataView.Columns[dataView.ColumnCount-1].Clone()));//sınıf kırmını yeni sutun eklemek için
            
            for (int i = 0; i < dataView.RowCount; i++)//Tüm sınıfların olduğu liste
                classes.Add(dataView.Rows[i].Cells[dataView.ColumnCount-1].FormattedValue.ToString());         
           
            totalRowCount.Text = dataView.RowCount.ToString();// Toplam satır sayısının tutulduğu text
            Normalization();//Verileri normalize et
            rndTrack.Maximum = Convert.ToInt16(totalRowCount.Text)-1;// Track limitini toplam verisetinin 1 eksiği yapıldı çünkü en az 1 tane olmalı
            ////////// Tahminlerin tutulduğu sütun tanımlamak için sütun başlığı Guess \\\\\\\\\\\
            DataGridViewColumn columnGuess = new DataGridViewTextBoxColumn();
            columnGuess.DataPropertyName = "columnGuess";
            columnGuess.HeaderText = "Guess";
            columnGuess.Name = "columnGuess";
            dataDefClass.Columns.Add(columnGuess);

            clearConfDataView();// Başlarken conf matrisi 0 olsun
        }

        /// KARMAŞIKLIK MATRİSİNE SATIR SUTUN EKLER GÖRÜNTÜ OLSUN DİYE
        private void addColumnRowConfMatrix() {
            confMatrix.Rows.Clear();
            confMatrix.Columns.Clear();
            // Karmaşıklık Matrisi için boş sütun \\
            DataGridViewColumn columnEmpty = new DataGridViewTextBoxColumn();
            columnEmpty.DataPropertyName = "empty";
            columnEmpty.HeaderText = " ";
            columnEmpty.Name = "empty";
            confMatrix.Columns.Add(columnEmpty);
            List<string> distancClassValue = new List<string>();
            distancClassValue=classes.Distinct().ToList();
            //Confisuon matrisinin oluşturulduğu kısım
            for (int i = 0; i < distancClassValue.Count;i++ )
            {
                DataGridViewColumn columnGuess = new DataGridViewTextBoxColumn();
                columnGuess.DataPropertyName = distancClassValue[i].ToLower().ToString();
                columnGuess.HeaderText = distancClassValue[i].ToUpper().ToString();
                columnGuess.Name = distancClassValue[i].ToLower().ToString();
                confMatrix.Columns.Add(columnGuess);
            }
            // Satır başlığı ekleme \\
            for (int i = 0; i < distancClassValue.Count; i++)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewCell hucre = new DataGridViewTextBoxCell();
                hucre.Style.Font = new Font("Microsoft Sans Serif", 8.0f, FontStyle.Bold);
                hucre.Value = distancClassValue[i].ToUpper();
                row.Cells.Add(hucre);
                confMatrix.Rows.Add(row);
            }        
        }

        //KARMAŞIKLIK MATRİSİNİN DEĞERLERİNİ BAŞLANGIÇTA SIFIRLAMAK İÇİN KULLANILIR
        private void clearConfDataView()
        {
            /// Conf Matrisinde Boş Satırları 1 Yapma
            for (int i = 1; i < confMatrix.ColumnCount; i++)
                for (int j = 0; j < confMatrix.RowCount; j++)
                    confMatrix.Rows[j].Cells[i].Value = 0;
        }
        ///////////  Verilerin normalize edildiği fonksiyondur  \\\\\\\\\\\\\\\
        private void Normalization() {         
            foreach (int key in attributes.Keys)
            {
                double minValue=double.MaxValue;
                double maxValue=0;
                List<double> attribute = (List<double>)attributes[key];
                for (int i = 0; i < attribute.Count; i++) {
                    if (maxValue < attribute[i]) {
                        maxValue = attribute[i];
                    }
                    if (minValue > attribute[i]) {
                        minValue=attribute[i];
                    }
                }
                for (int i = 0; i < attribute.Count; i++) {
                    attribute[i] = (attribute[i] - minValue) / (maxValue - minValue);
                }
            }
        }

        private void createDataSet_Click(object sender, EventArgs e)
        {
            /////////////  Yeniden başlatma için temizlik yapıldı.  \\\\\\\\\\\\
            kValue = 1;
            tempBestK = 0;
            tempDogruluk = 0;
            sayac = 0;
            listBoxBestK.Items.Clear();
            if (rndTrack.Value == 200) return;
            dataModelView.Rows.Clear();
            modelData.Clear();
            testData.Clear();
            modelClasses.Clear();
            testClasses.Clear();
            /// Arkaplan temizleme eski haline getirme
            for (int i = 0; i < dataView.RowCount; i++)
            {
                dataView.Rows[i].DefaultCellStyle.BackColor = Color.White;
                dataView.Rows[i].DefaultCellStyle.ForeColor = Color.Black;  
            }
            

            ////////////////////  Rasgele veri üretmek için tracktan aldığı bilgiyi kullanıyoruz ve seçilen veriler ana verisetinde arkaplanı değişiyor.  \\\\\\\\\\\\\\\\\\\\\\\\\
            Random rand = new Random();
            List<int> rndNumbers = new List<int>();
            for (int i = 0; i < Convert.ToInt16(trackValue.Text); i++)
            {
                
                int random = rand.Next(Convert.ToInt16(totalRowCount.Text));
                if (rndNumbers.Contains(random)) i--;
                else
                {
                    List<double> attribute;
                    DataGridViewRow row = new DataGridViewRow();
                    for (int j = 0; j <= attributes.Count; j++)
                    {
                        DataGridViewCell hucre = new DataGridViewTextBoxCell();
                        attribute = (List<double>)attributes[j];
                        if (j == attributes.Count)
                            hucre.Value = classes[random];
                        else
                            hucre.Value = attribute[random];
                        row.Cells.Add(hucre);
                    }                  
                    dataModelView.Rows.Add(row);
                    dataView.Rows[random].DefaultCellStyle.BackColor = Color.Gray;
                    dataView.Rows[random].DefaultCellStyle.ForeColor = Color.White;   
                    rndNumbers.Add(random);
                }
            }
            //Model verilerini ve Sınıflarını Hashimizde tutmamız gerekir...
            for (int i = 0; i < dataModelView.RowCount; i++)
            {
                List<double> attribute = new List<double>();
                for (int j = 0; j < dataModelView.ColumnCount - 1; j++)
                     attribute.Add(Convert.ToDouble(dataModelView.Rows[i].Cells[j].FormattedValue));

                if (!testData.ContainsKey(i))
                    testData.Add(i, attribute);
            }
            for (int i = 0; i < dataModelView.RowCount; i++)
               testClasses.Add(dataModelView.Rows[i].Cells[dataModelView.ColumnCount - 1].FormattedValue.ToString());
           
            //Test verilerini ve Sınıflarını Hashimizde tutmamız gerekir...
            comboBox1.SelectedIndex = 1;
            int index = 0;
            for (int i = 0; i < dataView.RowCount; i++)
            {
                if (dataView.Rows[i].DefaultCellStyle.BackColor != Color.Gray)
                {
                    
                    List<double> attribute = new List<double>();
                    for (int j = 0; j < dataView.ColumnCount - 1; j++)
                        attribute.Add(Convert.ToDouble(dataView.Rows[i].Cells[j].FormattedValue));

                    if (!modelData.ContainsKey(index))
                        modelData.Add(index, attribute);
                    index++;
                }
                
            }
            ////// Arkaplan rengine göre atama yapma gri renkli olanları çıkarma
            for (int i = 0; i < dataView.RowCount; i++)         
                if (dataView.Rows[i].DefaultCellStyle.BackColor != Color.Gray)           
                    modelClasses.Add(dataView.Rows[i].Cells[dataView.ColumnCount - 1].FormattedValue.ToString());  //SORUN BURADAYDI GRAY OLMAYANLARDA EKLENİYORDU 
                
            
            totalModelRowCount.Text = modelData.Count+" Kayıt var.";
            totalTestRowCount.Text = testData.Count + " Kayıt var.";

            addColumnRowConfMatrix();
        }


        ///ALGORİTMANIN BAŞLATILDIĞI KISIM
        double tempDogruluk=0;
        int tempBestK = 0;
        int sayac = 0;
        private void button1_Click(object sender, EventArgs e)
        {
                listBoxSpecificity.Items.Clear();
                listBoxSensitivity.Items.Clear();          
                listBoxFMeasure.Items.Clear();
                dataDefClass.Rows.Clear();
                clearConfDataView();
                listBoxClasses.Items.Clear();
                listBoxDistance.Items.Clear();
                //DEFAULT KEY DEĞERİ ATANDI.
                if (checkKValue.Checked == false && textKvalue.Text != "Default: 3")
                {
                    kValue = Convert.ToInt16(textKvalue.Text);
                }
                else if (checkKValue.Checked == false && textKvalue.Text == "Default: 3") {
                    kValue = 3;
                }
                
                

                    //UZAKLIK ÖLCÜLERİ HESAPLANDI    -------   ÖKLİD UZAKLIK --------
                    //UZAKLIKLAR VE SINIFLARI SIRALANMAK ÜZERE LİSTELERE ATANDILAR.
                    for (int key = 0; key < testData.Count; key++)
                    {
                        List<double> test = (List<double>)testData[key];
                        listDistance.Clear();
                        listClasses.Clear();
                        for (int key2 = 0; key2 < modelData.Count; key2++)
                        { // her Model satırı olduğundan burda yapılan işlem sınıf belirlicek BURANIN DIŞINDA SINIF BELİRLENMEYECEK                    
                            List<double> model = (List<double>)modelData[key2];
                            double sum = 0;
                            for (int i = 0; i < test.Count; i++)
                            {
                                // MessageBox.Show(test[i]+" test to model   " + model[i]);// Burada her test için model satırının hücresi karsılaştırıldı. {unutma}
                                sum += Math.Pow((test[i] - model[i]), 2);
                            }
                            //FARKLARININ KARELERİ TOPLAMI BULUNDU -> SUM ŞİMİ BUNLAR KAREKÖK ALINIP SINIFIYLA BİRLİKTE TUTULMAK ZORUNDA                      
                            listDistance.Add(Math.Sqrt(sum));  //uzaklık tutan liste
                            listClasses.Add(modelClasses[key2]);  //sınıfını tutan liste  //   SORUN BURADA GÖRÜNÜYOR ARKAPLANI GRAY OLANLARIN SINIFLARINIDA EKLİYOR  ****MODELCLASS EKLERKEN GRAY HARİC DENMEMİŞTİ                                       
                        }
                        //** Önemli ***Mutlak Doğru= Bu listelerin key içinde yani her test için sıralanması en fazla sınıfın bulunması (k) ve sonradan sıfırlanması gerekiyor.        

                       // MessageBox.Show("kvalue"+kValue+"  listclasses:"+listClasses.Count);

                       
                        if (textKvalue.Text != "Default: 3" && (Convert.ToInt16(textKvalue.Text) > listClasses.Count || Convert.ToInt16(textKvalue.Text) <= 0) || kValue > listClasses.Count)
                        {
                            MessageBox.Show("K değeri model veri setinden büyük veya negatif olamaz.");
                            return;
                        }


                        // ARTAN ŞEKİLDE UZAKLIKLAR SIRALANDI DEĞİŞEN İNDİSLER SINIF DEĞERLERİ İÇİNDE DEĞİŞTİRİLDİ.
                        bubbleSort();

                        //SIRALANAN UZAKLIK LİSTESİ İÇİNDEKİ K KADAR VERİ İÇİNDE EN ÇOK TEKRAR EDEN DATADEFCLASS DATAGRİDVİEWİNA EKLENDİ -----  TAHMİN --------
                        DataGridViewRow row = new DataGridViewRow();
                        for (int i = 0; i <= test.Count; i++)
                        {
                            DataGridViewCell hucre = new DataGridViewTextBoxCell();
                            if (i == test.Count) hucre.Value = findClass();
                            else
                                hucre.Value = test[i];
                            row.Cells.Add(hucre);
                        }
                        dataDefClass.Rows.Add(row);

                        //// GÖRSELLİK SONUÇLAR LİSTBOXLARA YAZILDI. \\\\
                        bool kntrl = false;
                        for (int i = 0; i < listDistance.Count; i++)
                        {
                            if (i == 0 && kntrl == false)
                            {
                                int num = key + 1;
                                listBoxDistance.Items.Add("                            ");
                                listBoxDistance.Items.Add("----------------------------");
                                listBoxDistance.Items.Add("-- " + num + ". Test Kaydı --");
                                listBoxDistance.Items.Add("----------------------------");
                                listBoxDistance.Items.Add("                            ");
                                listBoxClasses.Items.Add("                            ");
                                listBoxClasses.Items.Add("----------------------------");
                                listBoxClasses.Items.Add("-- " + num + ". Test Kaydı --");
                                listBoxClasses.Items.Add("----------------------------");
                                listBoxClasses.Items.Add("                            ");
                                kntrl = true;
                            }
                            listBoxDistance.Items.Add(listDistance[i]);
                            listBoxClasses.Items.Add(listClasses[i]);
                        }
                    }

                    //KARMAŞIKLIK MATRİSİ GEREKLİ YERLER -GERÇEK DEĞERE KARŞILIK GELEN TAHMİN DEĞERİ- ARTTIRILDI
                    //KARMAŞIKLIK MATRİSİ DOĞRU TESPİT EDİLMİŞ SINIFLAR YEŞİLLE YANLIŞ TESPİT EDİLMİŞ SINIFLAR KIRMIZYLA    --- RENKLENDİRİLDİ ---

                    int countTrue = 0;
                    int countFalse = 0;

                    for (int i = 0; i < dataDefClass.RowCount; i++)
                    {
                        for (int j = 1; j < confMatrix.ColumnCount; j++)
                        {
                            for (int k = 0; k < confMatrix.RowCount; k++)
                            {
                                if ((confMatrix.Columns[j].HeaderText.ToString().ToLower() == dataDefClass.Rows[i].Cells[dataDefClass.ColumnCount - 1].Value.ToString()) && (confMatrix.Rows[k].Cells[0].Value.ToString().ToLower() == testClasses[i]))
                                {
                                    int value = (int)confMatrix.Rows[k].Cells[j].Value;
                                    confMatrix.Rows[k].Cells[j].Value = value + 1;
                                    if (dataDefClass.Rows[i].Cells[dataDefClass.ColumnCount - 1].Value.ToString() != testClasses[i])
                                    {
                                        dataDefClass.Rows[i].Cells[dataDefClass.ColumnCount - 1].Style.BackColor = Color.Red;
                                        countFalse++;
                                    }
                                    else
                                    {
                                        dataDefClass.Rows[i].Cells[dataDefClass.ColumnCount - 1].Style.BackColor = Color.LightGreen;
                                        countTrue++;
                                    }
                                }
                            }
                        }
                    }
                    ///////////////////// Doğruluk ve Hata Oranı Hesaplanması \\\\\\\\\\\\\\\\\\\\\
                    double dogruluk = ((double)countTrue / (double)testData.Count) * (double)100;
                    labelAccuracy.Text = "% " + dogruluk.ToString("F2");
                    labelError.Text = "% " + (Math.Abs(100 - dogruluk)).ToString("F2");

                    ///////////////////////// Specificity Hesaplaması \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    int rowSum = 0;
                    int TP = 0;
                    string text;
                    for (int j = 1; j < confMatrix.ColumnCount; j++)
                    {
                        text = confMatrix.Columns[j].HeaderText.ToString();
                        for (int k = 0; k < confMatrix.RowCount; k++)
                        {
                            if (j - 1 == k) TP = (int)confMatrix.Rows[k].Cells[j].Value;
                            rowSum += (int)confMatrix.Rows[k].Cells[j].Value;
                        }
                        text += " = % " + (((double)TP / (double)rowSum) * 100).ToString("F2");
                        listBoxSpecificity.Items.Add(text);
                        rowSum = 0;
                        TP = 0;
                        text = "";
                    }
                    ///////////////////////// Sensitivity Hesaplaması \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    int columnSum = 0;
                    TP = 0;
                    text = "";
                    for (int k = 0; k < confMatrix.RowCount; k++)
                    {
                        text = confMatrix.Columns[k + 1].HeaderText.ToString();
                        for (int j = 1; j < confMatrix.ColumnCount; j++)
                        {
                            if (j - 1 == k) TP = (int)confMatrix.Rows[k].Cells[j].Value;
                            columnSum += (int)confMatrix.Rows[k].Cells[j].Value;
                        }
                        text += " = % " + (((double)TP / (double)columnSum) * 100).ToString("F2");
                        listBoxSensitivity.Items.Add(text);
                        columnSum = 0;
                        TP = 0;
                        text = "";
                    }
                    ///////////////////////// F Ölçüm Hesaplaması \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                    rowSum = 0;
                    columnSum = 0;
                    TP = 0;
                    text = "";
                    for (int i = 0; i < confMatrix.RowCount; i++)
                    {

                        text = confMatrix.Columns[i + 1].HeaderText.ToString();
                        for (int j = 1; j < confMatrix.ColumnCount; j++)
                        {
                            if (j - 1 == i) TP = (int)confMatrix.Rows[i].Cells[j].Value;
                            else
                                rowSum += (int)confMatrix.Rows[i].Cells[j].Value;
                        }

                        for (int j = 0; j < confMatrix.RowCount; j++)
                        {
                            if (j != i)
                                columnSum += (int)confMatrix.Rows[j].Cells[i + 1].Value;
                        }
                        text += " = % " + (((double)(2 * TP) / (double)((2 * TP + columnSum + rowSum))) * 100).ToString("F2");
                        listBoxFMeasure.Items.Add(text);
                        columnSum = 0;
                        rowSum = 0;
                        TP = 0;
                        text = "";
                    }

                    listBoxBestK.Items.Add(kValue + " : " + dogruluk.ToString("F2"));
                    ///////////////// OPTİMİZE K DEĞERİNİN TESPİTİ \\\\\\\\\\\\\\\
                    if (checkKValue.Checked == true)
                    {

                        if (Math.Ceiling((double)(listClasses.Count / Math.Sqrt(listClasses.Count))) != kValue && kValue != tempBestK)
                        {
                            if (tempDogruluk <= dogruluk) { tempDogruluk = dogruluk; tempBestK = kValue; }
                            kValue++;
                            button1.PerformClick();
                        }
                        sayac++;
                        if (sayac == Math.Ceiling((double)(listClasses.Count / Math.Sqrt(listClasses.Count))))
                        {
                            kValue = tempBestK;
                            sayac = 0;
                            button1.PerformClick();
                        }
                    }
                
        }


        ///// K SAYISI KADAR VERİ İÇİNDE EN ÇOK GEÇEN SINIFI DÖNDÜRÜR//////////////////7
        string tempClass;   //SINIF BİLGİSİNİ SWAP YAPMAK İÇİN KULLANILDI
        public string findClass() {
            Hashtable kClass = new Hashtable();
            int say=1;
            for (int i = 0; i < kValue; i++)
            {
                if (kClass.ContainsKey(listClasses[i]))
                {
                    say = (int)kClass[listClasses[i]];
                    kClass[listClasses[i]]=say+1;
                }else
                kClass.Add(listClasses[i], say);
            }
           
            int tempCount=0;
            foreach (string key in kClass.Keys) {
                if ((int)kClass[key] > tempCount) {
                    tempCount = (int)kClass[key];
                    tempClass = key;
                }
  
            }

            return tempClass;
        }

        //// UZAKLIKLARI VE UZAKLIKLARA BAĞLI SINIFLARI ARTAN ŞEKİLDE SIRALAR
        public void bubbleSort()
        {
            bool swapped = true;
            int say = 0;
            double tempDistance;
            string tempClass;
            while (swapped)
            {
                swapped = false;
                say++;
                for (int i = 0; i < listDistance.Count - say; i++)
                {
                    if (listDistance[i] > listDistance[i + 1])
                    {
                        tempDistance = listDistance[i];
                        tempClass = listClasses[i];

                        listDistance[i] = listDistance[i + 1];
                        listClasses[i] = listClasses[i + 1];

                        listDistance[i + 1] = tempDistance;
                        listClasses[i + 1] = tempClass;
                        swapped = true;
                    }
                }
            }
        }
     
        ////////////////// Normalize veya gerçek verinin gösterildiği combobox \\\\\\\\\\\\\\\\\\\\\\\\\\
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                dataView.DataSource = null;
                Form1_Load(sender, e);
            }
            else {
             
                foreach (int key in attributes.Keys)
                {
                    List<double> attribute = (List<double>)attributes[key];                  
                    for (int k = 0; k < attribute.Count; k++)
                    {
                        dataView.Rows[k].Cells[key].Value = attribute[k];
                    }
                }
               
            }
        }
        ///////// Track değerini texte aktarılması  \\\\\\\\\\\\\\\\\\\\\\
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            trackValue.Text = rndTrack.Value.ToString();
        }

        ////////////////////////// Görev yönetici uygulamayı (Exell) kill etmek için \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ExcelProje.Close();
                ExcelUygulama.Quit();
            }
            catch (Exception)
            {
                throw;
            }
            releaseObject(ExcelSayfa);
            releaseObject(ExcelProje);
            releaseObject(ExcelUygulama);

            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                if (p.ProcessName == "EXCEL")
                {
                    p.Kill();
                }
            }
        }
        //////////////////////////////////////////////////////////////////////////////////////
        

        /////// Optimize etmek için checkboxa tıklandığında kvalue sıfırlanır ve elle girilen k değeri kapatıldı.
          private void checkKValue_CheckedChanged(object sender, EventArgs e)
        {
            if (checkKValue.Checked == true) kValue = 1;
            textKvalue.Enabled = !textKvalue.Enabled;
        }


        ///// Textboxun temizlenmesi
        private void textKvalue_Click(object sender, EventArgs e)
        {
            textKvalue.Clear();
        }


        /////////////////// Listelerin eş zamanlı seçimi \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        private void listBoxDistance_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxClasses.SelectedIndex = listBoxDistance.SelectedIndex; 
        }

        private void listBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxDistance.SelectedIndex=listBoxClasses.SelectedIndex; 
        }
       
    }
}
