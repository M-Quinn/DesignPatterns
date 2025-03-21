using System;
using UnityEngine;

namespace DesignPatterns.Builder
{
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
            _pole.BaseSection = baseGo;
        }

        public void BuildMiddleSections(int count)
        {
            _pole.MiddleSections = new GameObject[count];
            for (int i = 0; i < count; i++)
            {
                GameObject middlePrefab = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
                middlePrefab.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Wood");
                _pole.MiddleSections[i] = middlePrefab;
            }
        }

        public void BuildTop()
        {
            GameObject topPrefab = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            topPrefab.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Wood");
            _pole.TopSection = topPrefab;
        }

        public TotemPole GetResult()
        {
            return _pole;
        }
    }
}
