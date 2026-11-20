using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    [SerializeField] Slider Hunger;
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;
    
    public void set_Max(float MaxHunger)
    {
        Hunger.maxValue = MaxHunger;
        Hunger.value = MaxHunger;
        fill.color = gradient.Evaluate(1f);
    }

    public void set_Value(float hungerValue)
    {
        Hunger.value = hungerValue;
        fill.color = gradient.Evaluate(Hunger.normalizedValue);
    }
}
