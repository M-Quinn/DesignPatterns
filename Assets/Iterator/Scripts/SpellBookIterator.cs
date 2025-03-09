
using System;
using System.Linq;

namespace DesignPatterns.Iterator
{
    public class SpellBookIterator : IIterator
    {
        private Spell[] _spells;
        private int index = 0;

        public SpellBookIterator(Spell[] spells)
        {
            _spells = spells;
        }


        public bool HasNext()
        {
            return index < _spells.Length;
        }

        public object Next()
        {
            var spell = _spells[index];
            index = (index + 1) % _spells.Length;
            return spell;
        }

        public void Reset()
        {
            index = 0;
        }

        public bool Add(object value)
        {
            if (value is Spell spell)
            {
                Spell[] spells = new Spell[_spells.Length + 1];

                for (int i = 0; i < spells.Length; i++)
                {
                    if (i < _spells.Length)
                        spells[i] = _spells[i];
                    else
                        spells[i] = spell;
                }

                _spells = spells;

                return true;
            }

            return false;
        }

        public bool Remove(object value)
        {
            if (value is Spell spell)
            {
                if (Array.Exists(_spells, x=> x == spell))
                {
                    Spell[] spells = _spells.Where(x => !x.Equals(spell)).ToArray();
                    
                    _spells = spells;

                    return true;
                }
            }
            return false;
        }
    }
}
