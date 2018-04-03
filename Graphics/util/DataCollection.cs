using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics.util
{
    interface IDataCollection<T>
    {
        IDataCollection<T> Map(Func<IDataCollection<T>, double[], IDataCollection<T>> fun);

        IDataCollection<T> Map(Func<T, double[], T> fun);

    }
}
