using System;

namespace _1_function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] postClient = new string[0];
            string[] surNameClient = new string[0];
            bool isProgramContinuing = true;
            int userInput;

            while(isProgramContinuing == true)
            {
                Console.SetCursorPosition(0,0);
                Console.WriteLine("1 - Добавить досье");
                Console.WriteLine("2 - Вывести все досье");
                Console.WriteLine("3 - Удалить досье");
                Console.WriteLine("4 - Поиск по имени или фамилии");
                Console.WriteLine("5 - Выход");

                userInput = Convert.ToInt32(Console.ReadLine());
                
                switch (userInput)
                {
                    case 1:
                        AddDossier(ref surNameClient, ref postClient);
                        break;
                    case 2:
                        OutputAllDosiers(surNameClient, postClient);
                        break;
                    case 3:
                        DeliteDossier(ref surNameClient, ref postClient, userInput);
                        break;
                    case 4:
                        SearshSurname(surNameClient, postClient);
                        break;
                    case 5:
                        isProgramContinuing = false;
                        break;
                }
            }           
        }

        static void AddDossier(ref string[] array1, ref string[] array2)
        {
            string post = " ";
            string surName = " ";
            Console.Write("Введите фамилию: ");
            surName = Console.ReadLine();
            Console.Write("Введите должность: ");
            post = Console.ReadLine();

            array1 = WriteInArray(array1, surName);
            array2 = WriteInArray(array2, post);
            Console.Clear();
        }

        static string[]  WriteInArray(string[] array, string variable)
        {
            string[] tempArray = new string[array.Length + 1];

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }
            
            tempArray[tempArray.Length - 1] = variable;
            return tempArray;
        }

        static void OutputAllDosiers(string[] array1, string[] array2)
        {
            Console.SetCursorPosition(0, 15);

            for (int i = 0; i < array1.Length; i++)
            {
                Console.WriteLine((i + 1) + " " + array1[i] + " " + array2[i]);
            }
        }

        static void DeliteDossier(ref string[] array1, ref string[] array2, int variable)
        {
            Console.Write("Введите номер досье для удаления: ");
            variable = Convert.ToInt32(Console.ReadLine());

            array1 = DeliteInArray(array1, variable);
            array2 = DeliteInArray(array2, variable);
            
            Console.Clear();
        }

        static string[] DeliteInArray(string[] array, int veriable)
        {
            int index = 0;
            string[] tempArray = new string[array.Length - 1];

            for (int i = 0; i < tempArray.Length; i++)
            {
                if (index != (veriable - 1))
                {
                    tempArray[i] = array[index];
                    index++;
                }
                else
                {
                    index++;
                    tempArray[i] = array[index];
                }
            }
            return tempArray;
        }

        static void SearshSurname(string[] array1, string[] array2)
        {
            Console.Write("Введите фамилию для поиска: ");
            string surname = Console.ReadLine();
            Console.WriteLine($"Фамилия {surname} встречаеться в следующих досье: ");

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i].ToLower() == surname.ToLower())
                {
                    Console.WriteLine((i+1) + " " + array1[i] + " - " + array2[i]);
                }
            }
        }
    }
}
