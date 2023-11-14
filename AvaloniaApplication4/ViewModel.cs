using AvaloniaApplication4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication4
{
   internal class ViewModel
    {
         //public IEnumerable<DataGridItems> DataGridItems { get; set; }

        //public GameScoreModel GameScoreModel { get; set; }

        public IEnumerable<GameScoreModel> GameScoreModel { get; set; }

        public GameScore currentMatch { get; set; }

        public IEnumerable<GameScore> previousMatches { get; set; }

        public IEnumerable<string> buttonDetected { get; set; }
    }
}
