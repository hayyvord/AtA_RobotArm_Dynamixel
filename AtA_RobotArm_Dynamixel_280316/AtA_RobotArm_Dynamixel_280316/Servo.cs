using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtA_RobotArm_Dynamixel_280316
{
    /// <summary>
    /// Created by Adrian Yordanov
    /// Class that helps to initiaizate each servo.
    /// When you need to move a servo, just create an instance and call the function MoveServo.
    /// </summary>
    public class Servo
    {
        /// <summary>
        /// Number of the servo.
        /// </summary>
        private readonly int servoNumber;

        public Servo(int servoNumber)
        {
            this.servoNumber = servoNumber;
        }
        
        /// <summary>
        /// Function that sets the current servo position.
        /// </summary>
        /// <param name="value"></param>
        public void MoveServo(int value)
        {
            Controller.dxl_write_word(this.servoNumber, ServoVaribles.GoalPositionL, value);
        }
    }
}
