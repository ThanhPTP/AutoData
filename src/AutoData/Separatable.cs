using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AutoData
{
    public class Separatable : ISeparatable
    {
        private List<Block> _blocks;

        public Separatable()
        {
            _blocks = new List<Block>();
        }

        #region Public 

        public List<Block> GetAllDataTypes<T>() => GetAllDataTypes(default(T));

        public List<Block> GetAllDataTypes(object data) => _blocks = GetAllProps(data);

        public Type ConvertDataType(DataType dataType) => DeserializeDataType(dataType);

        public PropertyInfo GetPropertyInfo(object data, string prop) => data.GetType().GetProperty(prop);
        #endregion

        #region Private

        private Type DeserializeDataType(DataType type) => type switch
        {
            DataType.Boolean => typeof(bool),
            DataType.Char => typeof(char),
            DataType.DateTime => typeof(DateTime),
            DataType.DateTimeOffset => typeof(DateTimeOffset),
            DataType.Double => typeof(double),
            DataType.Integer => typeof(int),
            DataType.String => typeof(string),
            DataType.Byte => typeof(byte),
            DataType.Long => typeof(long),
            DataType.Float => typeof(float),
            DataType.SByte => typeof(sbyte),
            DataType.UShort => typeof(ushort),
            DataType.Short => typeof(short),
            DataType.ULong => typeof(ulong),
            DataType.UInt => typeof(uint),
            DataType.Decimal => typeof(decimal),
            _ => throw new NotImplementedException()
        };

        private List<Block> GetAllProps(object data)
        {
            return data.GetType()
                .GetProperties()
                .Select(s => new Block
                {
                    DataType = SerializeDataType(s.PropertyType),
                    Name = s.Name,
                    Value = GetDataFromProp(data, s.Name)
                })
                .ToList();
        }

        private object GetDataFromProp(object source, string prop) => GetPropertyInfo(source, prop).GetValue(source);

        private DataType SerializeDataType(Type type)
        {
            if (type == typeof(bool))
            {
                return DataType.Boolean;
            }
            else if (type == typeof(char))
            {
                return DataType.Char;
            }
            else if (type == typeof(DateTime))
            {
                return DataType.DateTime;
            }
            else if (type == typeof(DateTimeOffset))
            {
                return DataType.DateTimeOffset;
            }
            else if (type == typeof(double))
            {
                return DataType.Double;
            }
            else if (type == typeof(int))
            {
                return DataType.Integer;
            }
            else if (type == typeof(string))
            {
                return DataType.String;
            }
            else if (type == typeof(byte))
            {
                return DataType.Byte;
            }
            else if (type == typeof(long))
            {
                return DataType.Long;
            }
            else if (type == typeof(float))
            {
                return DataType.Float;
            }
            else if (type == typeof(sbyte))
            {
                return DataType.SByte;
            }
            else if (type == typeof(ushort))
            {
                return DataType.UShort;
            }
            else if (type == typeof(short))
            {
                return DataType.Short;
            }
            else if (type == typeof(ulong))
            {
                return DataType.ULong;
            }
            else if (type == typeof(uint))
            {
                return DataType.UInt;
            }
            else if (type == typeof(decimal))
            {
                return DataType.Decimal;
            }
            else
            {
                return type.IsClass ? DataType.Class : DataType.Object;
            }
        }

        #endregion

    }
}
