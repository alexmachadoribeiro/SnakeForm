using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeForm
{
    internal class Comida
    {
        public Point Location { get; private set; }

        public void criarComida()
        {
            Random aleatorio = new Random();
            Location = new Point(aleatorio.Next(0,27), aleatorio.Next(0, 27));
        }
    }
}
