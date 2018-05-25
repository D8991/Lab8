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
   public class Journal : Good
    {
        [DataMember]
        public DateTime DataOfPublic { get; set; }
      
        public Journal(Sale Good_Name, string Book_Title, double Price, DateTime DataOfPublic) : base(Good_Name, Book_Title, Price)
        {
            this.DataOfPublic = DataOfPublic;

        }
        public Journal()
        { }
        public override string gd()
        {

            return "Название товара: " + Good_Name + ";" + "Заголовок: " + Book_Title + ";" + "Цена: " + Price + ";" + "Дата издания: " + DataOfPublic.ToString("dd MMMM yyyy");

        }
    }
}
