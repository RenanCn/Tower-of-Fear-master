using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HistoriaController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().Fim();
        }
    }
}
