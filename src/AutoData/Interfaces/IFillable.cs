namespace AutoData
{
    public interface IFillable: ISeparatable
    {
        void SetValueToProp(object desc, Block value);
    }
}
