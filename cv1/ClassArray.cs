using cviceni1;
using System;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using System.Text;

namespace c
{
    internal class ClassArray
    {
        public void Run()
        {
            CompositeBrick[] pole = new CompositeBrick[1];
            pole[0] = CreateT(2, 4);

            for(int i = 0; i < pole.Length; i++) 
            {
                CompositeBrick cp = pole[i];
                for (int j = 0; j < cp.brick.Length; j++)
                {
                    Brick b = cp.brick[j];
                    Console.SetCursorPosition(cp.x + b.x, cp.y + b.y);
                    Console.Write("X");
                }
            }

        }
        private CompositeBrick CreateT(int row, int col)
        {
            CompositeBrick cp = new CompositeBrick() { 
                x = row, 
                y = col,
                brick = new Brick[]
                {
                    new Brick() {x=0, y=0 },
                    new Brick() {x=1, y=0 },
                    new Brick() {x=2, y=0 },
                    new Brick() {x=1, y=1 }
                }
            };

            return cp;
        }
    }
}
