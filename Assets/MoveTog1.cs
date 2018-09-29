using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTog1 : MonoBehaviour {


    public float MaxTogetogeY = 0;
    public float MinTogetogeY = 0;
    private int Direction = -1;
    public float Position;
    public GameObject Togetoge;
    public Vector3 tmp;

    // Use this for initialization
    void Start()
    {

        tmp = Togetoge.transform.position;

        MinTogetogeY = tmp.y - 5.0f;
        MaxTogetogeY = tmp.y + 5.0f;

    }

    // Update is called once per frame
    void Update()
    {

        tmp = Togetoge.transform.position;

        if (tmp.y <= MinTogetogeY)
        {
            Direction = Direction * -1;
        }

        if (tmp.y >= MaxTogetogeY)
        {
            Direction = Direction * -1;
        }


        this.gameObject.transform.Translate( 0, 0.05f * Direction, 0);

        //        if (tmp.x >= MinTogetogeX)
        //        {
        //            this.gameObject.transform.Translate(0.05f * Direction, 0, 0);
        //            Direction = Direction * -1;
        //        }
    }

    public void OnCollisionEnter2D(Collision2D c)
    {
        string tag = c.gameObject.tag;

        if ((tag == "ob_wall") || (tag == "Karasu") || (tag == "Togetoge"))
        {
            Direction = Direction * -1;
        }

    }
}
