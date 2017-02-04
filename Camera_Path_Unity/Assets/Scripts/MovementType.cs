﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementType : ScriptableObject
{
    protected GameObject[] waypoints;
    protected float startTime;
    protected float distCovered;
    protected int wp_id;
    protected Curve curveType;


    [Header("Path Control")]
    public float speed = 0.5f;

    [Header("Debug Line")]
    public float debug_drawing_step = 0.01f;
    public float debug_duration = 1; 

    public MovementType() { }

    public void reset()
    {
        startTime = 0;
        wp_id = 0;
        distCovered = 0;
    }

    public void setWp(GameObject[] wp)
    {
        waypoints = new GameObject[wp.Length];
        waypoints = wp;
    }


    public abstract Vector3 moveCamera();

    protected void finishedSection()
    {
        MonoBehaviour.print("Updating Wp_id:.." + wp_id);
        wp_id++;
        startTime = Time.time;
        if (wp_id == waypoints.Length - 1)
        {

            wp_id = 0;
        }
    }


}

[CreateAssetMenu(fileName = "LerpMovement", menuName = "MovementTypes/LerpMovement", order = 1)]
public class LerpMovement : MovementType
{

    public LerpMovement() { }

    override public Vector3 moveCamera()
    {
        distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / Vector3.Distance(waypoints[wp_id].transform.position, waypoints[wp_id + 1].transform.position);
        Vector3 results = Vector3.Lerp(waypoints[wp_id].transform.position, waypoints[wp_id + 1].transform.position, fracJourney);

        Debug.DrawLine(waypoints[wp_id].transform.position, waypoints[wp_id + 1].transform.position, Color.red);

        if (fracJourney >= 1)
        {
            finishedSection();
        }
        return results;
    }
}


[CreateAssetMenu(fileName = "BezierMovement", menuName = "MovementTypes/BezierMovement", order = 2)]
public class BezierMovement : MovementType
{

    public BezierMovement() { }

    override public Vector3 moveCamera()
    {
        distCovered = (Time.time - startTime) * speed;
        curveType = new BezierCurve(waypoints[wp_id].transform.position,
                            waypoints[wp_id].transform.GetChild(1).transform.position,
                            waypoints[wp_id + 1].transform.GetChild(0).transform.position,
                            waypoints[wp_id + 1].transform.position);
        curveType.DrawDebugCurve(debug_drawing_step, debug_duration);

        Vector3 results = curveType.Evaluate(distCovered);
        MonoBehaviour.print("Result" + curveType.Evaluate(distCovered));


        if (distCovered >= 1)
        {
            finishedSection();
        }
        return results;
    }
}

[CreateAssetMenu(fileName = "BSplineMovement", menuName = "MovementTypes/BSplineMovement", order = 3)]
public class BSplineMovement : MovementType
{

    public BSplineMovement() { }

    override public Vector3 moveCamera()
    {
        distCovered = (Time.time - startTime) * speed;


        List<Vector3> tpositions = new List<Vector3>();

        tpositions.Add(waypoints[0].transform.position + (waypoints[0].transform.forward * 10));
        for (int i = 0; i < waypoints.Length; i++)
        {
            tpositions.Add(waypoints[i].transform.position);
        }
        tpositions.Add(waypoints[waypoints.Length - 1].transform.position + (waypoints[waypoints.Length - 1].transform.forward * 10));


        //curveType = new B3SplineCurve(tpositions[wp_id],
        //                              tpositions[wp_id+1],
        //                              tpositions[wp_id+2],
        //                              tpositions[wp_id+3]);


        //curveType = new B3SplineCurve(tpositions[0],
        //                              tpositions[1],
        //                              tpositions[2],
        //                              tpositions[3]);

        curveType = new B3SplineCurve(waypoints[0].transform.position, waypoints[1].transform.position, waypoints[2].transform.position, waypoints[3].transform.position);

        curveType.DrawDebugCurve(debug_drawing_step, debug_duration);

        Vector3 results = curveType.Evaluate(distCovered);



        if (distCovered >= 1)
        {
            finishedSection();
        }
        return results;
    }
}


[CreateAssetMenu(fileName = "HermitMovement", menuName = "MovementTypes/HermitMovement", order = 4)]
public class HermitMovement : MovementType
{

    public float angular_scalar = 30.0f; 

    public HermitMovement() { }

    override public Vector3 moveCamera()
    {

        distCovered = (Time.time - startTime) * speed;
        curveType = new HermitCurve(waypoints[wp_id].transform.position,
                                    waypoints[wp_id + 1].transform.position,
                                    -waypoints[wp_id].transform.forward*angular_scalar,
                                    waypoints[wp_id + 1].transform.forward*angular_scalar);
        Vector3 results = curveType.Evaluate(distCovered);

        curveType.DrawDebugCurve(debug_drawing_step, debug_duration);


        if (distCovered >= 1)
        {
            finishedSection();
        }
        return results;
    
    }
}

[CreateAssetMenu(fileName = "CatmullMovement", menuName = "MovementTypes/CatmullMovement", order = 5)]
public class CatmullMovement : MovementType
{

    public CatmullMovement() { }

    override public Vector3 moveCamera()
    {
        List<Vector3> tpositions = new List<Vector3>();

        tpositions.Add(waypoints[0].transform.position + (waypoints[0].transform.forward * 10));
        for(int i =0; i < waypoints.Length; i++)
        {
            tpositions.Add(waypoints[i].transform.position);
        }
        tpositions.Add(waypoints[waypoints.Length-1].transform.position + (waypoints[waypoints.Length-1].transform.forward * 10));


        distCovered = (Time.time - startTime) * speed;
        curveType = new CatmullRomCurve(tpositions[wp_id],
                                tpositions[wp_id+1],
                                tpositions[wp_id+2],
                                tpositions[wp_id+3]);

        curveType.DrawDebugCurve(debug_drawing_step, debug_duration);
        Vector3 results = curveType.Evaluate(distCovered);


        if (distCovered >= 1)
        {
            finishedSection();
        }

        return results;
    }
}
