using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject Bullet;
    private Vector2 abc;
    private GameObject BulletInstate;
    // Start is called before the first frame update
    void Start()
    {
        BulletInstate = Instantiate(Bullet, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        Duoitheo();
    }
    
    void Duoitheo(){
         abc = Player.transform.position;
        Vector2 xyz= new Vector2(abc.x,abc.y);
   
        BulletInstate.transform.position = Vector2.MoveTowards(BulletInstate.transform.position,xyz,Time.deltaTime*1f);
    }
}
