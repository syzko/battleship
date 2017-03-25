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
    class Ships
    {
        //Stack as my generic container
        public Stack<Ship> shipsStack { get; set; }

        //object variables
        public Battleship battleship { get; set; }
        public Carrier carrier { get; set; }
        public Cruiser cruiser { get; set; }
        public Destroyer destroyer { get; set; }
        public Sub submarine { get; set;}
        public Ship ship;
        public Ship blankShip;
        public Ship.Position position;

        public Ships()
        {
            //create a new stack to hold ships
            shipsStack = new Stack<Ship>();

            //new instance of a ship
            ship = new Ship();
            blankShip = new Ship();
            blankShip.shipLength = 1;
            blankShip.frontColor = ConsoleColor.White;
            blankShip.backColor = ConsoleColor.Black;
            blankShip.symbol = "   ";

            //new instance of each ship
            battleship = new Battleship();
            carrier = new Carrier();
            cruiser = new Cruiser();
            destroyer = new Destroyer();
            submarine = new Sub();

            //send the ships to the container.
            Add(battleship, carrier, cruiser, destroyer, submarine);

        }


        public void Add(Battleship battleship, Carrier carrier, Cruiser cruiser, Destroyer destroyer, Sub submarine)
        {
            //making sure the stack is empty for pushing new ships in
            Clear(shipsStack);

            //making sure the ships have default properties
            battleship.Reset();
            carrier.Reset();
            cruiser.Reset();
            destroyer.Reset();
            submarine.Reset();

            //push the ships into the stack
            shipsStack.Push(battleship);
            shipsStack.Push(carrier);
            shipsStack.Push(cruiser);
            shipsStack.Push(destroyer);
            shipsStack.Push(submarine);

        }

        public void Clear(Stack<Ship> shipsStack)
        {
            this.shipsStack = shipsStack;

            //loop to pop and empty stack
            for (int i = 0; i < shipsStack.Count(); i++)
            {
                shipsStack.Pop();
            }
        }

        
        //Attack which reads in the dropBomb() coordinates //input validation is in other classes
        public void Attack(int x,int y, Ship gridship)
        {
            //create a position for comparing
            position = ship.Place(new Ship.Position(x, y));

            //Compare ship from grid to the different ship types, search for that position in the positionList and remove, and print messages  
            if (gridship == battleship && battleship.positionList.Count() != 0)
            {
                for (int i = 0; i < battleship.positionList.Count(); i++)
                {
                    if (battleship.positionList[i].xPos == position.xPos && battleship.positionList[i].yPos == position.yPos)
                    {
                        battleship.positionList.RemoveAt(i);
                        Console.WriteLine("Hit!");
                    }
                }
                if (battleship.positionList.Count() == 0)
                {
                    Console.WriteLine("You sunk this ship!");
                    battleship.Sunk = true;
                }

            }
            else if(gridship == carrier && carrier.positionList.Count() != 0)
            {
                for (int i = 0; i < carrier.positionList.Count(); i++)
                {
                    if (carrier.positionList[i].xPos == position.xPos && carrier.positionList[i].xPos == position.xPos)
                    {
                        carrier.positionList.RemoveAt(i);
                        Console.WriteLine("Hit!");
                    }
                }
                if (carrier.positionList.Count() == 0)
                {
                    Console.WriteLine("You sunk this ship!");
                    carrier.Sunk = true;
                }
            }

            else if (gridship == cruiser && cruiser.positionList.Count() != 0)
            {
                for (int i = 0; i < cruiser.positionList.Count(); i++)
                {
                    if (cruiser.positionList[i].xPos == position.xPos && cruiser.positionList[i].xPos == position.xPos)
                    {
                        cruiser.positionList.RemoveAt(i);
                        Console.WriteLine("Hit!");
                    }
                }
                if (cruiser.positionList.Count() == 0)
                {
                    Console.WriteLine("You sunk this ship!");
                    cruiser.Sunk = true;
                }

            }
            else if (gridship == destroyer && destroyer.positionList.Count() != 0)
            {
                for (int i = 0; i < destroyer.positionList.Count(); i++)
                {
                    if (destroyer.positionList[i].xPos == position.xPos && destroyer.positionList[i].xPos == position.xPos)
                    {
                        destroyer.positionList.RemoveAt(i);
                        Console.WriteLine("Hit!");
                    }
                }
                if (destroyer.positionList.Count() == 0)
                {
                    Console.WriteLine("You sunk this ship!");
                    destroyer.Sunk = true;
                }

            }
            else if (gridship == submarine && submarine.positionList.Count() != 0)
            {
                for (int i = 0; i < submarine.positionList.Count(); i++)
                {
                    if (submarine.positionList[i].xPos == position.xPos && submarine.positionList[i].xPos == position.xPos)
                    {
                        submarine.positionList.RemoveAt(i);
                        Console.WriteLine("Hit!");
                    }
                }

                if (submarine.positionList.Count() == 0)
                {
                    Console.WriteLine("You sunk this ship!");
                    submarine.Sunk = true;
                }

            }
            else if (gridship == blankShip)
            {
                Console.WriteLine("Miss!");
            }
           

            System.Threading.Thread.Sleep(1000);
        }
    }
}
