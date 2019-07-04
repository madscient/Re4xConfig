using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FTD2XX_NET;

namespace Re4xConfig
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button_Reload_Click(object sender, EventArgs e)
        {

        }

        private void button_Apply_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBox_Interfaces.Items.Clear();
            comboBox_Interfaces.DataSource = Re4xProc.GetRe4xDeviceList();

            if (comboBox_Interfaces.Items.Count == 0)
            {
                MessageBox.Show("No interfaces found.");
                Close();
            }
            else
            {
                comboBox_Interfaces.SelectedIndex = 0;
            }
        }

        private void comboBox_Interfaces_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void comboBox_Slots_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
