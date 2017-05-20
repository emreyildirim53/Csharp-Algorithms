using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adaline_ANN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path;
        List<List<String>> datas = new List<List<String>>();
        List<double> weight = new List<double>();
        List<int> valueClass = new List<int>();
        private void buttonOpenSample_Click(object sender, EventArgs e)
        {
            valueClass.Clear();
            datas.Clear();
            dataGridKontrol.Rows.Clear();
            dataGridKontrol.AllowUserToAddRows = false;
            OpenFileDialog file = new OpenFileDialog();
            file.RestoreDirectory = false;
            file.InitialDirectory = @"C:\";
            file.Filter = "Txt (*.txt)|*.txt|Csv (*.csv)|*.csv";

            file.FilterIndex = 2;
            file.RestoreDirectory = false;
            file.CheckFileExists = true;
            file.CheckPathExists = true;
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                textBoxSampleURL.Text = path;
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Contains('.')) line = line.Replace('.', ',');
                        List<String> lines = new List<string>();
                        lines = line.Split(';').ToList();
                        datas.Add(lines);
                    }
                }

                Random rand = new Random();
                for (int i = 0; i < datas.Count; i++)
                    for (int j = 0; j < datas[i].Count; j++)
                    {
                        if (i == 0 && j == 0)
                            dataGridKontrol.ColumnCount = datas[i].Count() + 1;
                        if (i == 0)
                        {
                            dataGridKontrol.Columns[j].Name = datas[i][j];

                        }
                        else
                        {
                            dataGridKontrol.Rows.Add(datas[i].ToArray());
                            break;
                        }
                    }
                dataGridKontrol.Columns[dataGridKontrol.ColumnCount - 1].Name = "Tahmin";
                datas.RemoveAt(0); // sütunlar veri setinden silindi
                for (int i = 0; i < dataGridKontrol.Rows.Count; i++)
                    valueClass.Add(Convert.ToInt16(dataGridKontrol.Rows[i].Cells[dataGridKontrol.ColumnCount - 2].Value));
            }
        }
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            valueClass.Clear();
            weight.Clear();
            datas.Clear();
            noteList.Items.Clear();
            dataGridDatas.Rows.Clear();
            dataGridDatas.AllowUserToAddRows = false;
            OpenFileDialog file = new OpenFileDialog();
            file.RestoreDirectory = false;
            file.InitialDirectory = @"C:\";
            file.Filter = "Txt (*.txt)|*.txt|Csv (*.csv)|*.csv";
    
            file.FilterIndex = 2;
            file.RestoreDirectory = false;
            file.CheckFileExists = true;
            file.CheckPathExists = true;
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;

                textBoxUrl.Text = path;
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (line.Contains('.')) line = line.Replace('.', ',');
                        List<String> lines = new List<string>();
                        lines = line.Split(';').ToList();
                        datas.Add(lines);
                    }
                }

                Random rand = new Random();
                for (int i = 0; i < datas.Count; i++)
                    for (int j = 0; j < datas[i].Count; j++)
                    {
                        if (i == 0 && j == 0)
                            dataGridDatas.ColumnCount = datas[i].Count();
                        if (i == 0)
                        {
                            dataGridDatas.Columns[j].Name = datas[i][j];
                            weight.Add(Math.Round(rand.NextDouble() % 0.8, 1) == 0 ? 0.1 : Math.Round(rand.NextDouble() % 0.8, 1));
                        }
                        else
                        {
                            dataGridDatas.Rows.Add(datas[i].ToArray());
                            break;
                        }
                    }
                datas.RemoveAt(0); // sütunlar veri setinden silindi
                for (int i = 0; i < dataGridDatas.Rows.Count; i++)
                    valueClass.Add(Convert.ToInt16(dataGridDatas.Rows[i].Cells[dataGridDatas.ColumnCount - 1].Value));

                //  weight.Add(0.3);
                // weight.Add(0.2);
                //  weight.RemoveAt(weight.Count - 1); // son eleman fazlalık sildik.
                for (int i = 0; i < weight.Count - 1; i++)
                    comboBoxWeight.Items.Add(weight[i]);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String text = "             ";
            String header = "Adaline-Artificial Neural Network";
            for (int i = 0; i < this.Width / header.Length; i++)
            {
                text += "    ";
            }
            this.Text = text + header;
        }
        private void textBoxOgrenmeKatsayısı_MouseEnter(object sender, EventArgs e)
        {
            if (textBoxOgrenmeKatsayısı.Text == "Default : 0.5") textBoxOgrenmeKatsayısı.Clear();        
        }
        private void textBoxOgrenmeKatsayısı_MouseLeave(object sender, EventArgs e)
        {
            if (textBoxOgrenmeKatsayısı.Text == "") textBoxOgrenmeKatsayısı.Text = "Default : 0.5";
        }

        private void textBoxEsilDegeri_MouseEnter(object sender, EventArgs e)
        {
            if (textBoxEsilDegeri.Text == "Default : 0.1") textBoxEsilDegeri.Clear(); 
        }

        private void textBoxEsilDegeri_MouseLeave(object sender, EventArgs e)
        {
            if (textBoxEsilDegeri.Text == "") textBoxEsilDegeri.Text = "Default : 0.1";
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            double valueTahmin,error = 0;
            int countTrue=0;
            double net = 0;
            int say = 0;
            //5.1;   3.5;    1.4;  0.2;   1
            if (textBoxUrl.Text != "") {
                double ogrenmeKatsayisi = Convert.ToDouble(textBoxOgrenmeKatsayısı.Text == "Default : 0.5" ? "0,5" : textBoxOgrenmeKatsayısı.Text);
                double esikdegeri = Convert.ToDouble(textBoxEsilDegeri.Text == "Default : 0.1" ? "0,1" : textBoxEsilDegeri.Text);
                do
                {
                    say++;
                    noteList.Items.Add("");
                    noteList.Items.Add("*******************************************");
                    noteList.Items.Add("*******************************************");
                    noteList.Items.Add("**************" + say + "-İterasyon*****************");
                    noteList.Items.Add("*******************************************");
                    noteList.Items.Add("*******************************************");
                for (int i = 0; i < datas.Count; i++)
                    {
                    noteList.Items.Add("");
                    noteList.Items.Add("-------------"+(i+1)+"-Kayıt Gösterildi.------------");
                        
                        double topla = 0;
                            for (int j = 0; j < datas[i].Count - 1; j++)
                            {                              
                                noteList.Items.Add("( İlgili eleman: " + Convert.ToDouble(datas[i][j]) + " ) x ( weight[j]: " + weight[j] + " ) = " + Convert.ToDouble(datas[i][j]) * weight[j]);                               
                                topla += Convert.ToDouble(datas[i][j]) * weight[j];
                            }
                            noteList.Items.Add("net =  ( topla = " + topla + " ) + ( eşikdeğeri: " + esikdegeri+" )");
                            net=topla+esikdegeri;
                            noteList.Items.Add("------------- Net = " + net+"------------");
                                if (net >= 0)
                                    valueTahmin = 1;
                                else
                                    valueTahmin = -1;

                                noteList.Items.Add("( Tahmin Edilen = " + valueTahmin + " ) =? ( Gerçekte Değeri=" + valueClass[i]+" )");

                                if (valueClass[i] == valueTahmin)
                                {
                                    countTrue++;
                                    noteList.Items.Add("");
                                    noteList.Items.Add("Tahmin Edilen = Gerçek Değeri -> Ağırlıklar Değiştirilmez!");
                                    String text = " Güncel Ağırlıklar ( ";
                                    for (int k = 0; k < weight.Count-1; k++) {
                                        text +="  "+weight[k];
                                    }
                                    text+=" )";
                                    noteList.Items.Add(text);
                                }
                                else
                                {
                                    countTrue = 0;
                                    error = valueClass[i] - valueTahmin;
                                    String text = "Güncel Ağırlıklar (";
                                    comboBoxWeight.Items.Add("------");
                                    for (int k = 0; k < weight.Count-1; k++) // ağırlık degerleri değiştirilir.
                                    {
                                        noteList.Items.Add("( ogrenmeKatsayisi * error * İlgili eleman ): ( " + ogrenmeKatsayisi + " ) * (" + error + " ) * ( " + Convert.ToDouble(datas[i][k]) + " ) =  " + ogrenmeKatsayisi * error * Convert.ToDouble(datas[i][k]));
                                        weight[k] += ogrenmeKatsayisi * error * Convert.ToDouble(datas[i][k]);
                                        text += "  " + weight[k];
                                        comboBoxWeight.Items.Add("" + weight[k]);
                                    }
                                    esikdegeri += ogrenmeKatsayisi * error;
                                    text += " )  ,Eşik değer:" + esikdegeri + " --> NET= " + net;
                                    noteList.Items.Add(text);

                                }
                       
                    }
                   
            }while(countTrue<datas.Count);
                textBoxWeight.Text = "[";
                for (int k = 0; k < weight.Count - 1; k++)               
                    textBoxWeight.Text += "    w"+(k+1)+": " + weight[k];
                
                textBoxWeight.Text += "  ]";
            }
        }

        private void buttonKotrol_Click(object sender, EventArgs e)
        {
            double valueTahmin= 0;
            double net = 0;
            if (textBoxWeight.Text != "" && textBoxSampleURL.Text!="")
            {
                double ogrenmeKatsayisi = Convert.ToDouble(textBoxOgrenmeKatsayısı.Text == "Default : 0.5" ? "0,5" : textBoxOgrenmeKatsayısı.Text);
                double esikdegeri = Convert.ToDouble(textBoxEsilDegeri.Text == "Default : 0.1" ? "0,1" : textBoxEsilDegeri.Text);

                for (int i = 0; i < datas.Count; i++)
                {
                  
                    double topla = 0;
                    for (int j = 0; j < datas[i].Count - 1; j++) 
                        topla += Convert.ToDouble(datas[i][j]) * weight[j];
                         net = topla + esikdegeri;         
                    if (net >= 0)
                        valueTahmin = 1;
                    else
                        valueTahmin = -1;

                    dataGridKontrol.Rows[i].Cells[dataGridKontrol.ColumnCount - 1].Value = valueTahmin;

                }
                int dogru=0;
                for (int i = 0; i < dataGridKontrol.Rows.Count; i++)
                    if (Convert.ToInt16(dataGridKontrol.Rows[i].Cells[dataGridKontrol.ColumnCount - 1].Value) == valueClass[i])
                    {
                        dogru++;
                        dataGridKontrol.Rows[i].Cells[dataGridKontrol.ColumnCount - 1].Style.BackColor = Color.LightGreen;
                    }else
                        dataGridKontrol.Rows[i].Cells[dataGridKontrol.ColumnCount - 1].Style.BackColor = Color.Red;
                labelAccuary.ForeColor = ((100 * (double)dogru / datas.Count()) > 75 ? Color.Green : Color.Red);
                labelAccuary.Text = "%" + (100*(double)dogru / datas.Count());   


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Width == 1021 && this.Height == 464)
            {
                this.Size = new Size(1684, 464);
                buttonOpenTestArea.Text = "<<";
            }
            else {
                this.Size = new Size(1021, 464);
                buttonOpenTestArea.Text = ">>";
            }
            this.Text = "";
            String text = "                ";
            String header = "Adaline-Artificial Neural Network";
            for (int i = 0; i < this.Width / header.Length; i++)
            {
                text += "    ";
            }
            this.Text = text + header;


        }

       

        
    }
}
