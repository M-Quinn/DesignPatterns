using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Facade
{
    public class PanelTransitionFacade
    {
        IPanel _currentPanel;
        List<IPanel> _allPanels = new List<IPanel>();

        public void AddPanel(IPanel panel)
        {
            _allPanels.Add(panel);
        }

        public void InitPanels(IPanel panel)
        {
            CloseAllPanels();
            _currentPanel = panel;
            _currentPanel.OpenPanel();
        }

        public void TransitionPanel(IPanel panel)
        {
            _currentPanel.ClosePanel();
            _currentPanel = panel;
            _currentPanel.OpenPanel();
        }

        void CloseAllPanels()
        {
            foreach (var panel in _allPanels)
            {
                panel.ClosePanel();
            }
        }
    }
}
