using System;
using System.Collections.Generic;
using System.Reflection;

namespace AutoData
{
    public interface ISeparatable
    {
        List<Block> GetAllDataTypes<T>();
        List<Block> GetAllDataTypes(object data);
        Type ConvertDataType(DataType dataType);
        PropertyInfo GetPropertyInfo(object data, string prop);
    }
}
