using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace DesignPatterns.Composite
{
    public class Inventory : ItemComponent
    {
        string _name;
        bool _subContainer = false;
        public Inventory(string name, bool subContainer = false)
        {
            _name = name;
            _subContainer = subContainer;
        }

        public override string GetName()
        {
            return _name;
        }

        public override string DisplayInformation()
        {
            StringBuilder sb = new StringBuilder();

            if (!_subContainer)
            {
                sb.Append("Inventory\n");

                for (int i = 0; i < Children.Count; i++)
                {
                    sb.Append($"{Children[i].DisplayInformation()}");
                    if (Children.Count - i > 1)
                    {
                        sb.Append("\n");
                    }
                }
            }
            else
            {
                sb.Append($"<color=blue>{GetName()}</color>\n");
                for (int i = 0; i < Children.Count; i++)
                {
                    sb.Append($"\t<color=blue>{Children[i].DisplayInformation()}</color>");
                    if (Children.Count - i > 1)
                    {
                        sb.Append("\n");
                    }
                }
            }

            return sb.ToString();
        }
    }
}
