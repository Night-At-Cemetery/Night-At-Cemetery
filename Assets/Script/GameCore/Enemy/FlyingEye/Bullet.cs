using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject Player;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioboom; 
    Vector2 Playerposition;
    private void Start()
    {
        Playerposition=Player.transform.position;
    }
    
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetTrigger("Boom");
            audioSource.clip = audioboom;
            audioSource.Play();

        }
    }
    void DesTroyGameObject()
    {
        Destroy(gameObject);
    }

}
