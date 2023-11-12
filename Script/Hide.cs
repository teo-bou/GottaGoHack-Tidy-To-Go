using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject toHide;
    // Start is called before the first frame update
    void Hiding()
    {
        if (toHide != null)
        {
            toHide.SetActive(false);
        }
    }
}
