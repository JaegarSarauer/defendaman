using UnityEngine;
using System.Collections;

class Resource : MonoBehaviour {
	public int x {get; set;}
	public int y {get; set;}
	public int resourceLeft;
	Animator animator;

    public Resource(int x, int y) {
        this.x = x;
        this.y = y;
        this.resourceLeft = 10;
    }

    public Resource(int x, int y, int ra) {
        this.x = x;
        this.y = y;
        this.resourceLeft = ra;
    }
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void decreaseAmount(int amt) {
		resourceLeft -= amt;

		if (resourceLeft < 0) {
			resourceLeft = 0;
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log ("Resource collider triggered");
		if (resourceLeft == 0) {
			animator.Play("tree_explode_animation2_");
		}
	}
}

