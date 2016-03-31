using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AtA_RobotArm_Dynamixel_280316
{
    public class Controller
    {

        #region Varibles

        #region Servo Index
        /// <summary>
        /// Base index.
        /// </summary>
        private int Base = 1;

        /// <summary>
        /// Soulder index.
        /// </summary>
        private int Shoulder = 2;

        /// <summary>
        /// Elbow index.
        /// </summary>
        private int Elbow = 3;
        
        /// <summary>
        /// Wrist index.
        /// </summary>
        private int Wirst = 4;

        #endregion

        #region Servo Positions
        
        /// <summary>
        /// Base position.
        /// </summary>
        private int posBase = 0;
        
        /// <summary>
        /// Shoulder position.
        /// </summary>
        private int posShoulder = 0;

        /// <summary>
        /// Elbow position.
        /// </summary>
        private int posElbow = 0;
        
        /// <summary>
        /// Wirst position.
        /// </summary>
        private int posWirst = 0;
        
        #endregion
       
        /// <summary>
        /// Number of port.
        /// </summary>
        private int port = 0;

        /// <summary>
        /// isConnected.
        /// </summary>
        private bool isConnected = false;

        #endregion

        #region DllImports

        public static UInt16 DXL_MAKEWORD(UInt32 a, UInt32 b) { return (UInt16)((a & 0xFF) | ((b & 0xFF) << 8)); }
        public static UInt32 DXL_MAKEDWORD(UInt32 a, UInt32 b) { return (UInt32)((a & 0xFFFF) | ((b & 0xFFFF) << 16)); }
        public static UInt16 DXL_LOWORD(UInt32 l) { return (UInt16)(l & 0xFFFF); }
        public static UInt16 DXL_HIWORD(UInt32 l) { return (UInt16)((l >> 16) & 0xFFFF); }
        public static byte DXL_LOBYTE(UInt16 w) { return (byte)(w & 0xFF); }
        public static byte DXL_HIBYTE(UInt16 w) { return (byte)((w >> 8) & 0xFF); }


        [DllImport("dynamixel2_win32.dll")]
        public static extern int dxl_initialize(int port_num, int baud_rate);
        [DllImport("dynamixel2_win32.dll")]
        public static extern int dxl_change_baudrate(int baud_rate);
        [DllImport("dynamixel2_win32.dll")]
        public static extern int dxl_terminate();

        [DllImport("dynamixel2_win32.dll")]
        public static extern int dxl_get_comm_result();

        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl_tx_packet();
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl_rx_packet();
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl_txrx_packet();

        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl_set_txpacket_id(int id);
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl_set_txpacket_instruction(int instruction);
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl_set_txpacket_parameter(int index, int value);
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl_set_txpacket_length(int length);
        [DllImport("dynamixel2_win32.dll")]
        public static extern int dxl_get_rxpacket_error(int error);
        [DllImport("dynamixel2_win32.dll")]
        public static extern int dxl_get_rxpacket_error_byte();
        [DllImport("dynamixel2_win32.dll")]
        public static extern int dxl_get_rxpacket_parameter(int index);
        [DllImport("dynamixel2_win32.dll")]
        public static extern int dxl_get_rxpacket_length();

        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl_ping(int id);
        [DllImport("dynamixel2_win32.dll")]
        public static extern int dxl_read_byte(int id, int address);
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl_write_byte(int id, int address, int value);
        [DllImport("dynamixel2_win32.dll")]
        public static extern int dxl_read_word(int id, int address);
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl_write_word(int id, int address, int value);

        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl2_tx_packet();
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl2_rx_packet();
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl2_txrx_packet();

        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl2_set_txpacket_id(byte id);
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl2_set_txpacket_instruction(byte instruction);
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl2_set_txpacket_parameter(UInt16 index, byte value);
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl2_set_txpacket_length(UInt16 length);
        [DllImport("dynamixel2_win32.dll")]
        public static extern int dxl2_get_rxpacket_error_byte();
        [DllImport("dynamixel2_win32.dll")]
        public static extern int dxl2_get_rxpacket_parameter(int index);
        [DllImport("dynamixel2_win32.dll")]
        public static extern int dxl2_get_rxpacket_length();

        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl2_ping(byte id);
        [DllImport("dynamixel2_win32.dll")]
        public static extern int dxl2_get_ping_result(byte id, int info_num);
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl2_broadcast_ping();

        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl2_reboot(byte id);
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl2_factory_reset(byte id, int option);

        [DllImport("dynamixel2_win32.dll")]
        public static extern byte dxl2_read_byte(byte id, int address);
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl2_write_byte(byte id, int address, byte value);
        [DllImport("dynamixel2_win32.dll")]
        public static extern UInt16 dxl2_read_word(byte id, int address);
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl2_write_word(byte id, int address, UInt16 value);
        [DllImport("dynamixel2_win32.dll")]
        public static extern UInt32 dxl2_read_dword(byte id, int address);
        [DllImport("dynamixel2_win32.dll")]
        public static extern void dxl2_write_dword(byte id, int address, UInt32 value);

        [DllImport("dynamixel2_win32.dll")]
        public static extern byte dxl2_get_bulk_read_data_byte(byte id, UInt32 start_address);
        [DllImport("dynamixel2_win32.dll")]
        public static extern UInt16 dxl2_get_bulk_read_data_word(byte id, UInt32 start_address);
        [DllImport("dynamixel2_win32.dll")]
        public static extern UInt32 dxl2_get_bulk_read_data_dword(byte id, UInt32 start_address);

        [DllImport("dynamixel2_win32.dll")]
        public static extern byte dxl2_get_sync_read_data_byte(byte id, UInt32 start_address);
        [DllImport("dynamixel2_win32.dll")]
        public static extern UInt16 dxl2_get_sync_read_data_word(byte id, UInt32 start_address);
        [DllImport("dynamixel2_win32.dll")]
        public static extern UInt32 dxl2_get_sync_read_data_dword(byte id, UInt32 start_address);

        #endregion

        #region Constructor
     
        /// <summary>
        /// Dynamixel.
        /// </summary>
        /// <param name="port"></param>
        /// <param name="boudrate"></param>
        public Controller(int port)
        {
            this.port = port;

            if (dxl_initialize(this.port, 1000000) == 0)
            {
                this.isConnected = false;
                Console.WriteLine(this.isConnected);
            }
            else
            {
                this.isConnected = true;
                Console.WriteLine(this.isConnected);
            }
        }

        #endregion

        /// <summary>
        /// Servo controller.
        /// </summary>
        /// <param name="posBase"></param>
        /// <param name="posShoulder"></param>
        /// <param name="posElbow"></param>
        /// <param name="posWirst"></param>
        public void Servo(int servoNumber, int value)
        {
            if (this.isConnected)
            {
                Servo currentServo = new Servo(servoNumber);
                int valueToDeg = this.PosToDeg(value);
                currentServo.MoveServo(valueToDeg);
            }
        }

        private int PosToDeg(int deg)
        {
            return (1023 * deg) / 300;
        }


    }
}
