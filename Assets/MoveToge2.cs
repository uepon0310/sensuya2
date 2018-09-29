using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToge2 : MonoBehaviour
{


    public float MaxTogetogeX = 0;
    public float MinTogetogeX = 0;
    private int Direction = -1;
    public float Position;
    public GameObject Togetoge;
    public Vector3 tmp;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        tmp = Togetoge.transform.position;

        if (tmp.x <= MinTogetogeX)
        {
            Direction = Direction * -1;
        }

        if (tmp.x >= MaxTogetogeX)
        {
            Direction = Direction * -1;
        }


        this.gameObject.transform.Translate(0.05f * Direction, 0, 0);

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
