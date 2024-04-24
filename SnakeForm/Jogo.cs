using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeForm
{
    internal class Jogo
    {
        public Keys direcao { get; set; }

        public Keys comando { get; set; }

        private Timer Frame { get; set; }

        private Label lblPontos { get; set; }

        private Panel pnlCenario { get; set; }

        private int pontos = 0;

        private Comida comida;
        private Cobra cobra;
        private Bitmap offScreenBitmap;
        private Graphics bitmapGraph;
        private Graphics screenGraph;

        public Jogo(ref Timer timer, ref Label label, ref Panel panel)
        {
            pnlCenario = panel;
            Frame = timer;
            lblPontos = label;
            offScreenBitmap = new Bitmap(428,428);
            cobra = new Cobra();
            comida = new Comida();
            direcao = Keys.Left;
            comando = direcao;
        }

        public void iniciarJogo()
        {
            cobra.resetar();
            comida.criarComida();
            direcao = Keys.Left;
            bitmapGraph = Graphics.FromImage(offScreenBitmap);
            screenGraph = pnlCenario.CreateGraphics();
            Frame.Enabled = true;
        }

        public void tick()
        {
            if (((comando == Keys.Left) && (comando != Keys.Right)) ||
            ((comando == Keys.Right) && (comando != Keys.Left)) ||
            ((comando == Keys.Up) && (comando != Keys.Down)) ||
            ((comando == Keys.Down) && (comando != Keys.Up)))
            {
                direcao = comando;
            }

            switch (comando)
            {
                case Keys.Left:
                    cobra.esquerda();
                    break;
                case Keys.Right:
                    cobra.direita();
                    break;
                case Keys.Up:
                    cobra.cima();
                    break;
                case Keys.Down:
                    cobra.baixo();
                    break;
            }

            bitmapGraph.Clear(Color.White);

            bitmapGraph.DrawImage(Properties.Resources.rat,(comida.Location.X * 15), (comida.Location.Y * 15),15,15);
            bool gameOver = false;

            for (int i = 0; i < cobra.Lenght; i++)
            {
                if (i == 0)
                {
                    bitmapGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#f00")), (cobra.Location[i].X * 15), (cobra.Location[i].Y * 15), 15, 15);
                }
                else
                {
                    bitmapGraph.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#4f774f")), (cobra.Location[i].X * 15), (cobra.Location[i].Y * 15), 15, 15);
                }

                if ((cobra.Location[i] == cobra.Location[0]) && (i > 0))
                {
                    gameOver = true;
                }
            }

            screenGraph.DrawImage(offScreenBitmap, 0,0);
            checarColisao();
            if (gameOver)
            {
                GameOver();
            }
        }

        public void checarColisao()
        {
            if (cobra.Location[0] == comida.Location)
            {
                cobra.comer();
                comida.criarComida();
                pontos += 10;
                lblPontos.Text = "PONTOS: " + pontos;
            }
        }

        public void GameOver()
        {
            Frame.Enabled = false;
            bitmapGraph.Dispose();
            screenGraph.Dispose();
            lblPontos.Text = "PONTOS: 0";
            MessageBox.Show("Game Over");
        }
    }
}
