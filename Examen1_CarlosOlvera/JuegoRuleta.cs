using System;
namespace examen1
{
    public class JuegoRuleta
    {
        List<int> numNegros = new List<int>();
        List<int> numRojos = new List<int>();
        List<int> numPar = new List<int>();
        List<int> numImpar = new List<int>();
        List<int> numeroRuleta = new List<int>();
       
        int rojosCont = 0;
        int negrosCont = 0;
        int paresCont = 0;
        int imparesCont = 0;
        int girosCont = 0;
        int balance = 0;

        int ganancia = 0;
      
        Random r = new Random();
        public JuegoRuleta()
        {
            guardarNumPorColor();
            guardarNumParImpar();

        }

        public void guardarNumPorColor()
        {
            for (int i = 1; i <= 36; i++)
            {
                if (i == 2 || i == 4 || i == 6 || i == 8 || i == 10 || i == 11 || i == 13 || i == 15 || i == 17 ||
                    i == 20 || i == 22 || i == 24 || i == 26 || i == 28 || i == 29 || i == 31 || i == 33 || i == 35)
                {
                    numNegros.Add(i);
                }
                else
                {
                    numRojos.Add(i);
                }
            }
        }
        public void guardarNumParImpar()
        {
            for (int i = 0; i <= 36; i++)
            {
                if (i%2 == 0)
                {
                    numPar.Add(i);
                }
                else
                {
                    numImpar.Add(i);
                }
            }
        }

        public void apostar(int apu)
        {
            balance += apu;
            ganancia -= apu;
            while (balance < 300 || balance % 10 != 0) //si el monto es menor a 300 o no es multiplo de 10, le pide que lo ingrese de nuevo
            {
                Console.WriteLine("El monto de la apuesta no es valido. Por favor asegurate que tu monto sea mayor a $300 y sea multiplo de 10.");
                string montoNuevo = Console.ReadLine();
                balance = int.Parse(montoNuevo);
                ganancia -= int.Parse(montoNuevo);


            }
            Console.WriteLine($"Excelente, estas apostando ${balance}\n");
        }

        public void juego1()
        {
            if (balance >= 300)
            {
                int aleatorio1 = r.Next(0, 37);
                Console.WriteLine("¿Cual sera tu numero de la suerte?");
                string numeroS = Console.ReadLine();
                int numero = Int32.Parse(numeroS);
                girosCont++;
                while (numero < 0 || numero > 36)
                {
                    Console.WriteLine("No puedes elegir este numero. Intenta con otro.");
                    numeroS = Console.ReadLine();
                    numero = Int32.Parse(numeroS);
                }
                numeroRuleta.Add(aleatorio1);
                if (numero == aleatorio1)
                {
                    balance *= 10;
                    //ganancia += balance;
                    Console.WriteLine("¡¡FELICIDADES!! HAS ACERTADO EL NUMERO\n");
                }
                else
                {
                    balance -= balance;
                   //ganancia -= balance;
                    Console.WriteLine($"Demonios!! No has acertado, el numero ganador fue {aleatorio1}\n");
                }
            }
            else
            {
                Console.WriteLine("No tienes suficiente dinero para apostar, intentar agregar mas dinero para jugar.\n");
            }
        }

        public void juego2()
        {
            if (balance >= 300) 
            {
                int aleatorio2;
                Boolean encontrado = false;
                Console.WriteLine("¿Cual sera tu color favorito? 1.-ROJO  2.- NEGRO");
                string colorS = Console.ReadLine();
                int color = Int32.Parse(colorS);
                girosCont++;
                while (color < 1 || color > 2)
                {
                    Console.WriteLine("Color incorrecto. Intenta con otro.");
                    colorS = Console.ReadLine();
                    color = Int32.Parse(colorS);
                }
                if (color == 1)
                {
                    aleatorio2 = r.Next(0, 37);
                    for (int i = 0; i < numRojos.Count; i++)
                    {
                        if (aleatorio2 == numRojos[i])
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (encontrado == true)
                    {
                        balance *= 5;
                        ganancia += balance;
                        Console.WriteLine("¡¡FELICIDADES!! HAS ACERTADO EL COLOR\n");
                        rojosCont++;
                    }
                    else
                    {
                        balance -= balance;
     
                        Console.WriteLine($"Demonios!! No has acertado, la bola cayo en el color negro.\n");
                        negrosCont++;
                    }

                }
                else if (color == 2)
                {
                    aleatorio2 = r.Next(0, 37);
                    for (int i = 0; i < numNegros.Count; i++)
                    {
                        if (aleatorio2 == numNegros[i])
                        {
                            encontrado = true;
                            break;
                        }
                    }
                    if (encontrado == true)
                    {
                        balance *= 5;
                        ganancia += balance;
                        Console.WriteLine("¡¡FELICIDADES!! HAS ACERTADO EL COLOR\n");
                        negrosCont++;
                    }
                    else
                    {
                        balance -= balance;
                       
                        Console.WriteLine($"Demonios!! No has acertado, la bola cayo en el color rojo.\n");
                        rojosCont++;
                    }
                }
            }
            else
            {
                Console.WriteLine("No tienes suficiente dinero para apostar, intentar agregar mas dinero para jugar.\n");
            }
        }

        public void juego3()
        {
            if(balance >= 300)
            {
                int aleatorio3;
                Boolean encontrado2 = false;
                Console.WriteLine("¿Vas Pares o Impares? 1.-Pares  2.- Impares");
                string paresS = Console.ReadLine();
                int pares = Int32.Parse(paresS);
                girosCont++;
                while (pares < 1 || pares > 2)
                {
                    Console.WriteLine("Eleccion incorrecta. Intenta con otra.");
                    paresS = Console.ReadLine();
                    pares = Int32.Parse(paresS);
                }
                if (pares == 1)
                {
                    aleatorio3 = r.Next(0, 37);
                    for (int i = 0; i < numPar.Count; i++)
                    {
                        if (aleatorio3 == numPar[i])
                        {
                            encontrado2 = true;
                            break;
                        }
                    }
                    if (encontrado2 == true)
                    {
                        balance *= 2;
                        ganancia += balance;
                        Console.WriteLine("¡¡FELICIDADES!! HAS ACERTADO EL TIPO DE NUMERO\n");
                        paresCont++;
                    }
                    else
                    {
                        balance -= balance;
                        
                        Console.WriteLine($"Demonios!! No has acertado, la bola cayo en un numero impar.\n");
                        imparesCont++;
                    }

                }
                else if (pares == 2)
                {
                    aleatorio3 = r.Next(0, 37);
                    for (int i = 0; i < numImpar.Count; i++)
                    {
                        if (aleatorio3 == numImpar[i])
                        {
                            encontrado2 = true;
                            break;
                        }
                    }
                    if (encontrado2 == true)
                    {
                        balance *= 2;
                        ganancia += balance;
                        Console.WriteLine("¡¡FELICIDADES!! HAS ACERTADO EL TIPO DE NUMERO\n");
                        imparesCont++;
                    }
                    else
                    {
                        balance -= balance;
                        
                        Console.WriteLine($"Demonios!! No has acertado, la bola cayo en el un numero par.\n");
                        paresCont++;
                    }
                }
            }
            else
            {
                Console.WriteLine("No tienes suficiente dinero para apostar, intentar agregar mas dinero para jugar.\n");
            }
        }


        public void numeroMasRepetido()
        {
            int maximoNumRepeticiones = 0;
            double moda = 0;
            numeroRuleta.Sort();
            for (int i = 0; i < numeroRuleta.Count; i++)
            {
                int numRepeticiones = 0;
                for (int j = 0; j < numeroRuleta.Count; j++)
                {
                    if (numeroRuleta[i] == numeroRuleta[j])
                    {
                        numRepeticiones++;
                    }   //fin if
                    if (numRepeticiones > maximoNumRepeticiones)
                    {
                        moda = numeroRuleta[i];
                        maximoNumRepeticiones = numRepeticiones;
                    }   //fin if
                }
            }
            Console.WriteLine($"El valor que mas veces se ha tirado es {moda}");
        }
        public void numeroMenosRepetido()
        {
            numeroRuleta.Sort();
            int maximoNumRepeticiones = 0;
            double modaInversa = 0;
            numeroRuleta.Sort();
            for (int i = 0; i < numeroRuleta.Count; i++)
            {
                int numRepeticiones = 0;
                for (int j = 0; j < numeroRuleta.Count; j++)
                {
                    if (numeroRuleta[i] != numeroRuleta[j])
                    {
                        numRepeticiones++;
                    }   //fin if
                    if (numRepeticiones > maximoNumRepeticiones)
                    {
                        modaInversa = numeroRuleta[i];
                        maximoNumRepeticiones = numRepeticiones;
                    }   //fin if
                }
            }
            Console.WriteLine($"El valor que menos veces se ha tirado es {modaInversa}");
        }
        public void menuEstadisticas()
        {
            int opcion2;
            do
            {
                Console.WriteLine("MENU DE ESTADISTICAS\n" +
        "1-.Balance\n" +
        "2.-Cantidad de giros realizadas\n" +
        "3.-Número que más veces se ha tirado\n" +
        "4.-Número que menos veces se ha tirado\n" +
        "5-.Cantidad de resultados rojos\n" +
        "6.-Cantidad de resultados negros\n" +
        "7.-Cantidad de resultados pares\n" +
        "8.-Cantidad de resultados impares\n" +
        "9.-Ganacias\n" +
        "0.-Salir\n" +
        "POR FAVOR ELIGE UNA OPCION");

                string opcion2S = Console.ReadLine();
                opcion2 = Int32.Parse(opcion2S);
                switch (opcion2)
                {
                    case 1:
                        Console.WriteLine($"Tu balance Actual es ${balance}\n");
                        break;
                    case 2:
                        Console.WriteLine($"Giraste la ruleta {girosCont} veces\n");
                        break;
                    case 3:
                        numeroMasRepetido();
                        break;
                    case 4:
                        numeroMenosRepetido();
                        break;
                    case 5:
                        Console.WriteLine($"La cantidad de resultados rojos en la ruleta es {rojosCont}");
                        break;
                    case 6:
                        Console.WriteLine($"La cantidad de resultados negros en la ruleta es {negrosCont}");
                        break;
                    case 7:
                        Console.WriteLine($"La cantidad de resultados pares en la ruleta es {paresCont}");
                        break;
                    case 8:
                        Console.WriteLine($"La cantidad de resultados impares en la ruleta es {imparesCont}");
                        break;
                    case 9:
                        Console.WriteLine($"tienes una ganancia de ${ganancia}");
                        break;
                }
            }
            while (opcion2 != 0);
            
        }
    }
        
}
