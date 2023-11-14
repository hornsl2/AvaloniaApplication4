using AvaloniaApplication4.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication4.Models
{
    class GameScoreModel
    { 
        
        private int team1Score; public int Team1Score
        {
            get { return team1Score; }
            set { team1Score = value; }
        }
        private int team2Score; public int Team2Score
        {
            get { return team2Score; }
            set { team2Score = value;  }
        }

       //public GameScore currentMatch { get; set; }

      // public List<GameScore> previousMatches { get; set; }

       
    }
    
}
