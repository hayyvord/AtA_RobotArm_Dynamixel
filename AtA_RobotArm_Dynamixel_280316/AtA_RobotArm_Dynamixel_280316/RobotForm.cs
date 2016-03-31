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
    public partial class RobotForm : Form
    {
        public Controller controll;
        public RobotForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Connect to the robot.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_connect_Click(object sender, EventArgs e)
        {
            this.controll = new Controller(25);
        }

        /// <summary>
        /// Set robot to default position(150 degrees) for each servo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_home_Click(object sender, EventArgs e)
        {
            int defaultValue = 150;
            int servoNumbers = 4;

            for (int servoIndex = 1; servoIndex <= servoNumbers; servoIndex++)
            {
                this.controll.Servo(servoIndex, defaultValue);
            }

            trackBar1.Value = defaultValue;
            trackBar2.Value = defaultValue;
            trackBar3.Value = defaultValue;
            trackBar4.Value = defaultValue;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int value = trackBar1.Value;
            this.controll.Servo(1, value);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            int value = trackBar2.Value;
            this.controll.Servo(2, value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            int value = trackBar3.Value;
            this.controll.Servo(3, value);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            int value = trackBar4.Value;
            this.controll.Servo(4, value);
        }
   
    
    }
}
