using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class photo : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        WebCamTexture webcam = new WebCamTexture();
        WebCamDevice[] devices = WebCamTexture.devices;
        WebCamTexture webcamTexture = new WebCamTexture();

        if (devices.Length > 0)
        {
            webcam.deviceName = devices[1].name;
            Debug.Log(webcam.deviceName);
        }
        RawImage renderer = GetComponent<RawImage>();
        renderer.texture = webcam;
        webcam.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
