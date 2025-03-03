using DesignPatterns.Adapter.Legacy;
using UnityEngine;

namespace DesignPatterns.Adapter
{
    public class StringFormatAdapter : IStringFormat
    {
        OldLegacyCode _legacyCode;

        public StringFormatAdapter(OldLegacyCode legacyCode)
        {
            _legacyCode = legacyCode;
        }

        public string FormatText(string message, TextColor textColor)
        {
            switch (textColor)
            {
                case TextColor.BLACK:
                    return _legacyCode.FormatLog(message, 0);
                case TextColor.BLUE:
                    return _legacyCode.FormatLog(message, 2);
                case TextColor.RED:
                    return _legacyCode.FormatLog(message, 1);
                default:
                    return "Something Went Wrong";
            }
        }
    }
}
