using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryBookShop;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Sale book_Sale = new Sale("Книга");
            Sale journal_Sale = new Sale("Журнал");
            Sale genre_Sale = new Sale("Детектив");

            Book good1 = new Book(book_Sale, "Преступление и наказание", 250, "Достоевский", "Роман", "Э");
            Book good2 = new Book(book_Sale, "Мастер и маргарита", 300, "Булгаков", "Роман", "Эксмо");
            Journal good3 = new Journal(journal_Sale, "Наука", 150, new DateTime(2018,02,15));
            Journal good4 = new Journal(journal_Sale, "Вестник", 140, new DateTime(2018, 03,17));
            Genre good5 = new Genre(book_Sale, "Десять негритят", 150, "Агата Кристи", "Э", genre_Sale);

            List<Good> ListGood = new List<Good>();
            ListGood.Add(good1);
            ListGood.Add(good2);
            ListGood.Add(good5);
            ListGood.Add(good3);
            ListGood.Add(good4);

            List<Type> TypeList = new List<Type>();
            foreach (Good g in ListGood)
            {
                try
                {
                    TypeList.Add(g.GetType());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка {0}", ex.Message);
                }
            }

            DataContractJsonSerializer js = new DataContractJsonSerializer(ListGood.GetType(), TypeList.ToArray());
            using (FileStream fs = new FileStream("good.json", FileMode.OpenOrCreate))
            {
                js.WriteObject(fs, ListGood);
                Console.WriteLine("Сериализация JSON прошла успешно");
            }
            using (FileStream fs = new FileStream("good.json", FileMode.OpenOrCreate))
            {
                List<Good> ListDeserGood = js.ReadObject(fs) as List<Good>;
                foreach (Good gd in ListDeserGood)
                {

                    Console.WriteLine("Наименование товара: {0} ; Заголовок: {1}; Цена: {2}", gd.Good_Name, gd.Book_Title, gd.Price);


                }
            }
            Console.ReadLine();
        }
    }
}


        