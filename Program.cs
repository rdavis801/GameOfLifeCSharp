/***************************************
             Ronald Davis
             Purpose:
 * To recreate the GOL secenerio using the 
      rules Born = 3 / Survice = 2 or 3
 * This program keeps track of age, if 
    it is alive, and if it will be in the next
    generation for each 'cell'
 * This program also features three known paterns,
    Gaspers Glider Gun, a Methuselah, and a 
    Spacefiller
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GOL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ron Davis: GOL";
            Console.SetWindowSize(82, 55);
            cell[,] grid = new cell[42, 62];
            Random rnd = new Random();
            bool valid;
            int H;
            int W;
            int generations = 0;
            int count = 0;
            int selection;

            Console.ForegroundColor = ConsoleColor.Yellow;// Sets the color for the text
            Console.WriteLine("Enter 1 for Random Fill\n2 for Glider Gun\n" +
                              "3 for Methesulah\n4 for Spacefiller\nOr 9 to Quit");
            valid = int.TryParse(Console.ReadLine(), out selection);
            while (!valid || (selection != 1 && selection != 2 &&
                  selection != 3 && selection != 4 && selection != 9))
            {
                Console.WriteLine("Please enter a valid number.");
                Console.WriteLine("Enter 1 for Random Fill\n2 for Glider Gun\n" +
                                  "3 for Puffer Train\n4 for Spacefiller\nOr 9 to Quit");
                valid = int.TryParse(Console.ReadLine(), out selection);
            }
            do// Create an infinite loop, the only way out is to use the menu selection when prompted
            {
                if (selection != 9 && selection != 5)// If the user did not select quit
                {
                    Console.Write("Enter the number of generations you would like to step through " +
                                  "between 1 and 500.");
                    while (!int.TryParse(Console.ReadLine(), out generations) &&
                            (generations >= 1 && generations <= 500))
                    {
                        Console.WriteLine("Please enter a valid number.");
                        Console.Write("Enter the number of generations between 1 and 500.");
                    }
                }
                #region// Create the grid based on user selection
                switch (selection)
                {
                    case 1:
                        #region// Random grid fill

                        count = 0;
                        // Reset the grid
                        for (int i = 1; i < grid.GetUpperBound(0); i++)
                        {
                            for (int j = 1; j < grid.GetUpperBound(1); j++)
                            {
                                grid[i, j].isAlive = grid[i, j].nextGen
                                    = grid[i, j].age = 0;
                            }
                        }
                        for (int i = 1; i < grid.GetUpperBound(0); i++)
                        {
                            for (int j = 1; j < grid.GetUpperBound(1); j++)
                            {
                                grid[i, j].isAlive = rnd.Next(0, 2);
                            }
                        }

                        #endregion
                        break;
                    case 2:
                        #region// Glider Gun

                        count = 0;
                        // Reset the grid
                        for (int i = 1; i < grid.GetUpperBound(0); i++)
                        {
                            for (int j = 1; j < grid.GetUpperBound(1); j++)
                            {
                                grid[i, j].isAlive = grid[i, j].nextGen
                                    = grid[i, j].age = 0;
                            }
                        }
                        // Use actual values because it is a patern that doesn't need extra space
                        // to grow or shrink based on the size of the grid
                        #region
                        grid[5, 1].isAlive = grid[5, 2].isAlive = grid[6, 1].isAlive = grid[6, 2].isAlive = grid[5, 11].isAlive = grid[6, 11].isAlive =
                        grid[7, 11].isAlive = grid[4, 12].isAlive = grid[8, 12].isAlive = grid[3, 13].isAlive = grid[9, 13].isAlive = grid[3, 14].isAlive =
                        grid[9, 14].isAlive = grid[6, 15].isAlive = grid[4, 16].isAlive = grid[8, 16].isAlive = grid[5, 17].isAlive = grid[6, 17].isAlive =
                        grid[7, 17].isAlive = grid[6, 18].isAlive = grid[3, 21].isAlive = grid[4, 21].isAlive = grid[5, 21].isAlive = grid[3, 22].isAlive =
                        grid[4, 22].isAlive = grid[5, 22].isAlive = grid[2, 23].isAlive = grid[6, 23].isAlive = grid[1, 25].isAlive = grid[2, 25].isAlive =
                        grid[6, 25].isAlive = grid[7, 25].isAlive = grid[3, 35].isAlive = grid[4, 35].isAlive = grid[3, 36].isAlive = grid[4, 36].isAlive = 1;
                        #endregion
                        #endregion
                        break;
                    case 3:
                        #region// Methuselah

                        count = 0;
                        // Reset the grid
                        for (int i = 1; i < grid.GetUpperBound(0); i++)
                        {
                            for (int j = 1; j < grid.GetUpperBound(1); j++)
                            {
                                grid[i, j].isAlive = grid[i, j].nextGen
                                    = grid[i, j].age = 0;
                            }
                        }
                        // Use the approximate center of the grid so that it will always be in
                        // the center no matter if the grid is resized later
                        H = grid.GetLength(0) / 2;
                        W = grid.GetLength(1) / 2;
                        grid[W, H - 1].isAlive = grid[W + 1, H - 1].isAlive = grid[W - 1, H].isAlive =
                        grid[W, H].isAlive = grid[W, H + 1].isAlive = 1;


                        #endregion
                        break;
                    case 4:
                        #region// Spacefiller

                        count = 0;
                        H = grid.GetLength(0) / 2;
                        W = grid.GetLength(1) / 2;

                        // Reset the grid
                        for (int i = 1; i < grid.GetUpperBound(0); i++)
                        {
                            for (int j = 1; j < grid.GetUpperBound(1); j++)
                            {
                                grid[i, j].isAlive = grid[i, j].nextGen
                                    = grid[i, j].age = 0;
                            }
                        }

                        // Use the approximate center of the grid so that it will always be in
                        // the center no matter if the grid is resized later, and uses 1/4th
                        // of the template as a region to be replicate by various transformations
                        #region
                        grid[W - 1, H].isAlive = grid[W + 1, H].isAlive =
                        grid[W, H - 1].isAlive = grid[W, H + 1].isAlive = grid[W, H - 1].isAlive = grid[W, H + 1].isAlive =
                        grid[W - 3, H].isAlive = grid[W + 3, H].isAlive =
                        grid[W - 3, H - 1].isAlive = grid[W - 3, H + 1].isAlive = grid[W + 3, H - 1].isAlive = grid[W + 3, H + 1].isAlive =
                        grid[W - 5, H].isAlive = grid[W + 5, H].isAlive =
                        grid[W - 5, H - 1].isAlive = grid[W - 5, H + 1].isAlive = grid[W + 5, H - 1].isAlive = grid[W + 5, H + 1].isAlive =
                        grid[W - 5, H - 2].isAlive = grid[W - 5, H + 2].isAlive = grid[W + 5, H - 2].isAlive = grid[W + 5, H + 2].isAlive =
                        grid[W - 5, H - 3].isAlive = grid[W - 5, H + 3].isAlive = grid[W + 5, H - 3].isAlive = grid[W + 5, H + 3].isAlive =
                        grid[W - 5, H - 4].isAlive = grid[W - 5, H + 4].isAlive = grid[W + 5, H - 4].isAlive = grid[W + 5, H + 4].isAlive =
                        grid[W - 3, H - 4].isAlive = grid[W - 3, H + 4].isAlive = grid[W + 3, H - 4].isAlive = grid[W + 3, H + 4].isAlive =
                        grid[W - 3, H - 5].isAlive = grid[W - 3, H + 5].isAlive = grid[W + 3, H - 5].isAlive = grid[W + 3, H + 5].isAlive =
                        grid[W - 4, H - 5].isAlive = grid[W - 4, H + 5].isAlive = grid[W + 4, H - 5].isAlive = grid[W + 4, H + 5].isAlive =
                        grid[W - 7, H - 1].isAlive = grid[W - 7, H + 1].isAlive = grid[W + 7, H - 1].isAlive = grid[W + 7, H + 1].isAlive =
                        grid[W - 7, H - 2].isAlive = grid[W - 7, H + 2].isAlive = grid[W + 7, H - 2].isAlive = grid[W + 7, H + 2].isAlive =
                        grid[W - 8, H - 1].isAlive = grid[W - 8, H + 1].isAlive = grid[W + 8, H - 1].isAlive = grid[W + 8, H + 1].isAlive =
                        grid[W - 8, H - 2].isAlive = grid[W - 8, H + 2].isAlive = grid[W + 8, H - 2].isAlive = grid[W + 8, H + 2].isAlive =
                        1;
                        #endregion

                        #endregion
                        break;
                    case 5:
                        #region
                        int countLive = 0;
                        int yellowAge, blueAge, greenAge, magentaAge, redAge;
                        yellowAge = blueAge = greenAge = magentaAge = redAge = 0;
                        for (int i = 1; i < grid.GetUpperBound(0); i++)
                        {
                            for (int j = 1; j < grid.GetUpperBound(1); j++)
                            {
                                if (grid[i, j].isAlive == 1)
                                {
                                    #region// Calculate how many live cells and the age breakdown
                                    countLive += grid[i, j].isAlive;
                                    switch (grid[i, j].age)
                                    {
                                        case 0:
                                            yellowAge += 1;
                                            break;
                                        case 1:
                                            greenAge += 1;
                                            break;
                                        case 2:
                                            blueAge += 1;
                                            break;
                                        case 3:
                                            magentaAge += 1;
                                            break;
                                        default:
                                            redAge += 1;
                                            break;
                                    }
                                    #endregion
                                }
                            }
                        }
                        Console.WriteLine("There are currently " + countLive + " live cells,\n" +
                            yellowAge + " of age 0\n" + blueAge + " of age 1\n" + greenAge +
                            " of age 2\n" + magentaAge + " of age 3\n" + redAge + " of age 4 or older.");


                        Console.WriteLine("\nEnter 0 to continue the current pattern\n1 " +
                         "for Random Fill\n2 for Glider Gun, 3 for Methuselah\n" +
                         "4 for Spacefiller\n5 for specific cell details\n" +
                         "Or 9 to Quit");
                        valid = int.TryParse(Console.ReadLine(), out selection);
                        while (!valid || ( (selection < 0 || selection > 5) && selection != 9))
                        {
                            Console.WriteLine("Please enter a valid number.");
                            Console.WriteLine("\nEnter 0 to continue the current pattern\n1 " +
                                "for Random Fill\n2 for Glider Gun, 3 for Methuselah\n" +
                                "4 for Spacefiller\n5 for specific cell details\n" +
                                "Or 9 to Quit");
                            valid = int.TryParse(Console.ReadLine(), out selection);
                        }
                        continue;

                        #endregion
                    case 9:
                        #region// End Program

                        Console.Write("Press any key to exit . . . . ");
                        Console.ReadKey();
                        Environment.Exit(0);

                        #endregion
                        break;
                    case 0:
                    default:// Do nothing
                        break;
                }
                #endregion
                Console.Clear();
                while (generations > 0)
                {
                    generations--;
                    CalculateNextGen(grid);
                    StepGen(grid);
                    Thread.Sleep(7);
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Generation # " + (count + 1));
                    count++;
                    // Print out the grid
                    for (int i = 1; i < grid.GetUpperBound(0); i++)
                    {
                        for (int j = 1; j < grid.GetUpperBound(1); j++)
                        {
                            if (grid[i, j].isAlive == 1)
                            {
                                #region// Set appropriate ForgroundColor determined by the age of the cell
                                switch (grid[i, j].age)
                                {
                                    case 0:
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        break;
                                    case 1:
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        break;
                                    case 2:
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        break;
                                    case 3:
                                        Console.ForegroundColor = ConsoleColor.Magenta;
                                        break;
                                    default://age 4 or older
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        break;

                                }
                                #endregion
				Console.OutputEncoding = System.Text.Encoding.UTF8;
                                Console.Write((char)9650);
                            }
                            else
                                Console.Write(" ");
                        }
                        Console.WriteLine();
                    }
                }
                // Reset ForgroundColor to yellow for the rest of the text
                Console.ForegroundColor = ConsoleColor.Yellow;
                #region//selection 
                Console.WriteLine("\nEnter 0 to continue the current pattern\n1 " +
                                  "for Random Fill\n2 for Glider Gun\n3 for Methuselah\n" +
                                  "4 for Spacefiller\n5 for specific cell details" +
                                  "\nOr 9 to Quit");
                valid = int.TryParse(Console.ReadLine(), out selection);
                while (!valid || (selection != 0 && selection != 1 &&
                     selection != 2 && selection != 3 &&
                     selection != 4 && selection != 5 && selection != 9))
                {
                    Console.WriteLine("Please enter a valid number.");
                    Console.WriteLine("\nEnter 0 to continue the current pattern\n1 " +
                                  "for Random Fill\n2 for Glider Gun\n3 for Methuselah\n" +
                                  "4 for Spacefiller\n5 for specific cell details" +
                                  "\nOr 9 to Quit");
                    valid = int.TryParse(Console.ReadLine(), out selection);
                }
                #endregion
            } while (true);// Infinite loop, the only way out is to use the menu selection when prompted
        }

        // Calculate the next generation of cells based on B3/S23
        private static void CalculateNextGen(cell[,] grid)
        {
            for (int i = 1; i < grid.GetUpperBound(0); i++)
            {
                for (int j = 1; j < grid.GetUpperBound(1); j++)
                {
                    // Neighbors is set to the sum of all of the live cells touching grid[i,j]
                    int neighbors = grid[i - 1, j - 1].isAlive + grid[i - 1, j].isAlive + grid[i - 1, j + 1].isAlive +
                                    grid[i, j - 1].isAlive + grid[i, j + 1].isAlive + grid[i + 1, j + 1].isAlive +
                                    grid[i + 1, j - 1].isAlive + grid[i + 1, j].isAlive;
                    if (neighbors >= 2 && neighbors <= 3)
                    {
                        if (neighbors == 3)
                        {
                            grid[i, j].nextGen = 1;// Will "become" alive if not already;
                        }
                        else
                        {
                            grid[i, j].nextGen = grid[i, j].isAlive;// Stays "alive" if already alive
                        }
                    }
                    else
                    {
                        grid[i, j].nextGen = 0;// "Dies"
                    }
                }
            }
        }

        // Update the 2d array of structs making the nextGen value become the isLive value
        private static void StepGen(cell[,] grid)
        {
            for (int i = 1; i < grid.GetUpperBound(0); i++)
            {
                for (int j = 1; j < grid.GetUpperBound(1); j++)
                {
                    // "Becoming" alive
                    if (grid[i, j].nextGen == 1)
                    {
                        if (grid[i, j].isAlive == 0)
                        {
                            grid[i, j].age = 0;// Reset age
                            grid[i, j].isAlive = grid[i, j].nextGen;
                        }
                        else// Then grid[i, j].isLive is equal to 1
                        {
                            grid[i, j].age += 1;
                        }
                    }
                    else// Then grid[i,j].nextGen is equal to 0
                    {
                            grid[i, j].isAlive = 0;
                    }
                }
            }
        }

        public struct cell
        {
            public int isAlive;
            public int nextGen;
            public int age;
        }
    }
}
