using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMoveRot : MonoBehaviour
{
    public float holizontal;
    public float vertical;
    public float moveSpeed = 1.0f;
    public float rotSpeed = 1.0f;
    public bool rotWorld = false;
    public bool rotAxis = false;

    public GameObject capsulObject;
    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        holizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 moveVec;
        if (Mathf.Abs(holizontal) > 0.001f)
        {
            moveVec = new Vector3(moveSpeed * Time.deltaTime * holizontal, 0.0f, 0.0f);
            gameObject.transform.Translate(moveVec);

        }
        if (Mathf.Abs(vertical) > 0.001f)
        {
            moveVec = new Vector3(0.0f, moveSpeed * Time.deltaTime * vertical, 0.0f);
            gameObject.transform.Translate(moveVec);

        }

        if (!rotWorld)
        {
            if (Input.GetKey(KeyCode.X))
            {
                gameObject.transform.Rotate(rotSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.Y))
            {
                gameObject.transform.Rotate(0.0f, rotSpeed * Time.deltaTime, 0.0f);
            }
            if (Input.GetKey(KeyCode.Z))
            {
                gameObject.transform.Rotate(0.0f, 0.0f, rotSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.X))
            {
                gameObject.transform.Rotate(rotSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
            }
            if (Input.GetKey(KeyCode.Y))
            {
                gameObject.transform.Rotate(0.0f, rotSpeed * Time.deltaTime, 0.0f, Space.World);
            }
            if (Input.GetKey(KeyCode.Z))
            {
                gameObject.transform.Rotate(0.0f, 0.0f, rotSpeed * Time.deltaTime, Space.World);
            }
        }

        if (Input.GetButtonDown("Jump"))
        {
            GameObject g = Instantiate(capsulObject);
            g.transform.position = gameObject.transform.position;
            g.transform.rotation = gameObject.transform.rotation;

            if ( g.GetComponent<ColorChange>() != null)
            {
                g.GetComponent<ColorChange>().SetColorHSVByIndex(count);
                count++;
            }

        }
        
    }
}
