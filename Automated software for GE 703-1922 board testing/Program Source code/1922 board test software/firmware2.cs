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
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace _1922_board_test_software
{
    public partial class firmware2 : Form
    {
        string USER = LOGIN_LOGIC.sendtext;
        string SERIAL = serial_logic.sendserial;
        public firmware2()
        {
            InitializeComponent();
        }

        private void start_logic_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("hypertrm");
            foreach (var process1 in processes)
            {
                process1.Kill();
            }
            Thread.Sleep(200);
            functional_test_settings P = new functional_test_settings();
            this.Hide();
            P.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcessesByName("hypertrm");
            foreach (var process1 in processes)
            {
                process1.Kill();
            }
            Thread.Sleep(200);
            string A = "FAIL";
            string B = "_";
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"D:\1922\Test Reports\1922 test report template.xlsx");
            Excel.Worksheet xlWorkSheet = xlWorkbook.ActiveSheet;
            DateTime TO = DateTime.Now;
            String TODAY = Convert.ToString(TO);
            xlWorkSheet.Cells[4, 2] = USER;
            xlWorkSheet.Cells[3, 2] = SERIAL;
            xlWorkSheet.Cells[5, 2] = A;
            xlWorkSheet.Cells[4, 4] = TODAY;
            xlWorkSheet.Cells[7, 3] = "PASS";
            xlWorkSheet.Cells[8, 3] = "PASS";
            xlWorkSheet.Cells[9, 3] = "PASS";
            xlWorkSheet.Cells[10, 3] = "PASS";
            xlWorkSheet.Cells[11, 3] = "FAIL";
            xlWorkSheet.Cells[12, 3] = "____";
            xlWorkSheet.Cells[13, 3] = "____";
            xlWorkSheet.Cells[14, 3] = "____";
            xlWorkSheet.Cells[15, 3] = "____";
            xlWorkSheet.Cells[16, 3] = "____";
            xlWorkSheet.Cells[17, 3] = "____";
            xlWorkSheet.Cells[18, 3] = "____";
            xlWorkSheet.Cells[19, 3] = "____";
            xlWorkSheet.Cells[20, 3] = "____";
            xlWorkSheet.Cells[21, 3] = "____";
            xlWorkSheet.Cells[22, 3] = "____";
            Thread.Sleep(500);
            string filename = SERIAL + B + A + B + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            xlWorkbook.SaveAs(@"D:\1922\Test Reports\" + filename);
            Thread.Sleep(500);
            fail P = new fail();
            this.Hide();
            P.ShowDialog();
        }
    }
}
