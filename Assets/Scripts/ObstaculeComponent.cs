using UnityEngine;

public class ObstaculeComponent : MonoBehaviour
{
    [SerializeField] int ReceiveAmount = 30;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OguriController player = other.GetComponent<OguriController>();
            player.hunger.CurrentHunger -= ReceiveAmount;
            
        }
    }
}
