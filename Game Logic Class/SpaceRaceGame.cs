﻿using System.Drawing;
using System.ComponentModel;
using Object_Classes;


namespace Game_Logic_Class
{
    public static class SpaceRaceGame
    {
        // Minimum and maximum number of players.
        public const int MIN_PLAYERS = 2;
        public const int MAX_PLAYERS = 6;

        private static int numberOfPlayers = 2;  //default value for test purposes only 
        public static int NumberOfPlayers
        {
            get
            {
                return numberOfPlayers;
            }
            set
            {
                numberOfPlayers = value;
            }
        }

        public static string[] names = { "One", "Two", "Three", "Four", "Five", "Six" };  // default values

        // Only used in Part B - GUI Implementation, the colours of each player's token
        private static Brush[] playerTokenColours = new Brush[MAX_PLAYERS] { Brushes.Yellow, Brushes.Red,
                                                                       Brushes.Orange, Brushes.White,
                                                                      Brushes.Green, Brushes.DarkViolet};
        /// <summary>
        /// A BindingList is like an array which grows as elements are added to it.
        /// </summary>
        private static BindingList<Player> players = new BindingList<Player>();
        public static BindingList<Player> Players
        {
            get
            {
                return players;
            }
        }

        // The pair of die
        private static Die die1 = new Die(), die2 = new Die();


        /// <summary>
        /// Set up the conditions for this game as well as
        ///   creating the required number of players, adding each player 
        ///   to the Binding List and initialize the player's instance variables
        ///   except for playerTokenColour and playerTokenImage in Console implementation.
        ///   
        ///     
        /// Pre:  none
        /// Post:  required number of players have been initialsed for start of a game.
        /// </summary>
        public static void SetUpPlayers()
        {
            // for number of players
            //      create a new player object
            //      initialize player's instance variables for start of a game
            //      add player to the binding list
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                players.Add(new Player(names[i])); // initialise and add to bindinglist
                players[i].Location = Board.Squares[0];
                players[i].PlayerTokenColour = playerTokenColours[i];
            }
        }

        /// <summary>
        ///  Plays one round of a game
        /// </summary>
        public static void PlayOneRound()
        {
            for (int i = 0; i < players.Count; i++)
            {
                PlayOneTurn(i);
            }// end loop for each player

        } // end PlayOneRound (Everybody)

        public static void PlayOneTurn(int i)
        {
            if (players[i].RocketFuel != 0) players[i].Play(die1, die2);
            for (int j = 0; j < Board.Squares.Length; j++)
            {
                if (Board.Squares[j].Number == players[i].Position)
                {
                    players[i].Location = Board.Squares[j];
                    break;
                }
            }// end loop for check each squares
            bool onUnique = false;
            for (int checkUnique = 0; checkUnique < Board.special.Length; checkUnique++)
            {
                if (players[i].Location.Number == Board.special[checkUnique])
                {
                    players[i].Location.LandOn(players[i]); // Square the player is on will run LandOn which updates location, position and remaining fuel
                    onUnique = true;
                }// if special hole

            }

            if (onUnique == false)
            {
                players[i].ConsumeFuel(2);
            }// if ordinary hole


            if (players[i].Position >= Board.FINISH_SQUARE_NUMBER)
            {
                players[i].Position = Board.FINISH_SQUARE_NUMBER;
                // add end game
            }

            if (players[i].RocketFuel == 0) // remove player when fuel is 0
            {
                System.Console.WriteLine("{0} is removed as there is zero fuel left.", players[i].Name);
            } // end remove player

        } // end PlayOneTurn ( one player )

        public static bool AllPlayerFuel()
        {
            int[] FuelCheck = new int[NumberOfPlayers];
            int totalFuel = 0;

            for (int i = 0; i < NumberOfPlayers; i++)
            {
                if (Players[i].RocketFuel == 0) FuelCheck[i] = 1;
                else FuelCheck[i] = 0;
                totalFuel += FuelCheck[i];
            }


            if (totalFuel == NumberOfPlayers) return true;

            else return false;
        } // end AllPlayerFuel() to check if all players still have fuel left


    }//end SnakesAndLadders
}