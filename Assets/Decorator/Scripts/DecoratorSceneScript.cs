using UnityEngine;

namespace DesignPatterns.Decorator
{
    public class DecoratorSceneScript : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Armor basicSteel = new SteelArmor();

            Armor blessedSteel = new SteelArmor();
            blessedSteel = new HolyDecorator(blessedSteel);

            Armor reinforcedSteel = new SteelArmor();
            reinforcedSteel = new ReinforcedDecorator(reinforcedSteel);

            Armor blessedReinforcedSteel =new SteelArmor();
            blessedReinforcedSteel = new HolyDecorator(blessedReinforcedSteel);
            blessedReinforcedSteel = new ReinforcedDecorator(blessedReinforcedSteel);

            Debug.Log($"{basicSteel.GetArmorStats()} - {basicSteel.GetDescription()}\n" +
                      $"{blessedSteel.GetArmorStats()} - {blessedSteel.GetDescription()}\n" +
                      $"{reinforcedSteel.GetArmorStats()} - {reinforcedSteel.GetDescription()}\n" +
                      $"{blessedReinforcedSteel.GetArmorStats()} - {blessedReinforcedSteel.GetDescription()}\n");
        }
    }
}
