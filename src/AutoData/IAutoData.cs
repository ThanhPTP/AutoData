using System.Collections.Generic;

namespace AutoData
{
    public interface IAutoData: IFillable
    {
        void Fill(object data);
        IEnumerable<T> Create<T>(int number);
        T Fill<T>();
    }
}
