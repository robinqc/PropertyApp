using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyApp.Domain
{
    public class PropertyImage
    {
        public Guid IdPropertyImage { get; set; }
        public Guid IdProperty { get; set; }
        public string File { get; set; }
        public string Enabled { get; set; }
    }
}
