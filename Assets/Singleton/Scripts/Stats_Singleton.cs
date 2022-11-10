
public class Stats_Singleton
{
    private static readonly Stats_Singleton uniqueInstance = new Stats_Singleton();

    static Stats_Singleton() { }
    private Stats_Singleton() { }

    public static Stats_Singleton getInstance {
        get { return uniqueInstance; }
    }
    int _coins;
    public void UpdateCoins(int num)
    {
        _coins += num;
    }
    public int GetCoins()
    {
        return _coins;
    }
}
