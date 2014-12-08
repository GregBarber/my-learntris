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

        public LearntrisGame() 
        {
            this.matrix = new string[22, 10];
            SetupGame();
        }

        public void RunGame()
        {
            do
            {
                //Console.WriteLine("Select an action");
                int input = Console.Read();
                char key = ' ';
                //if(input.Length > 0)
                    key = Convert.ToChar(input);
                
                if (key == 'p')
                {
                    PrintMatrix();
                }
                else if (key == 'g')
                {
                    PopulateMatrix();
                }
                else if (key == 'c')
                {
                    ClearMatrix();
                }
                else if (key == 'q')
                {
                    quit = true;
                    return;
                }
            } while (!quit);
        }

        void SetupGame()
        {
            ClearMatrix();
        }

        public void ClearMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ".";
                }
            }
        }

        public void PrintMatrix()
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

        public void PopulateMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string input = Console.ReadLine();
                string[] chars = input.Split(' ');
                if (chars.Length == 0)
                    continue;

                for (int j = 0; j < chars.Length; j++)
                {
                    matrix[i, j] = chars[j];
                }
            }
        }
    }
}
