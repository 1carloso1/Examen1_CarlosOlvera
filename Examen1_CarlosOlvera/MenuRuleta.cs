using System;
namespace examen1
{
	public class MenuRuleta
	{
		public MenuRuleta()
		{
			JuegoRuleta juegos = new JuegoRuleta();
            int opcion;
            do
            {
                Console.WriteLine("¿Que actividad quieres realizar?\n" +
                    "1-.Agregar dinero para apostar\n" +
                    "2-.Apostar a un numero especifico (Multiplica tu apuesta x10)\n" +
                    "3.-Apostar al color Rojo o Negro (Multiplica tu apuesta x5)\n" +
                    "4.-Apostar a un numero Par o Impar (Multiplica tu apuesta x2)\n" +
                    "5.-Ver estadisticas de mi juego\n" +
                    "0.-Salir\n" +
                    "POR FAVOR ELIGE UNA OPCION");
                string opcionS = Console.ReadLine();
                opcion = Int32.Parse(opcionS);

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("¿Cuanto Dinero vas a apostar? Recuerda que el monto inicial debe ser mayor a $300 y ser multiplo de 10.");
                        string montoNuevo = Console.ReadLine();
                        int apuesta = int.Parse(montoNuevo);
                        juegos.apostar(apuesta);
                        break;
                    case 2:
                        juegos.juego1();
                        break;

                    case 3:
                        juegos.juego2();
                        break;
                    case 4:
                        juegos.juego3();
                        break;
                    case 5:
                        juegos.menuEstadisticas();
                        break;

                }

            }
            while (opcion != 0);
        }
	}
}
