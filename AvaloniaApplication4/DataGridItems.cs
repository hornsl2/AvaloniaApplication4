using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AvaloniaApplication4
{
    internal class DataGridItems
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

        private static ObservableCollection<TeamScores> previousGames; public ObservableCollection<TeamScores> PreviousGames
        {
            get
            {
                var toReturn = new ObservableCollection<TeamScores>();
                foreach (TeamScores game in previousGames)
                {
                    previousGames.Add(game);
                }
                return toReturn;
            }
            set { previousGames = value; RaiseProperChanged(); }
        }
        public static TeamScores GetPreviousGame(int index)
        {

            return previousGames.ElementAt(index);
        }

        public bool ResetNewGame()
        {
            previousGames.Add(new TeamScores() { Team1Score = this.team1Score, Team2Score = this.team2Score });
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
        public static List<DataGridItems> GetPreviousGames()
        {
            List<DataGridItems> fakePrevious = new List<DataGridItems>();
            fakePrevious.Add(new DataGridItems() { Team1Score = 4, Team2Score = 5 });
            fakePrevious.Add(new DataGridItems() { Team1Score = 2, Team2Score = 3 });
            fakePrevious.Add(new DataGridItems() { Team1Score = 7, Team2Score = 8 });
            fakePrevious.Add(new DataGridItems() { Team1Score = 1, Team2Score = 2 });
            return fakePrevious;

            //return previousGames;
        }
        public static ObservableCollection<int> GetTeam1Score()
        {
            ObservableCollection<int> fakePrevious = new ObservableCollection<int>();
            fakePrevious.Add(1);
            return fakePrevious;

            //return previousGames;
        }
    }









}