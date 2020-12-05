using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XGame
{
    class GameResult
    {
        private DateTime playGameTime;
        private String playGameTimeString;
        private Int32 playerChoice;
        private Int32 machineChoice;
        private Int32 gameResultCode;


        public DateTime GetPlayGameTime()
        {
            return playGameTime;
        }

        public String GetPlayGameTimeString()
        {
            return playGameTimeString;
        }

        public Int32 GetPlayerChoice()
        {
            return playerChoice;
        }

        public Int32 GetMachinceChoice()
        {
            return machineChoice;
        }

        public Int32 GetGameResultCode()
        {
            return gameResultCode;
        }
        static public GameResult FromBuffer(byte[] buffer)
        {
            GameResult gameResult = new GameResult();
            int i = 0;
            MemoryStream playGameTimeStringMemoryStream = new MemoryStream();
            for (i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == 0x20 && buffer[i + 1] == 0x20)
                {
                    i++;
                    break;
                }
                else
                {
                    playGameTimeStringMemoryStream.Write(buffer, i ,1);
                }
            }
            playGameTimeStringMemoryStream.Flush();

            playGameTimeStringMemoryStream.Position = 0;
            StreamReader streamReader = new StreamReader(playGameTimeStringMemoryStream);
            gameResult.playGameTimeString = streamReader.ReadToEnd();
            gameResult.playGameTimeString = gameResult.playGameTimeString.Trim();

            gameResult.playGameTime = DateTime.Parse(gameResult.playGameTimeString);



            MemoryStream playerChoiceStringMemoryStream = new MemoryStream();
            for (; i < buffer.Length; i++)
            {
                if (buffer[i] == 0x20 && buffer[i + 1] == 0x20)
                {
                    i++;
                    break;
                }
                else
                {
                    playerChoiceStringMemoryStream.Write(buffer, i, 1);
                }
            }

            playerChoiceStringMemoryStream.Flush();

            playerChoiceStringMemoryStream.Position = 0;
            streamReader = new StreamReader(playerChoiceStringMemoryStream);
            String playerChoiceString = streamReader.ReadToEnd();
            gameResult.playerChoice = Int32.Parse(playerChoiceString.Trim());
       

            MemoryStream machineChoiceStringMemoryStream = new MemoryStream();
            for (; i < buffer.Length; i++)
            {
                if (buffer[i] == 0x20 && buffer[i + 1] == 0x20)
                {
                    i++;
                    break;
                }
                else
                {
                    machineChoiceStringMemoryStream.Write(buffer, i, 1);
                }
            }
            machineChoiceStringMemoryStream.Flush();

            machineChoiceStringMemoryStream.Position = 0;
            streamReader = new StreamReader(machineChoiceStringMemoryStream);
            String machineChoiceString = streamReader.ReadToEnd();
            gameResult.machineChoice = Int32.Parse(machineChoiceString.Trim());

            if (gameResult.playerChoice == gameResult.machineChoice)
            {
                gameResult.gameResultCode = 0;
            }
            else if (((gameResult.playerChoice == 0) && (gameResult.machineChoice == 2)) || ((gameResult.playerChoice == 1) && (gameResult.machineChoice == 0)) || ((gameResult.playerChoice == 2) && (gameResult.machineChoice == 1)))
            {
                gameResult.gameResultCode = 1;
            }
            else if (((gameResult.playerChoice == 0) && (gameResult.machineChoice == 1)) || ((gameResult.playerChoice == 1) && (gameResult.machineChoice == 2)) || ((gameResult.playerChoice == 2) && (gameResult.machineChoice == 0)))
            {
                gameResult.gameResultCode = 2;
            }
            
            return gameResult;
        }


    }

    
}
