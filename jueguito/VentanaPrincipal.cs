using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace jueguito
{
    internal class VentanaPrincipal
    {
        public int Ancho;

        public int Alto;

        public ConsoleColor Color;

        public Point limSuperior;

        public Point limInferior;

        
        public VentanaPrincipal(int ancho, int alto, ConsoleColor colorcito, Point limSup, Point limInf)
        {
            Ancho = ancho;
            Alto = alto;
            Color = colorcito;
            limSuperior = limSup;
            limInferior = limInf;
            Init();
        }

        public int getAncho()
        {
            return Ancho;
        }
        public int getAlto()
        {
            return Alto;
        }

        private void Init()
        {
            Console.SetWindowSize(Ancho, Alto);
            Console.Title = "Juego Mancuso";
            Console.BackgroundColor = Color;
            Console.CursorVisible = false;
            Console.Clear();
            Marco();

        }

        private void Marco()
        {
            for(int i = limSuperior.X; i <= limInferior.X; i++)
            {
                Console.SetCursorPosition(i, limSuperior.Y);
                Console.Write("*");
                Console.SetCursorPosition(i, limInferior.Y);
                Console.Write("*");
            }

            for(int j = limSuperior.Y; j <= limInferior.Y; j++)
            {
                Console.SetCursorPosition(limSuperior.X, j);
                Console.Write("*");
                Console.SetCursorPosition(limInferior.X, j);
                Console.Write("*");
            }
        }

    }   
}
