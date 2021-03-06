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
    class Battleship : Ship
    {
        //readonly variables unique to this ship
        private readonly int length = 4;
        private readonly ConsoleColor front = ConsoleColor.Black;
        private readonly ConsoleColor back = ConsoleColor.Yellow;
        private readonly string bSymbol = " B ";


        //constructor that sets general ship properties to this specific ship
        public Battleship()
        {
            shipLength = length;
            frontColor = front;
            backColor = back;
            Sunk = false;
            isBattleShip = true;
            symbol = bSymbol;
            positionList = new List<Position>();

        }

        //method to reset position and status
        public void Reset()
        {
            Sunk = false;
            position = new Position();
            direction = new ShipDirection();
            positionList.Clear();
        }


        //method to take in coordinates for positionList
        public void insertPosition(Position position)
        {
            positionList.Add(position);

        }

       
    }
}
