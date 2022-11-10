
using UnityEngine;

public class Stats_Singleton: MonoBehaviour
{
    private static Stats_Singleton _uniqueInstance;

    public static Stats_Singleton getInstance {
        get {
            if (!_uniqueInstance) {
                _uniqueInstance = new GameObject().AddComponent<Stats_Singleton>();
                _uniqueInstance.name = _uniqueInstance.GetType().ToString();
                DontDestroyOnLoad(_uniqueInstance.gameObject);
            }
            return _uniqueInstance; }
    }
    int _coins;
    public void UpdateCoins(int num) {
        _coins += num;
    }
    public int GetCoins() {
        return _coins;
    }
}
