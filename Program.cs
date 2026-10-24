using System;
using System.IO;

class Program
{
    static void Main (string[] args)
    {
        GestorFicheros gestor = new GestorFicheros();
        int opcion;

        do
        {
            Console.WriteLine("\n===== GESTOR DE FICHEROS =====");
            Console.WriteLine("1. Crear un nuevo fichero");
            Console.WriteLine("2. Añadir registros al fichero");
            Console.WriteLine("3. Eliminar todos los registros");
            Console.WriteLine("4. Eliminar el fichero");
            Console.WriteLine("5. Visualizar los registros");
            Console.WriteLine("6. Cerrar la aplicación");
            Console.Write("Elige una opción: ");

            //Comprueba si la opción introducida es un número válido
            if(!int.TryParse(Console.ReadLine(), out opcion)) //Comprueba si la opción introducida es un número válido
            {
                opcion = 0;
            }

            switch (opcion)
            {
                case 1:
                gestor.CrearFichero();
                break;

                case 2:
                gestor.AñadirRegistros();
                break;

                case 3:
                gestor.VaciarFichero();
                break;

                case 4:
                gestor.EliminarFichero();
                break;

                case 5:
                gestor.VisualizarRegistros();
                break;

                case 6:
                Console.WriteLine("Cerrando la aplicación...");
                break;

                default:
                Console.WriteLine("Opción no válida. Elige un numero de los que aparece en el menu porfavor.");
                break;
            }

            
        }while (opcion != 6);
    }
}