
using UnityEngine;

public class Stats_Singleton: MonoBehaviour
{
    private static Stats_Singleton uniqueInstance;

    public static Stats_Singleton getInstance {
        get {
            if (!uniqueInstance) {
                uniqueInstance = new GameObject().AddComponent<Stats_Singleton>();
                uniqueInstance.name = uniqueInstance.GetType().ToString();
                DontDestroyOnLoad(uniqueInstance.gameObject);
            }
            return uniqueInstance; }
    }
    int _coins;
    public void UpdateCoins(int num) {
        _coins += num;
    }
    public int GetCoins() {
        return _coins;
    }
}
