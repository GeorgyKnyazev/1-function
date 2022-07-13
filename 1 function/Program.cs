using System;

namespace _1_function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstNameMassiv = new string[0];
            string[] secondNameMassiv = new string[0];
            string firstname;
            string secondname;
            int[] searchFirstNameResult = new int[0];
            int[] searchSecondNameResult = new int[0];

            bool continueProgram = true;
            int userInput;
            string nameForSearch;

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
                        Console.Write("Введите имя: ");
                        firstname = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Введите фамилию: ");
                        secondname = Console.ReadLine();

                        firstNameMassiv = WriteInMassiv(firstname, firstNameMassiv);
                        secondNameMassiv = WriteInMassiv(secondname, secondNameMassiv);
                        Console.Clear();
                        break;

                    case 2:
                        Console.SetCursorPosition(0, 15);
                        OutputMassiv(firstNameMassiv, secondNameMassiv);
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Введите номер досье которое хотите удалить: ");
                        userInput = Convert.ToInt32(Console.ReadLine());

                        if(userInput <= firstNameMassiv.Length)
                        {
                            firstNameMassiv = DeliteNameInMassiv(firstNameMassiv, userInput);
                            secondNameMassiv = DeliteNameInMassiv(secondNameMassiv, userInput);
                        }
                        else
                        {
                            Console.WriteLine("нет досье с таким номером: " + userInput);
                        }

                        break;

                    case 4:
                        Console.WriteLine("Введите имя или фамилию кого хотите найти: ");
                        nameForSearch = Console.ReadLine();
                        searchFirstNameResult = SearshResult(nameForSearch, firstNameMassiv);
                        searchSecondNameResult = SearshResult(nameForSearch, secondNameMassiv);
                        
                        if(searchFirstNameResult.Length >= 0)
                        {
                            Console.Write("Данное имя встречаеться в следующих досье: ");
                            for (int i = 0; i < searchFirstNameResult.Length; i++)
                            {
                                Console.Write(searchFirstNameResult[i] + " ");
                            }
                        }
                        else if(searchSecondNameResult.Length >= 0)
                        {
                            Console.Write("Данная фамилия встречаеться в следующих досье: ");
                            for (int i = 0; i < searchSecondNameResult.Length; i++)
                            {
                                Console.Write(searchSecondNameResult[i] + " ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ничего не найдено");
                        }

                        break;

                    case 5:
                        //for (int i = 0; i < firstNameMassiv.Length; i++)
                        //{
                        //    Console.WriteLine((i+1)+ " " +  firstNameMassiv[i] + " " + secondNameMassiv[i]);
                        //}
                        continueProgram = false;
                        break;
                }
            }           
        }
        static string[] WriteInMassiv(string name, string[] massiv)
        {
            string[] tempMassiv = new string[massiv.Length + 1];
            for (int i = 0; i < massiv.Length; i++)
            {
                tempMassiv[i] = massiv[i];
            }
            tempMassiv[tempMassiv.Length - 1] = name;
            
            return tempMassiv;
        }
        static void OutputMassiv(string[] firstNameMassiv, string[] secondNameMassiv)
        {
            for (int i = 0; i < firstNameMassiv.Length; i++)
            {
                Console.WriteLine((i + 1) + " " + firstNameMassiv[i] + " " + secondNameMassiv[i]);
            }
        }
        static string[] DeliteNameInMassiv(string[] massiv, int userInput)
        {
            int j = 0;
            string[] tempMassiv = new string[massiv.Length - 1];
            for (int i = 0; i < tempMassiv.Length; i++)
            {
                if (j != (userInput - 1))
                {
                    tempMassiv[i] = massiv[j];
                    j++;
                }
                else
                {
                    j++;
                    tempMassiv[i] = massiv[j];
                }
            }
            return tempMassiv;
        }
        static int[] SearshResult(string name, string[] massiv)
        {
            int[] firstTempMassiv = new int[0];
            
            for (int i = 0; i < massiv.Length; i++)
            {
                if (massiv[i].ToLower() == name.ToLower())
                {
                    int[] secondTempMassiv = new int[firstTempMassiv.Length + 1];
                    for(int j = 0; j < secondTempMassiv.Length - 1 ; j++)
                    {
                        secondTempMassiv[j] = firstTempMassiv[j];
                    }
                    secondTempMassiv[secondTempMassiv.Length - 1] = (i + 1);
                    firstTempMassiv = secondTempMassiv;
                }
            }
            return firstTempMassiv;
        }
    }
}
