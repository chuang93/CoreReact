using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreReact.Models;
using CoreReact.Models.ModelWrappers;
using Newtonsoft.Json.Linq;

namespace CoreReact.Services
{
    public class PlayerLogStatsService
    {
        //TO DO: Implement Stat Averager for wins and losses for a player and remove dummy stats.

        public PlayerLogStatsService()
        {}

        public PlayerProfile CalculateAndUpdateStats(PlayerProfile player, LogJsonWrapper playerstatWrapper)
        {
            if (player != null && playerstatWrapper != null)
            {
                
                player.PpgInLoss = 22.3;
                player.PpgInWin = 30.7;
                player.ToPgInLoss = 4.2;
                player.ToPgInWin = 3.1;
                return player;
            }
            return null;
        }

        public int GetPlayerStatId(LogJsonWrapper playerStatWrapper)
        {
            if (playerStatWrapper != null)
            {
                List<String> categories = playerStatWrapper.Headers;
                List<List<String>> gameLog = playerStatWrapper.RowSet;
                if (gameLog[0].Count != 0)
                {
                    //TODO: ITERATE THROUGH GAME LOG AND PARSE FOR AVERAGES/GAME IN LOSSES AND IN WIN
                }
            }
            return -1;
        }
    }
}
