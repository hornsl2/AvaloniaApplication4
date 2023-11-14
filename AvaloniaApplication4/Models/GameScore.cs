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
    class GameScore
    {

        private int team1Score; public int Team1Score
        {
            get { return team1Score; }
            set { team1Score = value; RaiseProperChanged(); }
        }
        private int team2Score; public int Team2Score
        {
            get { return team2Score; }
            set { team2Score = value; RaiseProperChanged(); }
        }

        private int duration; public int Duration
        {
            get { return duration; }
            set { duration = value; RaiseProperChanged(); }
        }

        private string gameType; public string GameType
        {
            get { return gameType; }
            set { gameType = value; RaiseProperChanged(); }
        }


        private static ObservableCollection<GameScore> previousGames; public ObservableCollection<GameScore> PreviousGames
        {
            get
            {
                var toReturn = new ObservableCollection<GameScore>();
                foreach (GameScore game in previousGames)
                {
                    previousGames.Add(game);
                }
                return toReturn;
            }
            set { previousGames = value; RaiseProperChanged(); }
        }
        public static GameScore GetPreviousGame(int index)
        {

            return previousGames.ElementAt(index);
        }

        public bool ResetNewGame()
        {
            previousGames.Add(new GameScore() { team1Score = this.team1Score, team2Score = this.team2Score });
            team1Score = 0;
            team2Score = 0;
            return true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseProperChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }

        //public static ObservableCollection<GameScore> GetFakePreviousGames()
        public static IEnumerable<GameScore> GetFakePreviousGames()
        {
            List<GameScore> fakePrevious = new List<GameScore>();
            // ObservableCollection<GameScore> fakePrevious = new ObservableCollection<GameScore>();
            fakePrevious.Add(new GameScore() { team1Score = 4, team2Score = 5 });
            fakePrevious.Add(new GameScore() { team1Score = 2, team2Score = 3 });
            fakePrevious.Add(new GameScore() { team1Score = 7, team2Score = 8 });
            fakePrevious.Add(new GameScore() { team1Score = 1, team2Score = 2 });
            return fakePrevious;

            //return previousGames;
        }
    }
}
