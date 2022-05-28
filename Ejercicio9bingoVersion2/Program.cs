/* Con los conocimientos vistos hasta ahora en clase realizar un programa que haga lo siguiente:
   Generar un programa que cree un cartón de bingo aleatorio y lo muestre por pantalla

1) Cartón de 3 filas por 9 columnas
2) El cartón debe tener 15 números y 12 espacios en blanco
3) Cada fila debe tener 5 números (osea que tambien debe tener 4 espacios en blanco)
4) Cada columna debe tener 1 o 2 números (si o si alguna columna tendra 3 numeros)
5) Ningún número puede repetirse
6) La primer columna contiene los números del 1 al 9, la segunda del 10 al 19, la tercera del 20 al 29, 
   así sucesivamente hasta la última columna la cual contiene del 80 al 90
7) Mostrar el carton por pantalla */

int[,] carton = new int[3, 9];
int[] numCargados = new int[27];
int[] blancosFila1 = new int[4];
int[] blancosFila2 = new int[4];
int[] blancosFila3 = new int[4];
int[] iguales = new int[4];

int i, j;
int k = 0;
int dato, dato1, dato2, dato3, aux, aux2;

string respuesta;

Random aleatorio = new Random();

do
{
    k = 0;
    // Lleno de numeros aleatorios TODO el carton de Bingo
    for (int columna = 0; columna < 9; columna++)
    {
        switch (columna)
        {
            case 0:
                i = 1;
                j = 10;
                break;

            case 1:
                i = 10;
                j = 20;
                break;

            case 2:
                i = 20;
                j = 30;
                break;

            case 3:
                i = 30;
                j = 40;
                break;

            case 4:
                i = 40;
                j = 50;
                break;

            case 5:
                i = 50;
                j = 60;
                break;

            case 6:
                i = 60;
                j = 70;
                break;

            case 7:
                i = 70;
                j = 80;
                break;

            default:
                i = 80;
                j = 91;
                break;
        }

        for (int fila = 0; fila < 3; fila++)
        {
            do
            {
                aux = 0;
                dato = aleatorio.Next(i, j);
                for (int l = 0; l < numCargados.Length; l++) // recorro el vector cargado para ver si el nuevo n° se repite
                {
                    if (dato == numCargados[l])
                    {
                        aux = 1;
                    }
                }
            } while (aux == 1);     // si es un n° repetido, vuelve a generar otro aleatorio
            carton[fila, columna] = dato;
            numCargados[k] = dato;  // cargo el nuevo numero en el vector que uso para controlar si se repiten los numeros
            k++;
        }
    }

    // Genero 4 posiciones por fila, para colocar espacios vacios en las filas 1 y 2
    for (int posicion = 0; posicion < 4; posicion++)
    {
        do
        {
            aux = 0;
            dato1 = aleatorio.Next(9);
            for (int l = 0; l < blancosFila1.Length; l++)
            {
                if (dato1 == blancosFila1[l])
                {
                    aux = 1;
                }
            }
        } while (aux == 1);
        blancosFila1[posicion] = dato1;

        do
        {
            aux = 0;
            dato2 = aleatorio.Next(9);
            for (int l = 0; l < blancosFila2.Length; l++)
            {
                if (dato2 == blancosFila2[l])
                {
                    aux = 1;
                }
            }
        } while (aux == 1);
        blancosFila2[posicion] = dato2;
    }

    // las posiciones que se repitan en las filas 1 y 2 las guardo en el vector "iguales" para compararlas luego con las de la Fila3
    for (int l = 0; l < 4; l++)
    {
        for (int m = 0; m < 4; m++)
        {
            if (blancosFila1[m] == blancosFila2[l])
            {
                iguales[m] = blancosFila1[m];
            }
        }
    }

    // Teniendo los espacios vacios de las filas 1 y 2, recien genero los espacios vacios de la fila 3 para poder comparar.
    // Si los espacios vacios de la Fila1 y Fila2 son los mismos, la Fila3 no puede tener espacio vacio en ese lugar
    for (int posicion = 0; posicion < 4; posicion++)
    {
        do
        {
            aux = 0;
            aux2 = 0;
            dato3 = aleatorio.Next(9);
            for (int l = 0; l < blancosFila3.Length; l++)
            {
                if (dato3 == blancosFila3[l])
                {
                    aux = 1;
                }
            }

            for (int l = 0; l < iguales.Length; l++)
            {
                if (dato3 == iguales[l])
                {
                    aux2 = 1;
                }
            }

        } while (aux == 1 || aux2 == 1);
        blancosFila3[posicion] = dato3;
    }


    // en la posiciones donde salieron los espacios en blanco, se coloca un "-1"
    for (int fila = 0; fila < 3; fila++)
    {
        for (int columna = 0; columna < 9; columna++)
        {
            switch (fila)
            {
                case 0:
                    for (int a = 0; a < 4; a++)
                    {
                        if (columna == blancosFila1[a])
                        {
                            carton[fila, columna] = -1;
                        }
                    }
                    break;

                case 1:
                    for (int a = 0; a < 4; a++)
                    {
                        if (columna == blancosFila2[a])
                        {
                            carton[fila, columna] = -1;
                        }
                    }
                    break;

                case 2:
                    for (int a = 0; a < 4; a++)
                    {
                        if (columna == blancosFila3[a])
                        {
                            carton[fila, columna] = -1;
                        }
                    }
                    break;
            }
        }
    }

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine(" ---  ---  ---  ---  ---  ---  ---  ---  --- ");
    for (int x = 0; x < 3; x++)
    {
        for (int y = 0; y < 9; y++)
        {
            if (carton[x, y] < 0)
            {
                Console.Write("|    ");
            }
            else
            {
                Console.Write($"| {carton[x, y]} ");
            }
        }
        Console.WriteLine();
        Console.WriteLine(" ---  ---  ---  ---  ---  ---  ---  ---  --- ");
    }

    //Console.WriteLine();
    //Console.WriteLine();
    //Console.WriteLine("Los numeros ingresados fueron: ");
    //for (int a = 0; a < numCargados.Length; a++)
    //{
    //    Console.Write($" {numCargados[a]} ");
    //}

    //Console.WriteLine();
    //Console.WriteLine();
    //Console.WriteLine("Posiciones en blanco fila 1");
    //for (int a = 0; a < 4; a++)
    //{
    //    Console.Write($" {blancosFila1[a]} ");
    //}
    //Console.WriteLine();
    //Console.WriteLine();
    //Console.WriteLine("Posiciones en blanco fila 2");
    //for (int a = 0; a < 4; a++)
    //{
    //    Console.Write($" {blancosFila2[a]} ");
    //}
    //Console.WriteLine();
    //Console.WriteLine();
    //Console.WriteLine("Posiciones en blanco fila 3");
    //for (int a = 0; a < 4; a++)
    //{
    //    Console.Write($" {blancosFila3[a]} ");
    //}

    Console.WriteLine();
    Console.WriteLine("Desea generar otro carton de Bingo? (S/N): ");
    respuesta = Console.ReadLine();

} while (respuesta.ToUpper() == "S");

