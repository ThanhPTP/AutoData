using System.Collections.Generic;

namespace AutoData
{
    public interface IAutoData
    {
        void Fill(object data);
        IEnumerable<T> Create<T>(int number);
        T Fill<T>();
    }
}
