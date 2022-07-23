using UnityEngine;
using Player;

public class HealthPotion : MonoBehaviour
{
    [SerializeField] private int healthAmount;

    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     Debug.Log("Collide");
    //     if (col.CompareTag("Player"))
    //     {
    //         PlayerManager.Instance.IncreaseHealth(healthAmount);
    //         //change later when apply GameObject Pooler
    //         Destroy(gameObject);
    //     }
    // }
}
