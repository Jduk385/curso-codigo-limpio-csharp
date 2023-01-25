using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> taskList { get; set; }

        static void Main(string[] args)
        {
            taskList = new List<string>();
            int menuSeleted = 0;
            do
            {
                menuSeleted = ShowMainMenu();
                if ((Menu)menuSeleted == Menu.Add)
                {
                    ShowMenuAdd();
                }
                else if ((Menu)menuSeleted == Menu.Remove)
                {
                    ShowMenuRemove();
                }
                else if ((Menu)menuSeleted == Menu.List)
                {
                    ShowMenuTaskList();
                }
            } while ((Menu)menuSeleted != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string optionToDo = Console.ReadLine();
            return Convert.ToInt32(optionToDo);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                
                ShowTaskList();

                string optionToRemove = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(optionToRemove) - 1;
                if (indexToRemove > -1 && taskList.Count > 0)
                {
                    string taskRemoved = taskList[indexToRemove];
                    taskList.RemoveAt(indexToRemove);
                    Console.WriteLine("Tarea " + taskRemoved + " eliminada");
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string taskName = Console.ReadLine();
                taskList.Add(taskName);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuTaskList()
        {
            if (taskList == null || taskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                ShowTaskList();
            }
        }

        private static void ShowTaskList()
        {
            Console.WriteLine("----------------------------------------");
            int indexNumber = 0;
            taskList.ForEach(task => Console.WriteLine(++indexNumber +". " + task));
            Console.WriteLine("----------------------------------------");
        }
    }
}
