using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public Vector3 cubePos;
    public Vector3 initPos;
    public float speed = 1.0f;
    public float amplitude = 1.0f ;
    public float frequency = 1.0f ;
    public float amplitude1 = 0.2f;
    public float frequency1 = 3.0f;
    public float randMin = -2.0f;
    public float randMax = 2.0f;
    public float pNoizeAmp = 1.0f;

    public float elaspedTime = 0.0f;
    public float elaspedTimeForRandom = 0.0f;
    public float randomTime = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        initPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // 直線
        // cubePos = new Vector3(elaspedTime * speed, 0.0f, 0.0f);

        // XだけSinで動かす
        // cubePos = new Vector3(amplitude * Mathf.Sin(elaspedTime * frequency), 0.0f, 0.0f);

        // XYをSinで動かす
        // cubePos = new Vector3(amplitude * Mathf.Sin(elaspedTime * frequency), amplitude * Mathf.Sin(elaspedTime * frequency), 0.0f);

        // X Sin, Y Cos
        // cubePos = new Vector3(amplitude * Mathf.Sin(elaspedTime * frequency), amplitude * Mathf.Cos(elaspedTime * frequency), 0.0f);

        // X Sin, Y Cos
        cubePos =
            new Vector3(amplitude * Mathf.Sin(elaspedTime * frequency) + amplitude1 * Mathf.Sin(elaspedTime * frequency1),
            amplitude * Mathf.Cos(elaspedTime * frequency) + amplitude1 * Mathf.Cos(elaspedTime * frequency1),
            0.0f);

        // Add X move
        // cubePos += new Vector3(elaspedTime * speed, 0.0f, 0.0f);

        float sample = Mathf.PerlinNoise(cubePos.x, cubePos.y);
        cubePos.z = sample * pNoizeAmp;

        // Random
        // cubePos = new Vector3(Random.Range(randMin, randMax), Random.Range(randMin, randMax), Random.Range(randMin, randMax));

        //if (elaspedTimeForRandom > randomTime)
        //{
        //    cubePos = new Vector3(Random.Range(randMin, randMax), Random.Range(randMin, randMax), Random.Range(randMin, randMax));
        //    elaspedTimeForRandom = 0.0f;
        //}

        gameObject.transform.position =  initPos + cubePos;

        elaspedTime += Time.deltaTime;
        elaspedTimeForRandom += Time.deltaTime;


    }
}
