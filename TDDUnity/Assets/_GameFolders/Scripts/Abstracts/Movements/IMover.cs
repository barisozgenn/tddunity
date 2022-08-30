namespace TDDUnity.Abstracts.Movements
{
    public interface IMover
    {
        void Tick();//call for update method
        void FixedTick();//call for fixed update method
    }

}
