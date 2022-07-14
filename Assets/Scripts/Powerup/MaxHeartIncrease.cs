using UnityEngine;
using Player;

public class MaxHeartIncrease : MonoBehaviour
{
    [SerializeField] private int increaseAmount;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collide");
        if (col.CompareTag("Player"))
        {
            PlayerManager.Instance.IncreaseMaxHealth(increaseAmount);
            //change later when apply GameObject Pooler
            Destroy(gameObject);
        }
    }
}
