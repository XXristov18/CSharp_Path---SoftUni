namespace _02.NavyBattle
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int cRow = 0;
            int cCol = 0;
            List<int> uStart = new List<int>();
            int minecount = 0;
            int cruisercount = 0;

            for (int row = 0; row < n; row++)
            {
                string cmd = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    
                    if (cmd[col] == 'S' && uStart.Count == 0)
                    {
                        uStart.Add(row);
                        uStart.Add(col);
                        cRow = row;
                        cCol = col;
                    }
                    matrix[row, col] = cmd[col];
                }
            }
            bool run = true;
            while (run)
            {
                string cmd = Console.ReadLine();
                switch (cmd.ToLower())
                {
                    case "left":
                        cCol--;
                        if (matrix[cRow, cCol] == '-')
                        {
                            matrix[uStart[0], uStart[1]] = '-';
                            uStart[1] = cCol;
                            matrix[uStart[0], uStart[1]] = 'S';
                        }
                        else if (matrix[cRow, cCol] == '*')
                        {
                            matrix[uStart[0], uStart[1]] = '-';
                            uStart[1] = cCol;
                            matrix[uStart[0], uStart[1]] = 'S';
                            minecount++;
                            if (minecount == 3)
                            {
                                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{uStart[0]}, {uStart[1]}]!");
                                run = false;
                                break;
                            }
                        }
                        else if (matrix[cRow, cCol] == 'C')
                        {
                            matrix[uStart[0], uStart[1]] = '-';
                            uStart[1] = cCol;
                            matrix[uStart[0], uStart[1]] = 'S';
                            cruisercount++;
                            if (cruisercount == 3)
                            {
                                Console.WriteLine($"Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                                run = false;
                                break;
                            }
                        }
                        break;
                    case "right":
                        cCol++;
                        if (matrix[cRow, cCol] == '-')
                        {
                            matrix[uStart[0], uStart[1]] = '-';
                            uStart[1] = cCol;
                            matrix[uStart[0], uStart[1]] = 'S';
                        }
                        else if (matrix[cRow, cCol] == '*')
                        {
                            matrix[uStart[0], uStart[1]] = '-';
                            uStart[1] = cCol;
                            matrix[uStart[0], uStart[1]] = 'S';
                            minecount++;
                            if (minecount == 3)
                            {
                                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{uStart[0]}, {uStart[1]}]!");
                                run = false;
                                break;
                            }
                        }
                        else if (matrix[cRow, cCol] == 'C')
                        {
                            matrix[uStart[0], uStart[1]] = '-';
                            uStart[1] = cCol;
                            matrix[uStart[0], uStart[1]] = 'S';
                            cruisercount++;
                            if (cruisercount == 3)
                            {
                                Console.WriteLine($"Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                                run = false;
                                break;
                            }
                        }
                        break;
                    case "up":
                        cRow--;
                        if (matrix[cRow, cCol] == '-')
                        {
                            matrix[uStart[0], uStart[1]] = '-';
                            uStart[0] = cRow;
                            matrix[uStart[0], uStart[1]] = 'S';
                        }
                        else if (matrix[cRow, cCol] == '*')
                        {
                            matrix[uStart[0], uStart[1]] = '-';
                            uStart[0] = cRow;
                            matrix[uStart[0], uStart[1]] = 'S';
                            minecount++;
                            if (minecount == 3)
                            {
                                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{uStart[0]}, {uStart[1]}]!");
                                run = false;
                                break;
                            }
                        }
                        else if (matrix[cRow, cCol] == 'C')
                        {
                            matrix[uStart[0], uStart[1]] = '-';
                            uStart[0] = cRow;
                            matrix[uStart[0], uStart[1]] = 'S';
                            cruisercount++;
                            if (cruisercount == 3)
                            {
                                Console.WriteLine($"Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                                run = false;
                                break;
                            }
                        }
                        break;
                    case "down":
                        cRow++;
                        if (matrix[cRow, cCol] == '-')
                        {
                            matrix[uStart[0], uStart[1]] = '-';
                            uStart[0] = cRow;
                            matrix[uStart[0], uStart[1]] = 'S';
                        }
                        else if (matrix[cRow, cCol] == '*')
                        {
                            matrix[uStart[0], uStart[1]] = '-';
                            uStart[0] = cRow;
                            matrix[uStart[0], uStart[1]] = 'S';
                            minecount++;
                            if (minecount == 3)
                            {
                                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{uStart[0]}, {uStart[1]}]!");
                                run = false;
                                break;
                            }
                        }
                        else if (matrix[cRow, cCol] == 'C')
                        {
                            matrix[uStart[0], uStart[1]] = '-';
                            uStart[0] = cRow;
                            matrix[uStart[0], uStart[1]] = 'S';
                            cruisercount++;
                            if (cruisercount == 3)
                            {
                                Console.WriteLine($"Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
                                run = false;
                                break;
                            }
                        }
                        break;
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

        }
    }
}
