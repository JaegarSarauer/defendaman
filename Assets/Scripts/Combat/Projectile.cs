﻿using UnityEngine;
using System.Collections;

public abstract class Projectile : Trigger
{
    private Vector2 startPos;
    public int maxDistance;
    public int pierce = 0;
    
    protected void Start()
    {
        startPos = transform.position;
        if(GameData.MyPlayer == null)
        {
            Debug.Log("caught null");
            return;
        }
        if (teamID != GameData.MyPlayer.TeamID)
        {
            Material hiddenMat = (Material)Resources.Load("Stencil_01_Diffuse Sprite", typeof(Material));
            gameObject.layer = LayerMask.NameToLayer("HiddenThings");
            gameObject.GetComponent<SpriteRenderer>().material = hiddenMat;
        }
    }

    void Update()
    {
        if (Vector2.Distance(startPos, transform.position) >= maxDistance)
        {
            Destroy(gameObject);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        // ignore health bar
        if (other.gameObject.tag == "HealthBar")
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
        //Otherwise, its a wall or some solid

        if (--pierce < 0 || other.name == "obstacleTiles(Clone)" || other.name == "tron_obstacle(Clone)") 
		{
            Destroy(gameObject);
        }
    }
}
