using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyApp.Applications.Interfaces;
using PropertyApp.Domain;
using PropertyApp.Domain.Interfaces;
using PropertyApp.Domain.Interfaces.Repositories;

namespace PropertyApp.Applications.Services
{
    public class OwnerService: IOwnerService<Owner, Guid>
    {
        private readonly IBaseRepository<Owner, Guid> ownerRepository;
        public OwnerService(IBaseRepository<Owner, Guid> _ownerRepository)
        {
            ownerRepository = _ownerRepository;
        }
        public Owner Create(Owner obj)
        {
            if (obj == null)
                throw new ArgumentNullException("The object to be created cannot be null");
            var res = ownerRepository.Create(obj);
            ownerRepository.Commit();
            return res;
        }
        public void Delete(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("The id to be deleted cannot be empty");
            ownerRepository.Delete(id);
            ownerRepository.Commit();
        }
        public List<Owner> List()
        {
            return ownerRepository.List();
        }
        public Owner GetById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException("The id to be retrieved cannot be empty");
            return ownerRepository.GetById(id);
        }
        public void Update(Owner obj)
        {
            if (obj == null)
                throw new ArgumentNullException("The object to be updated cannot be null");
            ownerRepository.Update(obj);
            ownerRepository.Commit();
        }

    }
}
