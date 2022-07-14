using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    [SerializeField] SpriteRenderer sRender;
    [SerializeField] Animator animator;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] AudioSource audioSource;
   // [SerializeField] AudioClip Audioattack;
    [SerializeField] AudioClip AudioTakeHit;

    //public float fadeInDuration;
    public float fadeInDuration;
    
    Vector2 MushroomPosition;
    bool checkMove=false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn(fadeInDuration));
        MushroomPosition=transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FeelPlayer();
       // AutoTakeHit();
    }

    void MoveBefore()
    {
        if (checkMove == false)
        {
            transform.Translate(Vector2.up * Time.deltaTime);
            
        }
        if (Vector2.Distance(transform.position, MushroomPosition) - 3 >= 0.1f)
        {
            checkMove = true;
        }
    }
    void FeelPlayer()
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, 15f, playerLayer);
        if (player)
        {
            MoveBefore();
            FeelPlayerNear();
        }
    }
    void FeelPlayerNear()
    {
        Collider2D playernear = Physics2D.OverlapCircle(transform.position, 3f, playerLayer);
        if (playernear)
        {
            animator.SetBool("Attack",true);
          
        }
    }
    public void StopAttack()
    {
        animator.SetBool("Attack",false);
    }
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

    IEnumerator FadeIn(float duration)
    {
        float timePassed = 0;
        while (timePassed < duration)
        {
            Color newColor = sRender.color;
            newColor.a = timePassed / duration;
            sRender.color = newColor;

            timePassed += Time.deltaTime;
            yield return null;
        }

    }
}

