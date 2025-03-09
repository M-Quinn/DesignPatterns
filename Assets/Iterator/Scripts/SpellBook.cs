using DesignPatterns.Iterator;
using UnityEngine;

public class SpellBook
{
    public Spell[] Spells { get; private set; }

    public SpellBook()
    {
        Spells = new Spell[]
        {
            new Spell("Fire Ball"),
            new Spell("Ice Wall"),
            new Spell("Earthquake"),
            new Spell("Water Splash")
        };
    }
}
