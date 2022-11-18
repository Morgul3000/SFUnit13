using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace SFUnit13_InsertTextToLink
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string book = File.ReadAllText(@"C:\Users\udav\Desktop\test.txt");  //считываем текст в строку
            char[] chars = new char[] { ' ', '\n', '\r', '.', ',', '-', };

            string[] text = book.Split(chars, StringSplitOptions.RemoveEmptyEntries); //делим строку на массив строк

            List<string> list1 = new List<string>(text);            //Инициируем List 
            LinkedList<string> list2 = new LinkedList<string>(text);    //Инициируем LinkedList 

            Stopwatch stopwatch1 = Stopwatch.StartNew();   //Замеряем сорость работы при первой вставке в Листе
            list1.Insert(1, "Вставка строки");
            Console.WriteLine($"Время на вставку первого элемента (одна итерация) в простой список составляет {stopwatch1.Elapsed.TotalMilliseconds}  мс");

            //Замеряем сорость работы при второй вставке в Листе
            Stopwatch stopwatch1_2 = Stopwatch.StartNew();
            list1.Insert(1, "Вставка строки");
            Console.WriteLine($"Время на вставку второго элемента (одна итерация) в простой список составляет {stopwatch1_2.Elapsed.TotalMilliseconds}  мс");

            //Замеряем сорость работы при вставке 100 элементов в Листе
            Stopwatch stopwatch2 = Stopwatch.StartNew();
            for(int i = 0; i < 100; i++) 
            {
                list1.Insert(1, "Вставка строки");
            }
            Console.WriteLine($"Время на вставку (100 итераций) в простой список составляет {stopwatch2.Elapsed.TotalMilliseconds} мс");

            Console.WriteLine();

            Stopwatch stopwatch3 = Stopwatch.StartNew();           //Замеряем сорость работы при первой вставке в ЛинкедЛисте
            list2.AddAfter(list2.First, "Вставка строки");
            Console.WriteLine($"Время на вставку первого элемента (одна итерация) в связанный список составляет {stopwatch3.Elapsed.TotalMilliseconds} мс");

            //Замеряем сорость работы при второй вставке в ЛинкедЛисте
            Stopwatch stopwatch3_2 = Stopwatch.StartNew();
            list2.AddAfter(list2.First, "Вставка строки");
            Console.WriteLine($"Время на вставку второго элемента (одна итерация) в связанный список составляет {stopwatch3_2.Elapsed.TotalMilliseconds} мс");

            //Замеряем сорость работы при вставке 100 элементов в ЛинкедЛисте
            Stopwatch stopwatch4 = Stopwatch.StartNew();
            for(int i = 0; i < 100; i++) 
            {
                list2.AddAfter(list2.First, "Вставка строки");
            }       
            Console.WriteLine($"Время на вставку (100 итераций) в связанный список составляет {stopwatch4.Elapsed.TotalMilliseconds}  мс");
        }
    }
}
