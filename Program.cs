using System;
using System.Collections.Generic;

namespace WarCardGame
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.SetWindowSize(100, 40);
            Console.WriteLine("Welcome to the WAR CARD GAME\n");

            Console.WriteLine("|| HOW TO PLAY:\n");                            
            Console.WriteLine(" - You and the computer are dealt one half of a shuffled deck of cards.".PadLeft(1));
            Console.WriteLine(" - Each turn, each player draws a card from their deck and lays it face up.".PadLeft(1));
            Console.WriteLine(" - The player that draws the card with higher value gets both cards.".PadLeft(1));
            Console.WriteLine(" - Winning cards return to the winner's deck.".PadLeft(1));
            Console.WriteLine(" - If there is a draw, the cards are thrown away\n".PadLeft(1));

            Console.WriteLine("|| HOW TO WIN:\n");
            Console.WriteLine(" - The player that runs out of cards first, wins!\n".PadLeft(1));

            Console.WriteLine("|| CONTROLS:\n");
            Console.WriteLine(" - Press enter to start the next hand, and both cards for the user and computer will be drawn\n".PadLeft(1));

            
            while (true)
            {
                // variable to hold number of hands to show total hands once the game is finished
                int totalHands = 0;

                // create WarDeck, filling it with WarCards
                WarDeck mainDeck = new WarDeck();
                mainDeck.GenerateDeck();
                

                // Split deck into 2 for player and computer
                WarDeck yourDeck = new WarDeck();
                WarDeck computerDeck = new WarDeck();

                bool isPlayerTurn = false;

                foreach (WarCard card in mainDeck.deck)
                {
                    if (isPlayerTurn)
                    {
                        yourDeck.deck.Add(card);
                    }
                    else
                    {
                        computerDeck.deck.Add(card);
                    }
                    // switch between the player and computer after each loop
                    isPlayerTurn = !isPlayerTurn;
                }

                // Draw loop (as long as both decks still have at least 1 card)
                while (!yourDeck.IsEmpty() && !computerDeck.IsEmpty())
                {
                    Console.ReadLine();
                    // player and computer both draw cards
                    WarCard playerDraw = yourDeck.DrawCard();
                    WarCard computerDraw = computerDeck.DrawCard();
                    totalHands++;
                    //clear each previous hand
                    Console.Clear();
                    //0 is the suit, 1 is the face as set in Card.cs
                    Console.WriteLine("Player has drawn: {0} of {1}.\n", playerDraw.face, playerDraw.suit);
                    Console.WriteLine("Computer has drawn: {0} of {1}.\n", computerDraw.face, computerDraw.suit);

                    if ((int)playerDraw.face > (int)computerDraw.face)
                    {
                        Console.WriteLine("You have won this hand.\nThe cards have been added to your deck.\n\n");
                        yourDeck.PlaceInDeck(playerDraw, computerDraw);
                    }
                    else if ((int)playerDraw.face < (int)computerDraw.face)
                    {
                        Console.WriteLine("The Computer has won this hand.\nThe cards have been added to the computer's deck.\n");
                        computerDeck.PlaceInDeck(playerDraw, computerDraw);
                    }
                    //WAR CASE: when there's a draw, each player draws 5 cards, and the 5th card for each player decides
                    //who wins all the cards drawn in the hand. Whoever has the higher face value card with the 5th card
                    //will add all the 
                    //cards their opponent drew in the hand (5) plus the original card that was drawn that caused the War
                    //Case. The winner will also add all cards the winner drew in the War Case + the initial card.

                    //BUG: the reason the game can end on a draw is because once a player or comp deck gets to 1 card and they 
                    //play it, there deck is now empty and the next hand they have no cards. Something more eleborate 
                    //would have to be coded to handle a war case, and a war case when the player/comp has less than the 
                    //amount of cards used in the war case.
                    
                    //the War logic would go here in the else block below.
                    else
                    {
                        Console.WriteLine("It's a draw!\n");
                    }
                }
                if (yourDeck.IsEmpty())
                {
                    Console.WriteLine("After a total of {0} hands, the player has won!\n\n", totalHands);
                }
                else
                {
                    Console.WriteLine("After a total of {0} hands, the computer has won!\n\n", totalHands);
                }
                string userInput;
                do
                {
                    Console.WriteLine("Would you like to play again?\nIf yes, type 'y'. If not, type 'n'.\n");
                    userInput = Console.ReadLine();
                } while (userInput != "n" && userInput != "y");

                if (userInput == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nGreat! Let's play again!\n");
                    Console.WriteLine("|| CONTROLS:\n");
                    Console.WriteLine(" - Press enter to start the next hand, and both cards for the user and computer will be drawn\n".PadLeft(1));
                }
            }           
        }  
    }
}

