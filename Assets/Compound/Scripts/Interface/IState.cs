using UnityEngine;

namespace DesignPatterns.Compound
{
    public interface IState
    {
        public void Enter();
        public void Exit();
        public void Tick();
    }
}
