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

        [Display(Name = "Points/g Win")]
        public double PpgInWin { get; set; }

        [Display(Name = "Points/g Loss")]
        public double PpgInLoss { get; set; }

        [Display(Name = "TO/g Win")]
        public double ToPgInWin { get; set; }

        [Display(Name = "TO/g Loss")]
        public double ToPgInLoss { get; set; }

        [Display(Name = "Apg Win")]
        public double ApgInWin { get; set; }

        [Display(Name = "Apg Loss")]
        public double ApgInLoss { get; set; }

        [Display(Name = "Rpg Win")]
        public double RpgInWin { get; set; }

        [Display(Name = "Rpg Loss")]
        public double RpgInLoss { get; set; }

        [Display(Name = "FG% Win")]
        public double FgPerInWin { get; set; }

        [Display(Name = "FG% Loss")]
        public double FgPerInLoss { get; set; }

        [Display(Name = "3P% Win")]
        public double ThreePerInWin { get; set; }

        [Display(Name = "3P% Loss")]
        public double ThreePerInLoss { get; set; }
    }
}
