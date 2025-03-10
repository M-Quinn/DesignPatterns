using UnityEngine;

namespace DesignPatterns.Proxy
{
    public class ProxyDoor : MonoBehaviour, IDoor
    {
        private string _keyString = "gold key";

        public void Open(Key key)
        {
            if (key.KeyString.ToLower() == _keyString)
            {
                IDoor door = new RealDoor(gameObject);
                door.Open(null);
                Debug.Log($"Tried {key.KeyString} | Door Opens!");
            }
            else
                Debug.Log($"Tried {key.KeyString} | Door is locked!");
        }
    }
}
