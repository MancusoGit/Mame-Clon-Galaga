using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace jueguito
{
    internal class Bala
    {
        public Point Posicion {  get; set; }
        
        public ConsoleColor ColorBala { get; set; }

        public List <Point> PosicionesBalita { get; set; }

        private DateTime _tiempo;

        public Bala(Point posicion, ConsoleColor colorBala)
        {
            Posicion = posicion;
            ColorBala = colorBala; 
            PosicionesBalita = new List<Point>();
            _tiempo = DateTime.Now;
        }

        public void DrawBala()
        {
            Console.ForegroundColor = ColorBala;

            int x = Posicion.X;

            int y = Posicion.Y;

            PosicionesBalita.Clear();

            Console.SetCursorPosition(x, y);

            Console.Write("■");

            PosicionesBalita.Add(new Point(x, y));
        }

        public void BorrarRastro()
        {
            foreach(Point p in  PosicionesBalita)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(" ");
            }
        }

        public bool CaminoBala(int velocidad, int limite)
        {

            if (DateTime.Now > _tiempo.AddMilliseconds(30))
            {
                BorrarRastro();

                Posicion = new Point(Posicion.X, Posicion.Y - velocidad);

                if (Posicion.Y <= limite)
                    return true;

                DrawBala();

                _tiempo = DateTime.Now;
            }
            
            return false;
        }
    }
}
