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

        private FTDI myFtdiDevice = new FTDI();

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
            UInt32 ftdiDeviceCount = 0;
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

            // Determine the number of FTDI devices connected to the machine
            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
            // Check status
            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                // Allocate storage for device info list
                FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];

                // Populate our device list
                ftStatus = myFtdiDevice.GetDeviceList(ftdiDeviceList);
                if (ftStatus == FTDI.FT_STATUS.FT_OK)
                {
                    for (UInt32 i = 0; i < ftdiDeviceCount; i++)
                    {
                        if (ftdiDeviceList[i].Type == FTDI.FT_DEVICE.FT_DEVICE_2232 && ftdiDeviceList[i].Description.ToString() == "Re:inforce 4x Rev.1.0")
                        {
                            comboBox_Interfaces.Items.Add(ftdiDeviceList[i].SerialNumber.ToString());
                        }
                    }
                }

            }
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
