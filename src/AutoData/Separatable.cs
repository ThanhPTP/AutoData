using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoData
{
    public abstract class Separatable : ISeparatable, IDisposable
    {
        private List<Block> _blocks;

        protected Separatable()
        {
            _blocks = new List<Block>();
        }

        #region Public

        public void Dispose()
        {
            _blocks.Clear();
        }

        ~Separatable()
        {
            _blocks.Clear();
        }

        #endregion

        #region Protected 

        public List<Block> GetAllDataTypes<T>() => GetAllDataTypes(default(T));

        public List<Block> GetAllDataTypes(object data) => _blocks = GetAllProps(data);

        #endregion

        #region Private

        private List<Block> GetAllProps(object data)
        {
            return data.GetType()
                .GetProperties()
                .Select(s => new Block
                {
                    DataType = DataType.Integer,
                    Name = s.Name,
                    Value = GetDataFromProp(s.Name, data)
                })
                .ToList();
        }

        private object GetDataFromProp(string prop, object source) => source.GetType().GetProperty(prop).GetValue(source);

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

        #endregion

    }
}
