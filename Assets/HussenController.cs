using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class HussenController : MonoBehaviour
{

    new Rigidbody2D rigidbody2D;

    public float MaxHeight;
    public float HusenVelocity;
    public Vector3 Pos;
    public Vector3 WorldPointPos;
    public float PointX;
    public float PointY;


    public int HusenGravityX;
    public int HusenGravityY;

    public int StageSize = 6;
    public Vector2 HusenPosition;

    public float HusenPositionDontMoveX;
    public float HusenPositionDontMoveY;

    public float coefficient;



    public GameObject gameObjectMakeStage;

    public GameObject target1;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start()
    {
        target1 = GameObject.Find("huusen");
        HusenPosition = target1.transform.position;

        gameObjectMakeStage = GameObject.Find("Stage") as GameObject;
        gameObjectMakeStage.GetComponent< MakeStage >();

    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.StageWriteFlag == true)
        {
                gameObjectMakeStage.GetComponent<MakeStage>();
        }

        HusenPosition = target1.transform.position;

        if (Input.GetMouseButtonDown(0) && transform.position.y < MaxHeight)
        {
            //            target1.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
            //マウス位置座標をVector3で取得
            Pos = Input.mousePosition;
            // マウス位置座標をスクリーン座標からワールド座標に変換する
            WorldPointPos = Camera.main.ScreenToWorldPoint(Pos);
            PointX = WorldPointPos.x;
            PointY = WorldPointPos.y;

            Flap();


        }
    }

    public void OnCollisionEnter2D(Collision2D c)
    {
        string tag = c.gameObject.tag;

        if (tag == "ob_wall")
        {
            //            rigidbody2D.velocity = new Vector2(-1 * PointX, -1 * PointY);

            if ((PointX < 0.0f) && (PointY < 0.0f))//00
            {
                rigidbody2D.velocity = new Vector2(2, 2);
            }
            if ((PointX >= 0.0f) && (PointY < 0.0f))//10
            {
                rigidbody2D.velocity = new Vector2(-1 * 2, 2);
            }
            if ((PointX >= 0.0f) && (PointY >= 0.0f))//11
            {
                rigidbody2D.velocity = new Vector2(-1 * 2, -1 * 2);
            }
            if ((PointX < 0.0f) && (PointY >= 0.0f))//01
            {
                rigidbody2D.velocity = new Vector2(2, -1 * 2);
            }
        else if(tag == "Togetoge")
            {

            }
/*
            if (tag == "goal")
            {
                GlobalVariables.StageNumber = GlobalVariables.StageNumber + 1;
                GlobalVariables.StageWriteFlag = true;
                //            CreateStage(StageData2, 21, 57);
                GameObject[] cubes = GameObject.FindGameObjectsWithTag("ob_wall");
                foreach (GameObject cube in cubes)
                {
                    // 消す！
                    Destroy(cube);
                }
                GameObject[] cubes2 = GameObject.FindGameObjectsWithTag("goal");
                foreach (GameObject cube in cubes2)
                {
                    // 消す！
                    Destroy(cube);
                }
                GameObject[] cubes3 = GameObject.FindGameObjectsWithTag("Karasu");
                foreach (GameObject cube in cubes3)
                {
                    // 消す！
                    Destroy(cube);
                }
                GameObject[] cubes4 = GameObject.FindGameObjectsWithTag("Togetoge");
                foreach (GameObject cube in cubes4)
                {
                    // 消す！
                    Destroy(cube);
                }
                tag = "";
                gameObjectMakeStage.GetComponent<MakeStage>().Update();
            }

            Debug.Log("hit Object  COLLISION");
            Debug.Log("1:hit filed: " + c.gameObject.tag);
*/
        }
    }


    public void OnTriggerEnter2D(Collider2D t)
    {
        string tag = t.gameObject.tag;

        if (tag == "goal")
        {
            GlobalVariables.StageNumber = GlobalVariables.StageNumber + 1;
            GlobalVariables.StageWriteFlag = true;
            //            CreateStage(StageData2, 21, 57);
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("ob_wall");
            foreach (GameObject cube in cubes)
            {
                // 消す！
                Destroy(cube);
            }
            GameObject[] cubes2 = GameObject.FindGameObjectsWithTag("goal");
            foreach (GameObject cube in cubes2)
            {
                // 消す！
                Destroy(cube);
            }
            GameObject[] cubes3 = GameObject.FindGameObjectsWithTag("Karasu");
            foreach (GameObject cube in cubes3)
            {
                // 消す！
                Destroy(cube);
            }
            GameObject[] cubes4 = GameObject.FindGameObjectsWithTag("Togetoge");
            foreach (GameObject cube in cubes4)
            {
                // 消す！
                Destroy(cube);
            }
            tag = "";
            gameObjectMakeStage.GetComponent<MakeStage>().Update();
        }

  }
        void FixedUpdate()
        {
            // 空気抵抗を与える
            rigidbody2D.AddForce(-coefficient * rigidbody2D.velocity);
        }


    public void Flap()
    {

        HusenGravityX = Mathf.CeilToInt(PointX - HusenPosition.x);
        HusenGravityY = Mathf.CeilToInt(PointY - HusenPosition.y);


            /*
            HusenGravityX = Mathf.CeilToInt(PointX);
            HusenGravityY = Mathf.CeilToInt(PointY);
            */
            if (HusenGravityX == 0)
        {
            HusenGravityX = -1;
        }
        if (HusenGravityY == 0)
        {
            HusenGravityY = -1;
        }

        HusenPositionDontMoveX = Mathf.CeilToInt(PointX - HusenPosition.x);
        HusenPositionDontMoveY = Mathf.CeilToInt(PointY - HusenPosition.y);


        if (((HusenPositionDontMoveX <= 0) && (HusenPositionDontMoveY <= 0)) || ((HusenPositionDontMoveX >= 0) && (HusenPositionDontMoveY <= 0)))
        {
            if ((HusenGravityX < 0.0f) && (HusenGravityY < 0.0f))//00
            {
                            rigidbody2D.velocity = new Vector2(-1 * 6.0f / HusenGravityX, -1 * 6.0f / HusenGravityY);
                //rigidbody2D.velocity = new Vector2(-1 * 10.0f / ( Mathf.ClosestPowerOfTwo(HusenGravityX)), -1 * 10.0f / HusenGravityY);
            }
            if ((HusenGravityX >= 0.0f) && (HusenGravityY < 0.0f))//10
            {
                rigidbody2D.velocity = new Vector2(-1 * 10.0f / (Mathf.ClosestPowerOfTwo(HusenGravityX)), -1 * 10.0f / HusenGravityY);
                //rigidbody2D.velocity = new Vector2(-1 * 10.0f / HusenGravityX * 0.5f, -1 * 10.0f / HusenGravityY);
            }
            if ((HusenGravityX >= 0.0f) && (HusenGravityY >= 0.0f))//11
            {
                //rigidbody2D.velocity = new Vector2(-1 * 10.0f / (Mathf.ClosestPowerOfTwo(HusenGravityX)), -1 * 10.0f / HusenGravityY);
                                rigidbody2D.velocity = new Vector2(-1 * 10.0f / HusenGravityX * 0.5f, -1 * 10.0f / HusenGravityY);
            }
            if ((HusenGravityX < 0.0f) && (HusenGravityY >= 0.0f))//01
            {
                //rigidbody2D.velocity = new Vector2(-1 * 10.0f / (Mathf.ClosestPowerOfTwo(HusenGravityX)), -1 * 10.0f / HusenGravityY);
                rigidbody2D.velocity = new Vector2(-1 * 10.0f / HusenGravityX * 0.5f, -1 * 10.0f / HusenGravityY);
            }
        }
        //        Debug.Log("PointX:" + PointX);
        Debug.Log("PointY:" + PointY);
        //        Debug.Log("HusenGravityX:" + HusenGravityX);
        Debug.Log("HusenGravityY:" + HusenGravityY);
        Debug.Log("pos1.x:" + HusenPosition.x);
        Debug.Log("pos1.y:" + HusenPosition.y);

    }


}




