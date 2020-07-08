using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoData
{
    public class TreeBlock
    {
        private readonly ISeparatable separatable;
        private readonly IFillable fillable;

        public TreeBlock(ISeparatable separatable, IFillable fillable)
        {
            this.separatable = separatable;
            this.fillable = fillable;
        }

        public List<Block> Blocks { get; set; }

        public int Count()
        {
            return Blocks.Count;
        }

        public List<Block> Get(Func<Block, bool> predicate)
        {
            var result = Blocks.Where(predicate);
            return result.Any() ? result.ToList() : null;
        }

        private void Map(object data) => Blocks = separatable.GetAllDataTypes(data);

        public void Fill(object data)
        {
            Map(data);

            foreach (var block in Blocks)
            {
                if (block.DataType == DataType.Class)
                {
                    var subProp = separatable.GetPropertyInfo(data, block.Name);
                    var subData = Activator.CreateInstance(subProp.PropertyType);

                    Fill(subData);

                    subProp.SetValue(data, subData);
                }
                else
                {
                    fillable.SetValue(data, block);
                }
            }
        }
    }
}
