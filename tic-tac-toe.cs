using System;
namespace CSharpWork
{
    class tic_tac_toe
    {
        static char[,] PlayField =
        {
            {'1', '2', '3' },
            {'4', '5', '6' },
            {'7', '8', '9'}
        };

        static int turns = 0;
        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool InputCorrect = true;

            // run code as long as the program runs
            do
            {
                if (player == 2)
                {
                    player = 1;
                    EnterXorO(player, input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO(player, input);
                }
                setField();

                #region
                // check for winner
                char[] playerChars = { 'X', 'O' };
                foreach(char playerChar in playerChars)
                {
                    if (((PlayField[0,0] == playerChar)&& (PlayField[0,1] == playerChar) && (PlayField[0,2] == playerChar))
                        || ((PlayField[1, 0] == playerChar) && (PlayField[1, 1] == playerChar) && (PlayField[1, 2] == playerChar))
                        || ((PlayField[2, 0] == playerChar) && (PlayField[2, 1] == playerChar) && (PlayField[2, 2] == playerChar))
                        || ((PlayField[0, 0] == playerChar) && (PlayField[1, 0] == playerChar) && (PlayField[2, 0] == playerChar))
                        || ((PlayField[0, 1] == playerChar) && (PlayField[1, 1] == playerChar) && (PlayField[2, 1] == playerChar))
                        || ((PlayField[0, 2] == playerChar) && (PlayField[1, 2] == playerChar) && (PlayField[2, 2] == playerChar))
                        || ((PlayField[0, 0] == playerChar) && (PlayField[1, 1] == playerChar) && (PlayField[2, 2] == playerChar))
                        || ((PlayField[0, 2] == playerChar) && (PlayField[1, 1] == playerChar) && (PlayField[2, 0] == playerChar))
                        )
                    {
                        if (playerChar == 'X')
                        {
                            Console.WriteLine("\n Player 1 is the winner!");
                        }
                        else
                        {
                            Console.WriteLine("\n Player 2 is the winner!");
                        }

                        // reset field here
                        Console.WriteLine("Press any key to reset");
                        Console.ReadKey();
                        player = 1;
                        resetField();
                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("\n It is a draw!");
                        Console.WriteLine("\n Press any key to reset the game");
                        Console.ReadKey();
                        player = 1;
                        resetField();
                        break;
                    }
                }
                
                #endregion

                #region
                // this region tests whether the area is already taken!
                do
                {
                    Console.Write("\n Player {0}, Choose where to place the sign: ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid number");
                    }

                    if ((input == 1) && (PlayField[0, 0] == '1'))
                        InputCorrect = true;
                    else if ((input == 2) && (PlayField[0, 1] == '2'))
                        InputCorrect = true;
                    else if ((input == 3) && (PlayField[0, 2] == '3'))
                        InputCorrect = true;
                    else if ((input == 4) && (PlayField[1, 0] == '4'))
                        InputCorrect = true;
                    else if ((input == 5) && (PlayField[1, 1] == '5'))
                        InputCorrect = true;
                    else if ((input == 6) && (PlayField[1, 2] == '6'))
                        InputCorrect = true;
                    else if ((input == 7) && (PlayField[2, 0] == '7'))
                        InputCorrect = true;
                    else if ((input == 8) && (PlayField[2, 1] == '8'))
                        InputCorrect = true;
                    else if ((input == 9) && (PlayField[2, 2] == '9'))
                        InputCorrect = true;
                    else
                    {
                        Console.WriteLine("The area is already taken, please select another field!");
                        InputCorrect = false;
                    }

                } while (!InputCorrect);
                #endregion
            } while (true);
        }

        public static void resetField()
        {
            char[,] PlayFieldInitial =
            {
                {'1', '2', '3'},
                { '4', '5', '6'},
                {'7', '8', '9'}
            };
            PlayField = PlayFieldInitial;
            turns = 0;
            setField();
        }

        public static void setField()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("       |         |       ");
            Console.WriteLine("    {0}  |     {1}   |    {2}  ", PlayField[0,0], PlayField[0, 1], PlayField[0, 2]);
            Console.WriteLine("_______|_________|_______");
            Console.WriteLine("       |         |       ");
            Console.WriteLine("    {0}  |     {1}   |    {2}  ", PlayField[1, 0], PlayField[1, 1], PlayField[1, 2]);
            Console.WriteLine("_______|_________|_______");
            Console.WriteLine("       |         |       ");
            Console.WriteLine("    {0}  |     {1}   |    {2}  ", PlayField[2, 0], PlayField[2, 1], PlayField[2, 2]);
            Console.WriteLine("       |         |       ");
            turns++;
        }
        public static void EnterXorO(int player, int input)
        {
            char playerSign = ' ';
            if (player == 1)
            {
                playerSign = 'O';
            }
            else if (player == 2)
            {
                playerSign = 'X';
            }

            switch (input)
            {
                case 1: PlayField[0, 0] = playerSign; break;
                case 2: PlayField[0, 1] = playerSign; break;
                case 3: PlayField[0, 2] = playerSign; break;
                case 4: PlayField[1, 0] = playerSign; break;
                case 5: PlayField[1, 1] = playerSign; break;
                case 6: PlayField[1, 2] = playerSign; break;
                case 7: PlayField[2, 0] = playerSign; break;
                case 8: PlayField[2, 1] = playerSign; break;
                case 9: PlayField[2, 2] = playerSign; break;
            }
        }
    }
}