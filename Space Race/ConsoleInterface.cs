﻿using System;
//DO NOT DELETE the two following using statements *********************************
using Game_Logic_Class;
using Object_Classes;


namespace Space_Race
{
    class Console_Class
    {
        /// <summary>
        /// Algorithm below currently plays only one game
        /// 
        /// when have this working correctly, add the abilty for the user to 
        /// play more than 1 game if they choose to do so.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DisplayIntroductionMessage();
            Board.SetUpBoard();

            SpaceRaceGame.NumberOfPlayers = NumberOfPlayersInput();
            // enter playerinput logic here

            SpaceRaceGame.SetUpPlayers();
            bool playerState = false;
            

            while (playerState == false)
            {
                Console.WriteLine("\n\nPress Enter to play a round ...");
                Console.Read();
                SpaceRaceGame.PlayOneRound();
                DisplayCurrentPosition();
                Console.Read();
                for (int i = 0; i < SpaceRaceGame.Players.Count; i++)
                {
                    if (SpaceRaceGame.Players[i].AtFinish == true)
                    {
                        playerState = true;
                        break;
                    }
                }
            }

            if (playerState == true)
            {
                DisplayWinMessage();
            }

            //Console.WriteLine("\n\nPress Enter to play a round ...");
            //Console.Read();
            //SpaceRaceGame.PlayOneRound();
            //Console.WriteLine("{0} on square {1} with {2} yottawatt of power remaining", SpaceRaceGame.Players[0].Name, SpaceRaceGame.Players[0].Position, SpaceRaceGame.Players[0].RocketFuel);
            //Console.WriteLine("{0} on square {1} with {2} yottawatt of power remaining", SpaceRaceGame.Players[1].Name, SpaceRaceGame.Players[1].Position, SpaceRaceGame.Players[1].RocketFuel);

            /*                    
             Set up the board in Board class (Board.SetUpBoard)
             Determine number of players - initally play with 2 for testing purposes 
             Create the required players in Game Logic class
              and initialize players for start of a game             
             loop  until game is finished           
                call PlayGame in Game Logic class to play one round
                Output each player's details at end of round
             end loop
             Determine if anyone has won
             Output each player's details at end of the game
           */


            PressEnter();
            Console.Read();

        }//end Main


        /// <summary>
        /// Display a welcome message to the console
        /// Pre:    none.
        /// Post:   A welcome message is displayed to the console.
        /// </summary>
        static void DisplayIntroductionMessage()
        {
            Console.WriteLine("\n\tWelcome to Space Race.\n");
        } //end DisplayIntroductionMessage

        /// <summary>
        /// Displays a prompt and waits for a keypress.
        /// Pre:  none
        /// Post: a key has been pressed.
        /// </summary>
        static void PressEnter()
        {
            Console.Write("\nPress Enter to terminate program ...");
            Console.Read();
        } // end PressAny

        static void StartRound()
        {
            
        }

        static void DisplayCurrentPosition()
        {
            for (int i = 0; i< SpaceRaceGame.Players.Count; i++)
            {
                Console.WriteLine("{0} on square {1} with {2} unobtainium of power remaining", SpaceRaceGame.Players[i].Name, SpaceRaceGame.Players[i].Position, SpaceRaceGame.Players[i].RocketFuel);
            }
        } // prints status

        static int NumberOfPlayersInput()
        {
            Console.WriteLine("\n\tThis game is for 2 to 6 players.");
            Console.Write("\tHow many players? (2-6): ");
            int playerNum;
            while (int.TryParse(Console.ReadLine(), out playerNum) != true || playerNum < 2 || playerNum > 6)
            {
                Console.WriteLine("\n\nError: invalid number of players entered.");
                Console.WriteLine("\n\tThis game is for 2 to 6 players.");
                Console.Write("\tHow many players? (2-6): ");

            }

            return playerNum;
        }

        static void DisplayWinMessage()
        {
            Console.WriteLine("Someone won");

        }
    }//end Console class
}
