﻿using UnityEngine;
using System.Collections;

/*-----------------------------------------------------------------------------
-- WorldItemManager.cs - Script attached to GameManager game object
--                       responsible for managing world items.
--
-- FUNCTIONS:
--		void Start()
--		void Update()
--		void DecreaseAmount(int amount)
--      void OnCollisionEnter2D(Collision2D other)
--
-- DATE:		05/03/2016
-- REVISIONS:	(V1.0)
-- DESIGNER:	Jaegar Sarauer, Krystle Bulalakaw
-- PROGRAMMER:  Krystle Bulalakaw
-----------------------------------------------------------------------------*/
class Resource : MonoBehaviour {
	public int x {get; set;}
	public int y {get; set;}
	public int amount {get; set;}
	Animator animator;
	CircleCollider2D mollider;

    public Resource(int x, int y) {
        this.x = x;
        this.y = y;
        this.amount = 10;
    }

    public Resource(int x, int y, int ra) {
        this.x = x;
        this.y = y;
        this.amount = ra;
    }

	/*------------------------------------------------------------------------------------------------------------------
    -- FUNCTION: 	Start
    -- DATE: 		March 24, 2016
    -- REVISIONS: 	N/A
    -- DESIGNER:  	Krystle Bulalakaw
    -- PROGRAMMER: 	Krystle Bulalakaw
    -- INTERFACE: 	Start(void)
    -- RETURNS: 	void.
    -- NOTES:
    -- Initialization of the resource game object's components.
    ----------------------------------------------------------------------------------------------------------------------*/
	void Start () {
		animator = GetComponent<Animator>();
		mollider = GetComponent<CircleCollider2D>(); 
	}

	/*------------------------------------------------------------------------------------------------------------------
    -- FUNCTION: 	Update
    -- DATE: 		March 24, 2016
    -- REVISIONS: 	N/A
    -- DESIGNER:  	Krystle Bulalakaw
    -- PROGRAMMER: 	Krystle Bulalakaw
    -- INTERFACE: 	Update(void)
    -- RETURNS: 	void.
    -- NOTES:
    -- Called once per frame. If resource amount is 0, triggers the resource depletion animation and disables collision
    -- on the game object.
    ----------------------------------------------------------------------------------------------------------------------*/
	void Update () {
		if (this.amount == 0) {
			animator.SetTrigger("Depleted");
			mollider.isTrigger = true;
		}
	}

	/*------------------------------------------------------------------------------------------------------------------
    -- FUNCTION: 	DecreaseAmount
    -- DATE: 		March 24, 2016
    -- REVISIONS: 	N/A
    -- DESIGNER:  	Krystle Bulalakaw
    -- PROGRAMMER: 	Krystle Bulalakaw
    -- INTERFACE: 	DecreaseAmount(int amount)
    --					int amount: the remaining quantity of the resource object on the map
    -- RETURNS: 	void.
    -- NOTES:
    -- Decreases the amount of a resource object by some number.
    ----------------------------------------------------------------------------------------------------------------------*/
	void DecreaseAmount(int amount) {
		this.amount -= amount;

		if (amount < 0) {
			amount = 0;
		}
	}

	/*------------------------------------------------------------------------------------------------------------------
    -- FUNCTION: 	DecreaseAmount
    -- DATE: 		March 24, 2016
    -- REVISIONS: 	N/A
    -- DESIGNER:  	Krystle Bulalakaw
    -- PROGRAMMER: 	Krystle Bulalakaw
    -- INTERFACE: 	DecreaseAmount(int amount)
    --					int amount: the remaining quantity of the resource object on the map
    -- RETURNS: 	void.
    -- NOTES:
    -- Triggered when the resource object's Collision2D detects collision with another Collision2D object.
    -- If the player interacted to claim the resource, decrease the resource amount by some number.
    ----------------------------------------------------------------------------------------------------------------------*/
	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log ("Resource collision other: " + other.collider.name);
		// If player action = collect resource
		//		Decrease amount 
	}
}

