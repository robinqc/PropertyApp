using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyApp.Domain;
using PropertyApp.Domain.Interfaces.Repositories;
using PropertyApp.Infrastructure.Data.Contexts;
using System.Linq;

namespace PropertyApp.Infrastructure.Data.Repositories
{
    public class PropertyRepository : IBaseRepository<Property, Guid>
    {
        private readonly PropertyContext db;

        public PropertyRepository(PropertyContext _db)
        {
            db = _db;
        }
        public void Commit()
        {
            db.SaveChanges();
        }

        public Property Create(Property entity)
        {
            entity.IdProperty = Guid.NewGuid();
            db.Properties.Add(entity);
            return entity;
        }

        public void Delete(Guid id)
        {
            var existingProperty = db.Properties.Where(p => p.IdProperty == id).FirstOrDefault();
            if (existingProperty != null)
            {
                db.Properties.Remove(existingProperty);
                this.Commit();
            }
        }

        public Property GetById(Guid id)
        {
            var property = db.Properties.Where(p => p.IdProperty == id).FirstOrDefault();
            if (property == null)
            {
                throw new KeyNotFoundException($"Property with Id {id} not found.");
            }
            return property;
        }

        public List<Property> List()
        {
            return db.Properties.ToList();
        }

        public void Update(Property entity)
        {
            var existingProperty = db.Properties.Where(p => p.IdProperty == entity.IdProperty).FirstOrDefault();
            if (existingProperty != null)
            {
                existingProperty.Name = entity.Name;
                existingProperty.Address = entity.Address;
                existingProperty.Price = entity.Price;
                existingProperty.CodeInternal = entity.CodeInternal;
                existingProperty.Year = entity.Year;
                existingProperty.IdOwner = entity.IdOwner;
                db.Properties.Update(existingProperty);
            }
        }
    }
}
