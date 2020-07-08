namespace AutoData
{
    public class Fillable : Separatable, IFillable
    {   
        public void SetValueToProp(object desc, Block value) => desc
                                                            .GetType()
                                                            .GetProperty(value.Name)
                                                            .SetValue(desc, DeserializeDataValueRandom(value));

        private object DeserializeDataValueRandom(Block block) => block.DataType switch
        {
            DataType.Boolean => RandomizeUtils.GetBoolean(),
            DataType.Char => RandomizeUtils.GetChar(),
            DataType.DateTime => RandomizeUtils.GetDateTime(),
            DataType.DateTimeOffset => RandomizeUtils.GetDateTimeOffset(),
            DataType.Double => RandomizeUtils.GetDouble(),
            DataType.Integer => RandomizeUtils.GetInt(int.MinValue, int.MaxValue),
            DataType.String => $"{block.Name} {RandomizeUtils.GetString()}",
            DataType.Byte => RandomizeUtils.GetInt(byte.MinValue, byte.MaxValue),
            DataType.Long => RandomizeUtils.GetInt(),
            DataType.Float => RandomizeUtils.GetDouble(),
            DataType.SByte => RandomizeUtils.GetInt(sbyte.MinValue, sbyte.MaxValue),
            DataType.UShort => RandomizeUtils.GetInt(ushort.MinValue, ushort.MaxValue),
            DataType.Short => RandomizeUtils.GetInt(short.MinValue, short.MaxValue),
            DataType.ULong => RandomizeUtils.GetInt(0, (int.MaxValue / 2) - 1),
            DataType.UInt => RandomizeUtils.GetInt(0, (int.MaxValue / 2) - 1),
            DataType.Decimal => RandomizeUtils.GetDouble(),
            DataType.Class => null,
            DataType.Object => null,
            _ => null
        };
    }
}
