using System;
using System.Collections.Generic;
using System.Text;

namespace cviceni1s
{
    internal class JaggedArray
    {
        public void Run()
        {
            /*
            int[] arr = new int[6];
            arr[0] = 10;
            int size = arr.Length;
            string[][] arr2d = new string[6][];
            */

            //vytvorit pole 20 radku 20 sloupcu

            bool[][] pole = new bool[20][];

            for (int i = 0; i < pole.Length; i++)
            {
                pole[i] = new bool[10];
            }

            // create vyvtovirt nekde kosticku typu T jeden radek 3 sloupce a druhy radek je ve druhem sloupci jen jeden
            Render(pole);
            CreateT(pole, 0, 1);
            CreateT(pole, 0, 6);

            while (true) {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Render(pole);
                Thread.Sleep(1000); //na sekundu

                //vytvorit Fall metodu ktera bude posouvat. nahore vzdy udelame nvoe pole
                Fall(pole); 
                Console.Clear();
            }
        }
        private void Render(bool[][] pole)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            for (int r = 0; r < pole.Length; r++)
            {
                for (int c = 0; c < pole[r].Length; c++)
                {
                    if (pole[r][c])
                    {
                        Console.Write("\u2588\u2588");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }

        private void CreateT(bool[][] pole, int radek, int sloupec)
        {
            pole[radek][sloupec] = true;
            pole[radek][sloupec+1] = true;
            pole[radek][sloupec+2] = true;
            pole[radek+1][sloupec+1] = true;
        }

        private void Fall(bool[][] pole)
        {
            for(int r = pole.Length - 1; r > 0; r--)
            {
                for (int c = 0; c < pole[r].Length; c++)
                {
                    if (pole[r - 1][c])
                    {
                        pole[r][c] = true;
                        pole[r - 1][c] = false;
                    }
                }
            }
        }


    }

}