using DesignPatterns.Adapter.Legacy;
using TMPro;
using UnityEngine;

namespace DesignPatterns.Adapter
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] TMP_Text textbox;

        private StringFormatAdapter stringFormat = new(new OldLegacyCode());


        void Start()
        {
            textbox.text = stringFormat.FormatText("Message 1", TextColor.BLACK);
            textbox.text += stringFormat.FormatText("Message 2", TextColor.RED);
            textbox.text += stringFormat.FormatText("Message 3", TextColor.BLUE);
        }

    }

}