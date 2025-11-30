using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Library
{
    public interface IStorage<TData>
    {
        List<TData> GetAll();

        void Add(TData data);
    }
}
