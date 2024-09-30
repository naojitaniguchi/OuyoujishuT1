using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMySelf : MonoBehaviour
{
    public float waitTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoDestory());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AutoDestory()
    {
        yield return new WaitForSeconds(waitTime);

        Destroy(gameObject);
    }
}
    