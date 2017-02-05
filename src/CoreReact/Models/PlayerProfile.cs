using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace CoreReact.Models
{
    public class PlayerProfile
    {
        public int Id { get; set; }

        [Display(Name="First Name")]
        public String FirstName { get; set; }
        
        [Display(Name="Last Name")]
        public String LastName { get; set; }

        [Display(Name="Player Name")]
        public String FullName => FirstName + LastName;

        [Display(Name="Player ID")]
        public int PlayerId { get; set; }

        [Display(Name = "Points/game in Win")]
        public double PpgInWin { get; set; }

        [Display(Name = "Points/game in Loss")]
        public double PpgInLoss { get; set; }

        [Display(Name = "Turnovers/game in Win")]
        public double ToPgInWin { get; set; }

        [Display(Name = "Turnovers/game in Loss")]
        public double ToPgInLoss { get; set; }
    }
}
