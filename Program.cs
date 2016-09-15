using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_Soccer
{
    class Program
    {
        //Team class has name wins and losses
            public class Team
        {
            public string Name;
            public int Wins;
            public int Losses; 
        }

        //Soccer team inherits from team, and adds specific elements for soccer
        public class SoccerTeam : Team
        {
            public int Draw;
            public int GoalsFor;
            public int GoalsAgainst;
            public int Differential;
            public int Points;

           public SoccerTeam(string sName, int iPoints)
            {
                this.Name = sName;
                this.Points = iPoints;
            }
        }

        //I decided not to implement the game class in my code, maybe I will add it in the future
        public class Game
        {
            public int TeamOneGoals;
            public int TeamTwoGoals;

        }

        //This is the method to change the first letter of the first word to upper case
        static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        //I added this method because I didn't want to have duplicate code. Any time the user inputs an integer
        //it calls this method to do the try/catch exception handeling and returns the value that they enter
        static int IntegerTryCatch ()
        {
            int iNum = 0;
            bool bRuleException = false;

            //as long as they do not enter in a valid integer it will give them the error message and keep bRuleException as false
            while (bRuleException == false)
            {
                try
                {
                    iNum = Convert.ToInt32(Console.ReadLine());
                    bRuleException = true;
                }
                catch (Exception)
                {
                    Console.Write("ERROR! Enter an integer: ");
                }
            }
            return iNum;
        }

        static void Main(string[] args)
        {
            List<SoccerTeam> lTeams = new List<SoccerTeam>();
            List<SoccerTeam> lSortedTeams = new List<SoccerTeam>();
            int iNumTeams = 0;
            string sUserInput;
            string sTeamName;
            int iPoints = 0;
            int iPosition = 1;

                Console.Write("How many teams? ");
          
                //see IntegerTryCatch method above
                iNumTeams = IntegerTryCatch();

            //loops for the number of teams that they want to enter. First enter the team name, and then the amount of points recieved. 
            for(int i=0; i < iNumTeams; i++)
            {
                Console.Write("\nEnter team " + (i+1) + "'s name: ");
                sUserInput = Console.ReadLine(); // Reads in "united states"
                sTeamName = UppercaseFirst(sUserInput); // teamName = "United states"

                Console.Write("Enter " + sTeamName + "'s Points: ");
               
                //see IntegerTryCatch method above
                iPoints = IntegerTryCatch();
            
                //Adds a new object to the lTeams array using the SoccerTeam constructor from the SoccerTeam class
                lTeams.Add(new SoccerTeam(sTeamName, iPoints));
            }

                //sorts teams by decending order based on number of points
                lSortedTeams = lTeams.OrderByDescending(soccerTeam => soccerTeam.Points).ToList();

            //Writes the column headers for the table
            Console.WriteLine("\nHere is the sorted list:\n\n" + 
                                "Position".PadRight(10) + "\tName".PadRight(25) + "\tPoints\n" +
                                "--------".PadRight(10) + "\t----".PadRight(25) + "\t------");

            //foreach loop goes through all of the objects in the array the link statment says that team will be the alias for the SoccerTeam objects
            //in the lSortedTeams list
            foreach (SoccerTeam team in lSortedTeams)
            {
                //For the top three postions I am changing the background colors to "gold", "silver", and "bronze".
                //because this effects the visibility of the characters, I also changed the color of the text to black
                //for the top 3 positions. Everything else is black background and gray foreground. 
                if(iPosition == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if(iPosition == 2)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if(iPosition == 3)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                //Prints the position, name, and points of the object and uses padding and tabs to format the info
                Console.WriteLine(Convert.ToString(iPosition).PadRight(10) + "\t" 
                                    + team.Name.PadRight(25) + "\t" 
                                    + Convert.ToString(team.Points).PadRight(10));
                
                //Increments the position for the next team
                iPosition++;
            }

            Console.Read();
        }
    }
}

