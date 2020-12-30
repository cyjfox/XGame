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
using System.Media;
using System.IO;

namespace XGame
{
    public partial class Form1 : Form
    {
        static void ToOpenSignal()
        {
            /*
            SoundPlayer soundPlayer = new SoundPlayer("./TestSound.wav");
            soundPlayer.Play();
            Int32[] stoneWavData = new Int32[192000];
            Int32[] seissorWavData = new Int32[192000];
            Int32[] clothWavData = new Int32[192000];

            Int32 dataCountPerCircle = 192000 / 96000;
            Int32[] sample = new int[dataCountPerCircle];
            for (int i = 0; i < dataCountPerCircle; i++)
            {
                sample[i] = (Int32)Math.Sin(2 * 3.141593 / dataCountPerCircle);
            }
            for (int i = 0; i < 192000; i++)
            {
                
                for (int j = 0; j < 96000; j++)
                {
                    
                }
                
                
                if ((i % 96000) < 96000)
                {
                    
                }
                

                //stoneWavData[i] = (int)Math.Sin((double)((i % 96000) / 96000));
                stoneWavData[i] = sample[i % dataCountPerCircle];
            }
            //Stream stoneWavStream = new MemoryStream(stoneWavData, true);
            //wavStream.Write()
            //SoundPlayer soundPlayer1 = new SoundPlayer(wavStream);
            */

            uint bitPerSample = 32;
            uint SampleCountPerChannel = 100000;
            ushort channelCount = 2;
            uint sampleRate = 192000;
            uint dataSize = bitPerSample / 8 * SampleCountPerChannel * channelCount;
            Byte[] wavData = new Byte[dataSize];
            Random random = new Random();
            random.NextBytes(wavData);
            
            Stream stoneWavStream = WavFile.GenerateWavFileStream(bitPerSample, SampleCountPerChannel, false, channelCount, sampleRate, wavData);
            SoundPlayer soundPlayer = new SoundPlayer();
            stoneWavStream.Position = 0;
            soundPlayer.Stream = null;
            soundPlayer.Stream = stoneWavStream;
            soundPlayer.Load();
            soundPlayer.PlaySync();
            //soundPlayer.Play();
        }

        static void XGameRun()
        {
            ManualResetEvent isPlayerDoneEvent = new ManualResetEvent(false);

            GlobalVariable.SetValue("IsPlayerDoneEvent", isPlayerDoneEvent);

            Label lbl_WinCount = (Label)GlobalVariable.GetValue("lbl_WinCount");
            Label lbl_DrawCount = (Label)GlobalVariable.GetValue("lbl_DrawCount");
            Label lbl_LoseCount = (Label)GlobalVariable.GetValue("lbl_LoseCount");
            Label lbl_WinCountPercentage = (Label)GlobalVariable.GetValue("lbl_WinCountPercentage");
            Label lbl_DrawCountPercentage = (Label)GlobalVariable.GetValue("lbl_DrawCountPercentage");
            Label lbl_LoseCountPercentage = (Label)GlobalVariable.GetValue("lbl_LoseCountPercentage");

            Label lbl_GameResult = (Label)GlobalVariable.GetValue("LableControl_GameResult");
            PictureBox picbox_MachineChoice = (PictureBox)GlobalVariable.GetValue("PictureBoxControl_MachineChoice");
            PictureBox picbox_PlayerChoice = (PictureBox)GlobalVariable.GetValue("PictureBoxControl_PlayerChoice");

            Image stoneImageForMachineChoice = Image.FromFile("./stone.jpg");
            Image seissorImageForMachineChoice = Image.FromFile("./seissor.jpg");
            Image clothImageForMachineChoice = Image.FromFile("./cloth.jpg");

            Image stoneImageForPlayerChoice = Image.FromFile("./stone.jpg");
            Image seissorImageForPlayerChoice = Image.FromFile("./seissor.jpg");
            Image clothImageForPlayerChoice = Image.FromFile("./cloth.jpg");

            
            //GlobalVariable.SetValue("RecordFileStream", recordFileStream);
            while (true)
            {
                /*
                Random random = new Random();
                Int32 machineChoice = random.Next() % 3;
                */
                //Random rand = new Random((int)DateTime.Now.Ticks);

                Random random = new Random(Guid.NewGuid().GetHashCode());
                Int32 machineChoice = random.Next(3);
                //Int32 machineChoice = new Random().Next(3);
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
                isPlayerDoneEvent.Reset();
                Int32 playerChoice = (Int32)GlobalVariable.GetValue("PlayerChoice");

                Int32 gameResult = 0;

                //机器石头，人石头
                if ((machineChoice == 0) && (playerChoice == 0))
                {

                    //平局
                    picbox_MachineChoice.Image = stoneImageForMachineChoice;
                    picbox_PlayerChoice.Image = stoneImageForPlayerChoice;
                    gameResult = 0;
                }
                //机器剪刀，人剪刀
                if ((machineChoice == 1) && (playerChoice == 1))
                {
                    //平局
                    picbox_MachineChoice.Image = seissorImageForMachineChoice;
                    picbox_PlayerChoice.Image = seissorImageForPlayerChoice;
                    gameResult = 0;
                }
                //机器布，人布
                if ((machineChoice == 2) && (playerChoice == 2))
                {
                    //平局
                    picbox_MachineChoice.Image = clothImageForMachineChoice;
                    picbox_PlayerChoice.Image = clothImageForPlayerChoice;
                    gameResult = 0;
                }

                //机器石头，人剪刀
                if ((machineChoice == 0) && (playerChoice == 1))
                {
                    //机器赢
                    picbox_MachineChoice.Image = stoneImageForMachineChoice;
                    picbox_PlayerChoice.Image = seissorImageForPlayerChoice;
                    gameResult = 1;
                }
                //机器剪刀，人布
                if ((machineChoice == 1) && (playerChoice == 2))
                {
                    //机器赢
                    picbox_MachineChoice.Image = seissorImageForMachineChoice;
                    picbox_PlayerChoice.Image = clothImageForPlayerChoice;
                    gameResult = 1;
                }
                //机器布，人石头
                if ((machineChoice == 2) && (playerChoice == 0))
                {
                    //机器赢
                    picbox_MachineChoice.Image = clothImageForMachineChoice;
                    picbox_PlayerChoice.Image = stoneImageForPlayerChoice;
                    gameResult = 1;
                }

                //机器石头，人布
                if ((machineChoice == 0) && (playerChoice == 2))
                {
                    //机器输
                    picbox_MachineChoice.Image = stoneImageForMachineChoice;
                    picbox_PlayerChoice.Image = clothImageForPlayerChoice;
                    gameResult = 2;
                }
                //机器剪刀，人石头
                if ((machineChoice == 1) && (playerChoice == 0))
                {
                    //机器输
                    picbox_MachineChoice.Image = seissorImageForMachineChoice;
                    picbox_PlayerChoice.Image = stoneImageForPlayerChoice;
                    gameResult = 2;
                }
                //机器布，人剪刀
                if ((machineChoice == 2) && (playerChoice == 1))
                {
                    //机器输
                    picbox_MachineChoice.Image = clothImageForMachineChoice;
                    picbox_PlayerChoice.Image = seissorImageForPlayerChoice;
                    gameResult = 2;
                }

                //将结果通知界面
                if (gameResult == 0)
                {
                    GlobalVariable.SetValue("GameResult", 0);
                    lbl_GameResult.Text = "平局";
                }
                else if (gameResult == 1)
                {
                    GlobalVariable.SetValue("GameResult", 1);
                    lbl_GameResult.Text = "失败";
                }
                else if (gameResult == 2)
                {
                    GlobalVariable.SetValue("GameResult", 2);
                    lbl_GameResult.Text = "胜利";
                }
                else
                {
                    //错误
                    //GlobalVariable.SetValue("GameResult", 3);
                    lbl_GameResult.Text = "错误";
                }

                //将结果写入记录文件
                //FileStream recordFileStream = File.OpenWrite("./Record.txt");
                StreamWriter recordFileStreamWriter = File.AppendText("./Record.txt");

                String resultString = String.Format("{0:G}  {1:D}  {2:D}  {3:D}  \r\n", System.DateTime.Now.ToString("yyyyMMddHHmmssffff"), playerChoice, machineChoice, gameResult);
                //byte[] resultStringBuffer = Encoding.ASCII.GetBytes(resultString);
                
                //recordFileStream.Write(resultStringBuffer, 0, resultStringBuffer.Length);
                //recordFileStream.Close();
                

                recordFileStreamWriter.Write(resultString);
                recordFileStreamWriter.Close();
                Form1.UpdateDashboard(lbl_WinCount, lbl_DrawCount, lbl_LoseCount, lbl_WinCountPercentage, lbl_DrawCountPercentage, lbl_LoseCountPercentage);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Stone_Click(object sender, EventArgs e)
        {
            GlobalVariable.SetValue("PlayerChoice", 0);
            ManualResetEvent isPlayerDoneEvent = (ManualResetEvent)GlobalVariable.GetValue("IsPlayerDoneEvent");
            isPlayerDoneEvent.Set();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            GlobalVariable.SetValue("lbl_WinCount", lbl_WinCount);
            GlobalVariable.SetValue("lbl_DrawCount", lbl_DrawCount);
            GlobalVariable.SetValue("lbl_LoseCount", lbl_LoseCount);
            GlobalVariable.SetValue("lbl_WinCountPercentage", lbl_WinCountPercentage);
            GlobalVariable.SetValue("lbl_DrawCountPercentage", lbl_DrawCountPercentage);
            GlobalVariable.SetValue("lbl_LoseCountPercentage", lbl_LoseCountPercentage);
            UpdateDashboard(lbl_WinCount, lbl_DrawCount, lbl_LoseCount, lbl_WinCountPercentage, lbl_DrawCountPercentage, lbl_LoseCountPercentage);
        }

        private static void UpdateDashboard(Label lbl_WinCount, Label lbl_DrawCount, Label lbl_LoseCount, Label lbl_WinCountPercentage, Label lbl_DrawCountPercentage, Label lbl_LoseCountPercentage)
        {
            FileStream recordFileStream = File.OpenRead("./Record.txt");
            MemoryStream memoryStream = new MemoryStream();
            byte[] buffer = new byte[1];
            Boolean isLastReturnChar = false;
            UInt32 winCount = 0;
            UInt32 drawCount = 0;
            UInt32 loseCount = 0;
            memoryStream.Position = 0;
            while (recordFileStream.Read(buffer, 0, 1) > 0)
            {
                memoryStream.Write(buffer, 0, 1);

                if (buffer[0] == Encoding.ASCII.GetBytes("\r")[0])
                {
                    isLastReturnChar = true;
                }

                if (buffer[0] == Encoding.ASCII.GetBytes("\n")[0] && isLastReturnChar)
                {
                    //break;
                    memoryStream.Flush();
                    byte[] resultStringBuffer = memoryStream.GetBuffer();
                    GameResult gameResult = GameResult.FromBuffer(resultStringBuffer);
                    Int32 gameResultCode = gameResult.GetGameResultCode();
                    if (gameResultCode == 0)
                    {
                        //平局
                        drawCount++;
                    }
                    else if (gameResultCode == 1)
                    {
                        //失败
                        loseCount++;
                    }
                    else if (gameResultCode == 2)
                    {
                        //胜利
                        winCount++;
                    }
                    else
                    {
                        MessageBox.Show("解析结果代码出错!");
                    }

                    memoryStream.Position = 0;
                }
            }

            UInt32 totalCount = drawCount + winCount + loseCount;
            Double winCountPercentage = (Double)winCount / (Double)totalCount;
            Double drawCountPercentage = (Double)drawCount / (Double)totalCount;
            Double loseCountPercentage = (Double)loseCount / (Double)totalCount;

            lbl_WinCount.Text = winCount.ToString();
            lbl_DrawCount.Text = drawCount.ToString();
            lbl_LoseCount.Text = loseCount.ToString();

            lbl_WinCountPercentage.Text = winCountPercentage.ToString();
            lbl_DrawCountPercentage.Text = drawCountPercentage.ToString();
            lbl_LoseCountPercentage.Text = loseCountPercentage.ToString();

            recordFileStream.Close();
        }

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            GlobalVariable.SetValue("LableControl_GameResult", lbl_Result);
            GlobalVariable.SetValue("PictureBoxControl_MachineChoice", picbox_MachineChoice);
            GlobalVariable.SetValue("PictureBoxControl_PlayerChoice", picbox_PlayerChoice);
            Thread workerThread = new Thread(new ThreadStart(XGameRun));
            GlobalVariable.SetValue("WorkerThread", workerThread);
            workerThread.Start();
            btn_StartGame.Enabled = false;
            btn_EndGame.Enabled = true;
        }

        private void btn_EndGame_Click(object sender, EventArgs e)
        {
            Thread workerThread = (Thread)GlobalVariable.GetValue("WorkerThread");
            workerThread.Abort();
            btn_StartGame.Enabled = true;
            btn_EndGame.Enabled = false;
            //((FileStream)GlobalVariable.GetValue("RecordFileStream")).Close();
        }

        private void btn_Seissor_Click(object sender, EventArgs e)
        {
            GlobalVariable.SetValue("PlayerChoice", 1);
            ManualResetEvent isPlayerDoneEvent = (ManualResetEvent)GlobalVariable.GetValue("IsPlayerDoneEvent");
            isPlayerDoneEvent.Set();
        }

        private void btn_Cloth_Click(object sender, EventArgs e)
        {
            GlobalVariable.SetValue("PlayerChoice", 2);
            ManualResetEvent isPlayerDoneEvent = (ManualResetEvent)GlobalVariable.GetValue("IsPlayerDoneEvent");
            isPlayerDoneEvent.Set();
        }

        private void chcbox_ToOpenSignal_CheckedChanged(object sender, EventArgs e)
        {
            if (chcbox_ToOpenSignal.Checked == true)
            {
                ToOpenSignal();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Thread workerThread = (Thread)GlobalVariable.GetValue("WorkerThread");
            if (workerThread != null)
            {
                workerThread.Abort();
            }
            FileStream recordFileStream = (FileStream)GlobalVariable.GetValue("RecordFileStream");
            if (recordFileStream != null)
            {
                recordFileStream.Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
