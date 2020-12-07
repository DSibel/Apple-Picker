using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{

    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge =10f;
    public float chanceToChangeDirections =0.1f;
    public float secondsBetweenAppleDrops = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //dropiing apples every second
         Invoke("DropApple", 2f);
    }
    void DropApple(){
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }
    // Update is called once per frame
    void Update()
    {
        //basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position =pos;

        //changing drection
        if (pos.x< -leftAndRightEdge){
            speed= Mathf.Abs(speed);
        }else if(pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed);
        }else if(Random.value < chanceToChangeDirections){
            speed *= -1;
        }
        
    }
}
