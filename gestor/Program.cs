using System.Collections.Generic;

namespace GestorDeTareas
{
    class Tarea
    {
        public string Descripcion { get; set; }
        public bool Completa { get; set; } = false;
    }

    class Program
    {
        static List<Tarea> tareas = new List<Tarea>();

        static void Main(string[] args)
        {
            Console.WriteLine("=== Gestor de Tareas ===");
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\n1. Agregar tarea");
                Console.WriteLine("2. Ver tareas");
                Console.WriteLine("3. Completar tarea");
                Console.WriteLine("4. Salir");
                Console.Write("Selecciona una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarTarea();
                        break;
                    case "2":
                        MostrarTareas();
                        break;
                    case "3":
                        CompletarTarea();
                        break;
                    case "4":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }

            Console.WriteLine("¡Hasta luego!");
        }

        static void AgregarTarea()
        {
            Console.Write("Escribe la descripción de la tarea: ");
            string descripcion = Console.ReadLine();
            tareas.Add(new Tarea { Descripcion = descripcion });
            Console.WriteLine("Tarea agregada correctamente.");
        }

        static void MostrarTareas()
        {
            Console.WriteLine("\n=== Lista de Tareas ===");
            if (tareas.Count == 0)
            {
                Console.WriteLine("No hay tareas registradas.");
            }
            else
            {
                for (int i = 0; i < tareas.Count; i++)
                {
                    string estado = tareas[i].Completa ? "Completa" : "Incompleta";
                    Console.WriteLine($"{i + 1}. {tareas[i].Descripcion} - {estado}");
                }
            }
        }

        static void CompletarTarea()
        {
            MostrarTareas();
            if (tareas.Count == 0) return;

            Console.Write("Número de tarea a marcar como completa: ");
            if (int.TryParse(Console.ReadLine(), out int num) && num >= 1 && num <= tareas.Count)
            {
                tareas[num - 1].Completa = true;
                Console.WriteLine($"La tarea '{tareas[num - 1].Descripcion}' ahora está completa.");
            }
            else
            {
                Console.WriteLine("Número inválido.");
            }
        }
    }
}
