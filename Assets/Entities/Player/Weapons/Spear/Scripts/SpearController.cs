using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour {

    private Vector2 pos1;
    private Vector2 pos2;

    private Rigidbody2D rb;

    private float countDown = 0;

    private bool first = true;

    void Start(){
        pos1 = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        if(rb.simulated == true){

            if(first){
                first = false;
            } else{
                pos2 = transform.position;
                transform.right = pos2 - pos1;
                pos1 = pos2;
            }

            
        } else{
            countDown += Time.deltaTime;
            if(countDown > 6){
                GameObject.Destroy(gameObject);
            } 
        }
        
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Ground"){
            rb.simulated = false;
        }
    }
}
