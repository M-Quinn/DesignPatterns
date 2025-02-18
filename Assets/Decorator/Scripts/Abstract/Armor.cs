using UnityEngine;

public abstract class Armor
{
    private string description = "Unknown";

    public string GetDescription()
    {
        return description;
    }

    public abstract float GetArmorStats();
}
