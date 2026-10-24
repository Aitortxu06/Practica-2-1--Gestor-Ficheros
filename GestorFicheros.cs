using System;
using System.IO;
using System.Collections.Generic;

class GestorFicheros
{
    private String nombreFichero;

    public GestorFicheros()
    {
        nombreFichero = "";
    }

    private void PedirNombre()
    {
        Console.WriteLine("Introduce el nombre del fichero: ");
        nombreFichero = Console.ReadLine()!;
    }

    //1. Crear un Fichero Nuevo
    public void CrearFichero()
    {
        PedirNombre();

        if (File.Exists(nombreFichero))
        {
            Console.WriteLine("El fichero ya existe.");
            return; //Esto evita a que el fichero se vuelva a crear otra vez.
        }

        File.Create(nombreFichero).Close();

        Console.WriteLine("Fichero creado correctamente.");
    }

    //2. Añadir Registros
    public void AñadirRegistros()
    {
       PedirNombre();

        if (!File.Exists(nombreFichero))
        {
            Console.WriteLine("El fichero no existe.");
            return; // Salimos si no existe
        }

        //Leemos todas las lineas del fichero y lo guardamos en una lista 
        List<String> registros = new List<string>(
            File.ReadAllLines(nombreFichero));

        //Pedimos el nuevo registro al usuario 
        Console.Write("Introduce el registro que quieres añadir:");
        String nuevoRegistro = Console.ReadLine()!;

        //Añadimos el nuevo registro al final de la lista 
        registros.Add(nuevoRegistro);

        //Convertimos la lista en un array y guardo todos los registros
        File.WriteAllLines(nombreFichero, registros.ToArray());

        //Mensaje para confirmar que se ha añadido el registro
        Console.WriteLine("Registro añadido correctamente");
    }

    //3. Eliminar todos los registros
    public void VaciarFichero()
    {
        //Pedimos el nombre del fichero al usuario
        PedirNombre();

        //Comprobamos si el fichero existe
        if (!File.Exists(nombreFichero))
        {
            Console.WriteLine("El fichero no existe.");
            return; // Salimos si no existe
        }
        
        //Escribimos un array vacio para borrar todos los registro
        File.WriteAllLines(nombreFichero, new string[0]);

        //Mensaje de confirmación
        Console.WriteLine("Se han eliminado todos los registros.");

    }

    //4. Eliminar el Fichero
    public void EliminarFichero()
    {
        //Pedimos el nombre del fichero al usuario
        PedirNombre();

        //Comprobamos si el fichero existe
        if (!File.Exists(nombreFichero))
        {
            Console.WriteLine("El fichero no existe.");
            return; // Salimos si el fichero no existe
        }

        //Eliminamos el fichero
        File.Delete(nombreFichero);

        //Mensaje de confirmación
        Console.WriteLine("Fichero eliminado correctamente.");
    }

    //5. Visualizar los Registros
    public void VisualizarRegistros()
    {
        //Pedimos el nombre del fichero al usuario
        PedirNombre();

        //Comprobamos si el fichero existe
        if (!File.Exists(nombreFichero))
        {
            Console.WriteLine("El fichero no existe.");
            return; // Salimos si el fichero no existe
        }

        //Leemos todos los registros del fichero
        string[] registros = File.ReadAllLines(nombreFichero);

        //Comprobamos si el fichero esta vacio
        if (registros.Length == 0)
        {
            Console.WriteLine("El fichero está vacío.");
            return; //Salimos si no hay registros
        }

        Console.WriteLine("\n--- REGISTROS DEL FICHERO ---");

        //Recorremos y muestro todos los registros que hay en el fichero
        foreach(string registro in registros)
        {
            Console.WriteLine(registro);
        }
        
    }
}