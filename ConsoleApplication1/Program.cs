using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryBookShop;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace ConsoleApplication1
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
            Journal good3 = new Journal(journal_Sale, "Наука", 150, new DateTime(15 / 02 / 2018));
            Journal good4 = new Journal(journal_Sale, "Вестник", 140, new DateTime(17 / 03 / 2018));
            Genre good5 = new Genre(book_Sale, "Десять негритят", 150, "Агата Кристи", "Э", genre_Sale);

            List<Good> ListGood = new List<Good>();
            ListGood.Add(good1);
            ListGood.Add(good2);
            ListGood.Add(good5);
            ListGood.Add(good3);
            ListGood.Add(good4);

            // массив для сериализации:
            Good[] good = new Good[] { good1, good2, good3, good4, good5 };

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream("tovar.dat", FileMode.OpenOrCreate))
            {
                // сериализуем весь массив tovar
                formatter.Serialize(fs, good);

                Console.WriteLine("Сериализация в поток байтов прошла успешно");
            }
            // десериализация
            using (FileStream fs = new FileStream("tovar.dat", FileMode.OpenOrCreate))
            {
                Good[] deserilizeGood = (Good[])formatter.Deserialize(fs);

                foreach (Good gd in deserilizeGood)

                    Console.WriteLine("Наименование товара: {0} ; Заголовок: {1}; Цена: {2}", gd.Good_Name, gd.Book_Title, gd.Price);

            }
            Console.ReadLine();
        }
    }
}
