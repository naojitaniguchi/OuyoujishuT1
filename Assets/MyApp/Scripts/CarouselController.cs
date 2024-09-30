using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarouselController : MonoBehaviour
{
    [SerializeField] GameObject[] objects;
    [SerializeField] float offset = 3.0f;
    Vector3[] positions;
    public int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        positions = new Vector3[objects.Length];
        int index = 0;
        foreach( GameObject g in objects)
        {
            g.transform.localPosition = new Vector3(0.0f, (float)index * offset, 0.0f);
            positions[index] = g.transform.localPosition;
            index++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Up()
    {
        currentIndex++;
        if ( currentIndex >= objects.Length)
        {
            currentIndex = 0;
        }

        for ( int i = 0; i < objects.Length; i++)
        {
            int posIndex = currentIndex + i;
            if (posIndex >= objects.Length)
            {
                posIndex -= objects.Length;
            }
            objects[i].transform.localPosition = positions[posIndex];
        }
    }

    public void Down()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = objects.Length-1;
        }

        for (int i = 0; i < objects.Length; i++)
        {
            int posIndex = currentIndex + i;
            if (posIndex >= objects.Length)
            {
                posIndex -= objects.Length;
            }
            objects[i].transform.localPosition = positions[posIndex];
        }
    }
}
