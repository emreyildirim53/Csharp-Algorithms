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

namespace Naive_Bayes_Classification
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
        int countAttribute = 0;
        private void buttonOpen_Click(object sender, EventArgs e)
        {

            this.Width = 595;
            attributes.Clear();
            keyAndUniq.Clear();
            infoDataList.Items.Clear();
            countDataList.Items.Clear();
            combos.Clear();
            inputs.Clear();
            model.Enabled = true;       
            DialogResult result = openFileDialog1.ShowDialog();
            ExcelUygulama = new Excel.Application();
            if (openFileDialog1.FileName != "openFileDialog1")
            {
                ExcelProje = ExcelUygulama.Workbooks.Open(openFileDialog1.FileName);
                ExcelSayfa = (Excel.Worksheet)ExcelProje.Worksheets.get_Item(1);
                ExcelRange = ExcelSayfa.UsedRange;
                ExcelSayfa = (Excel.Worksheet)ExcelUygulama.ActiveSheet;
                ExcelUygulama.Visible = false;
                ExcelUygulama.AlertBeforeOverwriting = false;
                dosyaYolu.Text = openFileDialog1.FileName + " adlı dosya yüklendi.";
                dosyaYolu.Enabled = false;
                rowCount = ExcelRange.Rows.Count + 1;
                columnCount = ExcelRange.Columns.Count + 1;

                String sdbconnection = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + openFileDialog1.FileName + "; Extended Properties='Excel 12.0; TypeGuessRows=0; HDR=YES; IMEX=1'";
                OleDbConnection dbconnection = new OleDbConnection(sdbconnection);
                dbconnection.Open();
                OleDbDataAdapter dbadapter = new OleDbDataAdapter("Select * from [Sayfa1$]", dbconnection);
                DataTable dtable = new DataTable();
                dbadapter.Fill(dtable);
                dataView.DataSource = dtable;
                
                for (int i = 1; i < columnCount; i++)
                {
                    List<string> attribute = new List<string>();
                    for (int j = 2; j < rowCount; j++)
                    {
                        object hucre = ExcelSayfa.Cells[j, i];
                        Excel.Range bolge = ExcelSayfa.get_Range(hucre, hucre);
                        if (bolge.Value2 != null)
                            attribute.Add(bolge.Value2.ToString());
                    }
                    if (!attributes.ContainsKey(i - 1))
                        attributes.Add(i - 1, attribute);
                }
                countAttribute = attributes.Count - 1;
                create();
                doldur();
            }
        }
         List<ComboBox> combos=new List<ComboBox>();
        private void create() {
            groupBox1.Controls.Clear();
            int x = 60; int y = -10; int ls = 1; int lx = 0;
            for (int i = 0; i < dataView.Columns.Count-1; i++)
            {
                if (i % 2 == 0 || i == 0)
                {
                    y += 30;
                    x = 60;
                    lx = x;                           
                } else {              
                    x = 270;
                    lx = x;                             
                }
                Label lbl = new Label();
                Point lblyer = new Point(lx - 50, y + 5);
                lbl.Location = lblyer;
                lbl.Width = 80;
                lbl.Text = dataView.Columns[i].Name.ToString() + " : ";
                lbl.Name = "lbl" + dataView.Columns[i].Name.ToString();
                ls++;
                groupBox1.Controls.Add(lbl);
                lx += 20;
                ComboBox cmb = new ComboBox();
                Point yer = new Point(x + 40, y);
                cmb.Name = "cmb" + dataView.Columns[i].Name.ToString();
                cmb.Location = yer;
                cmb.Width = 100; cmb.Height = 25;
                this.Controls.Add(cmb);
                groupBox1.Controls.Add(cmb);
                x += 60;             
                combos.Add(cmb);
            }
        }
        private void doldur()
        {
            dataView.Refresh();
            for (int i = 0; i < combos.Count; i++)         
                    combos[i].Items.Clear();          
            foreach (DataGridViewRow row in dataView.Rows) { 
               for(int i=0;i<combos.Count;i++){
                   if (!combos[i].Items.Contains(row.Cells[i].Value.ToString()))
                    combos[i].Items.Add(row.Cells[i].Value.ToString());
               }
            }           
        }   
        int countTotalData;
        Hashtable keyAndUniq = new Hashtable();
        List<string> inputs = new List<string>();     
        private void model_Click(object sender, EventArgs e)
        {        
            countDataList.Items.Clear();
            infoDataList.Items.Clear();
            inputs.Clear();
            for (int i = 0; i < combos.Count; i++)
            {
                if (combos[i].Text != "")
                    inputs.Add(combos[i].SelectedItem.ToString());
                else
                {
                    MessageBox.Show("Girdilerden bir veya bir kaçını seçilmedi.");
                    return;
                }
            }
            this.Width = 1105;
            if (dosyaYolu.Text != "")
            {
                foreach (int key in attributes.Keys)
                {
                    List<string> attribute = (List<string>)attributes[key];
                    Hashtable uniq = countUniq(attribute);
                    keyAndUniq.Add(key, uniq);//----->> yani (key=1,value={[key=memelideğil,value=13],[key=memeli,value=7]})
                    countDataList.Items.Add(dataView.Columns[key].Name.ToUpper());
                    countDataList.Items.Add("---------------------------------------");
                    foreach (string key2 in uniq.Keys)
                    {
                        int uniqCount = (int)uniq[key2];
                        countDataList.Items.Add(key2 + " = " + uniqCount.ToString());
                    }
                    countDataList.Items.Add("---------------------------------------");
                    countDataList.Items.Add("");
                    countTotalData = attribute.Count;
                }
                infoDataList.Items.Add("Toplam: " + countTotalData + " kayıt var.");
                infoDataList.Items.Add("----------------------------------------------------------------------------------------------------------------------------------------------------");
                List<double> classPro = classProbability(keyAndUniq);
                List<string> classValues = (List<string>)attributes[attributes.Count - 1];
                attributesProbability(classPro,classValues);
            }
            else  MessageBox.Show("Model Kurmadan Önce Veri Setini Seçiniz.");
            keyAndUniq.Clear();
        }
        public void attributesProbability(List<double> classPro,List<string> classValues) {
            
            double tempProduct=0;
            string tempClass="";
            int say = 0;
            Hashtable classAttributes = (Hashtable)countUniq((List<string>)attributes[attributes.Count - 1]);
            foreach (string key in classAttributes.Keys)
            {
                infoDataList.Items.Add("P( " + dataView.Columns[dataView.Columns.Count - 1].Name + " = \"" + key + "\" ) =" + (Convert.ToDouble(classAttributes[key]) / countTotalData));
                infoDataList.Items.Add("");
                double product=1;
                for(int k=0;k<attributes.Count-1;k++){
                    List<string> attribute = (List<string>)attributes[k];
                    for (int i = 0; i < attribute.Count; i++)
                     if (inputs[k] == attribute[i] && key==classValues[i]) 
                            say++;                                   
                    product *= (say / Convert.ToDouble(classAttributes[key]));
                    infoDataList.Items.Add("P( " + dataView.Columns[k].Name + " = \"" + inputs[k] + "\" | " + dataView.Columns[dataView.Columns.Count - 1].Name + " \" "+key+" \") =" + say + " / " + classAttributes[key] + " = " + (say / Convert.ToDouble(classAttributes[key])));
                    say = 0;
                }
                infoDataList.Items.Add("");
                infoDataList.Items.Add("Çarpımları ="+product);
                if (tempProduct < product)
                {
                    tempProduct = product;
                    tempClass = key;    
                }


                infoDataList.Items.Add("");
                infoDataList.Items.Add("P( X | " + dataView.Columns[dataView.Columns.Count - 1].Name + "= \"" + key + "\" ) * P( " + dataView.Columns[dataView.Columns.Count - 1].Name + "= \"" + key + "\" ) = " + product * (Convert.ToDouble(classAttributes[key]) / countTotalData));
                product = 1;
                infoDataList.Items.Add("----------------------------------------------------------------------------------------------------------------------------------------------------");
                infoDataList.Items.Add("X 'in Sınıfı => \"" + dataView.Columns[dataView.Columns.Count - 1].Name+"= "+tempClass+"\"");
            }
        }
        public List<double> classProbability(Hashtable keyAndUniq)
        {
            List<double> classPro = new List<double>();
            foreach(int key in keyAndUniq.Keys){
                Hashtable classes = (Hashtable)keyAndUniq[key];
                foreach (string key2 in classes.Keys) {
                    classPro.Add((Convert.ToDouble(classes[key2]) / countTotalData));                  
                }             
            }
            return classPro;
        }

        //Sınıfların uniq değerleri ve sayısı bulundu
        public Hashtable countUniq(List<string> sinifList)
        {
            Hashtable countSinif = new Hashtable();
            for (int i = 0; i < sinifList.Count; i++)
            {
                if (countSinif.ContainsKey(sinifList[i]))
                    countSinif[sinifList[i]] = (Convert.ToInt16(countSinif[sinifList[i]]) + 1);
                if (!countSinif.Contains(sinifList[i]))
                    countSinif.Add(sinifList[i], 1);
            }
            return countSinif;
        }

        // Görev yönetici uygulamayı (Exell) kill etmek için 
      
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
            if (dosyaYolu.Text != "")
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
        }

       

          
    }
}
