using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveWithKey : MonoBehaviour
{
    public Vector3 initPos;
    public float holizontal;
    public float vertical;
    public float speed = 1.0f;
    public GameObject prefab;
    public GameObject prefab2;
    bool byKeybaord = true;
    // Start is called before the first frame update
    void Start()
    {
        initPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        holizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 mousePos;
        

        Vector3 moveVec;
        if (Mathf.Abs(holizontal) > 0.001f )
        {
            moveVec = new Vector3(speed * Time.deltaTime * holizontal, 0.0f, 0.0f);
            gameObject.transform.Translate(moveVec);
            
        }
        if (Mathf.Abs(vertical) > 0.001f)
        {
            moveVec = new Vector3(0.0f, speed * Time.deltaTime * vertical, 0.0f);
            gameObject.transform.Translate(moveVec);
            
        }

        //GameObject shpereObj = Instantiate(prefab);
        //shpereObj.transform.position = gameObject.transform.position;
        //shpereObj.transform.rotation = Quaternion.identity;

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
            GameObject shpereObj = Instantiate(prefab2);
            shpereObj.transform.position = gameObject.transform.position;
            shpereObj.transform.rotation = Quaternion.identity;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Fire2");
            byKeybaord = !byKeybaord;


        }

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");

            GameObject shpereObj = Instantiate(prefab);
            shpereObj.transform.position = gameObject.transform.position;
            shpereObj.transform.rotation = Quaternion.identity;

        }

        if ( !byKeybaord)
        {
            mousePos = Input.mousePosition;
            {
                Debug.Log(mousePos.x);
                Debug.Log(mousePos.y);
            }

            Vector3 screenPos = new Vector3(mousePos.x, mousePos.y, gameObject.transform.position.z - Camera.main.transform.position.z);
            // ワールド座標に変換  
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            // ワールド座標を3Dオブジェクトの座標に適用  
            gameObject.transform.position = worldPos;

            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Fire1");
                GameObject shpereObj = Instantiate(prefab2);
                shpereObj.transform.position = gameObject.transform.position;
                shpereObj.transform.rotation = Quaternion.identity;
            }

        }
    }
}
