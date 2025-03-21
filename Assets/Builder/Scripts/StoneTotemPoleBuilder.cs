using UnityEngine;

namespace DesignPatterns.Builder
{
    public class StoneTotemPoleBuilder : ITotemPoleBuilder
    {
        TotemPole _pole;

        public StoneTotemPoleBuilder(TotemPole pole)
        {
            _pole = pole;
        }

        public void BuildBase()
        {
            GameObject baseGo = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Renderer renderer = baseGo.GetComponent<Renderer>();
            renderer.material = Resources.Load<Material>("Materials/Stone");
            _pole.BaseSection = baseGo;
        }

        public void BuildMiddleSections(int count)
        {
            _pole.MiddleSections = new GameObject[count];
            for (int i = 0; i < count; i++)
            {
                GameObject middlePrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
                middlePrefab.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Stone");
                _pole.MiddleSections[i] = middlePrefab;
            }
        }

        public void BuildTop()
        {
            GameObject topPrefab = GameObject.CreatePrimitive(PrimitiveType.Cube);
            topPrefab.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Stone");
            _pole.TopSection = topPrefab;
        }

        public TotemPole GetResult()
        {
            return _pole;
        }
    }
}
