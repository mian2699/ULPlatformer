using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator ani;
    public Boss enemigo;
    //  private BoxCollider2D  mCollider;
   // private BoxCollider2D  mCollider;
    void OnTriggerEnter2D(Collider2D mCollider)
    {     
       
        if (mCollider.CompareTag("Player"))
        {
            
        

           ani.SetBool("walk", false);
           ani.SetBool("run", false);
           ani.SetBool("attack", true);
           enemigo.atacando = true;
           GetComponent<BoxCollider2D>().enabled = false;            
        }else{
          //   ani.SetBool("attack", true);          
            Debug.Log(mCollider.CompareTag("Player"));
            
       
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
        
}
