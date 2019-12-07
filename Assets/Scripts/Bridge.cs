using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{

    [SerializeField]
    private float dropCoolDown = 0.5f;
    [SerializeField]
    private bool respawnBridge = true;

    Rigidbody2D rb;
    private bool touched = false;
    private float count = 0;
    private Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(touched){

            count += Time.deltaTime;
            if(count >= dropCoolDown){
                rb.constraints = RigidbodyConstraints2D.None;
            }


            if (respawnBridge == true)
            {
                if (count >= 5)
                {
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    transform.position = pos;
                    touched = false;
                    count = 0;
                }
            }
            

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           touched = true;
        }
    }
}
