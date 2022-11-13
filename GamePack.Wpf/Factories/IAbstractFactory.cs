namespace GamePack.Wpf.Factories
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}