using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyApp.Domain;
using PropertyApp.Domain.Interfaces.Repositories;
using PropertyApp.Infrastructure.Data.Contexts;
using System.Linq;
using MongoDB.EntityFrameworkCore.Extensions;
using PropertyApp.Domain.Interfaces;

namespace PropertyApp.Infrastructure.Data.Repositories
{
    public class PropertyImageRepository: IBareRepository<PropertyImage, string>
    {
        private readonly Contexts.MainContext db;

        public PropertyImageRepository(Contexts.MainContext _db)
        {
            db = _db;
        }

        public List<PropertyImage> List(string IdProperty)
        {
            return db.PropertyImages.Where(p => p.IdProperty.ToString() == IdProperty).ToList();
        }
    }
}
