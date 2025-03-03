using UnityEngine;

namespace DesignPatterns.Adapter
{
    public interface IStringFormat
    {
        public string FormatText(string message, TextColor textColor);
    }

    public enum TextColor
    {
        BLUE,
        RED,
        BLACK
    }
}
