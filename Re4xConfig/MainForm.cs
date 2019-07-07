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
        private Re4xProc.Re4xDevice theDevice = null;
        private Re4xProc.Re4xEEPROM theEeprom = null;

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
            foreach(ModulesCombo mc in modulesCombo)
            {
                mc.chip.DataSource = Enum.GetNames(typeof(Re4xProc.Re4xModules));
                mc.location.DataSource = Enum.GetNames(typeof(Re4xProc.Re4xLocation));
            }
        }

        private void button_Reload_Click(object sender, EventArgs e)
        {
            if (theDevice != null)
            {
                theDevice.Close();
                theDevice = null;
            }
            if (theEeprom != null)
            {
                theEeprom = null;
            }
            comboBox_Interfaces.DataSource = null;
            comboBox_Interfaces.Items.Clear();
            MainForm_Load(sender, e);
        }

        private void button_Apply_Click(object sender, EventArgs e)
        {
            if (theDevice != null && theEeprom != null)
            {
                theEeprom.Version = 0x00010000;
                uint.TryParse(comboBox_Slots.SelectedItem.ToString(), out theEeprom.Slots);
                for (int i=0; i<4; i++)
                {
                    Enum.TryParse<Re4xProc.Re4xModules>(modulesCombo[i].chip.SelectedItem.ToString(), out theEeprom.SlotInfo[i].ModuleId);
                    string strclock = (modulesCombo[i].clock.SelectedItem != null) ? modulesCombo[i].clock.SelectedItem.ToString() : modulesCombo[i].clock.Text;
                    uint.TryParse(strclock, out theEeprom.SlotInfo[i].Clock);
                    Enum.TryParse<Re4xProc.Re4xLocation>(modulesCombo[i].location.SelectedItem.ToString(), out theEeprom.SlotInfo[i].Location);
                }
                theDevice.WriteEEPROM(theEeprom);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            comboBox_Interfaces.DataSource = Re4xProc.GetRe4xDeviceList();

            if (comboBox_Interfaces.Items.Count == 0)
            {
                MessageBox.Show("No interfaces found.");
                Close();
            }
            else
            {
                comboBox_Interfaces.SelectedIndex = 0;
                comboBox_Interfaces_SelectionChangeCommitted(sender, e);
            }
        }

        private void comboBox_Interfaces_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_Interfaces.Items.Count != 0)
            {
                if (theDevice != null)
                {
                    theDevice.Close();
                }
                theDevice = comboBox_Interfaces.SelectedItem as Re4xProc.Re4xDevice;
                if (theDevice != null)
                {
                    theDevice.Open();
                    theEeprom = theDevice.ReadEEPROM();
                    RefreshEnable();
                }
            }
        }

        private void RefreshEnable()
        {
            comboBox_Slots.Enabled = (theDevice != null);
            if (theEeprom != null)
            {
                comboBox_Slots.SelectedIndex = comboBox_Slots.Items.IndexOf(theEeprom.Slots.ToString());
            }
            if (comboBox_Slots.SelectedIndex < 0)
            {
                comboBox_Slots.SelectedIndex = 0;
            }
            comboBox_Slots_SelectionChangeCommitted(null, null);
        }

        private void comboBox_Slots_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int numslots = (comboBox_Slots.SelectedIndex >= 0) ? int.Parse(comboBox_Slots.SelectedItem.ToString()) : 0;
            for (int i = 0; i < 4; i++)
            {
                modulesCombo[i].chip.Enabled = modulesCombo[i].clock.Enabled = modulesCombo[i].location.Enabled = i < numslots;
                if (theEeprom != null)
                {
                    modulesCombo[i].chip.SelectedIndex = Array.IndexOf(Enum.GetValues(typeof(Re4xProc.Re4xModules)), theEeprom.SlotInfo[i].ModuleId);
                    modulesCombo[i].clock.SelectedItem = theEeprom.SlotInfo[i].Clock.ToString();
                    modulesCombo[i].location.SelectedIndex = Array.IndexOf(Enum.GetValues(typeof(Re4xProc.Re4xLocation)), theEeprom.SlotInfo[i].Location);
                }
            }
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
