using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globin : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] LayerMask playerLayer;
    bool checkMove = true;
    bool checkAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FeelPlayer();
        AutoMove();
      //  AutoTakeHit();
    }

    void AutoMove()
    {
        transform.Translate(Vector2.right*Time.deltaTime);
    }
    void FeelPlayer()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, 5f, playerLayer);

        if (checkAttack == false)
        {
            if (player)
            {
                animator.SetTrigger("Attack");
                // Viet ham tan cong vao day
                checkAttack = true;
            }
        }
    }
    void StopAttack()
    {
        animator.SetTrigger("StopAttack");
    }
    // Chet
    void AutoTakeHit()
    {
        if (/* neu bi tan cong*/true) { animator.SetTrigger("TakeHit"); }
    }
    void AutoDeath()
    {
        Destroy(gameObject);
    }
    
   
}
