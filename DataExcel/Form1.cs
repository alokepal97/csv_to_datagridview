using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DataExcel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog opn = new OpenFileDialog();

                if (opn.ShowDialog() == DialogResult.OK)
                {
                    List<object> listA = new List<object>();

                    using (StreamReader reader = new StreamReader(opn.FileName))
                    {
                        string line = string.Empty;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.Contains("0,0,0,0,0,0,0"))
                            {
                                continue;
                            }
                            else
                            {
                                List<string> lst = SplitList(line);
                                listA.Add(lst);

                                DataTable dt = new DataTable();

                               
                                try
                                {
                                    dataGridView.Rows.Add(lst[0], lst[1], lst[2], lst[3], lst[4], lst[5], lst[6], lst[7], lst[8], lst[9], lst[10]);
                                }
                                catch (Exception t)
                                {
                                    MessageBox.Show("" + t);
                                    exit();
                                }
                            }
                        }
                    }
                    //was being used for testing purposes. List show all data. - breakpoint here to confirm.
                    Console.WriteLine(listA);
                }
                txtFilePath.Text = openFileDialog1.FileName;
            } 
            catch(Exception g)
            {
                MessageBox.Show(""+g);
            }
        }

        private void exit()
        {
            throw new NotImplementedException();
        }

        private static List<string> SplitList(string line)
        {
            List<string> result = new List<string>();
            string[] splitRow = line.Split(",".ToCharArray());
            result = splitRow.ToList<string>();
            return result;
        }
    }
}
