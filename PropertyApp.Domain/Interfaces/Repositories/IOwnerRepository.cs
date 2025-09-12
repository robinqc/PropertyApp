using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyApp.Domain.Interfaces.Repositories
{
    public interface IOwnerRepository<T, TID> : ICreate<T>, IList<T, TID>, IUpdate<T>, IDelete<TID>, ITransaction
    {
    }
}
