﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;











    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT =scoreGO.GetComponent<Text>();
        scoreGT.text ="0";
    }

    // Update is called once per frame
    void Update()
    {
        //move
            //get screen position from mouse
            Vector3 mousePos2D =Input.mousePosition;
            mousePos2D.z= -Camera.main.transform.position.z;
            Vector3 mousePos3d = Camera.main.ScreenToWorldPoint(mousePos2D);
            Vector3 pos =this.transform.position;
            pos.x =mousePos3d.x;
            this.transform.position =pos;




        //get hurt
      
    }

    void OnCollisionEnter(Collision coll){
        GameObject collidedWith= coll.gameObject;
        if (collidedWith.tag =="Apple"){
            Destroy(collidedWith);

        }
        //Parse score into iint
        int score = int.Parse(scoreGT.text);

        score += 100;
        scoreGT.text = score.ToString();
        //track the high score
        if(score > HighScore.score){
            HighScore.score =score;
        }



    } 
}
