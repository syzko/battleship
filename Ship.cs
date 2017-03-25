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
    class Ship
    {
        //struct for coordinates
        public struct Position
        {
            public int xPos, yPos;

            public Position(int x, int y)
            {
                xPos = x;
                yPos = y;
            }
        };

        
        //variables for all ships
        public int shipLength { get; set; }
        public ConsoleColor frontColor { get; set; }
        public ConsoleColor backColor { get; set; }
        public bool Sunk { get; set; }
        public bool isBattleShip { get; set; }
        public string symbol { get; set; }

        //variable to take in positions
        public Position position { get; set; }
        
        //enum for direction placement
        public enum ShipDirection
        {
            Vertical = 0,
            Horizontal
        }
        
        //variable to set coordinates
        public ShipDirection direction { get; set; }

        //list to hold game grid positions
        public List<Position> positionList { get; set; }

        public Ship()
        {
            

        }

        

        //method to randomize ship direction. Called from placeShips() in Grid.cs
        public ShipDirection assignDirection(int x)
        {
            if (x > 0 && x < 6)
            {
                direction = ShipDirection.Horizontal;
            }
            else
            {
                direction = ShipDirection.Vertical;
            }

            return direction;
        }

        //method to set and return position
        public Position Place(Position position)
        {
            this.position = position;
            return position;
        }

    }
}
