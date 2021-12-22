using System;

namespace SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());
            string[][] maze = new string[rows][];

            int marioRowIndex = 0;
            int marioColIndex = 0;

            bool marioDied = false;
            bool princessReached = false;

            FillMaze(maze);

            while (!marioDied && !princessReached)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = commands[0];

                int monsterSpawnRow = int.Parse(commands[1]);
                int monsterSpawnCol = int.Parse(commands[2]);

                maze[monsterSpawnRow][monsterSpawnCol] = "B";

                lives--;
                if (direction == "W")
                {
                    if (CheckIndex(maze, marioRowIndex - 1, marioColIndex))
                    {
                        marioRowIndex--;
                        maze[marioRowIndex + 1][marioColIndex] = "-";

                        if (maze[marioRowIndex][marioColIndex] == "B")
                        {
                            lives -= 2;
                            maze[marioRowIndex][marioColIndex] = "M";
                        }
                        if (maze[marioRowIndex][marioColIndex] == "P")
                        {
                            maze[marioRowIndex][marioColIndex] = "-";
                            princessReached = true;
                        }
                        else // non of these
                        {
                            maze[marioRowIndex][marioColIndex] = "M";
                        }
                    }
                }
                else if (direction == "S")
                {
                    if (CheckIndex(maze, marioRowIndex + 1, marioColIndex))
                    {
                        marioRowIndex++;
                        maze[marioRowIndex - 1][marioColIndex] = "-";

                        if (maze[marioRowIndex][marioColIndex] == "B")
                        {
                            lives -= 2;
                            maze[marioRowIndex][marioColIndex] = "M";
                        }
                        if (maze[marioRowIndex][marioColIndex] == "P")
                        {
                            maze[marioRowIndex][marioColIndex] = "-";
                            princessReached = true;
                        }
                        else // non of these
                        {
                            maze[marioRowIndex][marioColIndex] = "M";
                        }
                    }
                }
                else if (direction == "D")
                {
                    if (CheckIndex(maze, marioRowIndex, marioColIndex + 1))
                    {
                        marioColIndex++;
                        maze[marioRowIndex][marioColIndex - 1] = "-";

                        if (maze[marioRowIndex][marioColIndex] == "B")
                        {
                            lives -= 2;
                            maze[marioRowIndex][marioColIndex] = "M";
                        }
                        if (maze[marioRowIndex][marioColIndex] == "P")
                        {
                            maze[marioRowIndex][marioColIndex] = "-";
                            princessReached = true;
                        }
                        else // non of these
                        {
                            maze[marioRowIndex][marioColIndex] = "M";
                        }
                    }
                }
                else // L
                {
                    if (CheckIndex(maze, marioRowIndex, marioColIndex - 1))
                    {
                        marioColIndex--;
                        maze[marioRowIndex][marioColIndex + 1] = "-";

                        if (maze[marioRowIndex][marioColIndex] == "B")
                        {
                            lives -= 2;
                            maze[marioRowIndex][marioColIndex] = "M";
                        }
                        if (maze[marioRowIndex][marioColIndex] == "P")
                        {
                            maze[marioRowIndex][marioColIndex] = "-";
                            princessReached = true;
                        }
                        else // non of these
                        {
                            maze[marioRowIndex][marioColIndex] = "M";
                        }
                    }
                }

                if (lives <= 0)
                {
                    marioDied = true;
                    maze[marioRowIndex][marioColIndex] = "X";
                }
            }
            if (princessReached)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }
            else
            {
                Console.WriteLine($"Mario died at {marioRowIndex};{marioColIndex}.");
            }

            foreach (var array in maze)
            {
                Console.WriteLine(string.Join("", array));
            }

            void FillMaze(string[][] maze)
            {
                for (int row = 0; row < maze.Length; row++)
                {
                    string input = Console.ReadLine();
                    maze[row] = new string[input.Length];
                    for (int col = 0; col < maze[row].Length; col++)
                    {
                        if (input[col] == 'M')
                        {
                            marioRowIndex = row;
                            marioColIndex = col;
                        }
                        maze[row][col] = input[col].ToString();
                    }
                }
            }

            bool CheckIndex(string[][] maze, int marioRowIndex, int marioColIndex)
            {
                return marioRowIndex >= 0 && marioRowIndex < maze.Length && marioColIndex >= 0 && marioColIndex < maze[marioRowIndex].Length;
            }
        }
    }
}