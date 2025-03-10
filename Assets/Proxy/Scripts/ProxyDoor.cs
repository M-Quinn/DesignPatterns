using UnityEngine;

namespace DesignPatterns.Proxy
{
    public class ProxyDoor : MonoBehaviour, IDoor
    {
        public void Open(bool key)
        {
            if (key)
            {
                IDoor door = new RealDoor(gameObject);
                door.Open(true);
            }
            else
                Debug.Log("Door is locked!");
        }
    }
}
