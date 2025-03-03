using DesignPatterns.Adapter.Legacy;
using TMPro;
using UnityEngine;

namespace DesignPatterns.Adapter
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] TMP_Text textbox;

        OldLegacyCode _legacyCode = new();


        void Start()
        {
            textbox.text = _legacyCode.FormatLog("Message 1", 0);
            textbox.text += _legacyCode.FormatLog("Message 2", 1);
            textbox.text += _legacyCode.FormatLog("Message 3", 2);
        }

    }

}