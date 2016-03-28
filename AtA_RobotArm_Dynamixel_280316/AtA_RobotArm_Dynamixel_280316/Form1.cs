using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AtA_RobotArm_Dynamixel_280316
{
    public partial class Form1 : Form
    {
        public Controller controll;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.controll = new Controller(25);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.controll.DriveServo();
        }
    }
}
