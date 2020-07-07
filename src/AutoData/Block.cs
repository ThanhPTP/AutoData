namespace AutoData
{
    public class Block
    {
        public string Name { get; set; }
        public DataType DataType { get; set; }
        public object Value { get; set; }
        private Block _parent { get; }

        public Block()
        {
            _parent = null;
        }

        public Block(string name, DataType type, object value, Block parent)
        {
            Name = name;
            type = DataType;
            Value = value;
            _parent = parent;
        }

        public Block(Block parent)
        {
            _parent = parent;
        }

        public bool IsChild() => _parent != null;

        public Block GetParent() => _parent;

        public Block GetFirstParent()
        {
            Block cur = this;
            while (cur.IsChild())
            {
                cur = _parent;
            }

            return cur;
        }

    }
}
