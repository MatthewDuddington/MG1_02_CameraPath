using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{


    public MovementType movement;

    public GameObject wp_holder;
    public GameObject[] waypoints;

    void Start()
    {
        waypoints = new GameObject[wp_holder.transform.childCount];
        for (int i = 0; i != waypoints.Length; i++)
            waypoints[i] = wp_holder.transform.GetChild(i).gameObject;

        movement.reset();
        movement.setWp(waypoints);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = movement.moveCamera();
    }


}

