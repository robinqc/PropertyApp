using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyApp.Domain
{
    public class PropertyImage
    {
        public ObjectId IdPropertyImage { get; set; }
        public string? IdProperty { get; set; }
        public string? File { get; set; }
        public string? Enabled { get; set; }
    }
}
