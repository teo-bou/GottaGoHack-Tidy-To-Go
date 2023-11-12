using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;




public class Movement : MonoBehaviour
{
    public float animationTime = 1f;

    private float animationTimer = 0f;
    public GameObject Ref;
    public GameObject cube;
    public int index = 0;
    public List<Vector3> Views;
    public List<int> heights;

    // Start is called before the first frame update
    
    
    // Update is called once per frame
    void Update()
    {   Vector3 startPosition = transform.position;
        Vector3 endPosition = Views[index];
       

        // Increment the animation timer by the time that has passed since the last frame.
        animationTimer += Time.deltaTime;

        // Calculate the percentage of the animation time that has elapsed.
        float t = animationTimer / animationTime;

        // Use Lerp to smoothly interpolate the game object's position between the start and end positions.
        transform.position = Vector3.Lerp(startPosition, endPosition, t);
        transform.LookAt(Ref.transform);
        // If the animation time has elapsed, reset the timer and swap the start and end positions.
        if (animationTimer >= animationTime)
        {
            animationTimer = 0f;
            
        }
    }
    public void Home()
    {
        index = 0;
    }

    public void Inc()
    {
        index += 1;
        if (index >= Views.Count) { index = 0; }
    }

    public void Dec()
    {
        index -= 1;
        if (index < 0) { index = Views.Count - 1; }
    }
}

