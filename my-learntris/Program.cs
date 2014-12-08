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
        Tetramino activeTetramino;

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

                        case "I":
                            this.activeTetramino = new I();
                            break;
                        case "O":
                            this.activeTetramino = new O();
                            break;
                        case "Z":
                            this.activeTetramino = new Z();
                            break;
                        case "S":
                            this.activeTetramino = new S();
                            break;
                        case "L":
                            this.activeTetramino = new L();
                            break;
                        case "J":
                            this.activeTetramino = new J();
                            break;
                        case "T":
                            this.activeTetramino = new T();
                            break;
                            
                        case "t": 
                            this.activeTetramino.Draw();
                            break;
                    }
                }
            } while (!quit);
        }

        void SetupGame()
        {
            ClearMatrix();
            score = 0;
            clearedLines = 0;
            activeTetramino = null;
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

    public abstract class Tetramino
    {
        protected int rows, columns;
        protected string[,] shape;

        public void Draw()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < shape.GetLength(0); i++)
            {
                int columnCount = shape.GetLength(1);
                for (int j = 0; j < columnCount; j++)
                {
                    sb.Append(shape[i, j]);

                    if (j + 1 == columnCount)
                        sb.Append("\n");
                    else
                        sb.Append(" ");
                }
            }

            Console.Write(sb.ToString());
        }
    }

    class I : Tetramino
    {
        public I()
        {
            this.rows = 4;
            this.columns = 4;
            this.shape = new string[4, 4] { { ".", ".", ".", "." }, { "c", "c", "c", "c" }, { ".", ".", ".", "." }, { ".", ".", ".", "." } };
        }
    }

    class O : Tetramino
    {
        public O()
        {
            this.rows = 2;
            this.columns = 2;
            this.shape = new string[2, 2] {{ "y", "y" }, { "y", "y"} };
        }
    }

    class Z : Tetramino
    {
        public Z()
        {
            this.rows = 3;
            this.columns = 3;
            this.shape = new string[3, 3] { { "r", "r", "." }, { ".", "r", "r" }, { ".", ".", "." } };
        }
    }

    class S : Tetramino
    {
        public S()
        {
            this.rows = 3;
            this.columns = 3;
            this.shape = new string[3, 3] { { ".", "g", "g" }, { "g", "g", "." }, { ".", ".", "." } };
        }
    }

    class J : Tetramino
    {
        public J()
        {
            this.rows = 3;
            this.columns = 3;
            this.shape = new string[3, 3] { { "b", ".", "." }, { "b", "b", "b" }, { ".", ".", "." } };
        }
    }

    class L : Tetramino
    {
        public L()
        {
            this.rows = 3;
            this.columns = 3;
            this.shape = new string[3, 3] { { ".", ".", "o" }, { "o", "o", "o" }, { ".", ".", "." } };
        }
    }

    class T : Tetramino
    {
        public T()
        {
            this.rows = 3;
            this.columns = 3;
            this.shape = new string[3, 3] { { ".", "m", "." }, { "m", "m", "m" }, { ".", ".", "." } };
        }
    }
}
