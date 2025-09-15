using MongoDB.Bson;
using MongoDB.EntityFrameworkCore.Extensions;
using PropertyApp.Domain;
using PropertyApp.Domain.Interfaces.Repositories;
using PropertyApp.Infrastructure.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyApp.Infrastructure.Data.Repositories
{
    public class PropertyRepository : IBaseRepository<Property, ObjectId>
    {
        private readonly Contexts.MainContext db;

        public PropertyRepository(Contexts.MainContext _db)
        {
            db = _db;
        }
        public void Commit()
        {
            db.SaveChanges();
        }

        public Property Create(Property entity)
        {
            entity.IdProperty = ObjectId.GenerateNewId();
            db.Properties.Add(entity);
            return entity;
        }

        public void Delete(ObjectId id)
        {
            var existingProperty = db.Properties.Where(p => p.IdProperty == id).FirstOrDefault();
            if (existingProperty != null)
            {
                db.Properties.Remove(existingProperty);
                this.Commit();
            }
        }

        public Property GetById(ObjectId id)
        {
            var property = db.Properties.Where(p => p.IdProperty == id).FirstOrDefault();
            if (property == null)
            {
                throw new KeyNotFoundException($"Property with Id {id} not found.");
            }
            var images = db.PropertyImages.Where(p => p.IdProperty == property.IdProperty.ToString()).ToList();
            // print out images result
            Trace.WriteLine("printing...");
            foreach (PropertyImage image in images)
            {
                Trace.WriteLine(image.File);
            }
            if (images != null && images.Count > 0)
            {
                property.Images = images;
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
