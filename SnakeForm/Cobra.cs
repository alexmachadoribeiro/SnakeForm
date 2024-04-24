    using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeForm
{
    internal class Cobra
    {
        public int Lenght { get; private set; }

        public Point[] Location { get; private set; }

        public Cobra()
        {
            Location = new Point[28 * 28];
            resetar();
        }

        public void resetar()
        {
            Lenght = 5;

            for (int i = 0; i < Lenght; i++)
            {
                Location[i].X = 12;
                Location[i].Y = 12;
            }
        }

        public void seguir()
        {
            for (int i = Lenght - 1; i > 0; i--)
            {
                Location[i] = Location[i - 1];
            }
        }

        public void cima()
        {
            seguir();
            Location[0].Y--;
            if (Location[0].Y < 0)
            {
                Location[0].Y += 28;
            }
        }

        public void baixo()
        {
            seguir();
            Location[0].Y++;
            if (Location[0].Y > 27)
            {
                Location[0].Y -= 28;
            }
        }

        public void esquerda()
        {
            seguir();
            Location[0].X--;
            if (Location[0].X < 0)
            {
                Location[0].X += 28;
            }
        }

        public void direita()
        {
            seguir();
            Location[0].X++;
            if (Location[0].X > 27)
            {
                Location[0].X -= 28;
            }
        }

        public void comer()
        {
            Lenght++;
        }
    }
}
