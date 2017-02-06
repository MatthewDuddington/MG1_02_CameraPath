using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public enum movementType { lerp, bezier, bSpline, hermit, catmullRom }

    [Header("Movement Variables")]
    public movementType current_movement;

    public MovementType movement;

    public float debugLineDuration = 10.0f; 

    public GameObject wp_holder;

    private GameObject[] waypoints;

    private Vector3 previous;

    [Header("Lerp Specific")]
    public float l_move_speed = 10;

    [Header("Bezier Specific")]
    public float b_move_speed = 0.5f;
    public bool use_c1 = false;

    [Header("bSpline Specific")]
    public float bS_move_speed = 0.5f;

    [Header("Hermit Specific")]
    public float h_move_speed = 0.5f;
    public float angular_offset = 30;

    [Header("Catmull-Rom Specific")]
    public float c_move_speed = 0.5f;

    void Start()
    {
        waypoints = new GameObject[wp_holder.transform.childCount];
        for (int i = 0; i != waypoints.Length; i++)
            waypoints[i] = wp_holder.transform.GetChild(i).gameObject;

        switch (current_movement)
        {
            case movementType.lerp:
                movement = new LerpMovement(waypoints, l_move_speed);
                break;
            case movementType.bezier:
                movement = new BezierMovement(waypoints, b_move_speed, use_c1);
                break;
            case movementType.bSpline:
                movement = new BSplineMovement(waypoints, bS_move_speed);
                break;
            case movementType.hermit:
                movement = new HermitMovement(waypoints, h_move_speed, angular_offset);
                break;
            case movementType.catmullRom:
                movement = new CatmullMovement(waypoints, c_move_speed);
                break;
        }

        previous = waypoints[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = movement.moveCamera();
        
        // Drawing the trail behind the camera to see the debug line 
        Debug.DrawLine(previous, transform.position, Color.black,debugLineDuration);
        previous = transform.position;
      
    }
}