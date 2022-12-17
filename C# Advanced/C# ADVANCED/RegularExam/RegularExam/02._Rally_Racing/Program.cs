namespace _02._Rally_Racing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int rNum = int.Parse(Console.ReadLine());
            int km = 0;
            int cRow = 0;
            int cCol = 0;
            string result = $"Racing car {rNum} DNF.";
            List<int> finish = new List<int>();
            List<int> tStart = new List<int>();
            List<int> tEnd = new List<int>();

            for (int row = 0; row < n; row++)
            {
                char[] cmd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    if(cmd[col] == 'F')
                    {
                        finish.Add(row);
                        finish.Add(col);
                    }
                    else if (cmd[col]=='T' && tStart.Count==0)
                    {
                        tStart.Add(row);
                        tStart.Add(col);
                    }
                    else if(cmd[col] == 'T' && tStart.Count != 0)
                    {
                        tEnd.Add(row);
                        tEnd.Add(col);
                    }
                    matrix[row,col]= cmd[col];
                }
            }
            while (true)
            {
                string cmd = Console.ReadLine();
                switch(cmd.ToLower())
                {
                    case "left":
                        cCol--;
                        if(cRow == finish[0] && cCol == finish[1])
                        {
                            km += 10;
                            matrix[finish[0], finish[1]] = 'C';
                            result = $"Racing car {rNum} finished the stage!";
                        }
                        else if (cRow == tStart[0] && cCol == tStart[1])
                        {
                            km += 30;
                            cRow = tEnd[0];
                            cCol = tEnd[1];
                            matrix[tStart[0], tStart[1]] = '.';
                            matrix[tEnd[0], tEnd[1]] = '.';
                        }
                        else
                        {
                            km += 10;
                        }
                        break;
                    case "right":
                        cCol++;
                        if (cRow == finish[0] && cCol == finish[1])
                        {
                            km += 10;
                            matrix[finish[0], finish[1]] = 'C';
                            result = $"Racing car {rNum} finished the stage!";
                        }
                        else if (cRow == tStart[0] && cCol == tStart[1])
                        {
                            km += 30;
                            cRow = tEnd[0];
                            cCol = tEnd[1];
                            matrix[tStart[0], tStart[1]] = '.';
                            matrix[tEnd[0], tEnd[1]] = '.';
                        }
                        else
                        {
                            km += 10;
                        }
                        break;
                    case "up":
                        cRow--;
                        if (cRow == finish[0] && cCol == finish[1])
                        {
                            km += 10;
                            matrix[finish[0], finish[1]] = 'C';
                            result = $"Racing car {rNum} finished the stage!";
                        }
                        else if (cRow == tStart[0] && cCol == tStart[1])
                        {
                            km += 30;
                            cRow = tEnd[0];
                            cCol = tEnd[1];
                            matrix[tStart[0], tStart[1]] = '.';
                            matrix[tEnd[0], tEnd[1]] = '.';
                        }
                        else
                        {
                            km += 10;
                        }
                        break;
                    case "down":
                        cRow++;
                        if (cRow == finish[0] && cCol == finish[1])
                        {
                            km += 10;
                            matrix[finish[0], finish[1]] = 'C';
                            result = $"Racing car {rNum} finished the stage!";
                        }
                        else if (cRow == tStart[0] && cCol == tStart[1])
                        {
                            km += 30;
                            cRow = tEnd[0];
                            cCol = tEnd[1];
                            matrix[tStart[0], tStart[1]] = '.';
                            matrix[tEnd[0], tEnd[1]] = '.';
                        }
                        else
                        {
                            km += 10;
                        }
                        break;
                }

                if (result!= $"Racing car {rNum} DNF.")
                {
                    Console.WriteLine(result);
                    break;
                }
                else if (cmd.ToLower()=="end")
                {
                    matrix[cRow,cCol] = 'C';
                    Console.WriteLine($"Racing car {rNum} DNF.");
                    break;
                }
            }

            Console.WriteLine($"Distance covered {km} km.");

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }
    }
}
