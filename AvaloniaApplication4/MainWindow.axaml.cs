using Avalonia.Controls;
using AvaloniaApplication4.Models;
using ButtonFiles;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AvaloniaApplication4
{
    public partial class MainWindow : Window
    {

        private readonly ViewModel viewModel;
        public MainWindow()
        {

            Buttons buttons = new Buttons();
            List<string> boolList = buttons.ButtonLogic();


            GameScore GameScore = new GameScore();
            List<GameScoreModel> GameScoreModel = new List<GameScoreModel>()
            {
                new GameScoreModel(){

                Team1Score=1,
                Team2Score=2,

                }
            };
            IEnumerable<GameScore> previousMatches = GameScore.GetFakePreviousGames();


            InitializeComponent();



            this.viewModel = new ViewModel()
            {
                GameScoreModel = GameScoreModel,
                previousMatches=previousMatches,
                buttonDetected=boolList
            };

          
            


            this.DataContext = this.viewModel;
            //this.viewModel.GameScoreModel.ToList().ElementAt(0).Team1Score = 10;
            this.viewModel.GameScoreModel.ToList().ElementAt(0).Team1Score = buttons.team1Score;
            this.viewModel.GameScoreModel.ToList().ElementAt(0).Team2Score = buttons.team2Score;



            // myGrid.DataContext= Employee.GetEmployees();

        }
    }

 


    public class Employee : INotifyPropertyChanged
    {

        private string? name; public string Name
        {
            get { return name; }
            set { name = value; RaiseProperChanged(); }
        }
        private string? title; public string Title
        {
            get { return title; }
            set { title = value; RaiseProperChanged(); }
        }
        public static Employee GetEmployee()
        {
            var emp = new Employee()
            {
                Name = "Waqas",
                Title = "Software Engineer"
            };
            return emp;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseProperChanged([CallerMemberName] string caller = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
        public static ObservableCollection<Employee> GetEmployees()
        {
            var employees = new ObservableCollection<Employee>();
            employees.Add(new Employee() { Name = "Ali", Title = "Developer" });
            employees.Add(new Employee() { Name = "Ahmed", Title = "Programmer" });
            employees.Add(new Employee() { Name = "Amjad", Title = "Desiner" });
            employees.Add(new Employee() { Name = "Waqas", Title = "Programmer" });
            employees.Add(new Employee() { Name = "Bilal", Title = "Engineer" });
            employees.Add(new Employee() { Name = "Waqar", Title = "Manager" });
            return employees;
        }

    }//end class Employee


    public class TeamScores : INotifyPropertyChanged
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
            previousGames.Add(new TeamScores() { team1Score = this.team1Score, team2Score = this.team2Score });
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
        public static ObservableCollection<TeamScores> GetPreviousGames()
        {
            ObservableCollection<TeamScores> fakePrevious = new ObservableCollection<TeamScores>();
            fakePrevious.Add(new TeamScores() { team1Score = 4, team2Score = 5 });
            fakePrevious.Add(new TeamScores() { team1Score = 2, team2Score = 3 });
            fakePrevious.Add(new TeamScores() { team1Score = 7, team2Score = 8 });
            fakePrevious.Add(new TeamScores() { team1Score = 1, team2Score = 2 });
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

    }//end class TeamScore










}
