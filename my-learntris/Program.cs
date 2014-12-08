using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace my_learntris
{
    class Program
    {
        static void Main(string[] args)
        {
            LearntrisGame game = new LearntrisGame();
            game.RunGame();
        }
    }

    class LearntrisGame
    {
        string[,] matrix;
        bool quit = false;
        double score;
        int clearedLines;

        public LearntrisGame() 
        {
            this.matrix = new string[22, 10];
            SetupGame();
        }

        public void RunGame()
        {
            do
            {
                string[] input = Console.ReadLine().Split(new char[] {' '});

                foreach (string key in input)
                {
                    switch (key)
                    {
                        case "p":
                            PrintMatrix();
                            break;
                        case "g":
                            PopulateMatrix();
                            break;
                        case "c":
                            ClearMatrix();
                            break;
                        case "?s":
                            DisplayScore();
                            break;
                        case "?n":
                            DisplayClearedLines();
                            break;
                        case "s":
                            StepGame();
                            break;
                        case "q":
                            quit = true;
                            return;
                    }
                }
            } while (!quit);
        }

        void SetupGame()
        {
            ClearMatrix();
            score = 0;
            clearedLines = 0;
        }

        void ClearMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                ClearRow(i);
            }
        }

        private void ClearRow(int i)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = ".";
            }
        }

        void PrintMatrix()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int columnCount = matrix.GetLength(1);
                for (int j = 0; j < columnCount; j++)
                {
                    sb.Append(matrix[i, j]);

                    if (j + 1 == columnCount)
                        sb.Append("\n");
                    else
                        sb.Append(" ");
                }
            }

            Console.Write(sb.ToString());
        }

        void PopulateMatrix()
        {

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string input = Console.ReadLine().TrimEnd(new char[] {'\n','\r'}) ;
                string[] chars = input.Split(' ');
                if (chars.Length == 1)
                {
                    i--;
                    continue;
                }

                for (int j = 0; j < chars.Length; j++)
                {
                    matrix[i, j] = chars[j];
                }
            }
        }

        void DisplayScore()
        {
            Console.WriteLine(score.ToString());
        }

        void DisplayClearedLines()
        {
            Console.WriteLine(clearedLines.ToString());
        }

        void StepGame()
        {
            int newClearedLines = CheckLinesToClear();
            score += newClearedLines * 100;
            clearedLines += newClearedLines;
        }

        int CheckLinesToClear()
        {
            int lines = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == ".")
                        break;

                    if (j == matrix.GetLength(1) - 1)
                    {
                        ClearRow(i);
                        lines++;
                    }
                }
            }

            return lines;
        }
    }
}
