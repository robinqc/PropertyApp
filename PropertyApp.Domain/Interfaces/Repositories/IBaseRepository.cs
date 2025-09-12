using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyApp.Domain.Interfaces;

namespace PropertyApp.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T, TID> : IList<T, TID>, ICreate<T>, IUpdate<T>, IDelete<TID>, ITransaction
    {
    }
}
