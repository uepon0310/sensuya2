using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarasuMove : MonoBehaviour {

    private int Direction= -1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.Translate(0.05f* Direction, 0, 0);
    }

    public void OnCollisionEnter2D(Collision2D c)
    {
        string tag = c.gameObject.tag;

        if ((tag == "ob_wall")|| (tag == "Karasu"))
        {
            Direction = Direction * -1;
        }
        if (tag == "Player")
        {
            Direction = Direction;
        }

    }
}
