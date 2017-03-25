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
    class Destroyer : Ship
    {

        //readonly variables unique to this ship
        private readonly int length = 2;
        private readonly ConsoleColor front = ConsoleColor.Black;
        private readonly ConsoleColor back = ConsoleColor.Green;
        private readonly string bSymbol = " D ";

        //constructor that sets general ship properties to this specific ship
        public Destroyer()
        {
            shipLength = length;
            frontColor = front;
            backColor = back;
            Sunk = false;
            isBattleShip = false;
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


        //method to take in coordinates coordinates for positionList
        public void insertPosition(Position position)
        {
            positionList.Add(position);

        }


    }
}
