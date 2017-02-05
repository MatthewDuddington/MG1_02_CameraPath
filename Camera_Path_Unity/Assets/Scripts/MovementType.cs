using System.Collections.Generic;
using UnityEngine;

public abstract class MovementType
{
    protected GameObject[] wps;
    protected float startTime;
    protected float distCovered;
    protected int wp_id;
    protected Curve curveType;

    public float speed;
    public float debug_drawing_step = 0.01f;
    public float debug_duration = 1;

    public MovementType() { }

    public void reset()
    {
        startTime = Time.time;
        distCovered = 0;
        wp_id = 0;
    }

    public abstract Vector3 moveCamera();

    protected void finishedSection(float current_percentage)
    {
        if (current_percentage >= 1)
        {
            MonoBehaviour.print("Updating Wp_id:.." + wp_id);
            wp_id++;
            startTime = Time.time;
            if (wp_id == wps.Length - 1)
                wp_id = 0;
        }
    }

    protected List<Vector3> extend_wp(GameObject[] waypoints)
    {
        List<Vector3> tpositions = new List<Vector3>();
        tpositions.Add(wps[0].transform.GetChild(0).position + (wps[0].transform.GetChild(0).forward * 10));
        for (int i = 0; i < wps.Length; i++)
            tpositions.Add(wps[i].transform.GetChild(0).position);
        tpositions.Add(wps[wps.Length - 1].transform.GetChild(0).position + (wps[wps.Length - 1].transform.GetChild(0).forward * 10));

        return tpositions;
    }
}

public class LerpMovement : MovementType
{
    public LerpMovement(GameObject[] wp, float spd)
    {
        wps = new GameObject[wp.Length];
        wps = wp;
        speed = spd;
    }

    override public Vector3 moveCamera()
    {
        distCovered = (Time.time - startTime) * speed;

        // Creating temp vectors for the start and end
        Vector3 p0 = wps[wp_id].transform.GetChild(0).position;
        Vector3 p1 = wps[wp_id + 1].transform.GetChild(0).position;

        // Calculating the precentage of the journey covered
        float fracJourney = distCovered / Vector3.Distance(p0, p1);

        // Calcuting the position along the journey
        Vector3 results = Vector3.Lerp(p0, p1, fracJourney);
        Debug.DrawLine(p0, p1, Color.red);

        //Check to see if the section has been done and move on to the next set of waypoints
        finishedSection(fracJourney);

        return results;
    }
}

public class BezierMovement : MovementType
{
    public BezierMovement(GameObject[] wp, float spd, bool use_c1)
    {
        // Snaps the Next handle inline with the previous and main handles
        if (use_c1)
            c1_snap_handle(wp);

        wps = new GameObject[wp.Length];
        wps = wp;

        speed = spd;
    }

    override public Vector3 moveCamera()
    {
        distCovered = (Time.time - startTime) * speed;

        // creating variables for the current positions and handles
        Vector3 p0 = wps[wp_id].transform.GetChild(0).position;
        Vector3 p1 = wps[wp_id + 1].transform.GetChild(0).position;
        Vector3 h0 = wps[wp_id].transform.GetChild(2).position;
        Vector3 h1 = wps[wp_id + 1].transform.GetChild(1).position;

        // Caluating the position along the curve
        curveType = new BezierCurve(p0, h0, h1, p1);
        curveType.DrawDebugCurve(debug_drawing_step, debug_duration);
        Vector3 results = curveType.Evaluate(distCovered);

        //Check to see if the section has been done and move on to the next set of waypoints
        finishedSection(distCovered);

        return results;
    }

    // Handles placing the next handle inline with the main and previous handles
    private void c1_snap_handle(GameObject[] wps)
    {
        foreach (GameObject wp in wps)
        {
            // Get the vector between the main and previous handles
            Vector3 controlVector = wp.transform.GetChild(0).position - wp.transform.GetChild(1).position;
            //get the distance from the main and next handles 
            float dist = Vector3.Distance(wp.transform.GetChild(0).transform.position, wp.transform.GetChild(2).transform.position);
            // Reposition the next handle to be inline with the previous and main handles 
            wp.transform.GetChild(2).transform.position = wp.transform.GetChild(0).transform.position + (controlVector.normalized * dist);
        }
    }
}

public class BSplineMovement : MovementType
{
    public BSplineMovement(GameObject[] wp, float spd)
    {
        wps = new GameObject[wp.Length];
        wps = wp;
        speed = spd;
    }

    override public Vector3 moveCamera()
    {
        distCovered = (Time.time - startTime) * speed;

        // creating variables for the current positions and handles
        Vector3 p0 = wps[wp_id].transform.GetChild(0).position;
        Vector3 p1 = wps[wp_id + 1].transform.GetChild(0).position;
        Vector3 h0 = wps[wp_id].transform.GetChild(2).position;
        Vector3 h1 = wps[wp_id + 1].transform.GetChild(1).position;

        // Uses the control points to add the curve data
        curveType = new B3SplineCurve(p0, h0, h1, p1);
        curveType.DrawDebugCurve(debug_drawing_step, debug_duration);

        Vector3 results = curveType.Evaluate(distCovered);

        //Check to see if the section has been done and move on to the next set of waypoints
        finishedSection(distCovered);

        return results;
    }
}

public class HermitMovement : MovementType
{
    public float angular_scalar = 30.0f;

    public HermitMovement(GameObject[] wp, float spd, float ang_scl)
    {
        wps = new GameObject[wp.Length];
        wps = wp;
        speed = spd;
        angular_scalar = ang_scl;
    }

    override public Vector3 moveCamera()
    {

        distCovered = (Time.time - startTime) * speed;

        // Creating variables for the current set of the waypoints
        Vector3 p0 = wps[wp_id].transform.GetChild(0).position;
        Vector3 p1 = wps[wp_id + 1].transform.GetChild(0).position;
        Vector3 t0 = wps[wp_id].transform.GetChild(0).forward * angular_scalar;
        Vector3 t1 = -wps[wp_id + 1].transform.GetChild(0).forward * angular_scalar;

        // Calculating the current position along the curve
        curveType = new HermitCurve(p0, p1, t0, t1);
        Vector3 results = curveType.Evaluate(distCovered);
        curveType.DrawDebugCurve(debug_drawing_step, debug_duration);

        //Check to see if the section has been done and move on to the next set of waypoints
        finishedSection(distCovered);

        return results;
    }
}

public class CatmullMovement : MovementType
{
    public CatmullMovement(GameObject[] wp, float spd)
    {
        wps = new GameObject[wp.Length];
        wps = wp;
        speed = spd;
    }

    override public Vector3 moveCamera()
    {
        distCovered = (Time.time - startTime) * speed;

        // Extending the waypoint position to handle the ends
        List<Vector3> tpositions = extend_wp(wps);
        Vector3 p0 = tpositions[wp_id];
        Vector3 p1 = tpositions[wp_id + 1];
        Vector3 p2 = tpositions[wp_id + 2];
        Vector3 p3 = tpositions[wp_id + 3];

        // Calculating the position along the curve
        curveType = new CatmullRomCurve(p0, p1, p2, p3);
        curveType.DrawDebugCurve(debug_drawing_step, debug_duration);
        Vector3 results = curveType.Evaluate(distCovered);

        //Check to see if the section has been done and move on to the next set of waypoints
        finishedSection(distCovered);

        return results;
    }
}

