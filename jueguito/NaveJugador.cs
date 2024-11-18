using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace jueguito
{
    internal class NaveJugador
    {
        public float Vida {  get; set; }
        public Point Posicion { get; set; }
        public ConsoleColor ColorNave { get; set; }
        public VentanaPrincipal VentanaNave { get; set; }
        public List<Point> Posiciones { get; set; }

        public List<Bala> Balas { get; set; }
        public NaveJugador(Point posicion, ConsoleColor color, VentanaPrincipal window) 
        {
            Vida = 100;
            Posicion = posicion;
            ColorNave = color;
            VentanaNave = window;
            Posiciones = new List<Point>();
            Balas = new List<Bala>();
        }

        public void DibujarNave()
        {
            Console.ForegroundColor = ColorNave;
            int x = Posicion.X;
            int y = Posicion.Y;

            Console.SetCursorPosition(x + 2, y);
            Console.Write("┌A┐");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("\\\\<0>//");
            Console.SetCursorPosition(x + 2, y + 2);
            Console.Write("~^~");

            Posiciones.Clear();

            Posiciones.Add(new Point(x + 2, y));
            Posiciones.Add(new Point(x + 3, y));
            Posiciones.Add(new Point(x + 4, y));
            Posiciones.Add(new Point(x, y + 1));
            Posiciones.Add(new Point(x + 1, y + 1));
            Posiciones.Add(new Point(x + 2, y + 1));
            Posiciones.Add(new Point(x + 3, y + 1));
            Posiciones.Add(new Point(x + 4, y + 1));
            Posiciones.Add(new Point(x + 5, y + 1));
            Posiciones.Add(new Point(x + 6, y + 1));
            Posiciones.Add(new Point(x + 2, y + 2));
            Posiciones.Add(new Point(x + 3, y + 2));
            Posiciones.Add(new Point(x + 4, y + 2));
        }

        private void Borrar()
        {
            foreach (Point p in Posiciones)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(" ");
            }
        }

        public void letraPresionada(ref Point distancia, int velocidad)
        {
            ConsoleKeyInfo tecla = Console.ReadKey(true); //con true hacemos que no se muestre en la consola la tecla presionada

            if ((tecla.Key == ConsoleKey.W) | (tecla.Key == ConsoleKey.UpArrow))
            {
                distancia = new Point(0, -1);
            }
            else if ((tecla.Key == ConsoleKey.A) | (tecla.Key == ConsoleKey.LeftArrow))
            {
                distancia = new Point(-1, 0);
            }
            else if ((tecla.Key == ConsoleKey.S) | (tecla.Key == ConsoleKey.DownArrow))
            {
                distancia = new Point(0, 1);
            }
            else if ((tecla.Key == ConsoleKey.D) | (tecla.Key == ConsoleKey.RightArrow))
            {
                distancia = new Point(1, 0);
            }

            distancia.X *= velocidad;
            distancia.Y *= velocidad;

            if (tecla.Key == ConsoleKey.Spacebar)
            {
                Bala balaNave = new Bala(new Point(Posicion.X + 3, Posicion.Y),ConsoleColor.White);
                Balas.Add(balaNave);
            }

            Posicion = new Point(Posicion.X + distancia.X, Posicion.Y + distancia.Y);
        }

        public void Disparar()
        {
            for (int i = 0; i < Balas.Count; i++)
            {
                if (Balas[i].CaminoBala(1, VentanaNave.limSuperior.Y))
                {
                    Balas.Remove(Balas[i]);
                }

            }
        }
        public void Mover(int velocidad)
        {
            if (Console.KeyAvailable)
            {
                Borrar();
                Point distancia = new Point();
                letraPresionada(ref distancia, velocidad);
                Colisiones(distancia);
                DibujarNave();
            }
            Informacion();
        }

        public void Colisiones(Point distancia)
        {
            Point PosicionAux = new Point(Posicion.X + distancia.X, Posicion.Y + distancia.Y);
            
            if (PosicionAux.X <= VentanaNave.limSuperior.X)
                PosicionAux.X = VentanaNave.limSuperior.X + 1;

            if (PosicionAux.X + 6 >= VentanaNave.limInferior.X)
                PosicionAux.X = VentanaNave.limInferior.X - 7;
            
            if (PosicionAux.Y <= VentanaNave.limSuperior.Y)
                PosicionAux.Y = VentanaNave.limSuperior.Y + 1;

            if (PosicionAux.Y + 2 >= VentanaNave.limInferior.Y)
                PosicionAux.Y = VentanaNave.limInferior.Y - 3;

            Posicion = PosicionAux; 
        }

        public void Informacion()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(VentanaNave.limSuperior.X, VentanaNave.limSuperior.Y - 1);
            Console.Write("HEALTH: " + (int)Vida + "%  ");

        }
    }
}
