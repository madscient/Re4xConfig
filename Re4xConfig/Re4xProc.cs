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
                    eeprom.Version = ReadEEPROMLong(theDevice, 0xc0);
                    eeprom.Slots = ReadEEPROMLong(theDevice, 0xc4);
                    for (uint i=0; i<4; i++)
                    {
                        uint offset = i * 12;
                        eeprom.SlotInfo[i] = new Re4xSlotInfo();
                        eeprom.SlotInfo[i].ModuleId = (Re4xModules)ReadEEPROMLong(theDevice, 0xc8 + offset);
                        eeprom.SlotInfo[i].Clock = ReadEEPROMLong(theDevice, 0xcc + offset);
                        eeprom.SlotInfo[i].Location = (Re4xLocation)ReadEEPROMLong(theDevice, 0xd0 + offset);
                    }
                    return eeprom;
                }
                return null;
            }
        };
        public enum Re4xModules
        {
            NONE = 0x00,
            YM2149 = 0x2149,    //SSG
            YM2151 = 0x2151,    //OPM
            YM2163 = 0x2163,    //DSG
            YM2164 = 0x2164,    //OPP
            YM2203 = 0x2203,    //OPN
            YM2413 = 0x2413,    //OPLL
            YM2420 = 0x2420,    //OPLL2
            YM2423 = 0x2423,    //OPLL-X
            YM2414 = 0x2414,    //OPZ
            YM2602 = 0x2602,    //315-5124
            YM2608 = 0x2608,    //OPNA
            YM2612 = 0x2612,    //OPN2
            YM3438 = 0x3438,    //OPN2C
            YM3526 = 0x3526,    //OPL
            YM3801 = 0x3801,    //Y8950
            YM3812 = 0x3812,    //OPL2
            YM7116 = 0x7116,    //OPK
            YM7129 = 0x7129,    //OPK2
            YMF262 = 0xf262,    //OPL3
            YMF264 = 0xf264,    //OPNC
            YMF276 = 0xf276,    //OPN2L
            YMF281 = 0xf281,    //OPLLP
            YMF288 = 0xf288,    //OPN3L
            YMZ294 = 0xf294,    //SSGLP
            YMF709 = 0xf709,    //OPOS
            SN76489 = 0x76489,  //DCSG
            SN76496 = 0x76496,  //DCSG
            SAA1099 = 0x1099,   //SAA
            AY8910 = 0x8910,    //PSG
            AY8912 = 0x8912,    //PSG
            AY8913 = 0x8913,    //PSG
            AY8930 = 0x8930,    //APSG
            SCC = 0x2212,       //SCC
            SCCS = 0x2312,      //SCC-I
        };
        public enum Re4xLocation
        {
            None = 0,
            Left = 1,
            Right = 2,
            Both = 3,
            Stereo = 4,
        };
        public enum Re4xSlotNumbers
        {
            None = 0,
            _1Slot = 1,
            _4Slot = 4,
        };
        public class Re4xSlotInfo
        {
            public Re4xModules ModuleId;
            public uint Clock;
            public Re4xLocation Location;
        };
        public class Re4xEEPROM
        {
            public uint Version;
            public uint Slots;
            public Re4xSlotInfo[] SlotInfo = new Re4xSlotInfo[4];
        };
        public static uint ReadEEPROMLong(FTDI dev, uint address)
        {
            uint ret = 0;
            ushort eevalh = 0;
            ushort eevall = 0;
            dev.ReadEEPROMLocation(address, ref eevalh);
            dev.ReadEEPROMLocation(address + 0x02, ref eevall);
            ret = (uint)(((int)eevalh << 16) | (int)eevall);
            return ret;
        }
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
