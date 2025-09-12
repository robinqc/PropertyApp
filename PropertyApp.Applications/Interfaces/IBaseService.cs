using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyApp.Domain.Interfaces;
using PropertyApp.Domain.Interfaces.Repositories;

namespace PropertyApp.Applications.Interfaces
{
    interface IBaseService<T, TID>
        : ICreate<T>, IList<T, TID>, IUpdate<T>, IDelete<TID>
    {
    }
}
