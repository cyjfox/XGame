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
        static void XGameRun()
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

                Int32 playerChoice = (Int32)GlobalVariable.GetValue("PlayerChoice");

                Int32 gameResult = 0;

                //机器石头，人石头
                if ((machineChoice == 0) && (playerChoice == 0))
                {
                    //平局
                    gameResult = 0;
                }
                //机器剪刀，人剪刀
                if ((machineChoice == 1) && (playerChoice == 1))
                {
                    //平局
                    gameResult = 0;
                }
                //机器布，人布
                if ((machineChoice == 2) && (playerChoice == 2))
                {
                    //平局
                    gameResult = 0;
                }

                //机器石头，人剪刀
                if ((machineChoice == 0) && (playerChoice == 1))
                {
                    //机器赢
                    gameResult = 1;
                }
                //机器剪刀，人布
                if ((machineChoice == 1) && (playerChoice == 2))
                {
                    //机器赢
                    gameResult = 1;
                }
                //机器布，人石头
                if ((machineChoice == 2) && (playerChoice == 0))
                {
                    //机器赢
                    gameResult = 1;
                }

                //机器石头，人布
                if ((machineChoice == 0) && (playerChoice == 2))
                {
                    //机器输
                    gameResult = 2;
                }
                //机器剪刀，人石头
                if ((machineChoice == 1) && (playerChoice == 0))
                {
                    //机器输
                    gameResult = 2;
                }
                //机器布，人剪刀
                if ((machineChoice == 2) && (playerChoice == 1))
                {
                    //机器输
                    gameResult = 2;
                }

                if (gameResult == 0)
                {

                }
                else if (gameResult == 1)
                {

                }
                else if (gameResult == 2)
                {

                }
                else
                {
                    //错误
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            Thread workerThread = new Thread(new ThreadStart(XGameRun));
            workerThread.Start();

            
        }
    }
}
