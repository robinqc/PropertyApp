using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace PropertyApp.Domain
{
    public class PropertyTrace
    {
        public ObjectId IdPropertyTrace { get; set; }
        public ObjectId IdProperty { get; set; }
        public DateTime DateSale { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? Tax { get; set; }
    }
}
