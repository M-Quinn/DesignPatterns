using System.Collections.Generic;
using System.Text;
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

        InventoryIterator _inventoryIterator = new(new Inventory().Items);

        void Awake()
        {

            _getInventoryButton.onClick.AddListener(() => DisplayAnything(_inventoryIterator));

            _outputTextbox.text = string.Empty;
        }

        void DisplayAnything(IIterator iterator)
        {
            iterator.Reset();

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
