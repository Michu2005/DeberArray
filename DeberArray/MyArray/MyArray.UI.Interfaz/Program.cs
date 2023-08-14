
using MyArray.Logic;
using System;

try
{
    var continuar = true;
    var array = new Areglos(10);
    while (continuar)
    {
        Console.WriteLine($"El arreglo quedaria de la siguiente manera:\n {array}");
        // 1. Imprimir mensaje que diga: ingrese la opcion que desea
        Console.WriteLine("==============MENÚ PRINCIPAL=============");
        Console.Write("Seleccione la opción que desea: \n\t");
        Console.WriteLine(" 1. Agregar número \n\t 2. Insertar número \n\t 3. Llenar matriz \n\t 4. Números primos \n\t 5. Números pares \n\t 6. Números no repetidos \n\t 7. Números más repetidos");
        Console.WriteLine("Ingrese la opción que desea: ");
        // 2. Leer el valor ingresado por el usuario con readline
        int opcion = int.Parse(Console.ReadLine());
        // 3. Switch que llama a la opcion seleccionada
        switch (opcion)
        {
            case 1:
                Console.WriteLine("Ingrese el número que desea agregar: ");
                var numeroAgregado = Console.ReadLine();
                // 3.1 mostrar el resultado de la opcion seleccionada
                Console.WriteLine($"El número ingresado es: {numeroAgregado}");
                if (numeroAgregado != null)
                {
                    array.Add(int.Parse(numeroAgregado));
                }
                break;
            case 2:
                Console.WriteLine("Ingrese la posicion que desea insertar: ");
                var posicionInsertada = Console.ReadLine();
                Console.WriteLine($"La posicion ingresado es: {posicionInsertada}");
                Console.WriteLine("Ingrese el numero que desea insertar: ");
                var numeroInsertado = Console.ReadLine();
                Console.WriteLine($"La posición ingresado es: {numeroInsertado}");
                if(posicionInsertada != null && numeroInsertado != null)
                {
                    array.Insertar(int.Parse(posicionInsertada), int.Parse(numeroInsertado));
                }
                
                break;
            case 3:
                array.Fill(1, 100);
                break;
            case 4:
                var getPrimos = array.Primo();
                Console.WriteLine($"Los números primos son: {getPrimos.N} \n{getPrimos}");
                break;
            case 5:
                var getPares = array.Pares();
                Console.WriteLine($"Los números pares son: {getPares.N}\n {getPares}");
                break;
            case 6:
                array.Sort();
                var noRepeat = array.NotRepeat();
                Console.WriteLine($"Los números que no se repiten son: {noRepeat.N}\n{noRepeat}");
                break;
            case 7:
                array.Sort();
                var repeat = array.Repeated();
                Console.WriteLine($"Los números que más se repiten son: {repeat.N}\n{repeat}");
                break;
            default:
                Console.WriteLine("La opción seleccionada no es válida");
                break;
        }

        Console.WriteLine("***** Desea continuar [S/N] ****");
        // 4 indicar si desea continuar S/N
        Console.WriteLine("Ingrese su respuesta [S/N]: ");
        var verificar = Console.ReadLine();
        if ("N".Equals(verificar))
        {
            continuar = false;
        }
    }
}

catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

