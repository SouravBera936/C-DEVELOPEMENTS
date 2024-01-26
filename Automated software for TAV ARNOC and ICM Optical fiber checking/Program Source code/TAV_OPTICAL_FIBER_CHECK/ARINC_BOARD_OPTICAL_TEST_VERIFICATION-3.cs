﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;

namespace TAV_OPTICAL_FIBER_CHECK
{
    public partial class ARINC_BOARD_OPTICAL_TEST_VERIFICATION_3 : Form
    {
        string SERIAL1 = ARINC_OPTICAL_CABLE_TEST.send_serial;
        //string folder_name = ARINC_OPTICAL_CABLE_TEST.send_folder_name;
        string USER = ARINC_OPTICAL_CABLE_TEST.send_operator_name;

        public ARINC_BOARD_OPTICAL_TEST_VERIFICATION_3()
        {
            InitializeComponent();
        }

        public static string send_report3 = "";

        private void SUBMIT_Click(object sender, EventArgs e)
        {
            Select_report.Enabled = false;
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(LOG_PATH.Text))

            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }
                //TrimEnd(text, 'F');
                //MessageBox.Show(text.ToString());


            }

            send_report3 = LOG_PATH.Text;

            //richTextBox1.Text = text.ToString();
            if (text.ToString().Contains("Fail"))
            {
                MessageBox.Show("3rd Optical fiber check Failed");
                string STATUS = "3rd Optical fiber check Failed";
                string RESULT = "FAIL";
                // string folder_name = SERIAL1 + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss");
                string A = "_";
                string filename = SERIAL1 + A + RESULT + A+  DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".txt";
                System.IO.StreamWriter swExtLogFile = new System.IO.StreamWriter(@"D:\Resources\Report\arinc optical cable test\" + "\\" + filename, true);
                DataTable dt = new DataTable();
                //Adding data To DataTable
                dt.Columns.Add("ID");
                dt.Columns.Add("Name");
                dt.Columns.Add("STATS");
                dt.Columns.Add("RESULT");
                dt.Rows.Add(1, "USERNAME", USER);
                dt.Rows.Add(2, "SERIAL NUMBER", SERIAL1);
                dt.Rows.Add(3, "STATUS)", STATUS);
                dt.Rows.Add(3, "RESULT", RESULT);

                int i;
                swExtLogFile.Write(Environment.NewLine);
                foreach (DataRow row in dt.Rows)
                {
                    object[] array = row.ItemArray;
                    for (i = 0; i < array.Length - 1; i++)
                    {
                        swExtLogFile.Write(array[i].ToString() + " -------");
                    }
                    swExtLogFile.WriteLine(array[i].ToString());
                }
                swExtLogFile.Write("*****END OF DATA****" + DateTime.Now.ToString());

                swExtLogFile.Flush();
                swExtLogFile.Close();
                 Process[] processes = Process.GetProcessesByName("FiberChekPro");
                 foreach (var process1 in processes)
                 {
                  process1.Kill();
                 }
                Thread.Sleep(200);
                ARINC_OPTICAL_CABLE_TEST main = new ARINC_OPTICAL_CABLE_TEST();
                this.Hide();
                main.ShowDialog();

            }
            else
            {
                MessageBox.Show("3rd Optical fiber check Passed");
                MessageBox.Show("Connect 4th Optical Cable");
                ARINC_BOARD_OPTICAL_TEST_VERIFICATION_4 main = new ARINC_BOARD_OPTICAL_TEST_VERIFICATION_4();
                this.Hide();
                main.ShowDialog();

            }
            
        }

        private void start_logic_Click(object sender, EventArgs e)
        {
            Select_report.Enabled = true;
            NOT_OK.Enabled = false;
        }

        private void NOT_OK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("3rd Optical fiber check Failed");
            string STATUS = "3rd Optical fiber check Failed";
            string RESULT = "FAIL";
            // string folder_name = SERIAL1 + "_" + DateTime.Now.ToString("ddMMyyyy_hhmmss");
            string A = "_";
            string filename = SERIAL1 + A + RESULT + A+  DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".txt";
            System.IO.StreamWriter swExtLogFile = new System.IO.StreamWriter(@"D:\Resources\Report\arinc optical cable test\" + "\\" + filename, true);
            DataTable dt = new DataTable();
            //Adding data To DataTable
            dt.Columns.Add("ID");
            dt.Columns.Add("Name");
            dt.Columns.Add("STATS");
            dt.Columns.Add("RESULT");
            dt.Rows.Add(1, "USERNAME", USER);
            dt.Rows.Add(2, "SERIAL NUMBER", SERIAL1);
            dt.Rows.Add(3, "STATUS)", STATUS);
            dt.Rows.Add(3, "RESULT", RESULT);

            int i;
            swExtLogFile.Write(Environment.NewLine);
            foreach (DataRow row in dt.Rows)
            {
                object[] array = row.ItemArray;
                for (i = 0; i < array.Length - 1; i++)
                {
                    swExtLogFile.Write(array[i].ToString() + " -------");
                }
                swExtLogFile.WriteLine(array[i].ToString());
            }
            swExtLogFile.Write("*****END OF DATA****" + DateTime.Now.ToString());

            swExtLogFile.Flush();
            swExtLogFile.Close();
            Thread.Sleep(200);
            ARINC_OPTICAL_CABLE_TEST main = new ARINC_OPTICAL_CABLE_TEST();
            this.Hide();
            main.ShowDialog();
        }

        private void Select_report_Click(object sender, EventArgs e)
        {
            start_logic.Enabled = false;
            OpenFileDialog folderDlg = new OpenFileDialog();

            // folderDlg.ShowNewFolderButton = true;

            // Show the FolderBrowserDialog.

            DialogResult result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)

            {

                LOG_PATH.Text = folderDlg.FileName;

                // Environment.SpecialFolder root = folderDlg.RootFolder;


            }

            SUBMIT.Enabled = true;
        }
    }
}
