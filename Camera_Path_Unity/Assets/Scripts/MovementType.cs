using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementType : MonoBehaviour {

    public MovementTypes movement;

    public GameObject wp_holder;
    private GameObject[] waypoints;

	// Use this for initialization
	void Start () {

        waypoints = new GameObject[wp_holder.transform.childCount];
        for (int i = 0; i != waypoints.Length; i++)
            waypoints[i] = wp_holder.transform.GetChild(i).gameObject;

        movement.setWp(waypoints);       
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = movement.moveCamera();
	}
}

public abstract class MovementTypes : ScriptableObject
{
    public GameObject[] waypoints;
    public float startTime;
    public float distCovered;
    public int wp_id;
    public float speed; 

    public MovementTypes() { }

    public abstract void setWp(GameObject[] wp);

    public abstract Vector3 moveCamera();


}

[CreateAssetMenu(fileName = "LerpMovement", menuName = "MovementTypes/LerpMovement", order = 1)]
public class LerpMovement : MovementTypes
{

    public LerpMovement() { }

    public override void setWp(GameObject[] wp)
    {
        waypoints = new GameObject[wp.Length];
        waypoints = wp;
    }

    override public Vector3 moveCamera()
    {
        distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / Vector3.Distance(waypoints[wp_id].transform.position, waypoints[wp_id + 1].transform.position);
        Vector3 results = Vector3.Lerp(waypoints[wp_id].transform.position, waypoints[wp_id + 1].transform.position, fracJourney);

        Debug.DrawLine(waypoints[wp_id].transform.position, waypoints[wp_id + 1].transform.position, Color.red);

        if (fracJourney >= 1)
        {
            MonoBehaviour.print("Updating Wp_id:.." + wp_id);
            wp_id++;
            startTime = Time.time;
            if (wp_id == waypoints.Length - 1)
            {
                wp_id = 0;
            }
        }
        return results;
    }
}


[CreateAssetMenu(fileName = "BezierMovement", menuName = "MovementTypes/BezierMovement", order = 2)]
public class BezierMovement : MovementTypes
{

    public BezierMovement() { }

    public override void setWp(GameObject[] wp)
    {
        waypoints = new GameObject[wp.Length];
        waypoints = wp;
    }

    override public Vector3 moveCamera()
    {
        Vector3 results = Vector3.zero;
        return results;
    }
}

[CreateAssetMenu(fileName = "BSplineMovement", menuName = "MovementTypes/BSplineMovement", order = 3)]
public class BSplineMovement : MovementTypes
{

    public BSplineMovement() { }

    public override void setWp(GameObject[] wp)
    {
        waypoints = new GameObject[wp.Length];
        waypoints = wp;
    }

    override public Vector3 moveCamera()
    {
        Vector3 results = Vector3.zero;
        return results;
    }
}


[CreateAssetMenu(fileName = "HermitMovement", menuName = "MovementTypes/HermitMovement", order = 4)]
public class HermitMovement : MovementTypes
{

    public HermitMovement() { }

    public override void setWp(GameObject[] wp)
    {
        waypoints = new GameObject[wp.Length];
        waypoints = wp;
    }

    override public Vector3 moveCamera()
    {
        Vector3 results = Vector3.zero;
        return results;
    }
}

[CreateAssetMenu(fileName = "CatmullMovement", menuName = "MovementTypes/CatmullMovement", order = 5)]
public class CatmullMovement : MovementTypes
{

    public CatmullMovement() { }

    public override void setWp(GameObject[] wp)
    {
        waypoints = new GameObject[wp.Length];
        waypoints = wp;
    }

    override public Vector3 moveCamera()
    {
        Vector3 results = Vector3.zero;
        return results;
    }
}
