using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Library
{
    public abstract class ApplicationStorage<TData> : IStorage<TData>
    {
        public abstract List<TData> GetAll();
        public abstract int Add(TData data);
    }
}
