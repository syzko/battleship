/*////////////////////////////////////////////
// Programmer: Steven Bensinger			    //
// Course: GSD311				            //
// Program Name: Seminar 4 Assignment 2     //
// Created: 03/13/2017				        //
// Last Modified: 03/15/2017			    //
////////////////////////////////////////////*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StevenBensinger_Seminar4_ProgrammingAssignment2
{
    internal class BattleShipGame
    {
        private Grid grid;

        public BattleShipGame(int gridSize)
        {
            grid = new Grid(gridSize);

        }

        internal void Reset()
        {
            grid.Reset();

        }

        internal void Play()
        {

            //loop to check if the game is over
            while (grid.hitCounter != 21)
            {
                //displays grid
                grid.Draw();

                //variable to exit validation loop
                bool goodInput = false;

                //declare and intialize the x, y parameters for DropBomb method
                int x = 0;
                int y = 0;


                //while loop to validate input
                while (!goodInput)
                {
                    //prompt user & assign their guess
                    Console.Write("Enter your guess: ");
                    var guess = Console.ReadLine();

                    //variables to store the 2 parts of their guess
                    var guess1 = " ";
                    var guess2 = " ";


                    //Checks string length to prevent errors and assigns y based on user input
                    if (guess.Length > 2)
                    {
                        guess1 = guess.Substring(0, 1);
                        guess2 = guess.Substring(1, 2);
                        Int32.TryParse(guess2, out y);
                    }
                    else if (guess.Length > 0 && guess.Length == 2)
                    {
                        guess1 = guess.Substring(0, 1);
                        guess2 = guess.Substring(1, 1);
                        Int32.TryParse(guess2, out y);
                    }
                    else
                    {
                        y = -1;
                    }


                    //Sets x based on user input
                    switch (guess1)
                    {
                        case "A":
                            x = 0;
                            break;
                        case "B":
                            x = 1;
                            break;
                        case "C":
                            x = 2;
                            break;
                        case "D":
                            x = 3;
                            break;
                        case "E":
                            x = 4;
                            break;
                        case "F":
                            x = 5;
                            break;
                        case "G":
                            x = 6;
                            break;
                        case "H":
                            x = 7;
                            break;
                        case "I":
                            x = 8;
                            break;
                        case "J":
                            x = 9;
                            break;
                        default:
                            x = -1;
                            break;

                    }

                    //decrements y for use as a grid coordinate
                    y--;

                    //Determines whether or not input is a valid guess
                    if (x > -1 && x < 10 && y > -1 && y < 10)
                    {
                        goodInput = true;
                    }
                    else
                    {
                        //error message for invalid input
                        Console.WriteLine("This is not valid input!");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        grid.Draw();
                        goodInput = false;
                    }
                }

                //call to the DropBomb method with user input    
                grid.DropBomb(x, y);




                //clean the screen
                Console.Clear();

            }
        }
    }
}
