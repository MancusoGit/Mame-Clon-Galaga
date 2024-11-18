
using jueguito;
using System.Drawing;

VentanaPrincipal ventanaMain;
NaveJugador naveMain;
bool Play = true;

void Iniciar()
{
    ventanaMain = new VentanaPrincipal(180, 60, ConsoleColor.Black, new Point(10, 5), new Point(170, 50));
    naveMain = new NaveJugador(new Point(70, 40), ConsoleColor.Blue, ventanaMain);
    naveMain.DibujarNave();
}

void Game()
{
    while (Play)
    {
        naveMain.Mover(1);
        naveMain.Disparar();

    }
}

Iniciar();
Game();
Console.ReadKey();