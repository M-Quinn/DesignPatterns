
using System;
using System.Linq;
using static UnityEditor.Progress;
using System.Reflection;

namespace DesignPatterns.Iterator
{
    public class SpellBookIterator : IIterator
    {
        private Spell[] _spells;
        private int _index = 0;

        public SpellBookIterator(Spell[] spells)
        {
            _spells = spells;
        }


        public bool HasNext()
        {
            if (_index < _spells.Length)
            {
                return true;
            }

            _index = 0;
            return false;
        }

        public object Next()
        {
            return _spells[_index++];
        }

        public void Reset()
        {
            _index = 0;
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
