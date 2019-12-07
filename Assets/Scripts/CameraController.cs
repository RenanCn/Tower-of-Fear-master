using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float xMargin;
    public float yMargin;
    public float xSmooth;
    public float ySmooth;
    public Vector2 maxXAndY;
    public Vector2 minXAndY;

    private Transform player;
    

    void Awake(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update(){
        
        float targetX = transform.position.x;
		float targetY = transform.position.y;

        if(Mathf.Abs(transform.position.x - player.position.x) > xMargin){
            targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
        }

        if(Mathf.Abs(transform.position.y - player.position.y) > yMargin){
            targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
        }

        targetX = Mathf.Clamp(targetX, minXAndY.x, maxXAndY.x);
		targetY = Mathf.Clamp(targetY, minXAndY.y, maxXAndY.y);

        transform.position = new Vector3(targetX, targetY, transform.position.z);
    }
}
