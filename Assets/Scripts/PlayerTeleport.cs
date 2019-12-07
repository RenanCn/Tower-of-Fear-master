using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float coord_X, coord_Y;
    
    Transform pos;

    // Start is called before the first frame update
    void Start()
    {
        pos = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pos.transform.position = pos.transform.position + new Vector3(coord_X, coord_Y, transform.position.z);
        }
    }
}
