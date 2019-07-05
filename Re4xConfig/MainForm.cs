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
        private struct ModulesCombo
        {
            public ComboBox chip;
            public ComboBox clock;
            public ComboBox location;
        }
        private ModulesCombo[] modulesCombo = new ModulesCombo[4];
        public MainForm()
        {
            InitializeComponent();
            modulesCombo[0] = new ModulesCombo()
            {
                chip = comboBox_module0,
                clock = comboBox_clock0,
                location = comboBox_location0,
            };
            modulesCombo[1] = new ModulesCombo()
            {
                chip = comboBox_module1,
                clock = comboBox_clock1,
                location = comboBox_location1,
            };
            modulesCombo[2] = new ModulesCombo()
            {
                chip = comboBox_module2,
                clock = comboBox_clock2,
                location = comboBox_location2,
            };
            modulesCombo[3] = new ModulesCombo()
            {
                chip = comboBox_module3,
                clock = comboBox_clock3,
                location = comboBox_location3,
            };
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
            if (comboBox_Interfaces.Items.Count == 0)
            {
                Re4xProc.Re4xDevice dev = comboBox_Interfaces.SelectedItem as Re4xProc.Re4xDevice;
                if (dev != null)
                {
                    Re4xProc.Re4xEEPROM eeprom = dev.ReadEEPROM();
                    if (eeprom != null)
                    {
                        if (eeprom.Slots == 1 || eeprom.Slots == 4)
                        {
                            comboBox_Slots.SelectedItem = eeprom.Slots.ToString();
                        } else
                        {
                            comboBox_Slots.SelectedIndex = 0;   //default selection
                        }
                    }
                }
            }

        }

        private void comboBox_Slots_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
