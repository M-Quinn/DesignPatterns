using System.Text;
using UnityEngine;

namespace DesignPatterns.Adapter.Legacy
{
    public class OldLegacyCode
    {
        /// <summary>
        /// 0 = black, 1 = red, 2 = blue
        /// </summary>
        /// <param name="message"></param>
        /// <param name="selection"></param>
        /// <returns></returns>
        public string FormatLog(string message, int selection) 
        {
            StringBuilder sb = new StringBuilder();
            string colorStart = string.Empty;
            string colorEnd = "</color>";
            switch (selection)
            {
                case 0:
                    colorStart = "<color=\"black\"";
                    break;
                case 1:
                    colorStart = "<color=\"red\"";
                    break;
                case 2:
                    colorStart = "<color=\"blue\"";
                    break;
            }

            sb.Append(colorStart);
            sb.Append(message);
            sb.Append(colorEnd);

            return sb.ToString();
        }
    }
}
