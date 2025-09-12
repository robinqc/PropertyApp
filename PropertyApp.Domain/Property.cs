using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyApp.Domain
{
    public class Property
    {
        public Guid IdProperty{ get; set; }
        public Guid IdOwner { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Address { get; set; }
        public string? CodeInternal { get; set; }
        public int Year { get; set; }
    }
}
