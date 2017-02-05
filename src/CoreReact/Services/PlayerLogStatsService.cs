using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreReact.Models;
using Newtonsoft.Json.Linq;

namespace CoreReact.Services
{
    public class PlayerLogStatsService
    {
        //TO DO: Implement Stat Averager for wins and losses for a player and remove dummy stats.

        public PlayerLogStatsService()
        {}

        public PlayerProfile CalculateAndUpdateStats(PlayerProfile player, String playerJsonString)
        {
            if (player != null && playerJsonString != null)
            {
                JObject playerJsonJObject = JObject.Parse(playerJsonString);
                player.PpgInLoss = 22.3;
                player.PpgInWin = 30.7;
                player.ToPgInLoss = 4.2;
                player.ToPgInWin = 3.1;
                return player;
            }
            return null;
        }
    }
}
