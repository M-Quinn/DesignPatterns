namespace DesignPatterns.State
{
    public interface IState
    {
        void Enter();
        void Exit();
        void Tick();
        void FixedTick();
    }
}
