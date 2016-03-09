﻿using UnityEngine;
using System.Collections;

public abstract class Projectile : Trigger
{
    public Projectile()
    {

    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BaseClass>() != null && teamID == other.gameObject.GetComponent<BaseClass>().team)
        {
            return;
        }
        if (other.gameObject.GetComponent<Trigger>() != null && teamID == other.gameObject.GetComponent<Trigger>().teamID)
        {
            return;
        }
        Destroy(gameObject);
    }
}
