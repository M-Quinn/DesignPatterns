using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Iterator
{
    public class SceneController : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] Button _getSpellsButton;
        [SerializeField] Button _getInventoryButton;
        [SerializeField] TMP_Text _outputTextbox;

        Inventory _inventory = new Inventory();
        private SpellBook _spellBook = new SpellBook();

        SpellBookIterator _spellBookIterator = new(new SpellBook().Spells);
        InventoryIterator _inventoryIterator = new(new Inventory().Items);

        void Awake()
        {
            /*_getInventoryButton.onClick.AddListener(() => DisplayInventory(_inventory.Items));
            _getSpellsButton.onClick.AddListener(() => DisplaySpellBook(_spellBook.Spells));*/

            _getInventoryButton.onClick.AddListener(() => DisplayAnything(_inventoryIterator));
            _getSpellsButton.onClick.AddListener(() => DisplayAnything(_spellBookIterator));

            _outputTextbox.text = string.Empty;
        }

        void DisplayInventory(List<Item> inventory)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < inventory.Count; i++)
            {
                sb.Append(inventory[i].Name);
                sb.Append("\n");
            }

            _outputTextbox.text = sb.ToString();
        }

        void DisplaySpellBook(Spell[] spells)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < spells.Length; i++)
            {
                sb.Append(spells[i].Name);
                sb.Append("\n");
            }

            _outputTextbox.text = sb.ToString();
        }

        void DisplayAnything(IIterator iterator)
        {
            StringBuilder sb = new StringBuilder();
            while (iterator.HasNext())
            {
                sb.Append(((Item)iterator.Next()).Name);
                sb.Append("\n");
            }

            _outputTextbox.text = sb.ToString();
        }
    }
}
