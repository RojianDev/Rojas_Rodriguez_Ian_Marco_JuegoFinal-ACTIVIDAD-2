using UnityEngine;

public class FoodComponent : MonoBehaviour
{
    [SerializeField] int recoverAmount = 10;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OguriController player = other.GetComponent<OguriController>();
            player.hunger.CurrentHunger += recoverAmount;
            Destroy(gameObject);
        }
    }
}
