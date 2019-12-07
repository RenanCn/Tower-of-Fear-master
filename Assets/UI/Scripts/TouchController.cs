using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{
    
    void Start(){

        
    }

    
    void Update(){
        
    }

    public void OnPointerDown(PointerEventData eventData){
        Time.timeScale = 0.5f;
    }

    public void OnPointerUp(PointerEventData eventData){
        Time.timeScale = 1;
    }

}
