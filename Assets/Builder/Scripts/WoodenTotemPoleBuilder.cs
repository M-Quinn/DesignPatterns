using DesignPatterns.Builder;
using UnityEngine;

public class WoodenTotemPoleBuilder : ITotemPoleBuilder
{
    TotemPole _pole;

    public WoodenTotemPoleBuilder(TotemPole pole)
    {
        _pole = pole;
    }
    
    public void BuildBase()
    {
        GameObject baseGo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Renderer renderer = baseGo.GetComponent<Renderer>();
        renderer.material = Resources.Load<Material>("Materials/Wood");
    }

    public void BuildMiddleSections(int count)
    {
        throw new System.NotImplementedException();
    }

    public void BuildTop()
    {
        throw new System.NotImplementedException();
    }

    public TotemPole GetResult()
    {
        throw new System.NotImplementedException();
    }
}
