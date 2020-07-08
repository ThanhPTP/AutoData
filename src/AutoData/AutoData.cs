using System;
using System.Collections.Generic;

namespace AutoData
{
    public class AutoData: Fillable, IAutoData
    {
        private static readonly TreeBlock _tree = new TreeBlock();

        public IEnumerable<T> Create<T>(int number)
        {
            List<T> objs = new List<T>();

            for (int i = 0; i < number; i++)
            {
                objs.Add(Fill<T>());
            }

            return objs;
        }

        public void Fill(object data)
        {
            Map(data);

            foreach (var block in _tree.Blocks)
            {
                if (block.DataType == DataType.Class)
                {
                    var subProp = GetPropertyInfo(data, block.Name);
                    var subData = Activator.CreateInstance(subProp.PropertyType);

                    Fill(subData);

                    subProp.SetValue(data, subData);
                }
                else
                {
                    SetValueToProp(data, block);
                }
            }
        }

        public T Fill<T>()
        {
            var data = Activator.CreateInstance(typeof(T));
            Fill(data);
            return (T)data;
        }

        private void Map(object data) => _tree.Map(GetAllDataTypes(data));
    }
}
