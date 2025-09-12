using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyApp.Domain.Interfaces
{
    public interface IList<T, TID>
    {
        List<T> List();
        T GetById(TID id);
    }
}
