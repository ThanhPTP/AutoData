using System.Collections.Generic;

namespace AutoData
{
    public interface ISeparatable
    {
        List<Block> GetAllDataTypes<T>();
        List<Block> GetAllDataTypes(object data);
    }
}
