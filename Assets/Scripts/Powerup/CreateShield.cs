using UnityEngine;
using Player;

public class CreateShield : MonoBehaviour
{
    [SerializeField] private float shieldDuration;
    [SerializeField] private int shieldStrength;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            PlayerManager.Instance.CreateShield(shieldDuration,shieldStrength);
            //change later when apply GameObject Pooler
            Destroy(gameObject);
        }
    }
}
