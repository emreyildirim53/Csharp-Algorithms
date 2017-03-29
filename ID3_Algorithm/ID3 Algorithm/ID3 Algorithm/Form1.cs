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

namespace ID3_Algorithm
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
        Hashtable attributes= new Hashtable();
        int countAttribute=0;
        private void buttonOpen_Click(object sender, EventArgs e)
        {
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
                // başka bir dosya okursa hashi temizlesin diye
                attributes = new Hashtable();
                listBox1.Items.Clear();
                listBox1.Items.Add("-----------------------------------------------------------------------");
                listBox1.Items.Add("--------------------------ENTROPİLER-----------------------------------");
                listBox1.Items.Add("-----------------------------------------------------------------------");
                /*
                    Excell tablosundan değerler sütun bazında çekildi
                 */
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
            }
        }
        TreeNode root = null;
        TreeNode rootonceki = null;
        int tempkey = 0;
        private void model_Click(object sender, EventArgs e)
        {
           if(attributes.Count>1) {
                Hashtable gain = new Hashtable();
                foreach (int key in attributes.Keys)
                {
                    if (key != countAttribute)
                    {
                        gain.Add(key, sinifOzellikEntropisi(((List<string>)attributes[key]), ((List<string>)attributes[countAttribute])));
                        listBox1.Items.Add(gain[key]);
                    }
                }
                double tempGain = 0;
                int tempAttr = 0;
                foreach (int key in gain.Keys)
                {
                    if ((double)gain[key] > tempGain)
                    {
                        tempGain = (double)gain[key];
                        tempAttr = key;
                    }
                }             
                Hashtable parent = countUniq((List<string>)attributes[tempAttr]);
                List<string> faydaAttr = (List<string>)attributes[tempAttr];
                List<string> sinif = (List<string>)attributes[countAttribute];       
                Hashtable ozellikdal = new Hashtable();
                foreach (DictionaryEntry dictionaryEntry in parent)
                {                   
                    Hashtable dal = new Hashtable();
                    for (int i = 0; i < faydaAttr.Count; i++)
                    {
                        if (faydaAttr[i] == dictionaryEntry.Key.ToString())
                        {
                            if (!dal.ContainsKey(sinif[i]))
                                dal.Add(sinif[i], 1);
                            else if (dal.ContainsKey(sinif[i]))
                                dal[sinif[i]] = (Convert.ToInt16(dal[sinif[i]]) + 1);
                        }
                    }
                    ozellikdal.Add(dictionaryEntry.Key, dal);
                }           
                List<TreeNode> childs = new List<TreeNode>();           
                foreach (string key in parent.Keys)
                {
                    tempkey++;
                     Hashtable dal = (Hashtable)ozellikdal[key];
                     TreeNode ekle = new TreeNode("if (" + dataView.Columns[tempAttr].HeaderText + " )=> '" + key.ToString() + "'");
                     if (root == null)
                         treeView1.Nodes.Add(ekle);
                     else                     
                         if (rootonceki == null)                        
                             childEkle(root, ekle);                                           
                         else if (root != rootonceki)                        
                             childEkle(rootonceki, ekle);
      
                    foreach (DictionaryEntry dictionaryEntry in dal)
                    {
                        TreeNode child = new TreeNode(dictionaryEntry.Key.ToString());
                        childs.Add(child);
                    }
                    if (childs.Count == 1)
                    {
                        for (int i = 0; i < childs.Count; i++)
                            childEkle(ekle, (TreeNode)childs[i]);                                 
                        deleteData(faydaAttr,sinif,key,childs[0].ToString(),attributes);
                      
                    } else {                          
                            rootonceki = root;
                            root = ekle;                                                            
                    }
                    childs.Clear();
                    if (tempkey == parent.Count)
                    {
                        rootonceki = null;
                        tempkey = 0;
                       
                    }                  
                }              
                listBox1.Items.Add("En Faydalı --" + dataView.Columns[tempAttr].HeaderText.ToUpperInvariant()+"--");
                listBox1.Items.Add("");
                attributes.Remove(tempAttr);
                columnCount--;
                treeView1.ExpandAll();
                model.PerformClick();
            }
        }
        static void childEkle(TreeNode parent,TreeNode value) {
            parent.Nodes.Add(value);
        }    
        public void deleteData(List<string> faydaAttr,List<string> sinif,string faydaData,string sinifData,Hashtable attributes) {
            String[] sinifAdi = sinifData.ToString().Split(' ');
            int silinecekIndis = -1;
            for (int j = 0; j <=countAttribute;j++)
            {
                if (attributes.ContainsKey(j))
                {
                    List<string> sutunlar = (List<string>)attributes[j];
                    for (int i = 0; i < sutunlar.Count; i++)                                    
                        if (faydaData == sutunlar[i])                    
                            silinecekIndis = i-1;                                                    
                }
            }
            for (int j = 0; j <= countAttribute; j++)
            {
                if (attributes.ContainsKey(j))
                {
                    List<string> sutunlar = (List<string>)attributes[j];
                    for (int i = 0; i < sutunlar.Count; i++)
                    {
                        if ( i == silinecekIndis)
                        {                 
                            sutunlar.RemoveAt(i);
                            i--;
                        }
                    }
                    attributes[j] = sutunlar;
                }
            }
        }
        public double sinifEntropi(Hashtable sinif, int count)
        {
            double result = 0;
            foreach (string key in sinif.Keys)
                result += Convert.ToDouble(sinif[key]) / count * Math.Log((Convert.ToDouble(sinif[key])) / count, 2);
            return result * -1;
        }
        public double ozellikEntropisi(Hashtable unqOzellik,Hashtable unqSinif,List<string> ozellik, List<string> sinif)
        { 
            Hashtable ozellikdal = new Hashtable();
            foreach (DictionaryEntry dictionaryEntry in unqOzellik)
            {
                Hashtable dal = new Hashtable();
                for (int i = 0; i < sinif.Count; i++) {
                    if (ozellik[i] == dictionaryEntry.Key.ToString())
                    {
                        if (!dal.ContainsKey(sinif[i]))
                            dal.Add(sinif[i], 1);
                        else if (dal.ContainsKey(sinif[i]))
                            dal[sinif[i]] = (Convert.ToInt16(dal[sinif[i]]) + 1);                              
                    }
                }
                ozellikdal.Add(dictionaryEntry.Key, dal);
            }                
            double h = 0,htemp=0;
            foreach (string key in unqOzellik.Keys) {             
                    Hashtable dal = (Hashtable)ozellikdal[key];
                    foreach (string key3 in dal.Keys) {
                        htemp += ((Convert.ToDouble(dal[key3]) / Convert.ToDouble(unqOzellik[key]))) * Math.Log((Convert.ToDouble(dal[key3]) / Convert.ToDouble(unqOzellik[key])),2);                  
                    }               
                    h += Convert.ToDouble(unqOzellik[key]) / ozellik.Count * -1*(htemp);
                    htemp = 0;
            }      
            return h;
        }
        public double sinifOzellikEntropisi(List<string> ozellik, List<string> sinif) {
            Hashtable unqSinif = countUniq(sinif);         
            double sinifentropi = sinifEntropi(unqSinif,(((List<string>) attributes[countAttribute]).Count));         
            Hashtable unqOzellik = countUniq(ozellik);    
            return sinifentropi - ozellikEntropisi(unqOzellik, unqSinif, ozellik, sinif);
        }
        public Hashtable countUniq(List<string> sinifList)
        {
            Hashtable countSinif = new Hashtable();
            for (int i = 0; i < sinifList.Count; i++) {              
                if (countSinif.ContainsKey(sinifList[i]))
                    countSinif[sinifList[i]] = (Convert.ToInt16(countSinif[sinifList[i]]) + 1);
                if (!countSinif.Contains(sinifList[i]))
                    countSinif.Add(sinifList[i], 1);
            }
            return countSinif;
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
    }     
 }

