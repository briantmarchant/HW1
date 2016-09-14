using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1_Soccer
{
    class Program
    {
            public class Team
        {
            public string Name;
            public int Wins;
            public int Losses; 
        }

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

        static int IntegerTryCatch ()
        {
            int iNumber = 0;
            bool bRuleException = false;

            while (bRuleException == false)
            {
                try
                {
                    iNumber = Convert.ToInt32(Console.ReadLine());
                    bRuleException = true;
                }
                catch (Exception)
                {
                    Console.Write("ERROR! Enter an integer: ");
                }
            }
            return iNumber;
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
          
                iNumTeams = IntegerTryCatch();

            for(int i=0; i < iNumTeams; i++)
            {
                Console.Write("\nEnter team " + (i+1) + "'s name: ");
                sUserInput = Console.ReadLine(); // Reads in "united states"
                sTeamName = UppercaseFirst(sUserInput); // teamName = "United states"

                Console.Write("Enter " + sTeamName + "'s Points: ");
                
                
                iPoints = IntegerTryCatch();
            
                lTeams.Add(new SoccerTeam(sTeamName, iPoints));
            }

            //sorts teams by decending order based on number of points
            lSortedTeams = lTeams.OrderByDescending(soccerTeam => soccerTeam.Points).ToList();

            Console.WriteLine("\nHere is the sorted list:\n\n" + 
                                "Position".PadRight(10) + "\tName".PadRight(25) + "\tPoints\n" +
                                "--------".PadRight(10) + "\t----".PadRight(25) + "\t------");

            //foreach loop goes through all of the objects in the array
            foreach (SoccerTeam team in lSortedTeams)
            {
                //For the top three postions I am changing the background colors to "gold", "silver", and "bronze".
                //because this effects the ability to read the characters, I also changed the color of the text to black
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
                Console.WriteLine(Convert.ToString(iPosition).PadRight(10) + "\t" 
                                    + team.Name.PadRight(25) + "\t" 
                                    + Convert.ToString(team.Points).PadRight(10));
                iPosition++;
            }

            Console.Read();
        }
    }
}

