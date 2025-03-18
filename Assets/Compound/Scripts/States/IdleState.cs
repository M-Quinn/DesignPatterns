using UnityEngine;

namespace DesignPatterns.Compound
{
    public class IdleState : IState
    {
        private Material _mat;

        public IdleState(Material mat)
        {
            _mat = mat;
        }

        public void Enter()
        {
            _mat.color = Color.blue;
        }

        public void Exit()
        {
            _mat.color = Color.white;
        }

        public void Tick()
        {
            //
        }

        public void FixedTick()
        {
            //
        }
    }
}
