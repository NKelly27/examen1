using System;

class Program
{
    // Realmente en su mayoria use arreglos, funciones, como while, if, else, for, ya que a mi parecer son las que más se me facilitan
    // en este momento de mi carrera, aparte de que aún siendo bases en la programacion siguen siendo sumamente utiles. 
    // ademas de ello dividí las funciones con el fin de no hacer todo junto para evitar errores. 
    static string[] dias = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes" };

    static string[] materias = { "Español", "Matemáticas", "Ciencias", "Ciencias Sociales" };

    static string[,,] horario = new string[5, 4, 3];

    static void Main(string[] args)
    {
        int opcion = 0;

        while (opcion != 5)
        {
            Console.Clear();
            Console.WriteLine("===== PLANIFICADOR DE CLASES =====");
            Console.WriteLine("1. Registrar estudiante");
            Console.WriteLine("2. Eliminar estudiante");
            Console.WriteLine("3. Consultar estudiantes por materia y día");
            Console.WriteLine("4. Consultar estudiantes por día completo");
            Console.WriteLine("5. Salir");
            Console.Write("Elija una opción: ");

            string entrada = Console.ReadLine();
            int.TryParse(entrada, out opcion);

            if (opcion == 1)
            {
                Registrar();
            }
            else if (opcion == 2)
            {
                Eliminar();
            }
            else if (opcion == 3)
            {
                ConsultarPorMateria();
            }
            else if (opcion == 4)
            {
                ConsultarPorDia();
            }
            else if (opcion == 5)
            {
                Console.WriteLine("¡Gracias por usar el calendario!");
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente otra vez.");
            }

            if (opcion != 5)
            {
                Console.WriteLine("\nPresiona cualquier tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void Registrar()
    {
        int dia = SeleccionarDia();
        int materia = SeleccionarMateria();

        Console.Write("Nombre del estudiante: ");
        string nombre = Console.ReadLine();

        for (int i = 0; i < 3; i++)
        {
            if (horario[dia, materia, i] == nombre)
            {
                Console.WriteLine("El estudiante ya está en esta clase.");
                return;
            }
        }

        for (int i = 0; i < 3; i++)
        {
            if (string.IsNullOrEmpty(horario[dia, materia, i]))
            {
                horario[dia, materia, i] = nombre;
                Console.WriteLine("Estudiante registrado con éxito.");
                return;
            }
        }

        Console.WriteLine("No hay espacio en esta clase (máximo 3 estudiantes).");
    }

    static void Eliminar()
    {
        int dia = SeleccionarDia();
        int materia = SeleccionarMateria();

        Console.Write("Nombre del estudiante a eliminar: ");
        string nombre = Console.ReadLine();

        for (int i = 0; i < 3; i++)
        {
            if (horario[dia, materia, i] == nombre)
            {
                horario[dia, materia, i] = null;
                Console.WriteLine("Estudiante eliminado.");
                return;
            }
        }

        Console.WriteLine("Estudiante no encontrado en esta clase.");
    }

    static void ConsultarPorMateria()
    {
        int dia = SeleccionarDia();
        int materia = SeleccionarMateria();

        Console.WriteLine($"Estudiantes en {materias[materia]} el {dias[dia]}:");

        for (int i = 0; i < 3; i++)
        {
            if (!string.IsNullOrEmpty(horario[dia, materia, i]))
            {
                Console.WriteLine("- " + horario[dia, materia, i]);
            }
        }
    }

    static void ConsultarPorDia()
    {
        int dia = SeleccionarDia();

        Console.WriteLine($"Estudiantes en el día {dias[dia]}:");

        for (int m = 0; m < 4; m++)
        {
            Console.WriteLine("\nMateria: " + materias[m]);
            for (int i = 0; i < 3; i++)
            {
                if (!string.IsNullOrEmpty(horario[dia, m, i]))
                {
                    Console.WriteLine("- " + horario[dia, m, i]);
                }
            }
        }
    }

    static int SeleccionarDia()
    {
        Console.WriteLine("\nSeleccione un día:");
        for (int i = 0; i < dias.Length; i++)
        {
            Console.WriteLine((i + 1) + ". " + dias[i]);
        }

        int dia;
        while (!int.TryParse(Console.ReadLine(), out dia) || dia < 1 || dia > 5)
        {
            Console.Write("Opción inválida. Elija un número del 1 al 5: ");
        }

        return dia - 1;
    }

    static int SeleccionarMateria()
    {
        Console.WriteLine("\nSeleccione una materia:");
        for (int i = 0; i < materias.Length; i++)
        {
            Console.WriteLine((i + 1) + ". " + materias[i]);
        }

        int materia;
        while (!int.TryParse(Console.ReadLine(), out materia) || materia < 1 || materia > 4)
        {
            Console.Write("Opción inválida. Elija un número del 1 al 4: ");
        }

        return materia - 1;
    }
}
