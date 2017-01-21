﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    // Use this for initialization
    void Start()
    {
        transform.position = new Vector2(Grid.World.worldWidth / 2f, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Grid.GameManager.playerStarted)
        {
            //Moving
            float f = Time.deltaTime;
            float newY = transform.position.y + f * movement;
            transform.position = new Vector2(transform.position.x, newY);
        }
    }

    //if something hit the player
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("TriggerEnter");
        //var other = col.transform.gameObject;

        if (other.tag == "Enemy") {

            Enemy enemy = other.GetComponent<Enemy>();
            Fight fight = new Fight();

            fight.enemy = enemy;
            fight.player = this;
            fight.fighting();
        }



    }

    IEnumerator waitingInSec(float time)
    {
        yield return new WaitForSeconds(time);
    }



}





