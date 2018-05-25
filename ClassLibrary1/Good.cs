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
   public abstract class Good
    {
        [DataMember]
        public Sale Good_Name { get; set; }
        [DataMember]
        public string Book_Title { get; set; }
        [DataMember]

        public double Price { get; set; }

        public Good()
        { }
        public Good(Sale Good_Name, string Book_Title, double Price)
        {
            this.Good_Name = Good_Name;
            this.Book_Title = Book_Title;
            this.Price = Price;
        }
        public abstract string gd();

    }
}

