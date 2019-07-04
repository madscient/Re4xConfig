using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FTD2XX_NET;

namespace Re4xConfig
{
    class Re4xProc
    {
        public class Re4xDevice
        {
            public string Description;
            public string SerialNumber;
            public uint LocId = 0;
            public Re4xDevice() { }
            public override string ToString()
            {
                return string.Format("{0}:{1}({2:X4})", Description, SerialNumber, LocId);
            }
            private FTDI theDevice = null;
            public bool Open()
            {
                FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
                if (theDevice != null)
                {
                    ftStatus = theDevice.Close();
                }
                if (LocId != 0 && ftStatus == FTDI.FT_STATUS.FT_OK)
                {
                    theDevice = new FTDI();
                    ftStatus = theDevice.OpenByLocation(LocId);
                    //set MCU Host Bus Emulation mode
                    if (ftStatus == FTDI.FT_STATUS.FT_OK)
                    {
                        ftStatus = theDevice.SetBitMode(0x00, 0x08);
                    }
                } else
                {
                    ftStatus = FTDI.FT_STATUS.FT_OTHER_ERROR;
                }
                return (ftStatus == FTDI.FT_STATUS.FT_OK);
            }
            public bool Close()
            {
                FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
                if (theDevice != null)
                {
                    ftStatus = theDevice.Close();
                }
                return (ftStatus == FTDI.FT_STATUS.FT_OK);
            }
            public Re4xEEPROM ReadEEPROM()
            {
                if (theDevice != null)
                {
                    Re4xEEPROM eeprom = new Re4xEEPROM();
                    ushort eevalh = 0;
                    ushort eevall = 0;
                    theDevice.ReadEEPROMLocation(0xc0, ref eevalh);
                    theDevice.ReadEEPROMLocation(0xc2, ref eevall);
                    eeprom.Version = (uint)(((int)eevalh << 16) | (int)eevall);
                    theDevice.ReadEEPROMLocation(0xc4, ref eevalh);
                    theDevice.ReadEEPROMLocation(0xc6, ref eevall);
                    eeprom.Slots = (uint)(((int)eevalh << 16) | (int)eevall);
                    for (uint i=0; i<4; i++)
                    {
                        eeprom.SlotInfo[i] = new Re4xSlotInfo();
                        theDevice.ReadEEPROMLocation(0xc8 + (i * 12), ref eevalh);
                        theDevice.ReadEEPROMLocation(0xca + (i * 12), ref eevall);
                        eeprom.SlotInfo[i].ModuleId = (Re4xModules)((uint)(((int)eevalh << 16) | (int)eevall));
                        theDevice.ReadEEPROMLocation(0xcc + (i * 12), ref eevalh);
                        theDevice.ReadEEPROMLocation(0xce + (i * 12), ref eevall);
                        eeprom.SlotInfo[i].Clock = (uint)(((int)eevalh << 16) | (int)eevall);
                        theDevice.ReadEEPROMLocation(0xd0 + (i * 12), ref eevalh);
                        theDevice.ReadEEPROMLocation(0xd2 + (i * 12), ref eevall);
                        eeprom.SlotInfo[i].Location = (uint)(((int)eevalh << 16) | (int)eevall);
                    }
                    return eeprom;
                }
                return null;
            }
        };
        public enum Re4xModules
        {
            NONE = 0x00,
            YM2149 = 0x2149,
            YM2151 = 0x2151,
            YM2163 = 0x2163,
            YM2164 = 0x2164,
            YM2203 = 0x2203,
            YM2413 = 0x2413,
            YM2420 = 0x2420,
            YM2423 = 0x2423,
            YM2414 = 0x2414,
            YM2602 = 0x2602,
            YM2608 = 0x2608,
            YM2610 = 0x2610,
            YM2610B = 0x2610b,
            YM2612 = 0x2612,
            YM3438 = 0x3438,
            YM3526 = 0x3526,
            YM3801 = 0x3801,
            YM3812 = 0x3812,
            YM7116 = 0x7116,
            YM7129 = 0x7129,
            YMF262 = 0xf262,
            YMF264 = 0xf264,
            YMF278 = 0xf278,
            YMF276 = 0xf276,
            YMF281 = 0xf281,
            YMF288 = 0xf288,
            YMZ294 = 0xf294,
            SN76489 = 0x76489,
            SN76496 = 0x76496,
            SAA1099 = 0x1099,
            AY8910 = 0x8910,
            AY8912 = 0x8912,
            AY8913 = 0x8913,
            AY8930 = 0x8930,
            SCC = 0x2212,
            SCCS = 0x2312,
        };
        public class Re4xSlotInfo
        {
            public Re4xModules ModuleId;
            public uint Clock;
            public uint Location;
        };
        public class Re4xEEPROM
        {
            public uint Version;
            public uint Slots;
            public Re4xSlotInfo[] SlotInfo = new Re4xSlotInfo[4];
        };
        public static List<Re4xDevice> GetRe4xDeviceList()
        {
            UInt32 ftdiDeviceCount = 0;
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

            FTDI myFtdiDevice = new FTDI();
            // Determine the number of FTDI devices connected to the machine
            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
            // Check status
            if (ftStatus == FTDI.FT_STATUS.FT_OK)
            {
                // Allocate storage for device info list
                FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];
                List<Re4xDevice> ftdevlist = new List<Re4xDevice>();
                // Populate our device list
                ftStatus = myFtdiDevice.GetDeviceList(ftdiDeviceList);
                if (ftStatus == FTDI.FT_STATUS.FT_OK)
                {
                    for (UInt32 i = 0; i < ftdiDeviceCount; i++)
                    {
                        if (ftdiDeviceList[i].Type == FTDI.FT_DEVICE.FT_DEVICE_2232 &&
                            ftdiDeviceList[i].Description.ToString().StartsWith("Re:inforce 4x") && ftdiDeviceList[i].Description.ToString().EndsWith("A"))
                        {
                            Re4xDevice ftdev = new Re4xDevice()
                            {
                                Description = ftdiDeviceList[i].Description.ToString().TrimEnd('A'),
                                SerialNumber = ftdiDeviceList[i].SerialNumber.ToString().TrimEnd('A'),
                                LocId = ftdiDeviceList[i].LocId,
                            };
                            ftdevlist.Add(ftdev);
                        }
                    }
                }
                return ftdevlist;
            }
            return null;
        }
    }
}
