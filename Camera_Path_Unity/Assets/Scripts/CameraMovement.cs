using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public GameObject[] way_points;
    public int wp_id; 

    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    public float distCovered;

    void Start()
    {
      
        startTime = Time.time;
        //journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }
    void Update()
    {
        if (transform.position == way_points[wp_id+1].transform.position)
        {  
            wp_id++;
            startTime = Time.time;
            if (wp_id == way_points.Length-1)
            {
                wp_id = 0;
            }
        }

        distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / Vector3.Distance(way_points[wp_id].transform.position, way_points[wp_id+1].transform.position);
        transform.position = Vector3.Lerp(way_points[wp_id].transform.position,way_points[wp_id+1].transform.position, fracJourney);
    }
}
