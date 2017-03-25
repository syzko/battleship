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
    class Grid
    {

        public int size { get; set; }
        public Ship[,] gameGrid;
        public int[,] hitArray;
        public int hitCounter = 0;

        //object variables
        public Ships theirShips;
        public Ships yourShips;
        public Ship ship;
        public Ship.Position position;
        public Ship blankShip;
        public Ship missShip;
        public Ship hitShip;

        public Grid(int s)
        {
            //initializes parameter from main for use in the class
            size = s;

            //ship variable to set direction and coordinates
            ship = new Ship();

            //create blank ship to place for initializing grid
            blankShip = new Ship();
            blankShip.shipLength = 1;
            blankShip.frontColor = ConsoleColor.White;
            blankShip.backColor = ConsoleColor.Black;
            blankShip.symbol = "   ";

            //create ship variables for hit and miss
            hitShip = new Ship();
            hitShip.shipLength = 1;
            hitShip.frontColor = ConsoleColor.Red;
            hitShip.backColor = ConsoleColor.Black;
            hitShip.symbol = " X ";
        
            missShip = new Ship();
            missShip.shipLength = 1;
            missShip.frontColor = ConsoleColor.White;
            missShip.backColor = ConsoleColor.Black;
            missShip.symbol = " X ";


            //create and initialize gameGrid
            gameGrid = new Ship[s, s];
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    gameGrid[i, j] = blankShip;
                }
            }
            
            //create and initialize hitArray
            hitArray = new int[s, s];
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    hitArray[i, j] = 0;
                }
            }


            //calls method to place ships in gameGrid
            placeShips();
        }


        internal void placeShips()
        {
            //create random class variable
            Random rand = new Random();

            theirShips = new Ships(); 

            //variable for boat length
            int boatLength = 0;

            //variable to exit loop when stack is out of boats
            bool emptyStack = false;

            //loop to place ships until gone
            while (!emptyStack)
            {
                //counter to verify that there are no collisions
                int goodSpace = 0;

                //assigns boatLength variable based on ship in the Stack
                boatLength = theirShips.shipsStack.Peek().shipLength;
                
                //generates random cooridinates
                int x = rand.Next(1, 10);
                int y = rand.Next(1, 10);
                
                //generates a random number for use in the assignDirection() method
                int directionNumber = rand.Next(1, 10);

                ship.direction = new Ship.ShipDirection();
                ship.direction = ship.assignDirection(directionNumber);

                //assigns the ship at the top of the stack a direction 
                theirShips.shipsStack.Peek().direction = new Ship.ShipDirection();
                theirShips.shipsStack.Peek().direction = ship.direction;

                //checks for direction and valid starting coordinate
                if (gameGrid[y, x] == blankShip && theirShips.shipsStack.Peek().direction == Ship.ShipDirection.Horizontal)
                {
                    //check to make sure variables stay within scope
                    if (y + boatLength < 11)
                    {
                        //checks for more valid spaces
                        for (int i = 0; i < boatLength; i++)
                        {
                            if (gameGrid[y + i, x] == blankShip)
                            {
                                goodSpace++;
                            }
                        }
                    }

                    //if no collisions places boat in grid, adds to the ship's position array, and pops it out of the stack
                    if (goodSpace == boatLength)
                    {
                        for (int i = 0; i < boatLength; i++)
                        {
                            //Creates a new position variable
                            position = ship.Place(new Ship.Position(y + i, x));

                            //checks for the ship type to place in proper position list
                            switch (theirShips.shipsStack.Peek().symbol)
                            {
                                case " D ":
                                    theirShips.destroyer.insertPosition(position);
                                    break;
                                case " S ":
                                    theirShips.submarine.insertPosition(position);
                                    break;
                                case " B ":
                                    theirShips.battleship.insertPosition(position);
                                    break;
                                case " A ":
                                    theirShips.carrier.insertPosition(position);
                                    break;
                                case " C ":
                                    theirShips.cruiser.insertPosition(position);
                                    break;
                            }

                            gameGrid[y + i, x] = theirShips.shipsStack.Peek();

                        }
                        theirShips.shipsStack.Pop();
                    }
                }

                //same as the last block of code, but for different direction
                else if (gameGrid[y, x] == blankShip && theirShips.shipsStack.Peek().direction == Ship.ShipDirection.Vertical)
                {

                    if (x + boatLength < 11)
                    {
                        for (int i = 0; i < boatLength; i++)
                        {
                            if (gameGrid[y, x + i] == blankShip)
                            {
                                goodSpace++;
                            }
                        }
                    }

                    if (goodSpace == boatLength)
                    {
                        for (int i = 0; i < boatLength; i++)
                        {
                            //Creates a new position variable
                            position = ship.Place(new Ship.Position(y, x + i));

                            //checks for the ship type to place in proper position list
                            switch (theirShips.shipsStack.Peek().symbol)
                            {
                                case " D ":
                                    theirShips.destroyer.position = position;
                                    theirShips.destroyer.insertPosition(theirShips.destroyer.position);
                                    break;
                                case " S ":
                                    theirShips.submarine.position = position;
                                    theirShips.submarine.insertPosition(theirShips.submarine.position);
                                    break;
                                case " B ":
                                    theirShips.battleship.position = position;
                                    theirShips.battleship.insertPosition(theirShips.battleship.position);
                                    break;
                                case " A ":
                                    theirShips.carrier.position = position;
                                    theirShips.carrier.insertPosition(theirShips.carrier.position);
                                    break;
                                case " C ":
                                    theirShips.cruiser.position = position;
                                    theirShips.cruiser.insertPosition(theirShips.cruiser.position);
                                    break;
                            }

                            gameGrid[y, x + i] = theirShips.shipsStack.Peek();
                        }
                        theirShips.shipsStack.Pop();
                    }
                }


                //check for empty stack to exit the loop
                if (theirShips.shipsStack.Count() == 0)
                {
                    emptyStack = true;
                }
            }

        }

        //method to print the board and its contents
        internal void Draw()
        {
            //Printing the letters at the top of the board
            Console.WriteLine("     A    B    C    D    E    F    G    H    I    J  ");



            //For loop to print and format the board
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine("   #---##---##---##---##---##---##---##---##---##---#");

                //determines spacing for numbers down the side of the board
                if (i + 1 < 10)
                {
                    Console.Write(i + 1 + "  ");
                }
                else if (i + 1 >= 10)
                {
                    Console.Write(i + 1 + " ");
                }

                //For loop used to print and further format the board
                for (int j = 0; j < size; j++)
                {

                    Console.Write("|");

                    //determines the colors to be used depending on the ship
                    Console.BackgroundColor = gameGrid[i, j].backColor;
                    Console.ForegroundColor = gameGrid[i, j].frontColor;

                    //writes the ship's symbol
                    Console.Write(gameGrid[i, j].symbol);


                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("|");

                }
                Console.WriteLine();
            }
            Console.WriteLine("   #---##---##---##---##---##---##---##---##---##---#");
        }

        internal void Reset()
        {
            //clean the screen
            Console.Clear();

            //clear their shipstack
            theirShips.Clear(theirShips.shipsStack);

            //reset gameGrid
            gameGrid = new Ship[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    gameGrid[i, j] = blankShip;
                }
            }

            //reset hitArray
            hitArray = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    hitArray[i, j] = 0;
                }
            }
            hitCounter = 0;

            //calls method to place ships in gameGrid
            placeShips();

        }

        internal void DropBomb(int x, int y)
        {

            //variable to mark hit or miss in array
            int hitOrMiss = 0;

            //call to the attack method
            theirShips.Attack(y, x, gameGrid[y, x]);

            //checks for duplicates & determines how to alter grid
            if (gameGrid[y, x] == blankShip)
            {
                //replaces blankShip with missShip
                gameGrid[y, x] = missShip;

                //assigns a miss to the hitArray
                hitOrMiss = -1;
                hitArray[y, x] = hitOrMiss;

            }
            else if (gameGrid[y, x] == missShip || gameGrid[y, x] == hitShip)
            {
                //error message for ship already hit
                Console.WriteLine("This position has already been used!"); 
                System.Threading.Thread.Sleep(1000);

                //cleans and updates screen
                Console.Clear();
                Draw();

            }
            else
            {
                //replaces ship with hitShip
                gameGrid[y, x] = hitShip;

                //assigns a hit to the array
                hitOrMiss = 1;
                hitArray[y, x] = hitOrMiss;
                hitCounter++;

            }

            

            //cleans and updates screen
            Console.Clear();
            Draw();

        }


    }

}
