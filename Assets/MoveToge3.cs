using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToge3 : MonoBehaviour {


    public float MaxTogetogeX = 0;
    public float MinTogetogeX = 0;
    private int DirectionX = -1;
    public float MaxTogetogeY = 0;
    public float MinTogetogeY = 0;
    private int DirectionY = -1;
    public float Position;
    public GameObject Togetoge;
    public Vector3 tmp;

    // Use this for initialization
    void Start()
    {

        tmp = Togetoge.transform.position;

        MinTogetogeX = tmp.x - 5.0f;
        MaxTogetogeX = tmp.x + 5.0f;
        MinTogetogeY = tmp.y - 5.0f;
        MaxTogetogeY = tmp.y + 5.0f;

    }

    // Update is called once per frame
    void Update()
    {

        tmp = Togetoge.transform.position;

        if (tmp.x <= MinTogetogeX)
        {
            DirectionX = DirectionX * -1;
        }

        if (tmp.x >= MaxTogetogeX)
        {
            DirectionX = DirectionX * -1;
        }

        if (tmp.y <= MinTogetogeY)
        {
            DirectionY = DirectionY * -1;
        }

        if (tmp.y >= MaxTogetogeY)
        {
            DirectionY = DirectionY * -1;
        }

        this.gameObject.transform.Translate(0.05f * DirectionX, 0.05f * DirectionY, 0);

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
            DirectionX = DirectionX * -1;
            DirectionY = DirectionY * -1;
        }

    }
}
