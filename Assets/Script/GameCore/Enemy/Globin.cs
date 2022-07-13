using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globin : MonoBehaviour
{
    [SerializeField] GameObject Dotkil;
    [SerializeField] Animator animator;
    [SerializeField] LayerMask playerLayer;
    bool checkMove = true;
    bool checkAttack = false;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip Audioattack;
    [SerializeField] AudioClip AudioTakeHit;
    
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
                audioSource.clip = Audioattack;
                audioSource.Play();
                
                checkAttack = true;
            }
        }
    }
    void StopAttack()
    {
        animator.SetTrigger("StopAttack");
        Dotkil.SetActive(false);
    }
    void KillPlayer()
    {   Dotkil.SetActive(true) ;
        Collider2D playerwk = Physics2D.OverlapCircle(Dotkil.transform.position, 2f, playerLayer);
        if (playerwk)
        {
            //Thi nhan vat se mat di 1 mau
        }
    }
    // Chet
    void AutoTakeHit()
    {
        if (/* neu bi tan cong*/true) {
            animator.SetTrigger("TakeHit");
            audioSource.clip = AudioTakeHit;
            audioSource.Play();
        }
    }

    void AutoDeath()
    {
        Destroy(gameObject);
    }
}
