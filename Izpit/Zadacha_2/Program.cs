using System;
using System.Collections.Generic;

namespace Zadacha_2
{
    public class Program
    {
        public static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());
            string[][] matrix = new string[rowsCount][];
            for (int row = 0; row < rowsCount; row++)
            {
                matrix[row] = Console.ReadLine().Split();
            }

            List<string> collectedSeashells = new List<string>();
            int countStolenSeashells = 0;
            string[] token = Console.ReadLine().Split();
            while (true)
            {
                if (token[0] == "Sunset")
                {
                    break;
                }

                if (token[0] == "Collect")
                {
                    int seashellRow = int.Parse(token[1]);
                    int seashellCol = int.Parse(token[2]);
                    for (int row = 0; row < matrix.Length; row++)
                    {
                        for (int col = 0; col < matrix[row].Length; col++)
                        {
                            if (seashellRow < 0 || seashellCol < 0 || seashellRow > matrix.Length || seashellCol > matrix.Length)
                            {
                                break;
                            }
                            if (row == seashellRow && col == seashellCol && matrix[row][col] != "-")
                            {
                                collectedSeashells.Add(matrix[row][col]);
                                matrix[row][col] = "-";
                            }
                        }
                    }
                }
                if (token[0] == "Steal")
                {
                    int gullyRow = int.Parse(token[1]);
                    int gullyCol = int.Parse(token[2]);
                    string direction = token[3];

                    for (int row = 0; row < matrix.Length; row++)
                    {
                        for (int col = 0; col < matrix[row].Length; col++)
                        {
                            if (gullyRow < 0 || gullyCol < 0 || gullyRow > matrix.Length || gullyCol > matrix.Length)
                            {
                                break;
                            }
                            if (row == gullyRow && col == gullyCol && matrix[row][col] != "-")
                            {
                                matrix[row][col] = "-";
                                countStolenSeashells += 1;
                                if (direction == "up")
                                {
                                    for (int i = gullyRow-1; i >= gullyRow - 3; i--)
                                    {
                                        if (matrix[i][col] != "-")
                                        {
                                            matrix[i][col] = "-";
                                            countStolenSeashells += 1;
                                        }
                                        if (gullyRow - 1 < 0 || gullyRow - 2 < 0 || gullyRow - 3 < 0)
                                        {
                                            break;
                                        }
                                    }
                                }
                                else if (direction == "down")
                                {
                                    for (int i = gullyRow + 1; i <= gullyRow + 3; i++)
                                    {
                                        if (matrix[i][col] != "-")
                                        {
                                            matrix[i][col] = "-";
                                            countStolenSeashells += 1;
                                        }
                                        if (i > matrix.Length) 
                                        {
                                            break;
                                        }
                                    }
                                }
                                else if (direction == "right")
                                {
                                    for (int i = gullyCol + 1; i <= gullyCol + 3; i++)
                                    {
                                        if (matrix[row][i] != "-")
                                        {
                                            matrix[row][i] = "-";
                                            countStolenSeashells += 1;
                                        }
                                        if (i > matrix.Length) 
                                        {
                                            break;
                                        }
                                    }
                                }
                                else if (direction == "left")
                                {
                                    for (int i = gullyCol - 1; i >= gullyCol - 3; i--)
                                    {
                                        if (matrix[row][i] != "-")
                                        {
                                            matrix[row][i] = "-";
                                            countStolenSeashells += 1;
                                        }
                                        if (gullyCol - 1 < 0 || gullyCol - 2 < 0 || gullyCol - 3 < 0) 
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                token = Console.ReadLine().Split();
            }
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            if (collectedSeashells.Count == 0)
            {
                Console.WriteLine("Collected seashells: 0");
            }
            else
            {
                Console.WriteLine($"Collected seashells: {collectedSeashells.Count} -> {string.Join(", ", collectedSeashells)}");
            }
            Console.WriteLine($"Stolen seashells: {countStolenSeashells}");
        }
    }
}
