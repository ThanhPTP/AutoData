namespace AutoData
{
    public class Fillable : IFillable
    {
        private readonly IRandomize _random;
        public Fillable(IRandomize random)
        {
            _random = random;
        }

        public void SetValue(object desc, Block value) => desc
                                                            .GetType()
                                                            .GetProperty(value.Name)
                                                            .SetValue(desc, DeserializeDataValue(value));

        private object DeserializeDataValue(Block block) => block.DataType switch
        {
            DataType.Boolean => _random.GetBoolean(),
            DataType.Char => _random.GetChar(),
            DataType.DateTime => _random.GetDateTime(),
            DataType.DateTimeOffset => _random.GetDateTimeOffset(),
            DataType.Double => _random.GetDouble(),
            DataType.Integer => _random.GetInt(int.MinValue, int.MaxValue),
            DataType.String => $"{block.Name} {_random.GetString()}",
            DataType.Byte => _random.GetInt(byte.MinValue, byte.MaxValue),
            DataType.Long => _random.GetInt(),
            DataType.Float => _random.GetDouble(),
            DataType.SByte => _random.GetInt(sbyte.MinValue, sbyte.MaxValue),
            DataType.UShort => _random.GetInt(ushort.MinValue, ushort.MaxValue),
            DataType.Short => _random.GetInt(short.MinValue, short.MaxValue),
            DataType.ULong => _random.GetInt(0, (int.MaxValue / 2) - 1),
            DataType.UInt => _random.GetInt(0, (int.MaxValue / 2) - 1),
            DataType.Decimal => _random.GetDouble(),
            DataType.Class => null,
            DataType.Object => null,
            _ => null
        };
    }
}
