using System;

namespace _1_function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] postClient = new string[0];
            string[] surNameClient = new string[0];
            string post = " ";
            string surName = " ";
            bool continueProgram = true;
            int userInput;

            while(continueProgram == true)
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
                        AddDossier(ref surNameClient, ref postClient, surName, post);
                        break;
                    case 2:
                        OutputMassiv(surNameClient, postClient);
                        break;
                    case 3:
                        DeliteDossier(ref surNameClient, ref postClient, userInput);
                        break;
                    case 4:
                        SearshResult(surName, surNameClient);
                        break;
                    case 5:
                        continueProgram = false;
                        break;
                }
            }           
        }
        static void AddDossier(ref string[] massiv1, ref string[] massiv2, string surName, string post)
        {
            Console.Write("Введите фамилию: ");
            surName = Console.ReadLine();
            Console.Write("Введите должность: ");
            post = Console.ReadLine();

            massiv1 = WriteInMassiv(massiv1, surName);
            massiv2 = WriteInMassiv(massiv2, post);
            Console.Clear();
        }
        static string[]  WriteInMassiv(string[] massiv, string variable)
        {
            string[] tempMassiv = new string[massiv.Length + 1];
            for (int i = 0; i < massiv.Length; i++)
            {
                tempMassiv[i] = massiv[i];
            }
            tempMassiv[tempMassiv.Length - 1] = variable;
            return tempMassiv;
        }
        static void OutputMassiv(string[] massiv1, string[] massiv2)
        {
            Console.SetCursorPosition(0, 15);
            for (int i = 0; i < massiv1.Length; i++)
            {
                Console.WriteLine((i + 1) + " " + massiv1[i] + " " + massiv2[i]);
            }
        }
        static void DeliteDossier(ref string[] massiv1, ref string[] massiv2, int userInput)
        {
            Console.Write("Введите номер досье для удаления: ");
            userInput = Convert.ToInt32(Console.ReadLine());

            massiv1 = DeliteInMassiv(massiv1, userInput);
            massiv2 = DeliteInMassiv(massiv2, userInput);
            Console.Clear();
        }
        static string[] DeliteInMassiv(string[] massiv, int userInput)
        {
            int index = 0;
            string[] tempMassiv = new string[massiv.Length - 1];
            for (int i = 0; i < tempMassiv.Length; i++)
            {
                if (index != (userInput - 1))
                {
                    tempMassiv[i] = massiv[index];
                    index++;
                }
                else
                {
                    index++;
                    tempMassiv[i] = massiv[index];
                }
            }
            return tempMassiv;
        }
        static void SearshResult(string name, string[] massiv)
        {
            Console.Write("Введите фамилию для поиска: ");
            name = Console.ReadLine();
            Console.Write("Дааная фамилия встречаеться в следующих досье: ");

            for (int i = 0; i < massiv.Length; i++)
            {
                if (massiv[i].ToLower() == name.ToLower())
                {
                    Console.Write((i+1) + " ");
                }
            }
        }
    }
}
