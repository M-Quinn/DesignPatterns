using UnityEngine;
using UnityEngine.Serialization;

namespace DesignPatterns.Builder
{
    public class TotemPole : MonoBehaviour
    {
        public GameObject BaseSection;
        public GameObject TopSection;
        public GameObject[] MiddleSections = null;

        public void Display()
        {
            Vector3 currentPosition = new Vector3(0, 0.5f, 0);

            if (BaseSection != null)
            {
                BaseSection.transform.parent = transform;
                BaseSection.transform.localPosition = currentPosition;
                currentPosition.y += BaseSection.GetComponent<Renderer>().bounds.size.y/2;
            }

            if (MiddleSections != null)
            {
                foreach (GameObject middle in MiddleSections)
                {
                    currentPosition.y += middle.GetComponent<Renderer>().bounds.size.y/2;
                    middle.transform.parent = transform;
                    middle.transform.localPosition = currentPosition;
                    currentPosition.y += middle.GetComponent<Renderer>().bounds.size.y/2;
                }
            }

            if (TopSection != null)
            {
                currentPosition.y += TopSection.GetComponent<Renderer>().bounds.size.y/2;
                TopSection.transform.parent = transform;
                TopSection.transform.localPosition = currentPosition;
            }
        }
    }

}