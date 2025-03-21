using UnityEngine;

namespace DesignPatterns.Builder
{
    public class TotemManager
    {
        public void ConstructTotem(ITotemPoleBuilder builder, int middleSectionCount)
        {
            builder.BuildBase();
            builder.BuildMiddleSections(middleSectionCount);
            builder.BuildTop();
            TotemPole tp = builder.GetResult();
            tp.Display();
        }
    }
}
