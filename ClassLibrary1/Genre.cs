using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;

namespace ClassLibraryBookShop
{
    [Serializable]
    [DataContract]
  public class Genre : Good, IGenre
    {
        [DataMember]
        public string Book_Author { get; set; }
        [DataMember]
        public string Book_Publisher { get; set; }
        [DataMember]
        public Good Book_Genre { get; set; }

        public Genre()
        { }
        public Genre(Sale Good_Name, string Book_Title, double Price, string Book_Author, string Book_Publisher, Sale Book_Genre) : base(Good_Name, Book_Title, Price)
        {
            this.Book_Author = Book_Author;
            this.Book_Publisher = Book_Publisher;

        }
        public override string gd()
        {
            return "Наименоване товара: " + Good_Name + "; " + "Заголовок: " + Book_Title + "; " + "Цена: " + Price + "; " + "Автор: " + Book_Author + "; " + "Издательство: " + Book_Publisher;
        }
    }
}
