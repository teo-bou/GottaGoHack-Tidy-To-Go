using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{    
    void Start()
    {
        float l, L, h;
        Vector3 dimension = GameObject.Find("Data").GetComponent<Data>().dimension;
        l = dimension.x; h = dimension.y; L = dimension.z;
        GameObject bo = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject ri = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject fr = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject ba = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GameObject le = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Material newMat = Resources.Load("Glass", typeof(Material)) as Material;
        bo.GetComponent<Renderer>().material = newMat;
        ri.GetComponent<Renderer>().material = newMat;
        fr.GetComponent<Renderer>().material = newMat;
        ba.GetComponent<Renderer>().material = newMat;
        le.GetComponent<Renderer>().material = newMat;

        bo.transform.localScale = new Vector3(l, 0.1f, L);
        ri.transform.localScale = new Vector3(L, 0.1f, h);
        le.transform.localScale = new Vector3(L, 0.1f, h);
        fr.transform.localScale = new Vector3(l, 0.1f, h);
        ba.transform.localScale = new Vector3(l, 0.1f, h);
        
        fr.transform.Rotate(-90, 0, 0);
        ba.transform.Rotate(90, 0, 0);
        ri.transform.Rotate(-90, 0, 90);
        le.transform.Rotate(-90, 0, -90);

        bo.transform.position = new Vector3(l/2, 0, L / 2);
        fr.transform.position = new Vector3(l/2,h/2, L);
        ba.transform.position = new Vector3(l/2, h/2, 0);
        ri.transform.position = new Vector3(l, h/2, L/2);
        le.transform.position = new Vector3(-0, h/2, L/2);

        

    }
}
