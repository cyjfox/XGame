using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ManualResetEvent isPlayerDoneEvent = new ManualResetEvent(false);

            GlobalVariable.SetValue("IsPlayerDoneEvent", isPlayerDoneEvent);

            while (true)
            {
                Random random = new Random();
                Int32 machineChoice = random.Next() % 3;
                //GlobalVariable.
                GlobalVariable.SetValue("MachineChoice", machineChoice);

                /*
                if (发出测试信号)
                {
                    发出测试信号
                }
                */

                isPlayerDoneEvent = (ManualResetEvent)GlobalVariable.GetValue("IsPlayerDoneEvent");
                isPlayerDoneEvent.WaitOne();

            }
        }
    }
}
