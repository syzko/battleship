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
    class Program
    {
        static void Main(string[] args)
        {
            var game = new BattleShipGame(10);
            ConsoleKeyInfo response;
            do
            {
                game.Reset();
                game.Play();

                Console.WriteLine("Do you want to play again (y/n)");
                response = Console.ReadKey();

            } while (response.Key == ConsoleKey.Y);

        }
    }
}
