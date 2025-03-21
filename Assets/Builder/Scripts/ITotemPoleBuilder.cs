using UnityEngine;

namespace DesignPatterns.Builder
{
    public interface ITotemPoleBuilder
    {
        void BuildBase();
        void BuildMiddleSections(int count);
        void BuildTop();
        TotemPole GetResult();
    }
}
