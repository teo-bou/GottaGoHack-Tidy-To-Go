using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MoveTouch : MonoBehaviour
{

    // Start is called before the first frame update

    Vector3 dimension;
    public int Current;
    public List<GameObject> blocks;
    public GameObject box;
    public GameObject fin;
    public GameObject overlay;
    public GameObject Cam;
    int touched;
    public int Solution;
    public void Sol()
    {
        Solution = 1;
        Debug.Log("Solution");
        foreach (var cube in blocks)
        {
            cube.SetActive(false);
        }
        GameObject.Find("Data").GetComponent<CubePacking>().Solution();
    }
    public void Rx()
    {
        box = blocks[Current];
        box.transform.Rotate(90.0f, 0.0f, 0.0f);
        blocks[Current] = box;
    }
    public void Ry()
    {
        box = blocks[Current];
        box.transform.Rotate(0.0f, 90.0f, 0.0f);
        blocks[Current] = box;
    }
    public void Rz()
    {
        box = blocks[Current];
        box.transform.Rotate(0.0f, 0.0f, 90.0f);
        blocks[Current] = box;
    }
    public void Next()
    {
        box = blocks[Current];
        box.GetComponent<Rigidbody>().useGravity = false;
        box.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();
        blocks[Current] = box;
        Current = Current + 1;
        if (Current >= blocks.Count)
        {
            Current = 0;
        }

    }
    public void Prev()
    {
        box = blocks[Current];
        box.GetComponent<Rigidbody>().useGravity = false;
        box.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();
        blocks[Current] = box;
        Current = Current - 1;
        if (Current < 0)
        {
            Current = blocks.Count - 1;
        }

    }


    void Start()
    {
        Current = 0;
        Solution = 0;

        List<Vector3> items = GameObject.Find("Data").GetComponent<Data>().items;
        foreach (Vector3 item in items)
        {
            box = GameObject.CreatePrimitive(PrimitiveType.Cube);
            box.transform.localScale = new Vector3((float)item.x, (float)item.y, (float)item.z);
            box.transform.position = new Vector3(0, -100, 0);

            box.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();
            box.AddComponent<Rigidbody>();
            box.GetComponent<Rigidbody>().useGravity = false;
            box.GetComponent<Rigidbody>().freezeRotation = true;
            blocks.Add(box);


        }
        dimension = GameObject.Find("Data").GetComponent<Data>().dimension;

    }
    
    // Update is called once per frame
    void Update()
    {
        if (touched != 0)
        {
            touched += 1;
        }
        if (touched > 5)
        {
            touched = 0;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            box = blocks[Current];
            box.GetComponent<MeshRenderer>().material.color = Color.yellow;
            box.GetComponent<Rigidbody>().useGravity = true;
            Vector3 touchposition = touch.position;
            Debug.Log(touchposition);
            if (touchposition.y > 300 & touchposition.y < 1800)
            {
                touchposition = new Vector3(touchposition.x, touchposition.y, 7);
                touchposition = Camera.main.ScreenToWorldPoint(touchposition);
                if (touchposition.x < 0) { touchposition.x = 0; }
                if (touchposition.z < 0) { touchposition.z = 0; }
                if (touchposition.x + box.transform.localScale.x / 2 > dimension.x) { touchposition.x = dimension.x - box.transform.localScale.x; }
                if (touchposition.z + box.transform.localScale.z / 2 > dimension.z) { touchposition.z = dimension.z - box.transform.localScale.z; }
                box.transform.position = new Vector3((int)touchposition.x, (int)touchposition.y, (int)touchposition.z);
                //Debug.Log(touchposition); 

            }
            else if (touchposition.y < 300 & touched == 0)
            {
                touched = 1;
                if (touchposition.x > 650 & touchposition.x < 900)
                {
                    Cam.GetComponent<Movement>().Inc();
                }
                if (touchposition.x > 450 & touchposition.x < 650)
                {
                    Cam.GetComponent<Movement>().Home();
                }
                if (touchposition.x > 200 & touchposition.x < 450)
                {
                    Cam.GetComponent<Movement>().Dec();
                }
                
            }
            else if (touchposition.y > 1800 & touched == 0)
            {
                touched = 1;

                if (touchposition.y > 2200 & touchposition.x > 900)
                {
                    
                    if (Solution == 1) {
                        
                        fin.SetActive(true);
                            Debug.Log("Hello" + Solution);
                        overlay.SetActive(false);
                    }
                    else
                    {
                        Sol();
                    }

                }
                if (touchposition.y < 2200 & touchposition.x > 900)
                {
                    Next();
                }
                if (touchposition.x > 600 & touchposition.x < 900)
                {
                    Rz();
                }
                if (touchposition.x > 400 & touchposition.x < 600)
                {
                    Ry();
                }
                if (touchposition.x > 200 & touchposition.x < 400)
                {
                    Rx();
                }
                if (touchposition.y < 2200 & touchposition.x < 200)
                {
                    Prev();
                }
                

            }




            }

        }
}


