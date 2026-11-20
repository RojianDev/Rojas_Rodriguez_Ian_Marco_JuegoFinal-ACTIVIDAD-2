using Unity.VisualScripting;
using UnityEngine;

public class HungerComponent : MonoBehaviour
{
    
    [SerializeField] HungerBar hungerBar;
    [SerializeField] int MaxHunger = 100;
    public float CurrentHunger;
    public int ReduceAmount = 1;

    void Start()
    {
        CurrentHunger = MaxHunger;
        hungerBar.set_Max(MaxHunger);
    }

    
    void Update()
    {
        reduceHunger();
    }

    void reduceHunger()
    {
        CurrentHunger -= ReduceAmount * Time.deltaTime;
        hungerBar.set_Value(CurrentHunger);

    }

    void CheckHunger()
    {
        if(CurrentHunger <= 0)
        {
            //GameOver
        }
    }

}
