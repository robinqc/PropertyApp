using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyApp.Domain
{
    public class Property
    {
        public ObjectId IdProperty{ get; set; }
        public string? IdOwner { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Address { get; set; }
        public string? CodeInternal { get; set; }
        public int? Year { get; set; }
        public string? Overview { get; set; }
        public int? Area { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? County { get; set; }
        public int? ZipCode { get; set; }
        public string? Type { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public int? GarageSpaces { get; set; }
        public int? LivableArea { get; set; }
        public int? TotalArea { get; set; }

        [NotMapped]
        public List<PropertyImage>? Images { get; set; }
    }
}
