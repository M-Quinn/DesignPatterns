using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DesignPatterns.Composite
{
    public class SceneController : MonoBehaviour
    {
        [Header("References")] 
        [SerializeField] Button _getInventoryButton;
        [SerializeField] TMP_Text _outputTextbox;

       void Awake()
        {
            _getInventoryButton.onClick.AddListener(() => DisplayInventory(BuildTheInventory()));

            _outputTextbox.text = string.Empty;
        }

        void DisplayInventory(ItemComponent inventory)
        {
            _outputTextbox.text = inventory.DisplayInformation();
        }

        ItemComponent BuildTheInventory()
        {
            ItemComponent inventory = new Inventory(string.Empty);
            inventory.Add(new Item("Bronze Sword"));
            inventory.Add(new Item("Iron Axe"));

            ItemComponent smallBag = new Inventory("Small Bag", true);
            smallBag.Add(new Item("Leather Hat"));
            smallBag.Add(new Item("Broken Bowl"));
            smallBag.Add(new Item("Toy Figure"));

            inventory.Add(smallBag);
            inventory.Add(new Item("Iron Helmet"));
            inventory.Add(new Item("Steel Boots"));

            return inventory;
        }
    }
}
