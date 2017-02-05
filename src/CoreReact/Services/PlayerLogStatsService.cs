using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreReact.Models;
using CoreReact.Models.ModelWrappers;
using Newtonsoft.Json.Linq;

namespace CoreReact.Services
{
    enum Categories { SeasonId, PlayerId, GameId, GameDate, Matchup, Wl, Min, Fgm, Fga, FgPct, Fg3M, Fg3A, Fg3Pct, Ftm, Fta, FtPct, OReb, Dreb, Reb,
        Ast, Stl, Blk, Tov, Pf, Pts, PlusMinus, VideoAvailable }
 
    public class PlayerLogStatsService
    {
        //TO DO: Implement Stat Averager for wins and losses for a player and remove dummy stats.

        public PlayerLogStatsService()
        {}

        public PlayerProfile CalculateAndUpdateStats(PlayerProfile player, LogJsonWrapper playerstatWrapper)
        {
            if (player != null && playerstatWrapper != null)
            {
                List<String> categories = playerstatWrapper.Headers;
                List<List<String>> gameLog = playerstatWrapper.RowSet;
                if (gameLog.Count != 0)
                {
                    player.PpgInLoss = CalculateCategoryAverage(gameLog, (int) Categories.Pts,"loss");
                    player.PpgInWin = CalculateCategoryAverage(gameLog, (int)Categories.Pts, "win"); 
                    player.ToPgInLoss = CalculateCategoryAverage(gameLog, (int)Categories.Tov, "loss"); 
                    player.ToPgInWin = CalculateCategoryAverage(gameLog, (int)Categories.Tov, "win");
                    player.ApgInLoss = CalculateCategoryAverage(gameLog, (int)Categories.Ast, "loss");
                    player.ApgInWin = CalculateCategoryAverage(gameLog, (int)Categories.Ast, "win");
                    player.RpgInLoss = CalculateCategoryAverage(gameLog, (int)Categories.Reb, "loss");
                    player.RpgInWin = CalculateCategoryAverage(gameLog, (int)Categories.Reb, "win");
                    player.FgPerInLoss = CalculateCategoryAverage(gameLog, (int)Categories.FgPct, "loss");
                    player.FgPerInWin = CalculateCategoryAverage(gameLog, (int)Categories.FgPct, "win");
                    player.ThreePerInLoss = CalculateCategoryAverage(gameLog, (int)Categories.Fg3Pct, "loss");
                    player.ThreePerInWin = CalculateCategoryAverage(gameLog, (int)Categories.Fg3Pct, "win");
                    return player;
                }
                else
                {
                    Console.WriteLine("Player {0} played 0 gamesl; setting averages to 0", player.PlayerId);
                    ZeroAllAverages(player);
                    return player;
                }
            }
            return null;
        }

        private void ZeroAllAverages(PlayerProfile player)
        {
            player.PpgInLoss = 0;
            player.PpgInWin = 0;
            player.ToPgInLoss = 0;
            player.ToPgInWin = 0;
            player.ApgInLoss = 0;
            player.ApgInWin = 0;
            player.RpgInLoss = 0;
            player.RpgInWin = 0;
            player.FgPerInLoss = 0;
            player.FgPerInWin = 0;
            player.ThreePerInLoss = 0;
            player.ThreePerInWin = 0;

        }

        private double CalculateCategoryAverage(List<List<String>> gameLog, int category, string winOrLoss)
        {
            double average = 0;
            int numgames = 0;
            foreach (List<String> currentGame in gameLog)
            {
                String categoryValue = currentGame[category];
                if (winOrLoss == "win" && currentGame[5] == "W")
                {
                    average += Double.Parse(categoryValue);
                    numgames++;
                }
                else if (winOrLoss=="loss" && currentGame[5]=="L")
                {
                    average += Double.Parse(categoryValue);
                    numgames++;
                }
            }
            return Math.Round(average/numgames,2);
        }

        public int GetPlayerStatId(LogJsonWrapper playerStatWrapper)
        {
            if (playerStatWrapper != null)
            {
                return playerStatWrapper.PlayerID;

            }
            return -1;
        }
    }
}
