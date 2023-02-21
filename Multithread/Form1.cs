using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multithread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            //create folder browser dialog
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            //select folder and safe to lbFolderName
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                lbFolderName.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnStartThread_Click(object sender, EventArgs e)
        {
            //clear dataGridView1
            dataGridView1.Rows.Clear();
            //using class Searcher, method SearchString, filepath get from lbFolderName , searchstring get from tbSearchString
            string[,] results = new Searcher().SearchString(lbFolderName.Text, tbSearchString.Text);
            //set data to dataGridView1, first results[i, 0] to FileName column, second results[i, 1] to StringLine column, third results[i, 2] to StringText column
            for (int i = 0; i < results.GetLength(0); i++)
            {
                dataGridView1.Rows.Add(results[i, 0], results[i, 1], results[i, 2]);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //when press on button in dataGridView1, open file in FileName column
            if (e.ColumnIndex == 3)
            {
                System.Diagnostics.Process.Start(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }
    }
}
