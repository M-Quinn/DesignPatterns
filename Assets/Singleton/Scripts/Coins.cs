using UnityEngine;

public class Coins : MonoBehaviour
{
    int _coins;
    public void UpdateCoins(int num) {
        _coins += num;
    }
    public int GetCoins() {
        return _coins;
    }
}
