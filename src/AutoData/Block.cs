namespace AutoData
{
    public class Block
    {
        public string Name { get; set; }
        public DataType DataType { get; set; }
        public object Value { get; set; }
        private Block _parent { get; }

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
