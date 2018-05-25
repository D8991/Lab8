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
   public class Sale
    {
        [DataMember]
        public string Good_Name { get; set; }
     
        public Sale(string Good_Name)
        {
            this.Good_Name = Good_Name;
        }
        public Sale ()
            { }
        public override string ToString()
        {
            return Good_Name;
        }
    }
}
