using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoData
{
    public class TreeBlock
    {
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

        public void Map(List<Block> block) => Blocks = block;
    }
}
