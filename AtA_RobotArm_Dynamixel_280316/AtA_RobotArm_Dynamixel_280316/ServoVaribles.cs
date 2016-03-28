using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtA_RobotArm_Dynamixel_280316
{
    public class ServoVaribles
    {

        public const int MAX_ID = 252;
        public const int BROADCAST_ID = 254;

        public const int INST_PING = 1;
        public const int INST_READ = 2;
        public const int INST_WRITE = 3;
        public const int INST_REG_WRITE = 4;
        public const int INST_ACTION = 5;
        public const int INST_RESET = 6;
        public const int INST_SYNC_WRITE = 131;
        public const int INST_BULK_READ = 146;  // 0x92

        public const int INST_REBOOT = 8;
        public const int INST_STATUS = 85;   // 0x55
        public const int INST_SYNC_READ = 130;  // 0x82
        public const int INST_BULK_WRITE = 147;  // 0x93

        public const int ERRBIT_ALERT = 128;

        public const int ERR_RESULT_FAIL = 1;
        public const int ERR_INSTRUCTION = 2;
        public const int ERR_CRC = 3;
        public const int ERR_DATA_RANGE = 4;
        public const int ERR_DATA_LENGTH = 5;
        public const int ERR_DATA_LIMIT = 6;
        public const int ERR_ACCESS = 7;

        public const int COMM_TXSUCCESS = 0;
        public const int COMM_RXSUCCESS = 1;
        public const int COMM_TXFAIL = 2;
        public const int COMM_RXFAIL = 3;
        public const int COMM_TXERROR = 4;
        public const int COMM_RXWAITING = 5;
        public const int COMM_RXTIMEOUT = 6;
        public const int COMM_RXCORRUPT = 7;
        public const int MAXNUM_TXPARAM = 150;
        public const int MAXNUM_RXPARAM = 60;


        public const int ERRBIT_VOLTAGE = 1;
        public const int ERRBIT_ANGLE = 2;
        public const int ERRBIT_OVERHEAT = 4;
        public const int ERRBIT_RANGE = 8;
        public const int ERRBIT_CHECKSUM = 16;
        public const int ERRBIT_OVERLOAD = 32;
        public const int ERRBIT_INSTRUCTION = 64;

        public const int GOAL_POSITION = 30;

        public const int POSITION_LENGTH = 4;

        public static UInt16 DXL_MAKEWORD(UInt32 a, UInt32 b) { return (UInt16)((a & 0xFF) | ((b & 0xFF) << 8)); }
        public static UInt32 DXL_MAKEDWORD(UInt32 a, UInt32 b) { return (UInt32)((a & 0xFFFF) | ((b & 0xFFFF) << 16)); }
        public static UInt16 DXL_LOWORD(UInt32 l) { return (UInt16)(l & 0xFFFF); }
        public static UInt16 DXL_HIWORD(UInt32 l) { return (UInt16)((l >> 16) & 0xFFFF); }
        public static byte DXL_LOBYTE(UInt16 w) { return (byte)(w & 0xFF); }
        public static byte DXL_HIBYTE(UInt16 w) { return (byte)((w >> 8) & 0xFF); }

    }
}
