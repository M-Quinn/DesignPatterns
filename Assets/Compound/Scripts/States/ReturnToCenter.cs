using DesignPatterns.Compound;
using UnityEngine;

public class ReturnToCenter : IState
{
    private Material _mat;
    private CharacterController _cController;
    private float _speed;

    public ReturnToCenter(Material mat, CharacterController cController, ref float speed)
    {
        _mat = mat;
        _cController = cController;
        _speed = speed;
    }
    public void Enter()
    {
        _mat.color = Color.green;
    }

    public void Exit()
    {
        _mat.color = Color.white;
    }

    public void Tick()
    {
        _cController.Move(Vector3.zero * _speed * Time.deltaTime);
    }
}
