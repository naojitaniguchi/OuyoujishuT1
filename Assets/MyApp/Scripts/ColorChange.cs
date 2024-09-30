using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [SerializeField] GameObject targetObject;
    [SerializeField] int indexMax = 60;
    [SerializeField] float timeMax = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        // RamdomColorRGB();
        // RamdomColorHSV();
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColorByTimeHSV();

    }

    void RamdomColorRGB()
    {
        if (targetObject != null )
        {
            Color initColor = targetObject.GetComponent<Renderer>().material.color;
            Color c = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), initColor.a);

            targetObject.GetComponent<Renderer>().material.color = c;
        }
        
    }

    void RamdomColorHSV()
    {
        if (targetObject != null)
        {
            Color initColor = targetObject.GetComponent<Renderer>().material.color;
            Color c = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1.0f, 1.0f);
            c.a = initColor.a;
            targetObject.GetComponent<Renderer>().material.color = c;
        }

    }

    public void SetColorHSVByIndex( int index )
    {
        if (targetObject != null)
        {
            float h = (float)(index % indexMax) / (float)indexMax;
            Color initColor = targetObject.GetComponent<Renderer>().material.color;
            Color c = Color.HSVToRGB(h, 1.0f, 1.0f);
            c.a = initColor.a;
            targetObject.GetComponent<Renderer>().material.color = c;
        }

    }

    void ChangeColorByTimeHSV()
    {
        if (targetObject == null)
        {
            return;
        }
        
        Color c = targetObject.GetComponent<Renderer>().material.color;
        float a = c.a;
        float h, s, v;
        Color.RGBToHSV(c, out h, out s, out v);

        Debug.Log(h);

        h += Time.deltaTime / timeMax ;
        if ( h > 1.0f)
        {
            h -= 1.0f;
        }

        

        c = Color.HSVToRGB(h, 1.0f, 1.0f);
        // c.a = a;
        targetObject.GetComponent<Renderer>().material.color = c;
    }
}
