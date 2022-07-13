using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private Vector2 playerPosition;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] Animator animator;
    bool checkAttack=false;
    [SerializeField] GameObject Bullet;
    GameObject BulletInstate;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip Audioattack;
    [SerializeField] AudioClip AudioTakeHit;
   // [SerializeField] AudioClip Audiodead;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        FeelPlayer();
        //AutoTakeHit();
    }
   // Cam thay co nhan vat
    void FeelPlayer()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, 15f, playerLayer);
        
        if(checkAttack==false)
        {
            if (player)
            {
                animator.SetBool("Attack", true);
                
            }
        }else { animator.SetBool("Attack", false); }
        if (BulletInstate != null) { BulletInstate.transform.position = Vector3.MoveTowards(BulletInstate.transform.position, Player.transform.position, Time.deltaTime*5f); }
    }
    // Tan cong nhan vat
    public void AttackPlayer()
    {
        playerPosition = Player.transform.position;
        audioSource.clip = Audioattack;
        audioSource.Play();
        BulletFly();

        checkAttack=true;
    }
    public GameObject BulletFly()
    {
        BulletInstate= Instantiate(Bullet,transform.position,Quaternion.identity);
       return BulletInstate;
    }

    // Chet
    void AutoTakeHit()
    {
        if(/* neu bi tan cong*/true) { 
            animator.SetTrigger("TakeHit");
            audioSource.clip = AudioTakeHit;
            audioSource.Play();
        }

    }
    void AutoDeath()
    {
       // audioSource.clip = Audiodead;
        //audioSource.Play();
        Destroy(gameObject);
    }
}
