﻿using UnityEngine;
using System.Collections;
using System;

public class Laser : Projectile
{
    GameObject explosion;

    new void Start()
    {
        base.Start();
        explosion = (GameObject)Resources.Load("Prefabs/LaserExplosion", typeof(GameObject));
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
		// ignore health bar
		if(other.gameObject.tag == "HealthBar")
		{
			return;
		}
        //If its a player or an AI, ignore it, otherwise destroy itself
        var player = other.gameObject.GetComponent<BaseClass>();
        if (player != null && teamID == player.team)
        {
            //Ignore team players
            return;
        }

        var trigger = other.gameObject.GetComponent<Trigger>();
        if (trigger != null && (teamID == trigger.teamID || trigger is Area))
        {
            //Ignore team attacks or areas
            return;
        }

        var ai = other.gameObject.GetComponent<AI>();
        if (ai != null && teamID == ai.team)
        {

            //Ignore team AIs
            return;
        }

        if (other.gameObject.GetComponent<WorldItemData>() != null)
        {
            //Ignore items
            return;
        }
        
        var instance = (GameObject)Instantiate(explosion, transform.position, transform.rotation);
        Destroy(instance, 1);

        //Otherwise, its a wall or some solid
        if (--pierce < 0 || other.name == "obstacleTiles(Clone)" || other.name == "tron_obstacle(Clone)")
        {
            Destroy(gameObject);
        }
    }
}

