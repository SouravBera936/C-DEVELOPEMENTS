﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace _1922_board_test_software
{
    public partial class pass : Form
    {
        String USER = LOGIN_LOGIC.sendtext;
        string SERIAL = serial_logic.sendserial;
        public pass()
        {
            InitializeComponent();
        }

        private void PASS_logic_Click(object sender, EventArgs e)
        {
            string A = "PASS";
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
            xlWorkSheet.Cells[11, 3] = "PASS";
            xlWorkSheet.Cells[12, 3] = "PASS";
            xlWorkSheet.Cells[13, 3] = "PASS";
            xlWorkSheet.Cells[14, 3] = "PASS";
            xlWorkSheet.Cells[15, 3] = "PASS";
            xlWorkSheet.Cells[16, 3] = "PASS";
            xlWorkSheet.Cells[17, 3] = "PASS";
            xlWorkSheet.Cells[18, 3] = "PASS";
            xlWorkSheet.Cells[19, 3] = "PASS";
            xlWorkSheet.Cells[20, 3] = "PASS";
            xlWorkSheet.Cells[21, 3] = "PASS";
            xlWorkSheet.Cells[22, 3] = "PASS";
            Thread.Sleep(500);
            string filename = SERIAL + B + A + B + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".xlsx";
            xlWorkbook.SaveAs(@"D:\1922\Test Reports\" + filename);
            Thread.Sleep(500);
            serial_logic P = new serial_logic();
            this.Hide();
            P.ShowDialog();
        }
    }
}
