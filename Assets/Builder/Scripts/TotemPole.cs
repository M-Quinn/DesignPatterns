using UnityEngine;
using UnityEngine.Serialization;

namespace DesignPatterns.Builder
{
    public class TotemPole : MonoBehaviour
    {
        public GameObject BaseSection;
        public GameObject TopSection;
        public GameObject[] MiddleSections;

        public void Display()
        {
            Vector3 currentPosition = transform.position;

            if (BaseSection != null)
            {
                Instantiate(BaseSection, currentPosition, Quaternion.identity, transform);
                currentPosition.y += BaseSection.GetComponent<Renderer>().bounds.size.y;
            }

            if (MiddleSections != null)
            {
                foreach (GameObject middle in MiddleSections)
                {
                    Instantiate(middle, currentPosition, Quaternion.identity, transform);
                    currentPosition.y += middle.GetComponent<Renderer>().bounds.size.y;
                }
            }

            if (TopSection != null)
            {
                Instantiate(TopSection, currentPosition, Quaternion.identity, transform);
            }
        }
    }

}