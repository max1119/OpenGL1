using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace CGOpenGL1
{
    class Program
    {

        private static int Menu(string [] arrComm)
        {
            foreach(var c in arrComm)
                Console.WriteLine(c);
            int comm = -1;
            string commStr;
            commStr = Console.ReadLine();
            comm = Convert.ToInt32(commStr);
            return comm;
        }

        static void Main(string[] args)
        {
            string c1 = "Введите 1, чтобы запустить Task1";
            string c2 = "Введите 2, чтобы запустить Task2";
            string c3 = "Введите 3, чтобы запустить Task3";
            string c4 = "Введите 4, чтобы выйти";
            string[] arrComm = new string[4] { c1, c2, c3, c4 };
            int comm = Menu(arrComm);
            switch (comm)
            {
                case 1: Task1.Execute(); break;
                case 2:
                    string c11 = "Введите 1, чтобы нарисовать треугольник";
                    string c12 = "Введите 2, чтобы нарисовать четырехугольник";
                    string c13 = "Введите 3, чтобы нарисовать цветной треугольник";
                    string[] arrComm1 = new string[3] { c11, c12, c13 };
                    int i = Menu(arrComm1);
                    if (i >= 1 && i <= 3)
                        Task2.Execute(i);
                    else
                        Console.WriteLine("Неверная команда");
                    break;
                case 3: Task3.Execute(); break;
                case 4: break;
                default: Console.WriteLine("Такой комманды нет"); break;
            }
        }

    }
}

