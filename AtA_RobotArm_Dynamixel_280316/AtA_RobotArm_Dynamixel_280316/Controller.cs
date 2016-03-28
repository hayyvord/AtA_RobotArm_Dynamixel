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

        /// <summary>
        /// Number of port.
        /// </summary>
        private int port = 0;

        /// <summary>
        /// Index.
        /// </summary>
        int index = 0;

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
                Console.WriteLine("Ne staa");
            }
            else
            {
                Console.WriteLine("staa");
            }
        }
        #endregion
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="position"></param>
        public void DriveServo()
        {
            byte[] ID = new byte[] {1,2,3,4};
            int[] POS = new int[] { 512,512,512,512 };

            for (int i = 0; i <= POS.Length; i++)
            {
                dxl_set_txpacket_id(ID[i]);
                dxl_set_txpacket_length(5);
                dxl_set_txpacket_instruction(ServoVaribles.INST_WRITE);
                dxl_set_txpacket_parameter(0, ServoVaribles.GOAL_POSITION);
                dxl_set_txpacket_parameter(1, (byte)(POS[i] & 0xFF));
                dxl_set_txpacket_parameter(2, (byte)((POS[i] & 0xFF00) / 0x100));
                dxl_tx_packet();
            }
        }
    
    }
}
