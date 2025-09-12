using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyApp.Applications.Interfaces;
using PropertyApp.Domain.Interfaces;
using PropertyApp.Domain.Interfaces.Repositories;
using PropertyApp.Domain;

namespace PropertyApp.Applications.Services
{
    public class PropertyService : IBaseService<Property, Guid>
    {
        private readonly IBaseRepository<Property, Guid> propertyRepository;
        public PropertyService(IBaseRepository<Property, Guid> _propertyRepository)
        {
            propertyRepository = _propertyRepository;
        }

        public Property Create(Property obj)
        {
            if (obj == null)
                throw new ArgumentNullException("The object to be created cannot be null");
            var res = propertyRepository.Create(obj);
            propertyRepository.Commit();
            return res;
        }

        public void Delete(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("The id to be deleted cannot be empty");
            propertyRepository.Delete(id);
            propertyRepository.Commit();
        }

        public List<Property> List()
        {
            return propertyRepository.List();
        }

        public List<Property> List(string? searchTerm, double? minPrice, double? maxPrice)
        {
            var properties = propertyRepository.List();

            // Filter by searchTerm
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var lowerTerm = searchTerm.ToLower();
                properties = properties.Where(p =>
                    (!string.IsNullOrEmpty(p.Name) && p.Name.ToLower().Contains(lowerTerm)) ||
                    (!string.IsNullOrEmpty(p.Address) && p.Address.ToLower().Contains(lowerTerm)) ||
                    (!string.IsNullOrEmpty(p.CodeInternal) && p.CodeInternal.ToLower().Contains(lowerTerm))
                ).ToList();
            }

            // Filter by minPrice
            if (minPrice.HasValue)
            {
                properties = properties.Where(p => p.Price.HasValue && p.Price.Value >= minPrice.Value).ToList();
            }

            // Filter by maxPrice
            if (maxPrice.HasValue)
            {
                properties = properties.Where(p => p.Price.HasValue && p.Price.Value <= maxPrice.Value).ToList();
            }

            return properties;
        }

        public Property GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("The id to be retrieved cannot be empty");
            return propertyRepository.GetById(id);
        }

        public void Update(Property obj)
        {
            if (obj == null)
                throw new ArgumentNullException("The object to be updated cannot be null");
            propertyRepository.Update(obj);
            propertyRepository.Commit();
        }
    }
}
