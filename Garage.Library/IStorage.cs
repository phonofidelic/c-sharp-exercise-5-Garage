using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Library
{
    public interface IStorage<TData>
    {
        Queue<TData> GetAll();

        int Add(TData data);
    }
}
