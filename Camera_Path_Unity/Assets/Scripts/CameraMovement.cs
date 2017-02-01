using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour {

    [Header("Waypoints")]

    public GameObject waypoints_holder;
    public GameObject[] way_points;
    public int wp_id; 

    public enum curveType { lerp, bezier, bspline, hermit, catmullrom }
    public curveType curveState;

    private float startTime;
    private float distCovered;

    [Header("Debug line")]
    public float drawingStep = 0.1f;
    public float visibilityDyration = 0.5f;

    [Header("Lerp")]
    public float l_speed_multipler = 10;

    [Header("Bezier")]
    public float b_speed_multipler = 0.5f;

    [Header("B-Spline")]
    public float bS_speed_multipler = 0.5f;

    [Header("Hermit")]
    public float h_speed_multipler = 0.5f;
    public float h_angular_scale = 10;

    [Header("Catmull-Rom")]
    public float c_speed_multipler = 0.5f;

    Curve c;


    void Start(){
        startTime = Time.time;

        way_points = new GameObject[waypoints_holder.transform.childCount];
        for(int i = 0; i < way_points.Length; i++)
        {
            way_points[i] = waypoints_holder.transform.GetChild(i).gameObject;
        }

    }

    void Update()
    {

        switch (curveState){
            case curveType.lerp:
                //do lerp
                createLerp();
                break;
            case curveType.bezier:
                // do bezier
                createBezier();
                break;
            case curveType.bspline:
                // do bspline
                createBSpline();
                break;
            case curveType.hermit:
                // do hermit
                createHermit();
                break;
            case curveType.catmullrom:
                //do catmullrom
                createCatmullrom();
                break;
            default:
                //do lerp
                break; 

        }


    }

    void createLerp()
    {
        distCovered = (Time.time - startTime) * l_speed_multipler;
        float fracJourney = distCovered / Vector3.Distance(way_points[wp_id].transform.position, way_points[wp_id + 1].transform.position);
        transform.position = Vector3.Lerp(way_points[wp_id].transform.position, way_points[wp_id + 1].transform.position, fracJourney);

        Debug.DrawLine(way_points[wp_id].transform.position, way_points[wp_id + 1].transform.position, Color.red);
        

        if (fracJourney >= 1)
        {
            print("Updating Wp_id:.." + wp_id);
            wp_id++;
            startTime = Time.time;
            if (wp_id == way_points.Length - 1)
            {
                wp_id = 0;
            }
        }
    }

    void createBezier()
    {
        distCovered = (Time.time - startTime) * b_speed_multipler;
        c = new BezierCurve(way_points[wp_id].transform.position,
                            way_points[wp_id].transform.GetChild(1).transform.position,
                            way_points[wp_id+1].transform.GetChild(0).transform.position,
                            way_points[wp_id+1].transform.position);
        c.DrawDebugCurve(drawingStep, visibilityDyration);

        //print("P0: " + way_points[wp_id].transform.position +
        //      "P1: " + way_points[wp_id].transform.GetChild(1).transform.position +
        //      "P2: " + way_points[wp_id + 1].transform.GetChild(0).transform.position +
        //      "P3: " + way_points[wp_id + 1].transform.position);

        transform.position = c.Evaluate(distCovered);
        print("Result" + c.Evaluate(distCovered));


        if (distCovered >= 1)
        {
            print("Updating Wp_id:.." + wp_id);
            wp_id++;
            startTime = Time.time;
            if (wp_id == way_points.Length - 1)
            {
                
                wp_id = 0;
            }
        }
    }

    void createBSpline()
    {
        distCovered = (Time.time - startTime) * bS_speed_multipler;
        //c = new B3SplineCurve(way_points[wp_id].transform.position,
        //                   way_points[wp_id].transform.GetChild(1).transform.position,
        //                   way_points[wp_id + 1].transform.GetChild(0).transform.position,
        //                   way_points[wp_id + 1].transform.position);

        c = new B3SplineCurve(way_points[0].transform.position,
                                way_points[1].transform.position,
                                way_points[2].transform.position,
                                way_points[3].transform.position                        
                          
                           );
        c.DrawDebugCurve(drawingStep, visibilityDyration);

        print("P0: " + way_points[wp_id].transform.position +
              "P1: " + way_points[wp_id].transform.GetChild(1).transform.position +
              "P2: " + way_points[wp_id + 1].transform.GetChild(0).transform.position +
              "P3: " + way_points[wp_id + 1].transform.position);

        transform.position = c.Evaluate(distCovered);



        if (distCovered >= 1)
        {
            print("Updating Wp_id:.." + wp_id);
            wp_id++;
            startTime = Time.time;
            if (wp_id == way_points.Length - 1)
            {
                wp_id = 0;
            }
        }
    }

    void createHermit()
    {
        distCovered = (Time.time - startTime) * h_speed_multipler;
        c = new HermitCurve(way_points[wp_id].transform.position, way_points[wp_id + 1].transform.position, -way_points[wp_id].transform.forward * h_angular_scale, way_points[wp_id + 1].transform.forward * h_angular_scale);
        c.DrawDebugCurve(drawingStep, visibilityDyration);
        transform.position = c.Evaluate(distCovered);


        if (distCovered >= 1)
        {
            print("Updating Wp_id:.." + wp_id);
            wp_id++;
            startTime = Time.time;
            if (wp_id == way_points.Length - 1)
            {
                wp_id = 0;
            }
        }
    }

    void createCatmullrom()
    {
        distCovered = (Time.time - startTime) * c_speed_multipler;
        c = new CatmullRomCurve(way_points[wp_id].transform.GetChild(1).transform.position,
                                way_points[wp_id].transform.position,
                                way_points[wp_id + 1].transform.position,
                                way_points[wp_id + 1].transform.GetChild(0).transform.position);
        c.DrawDebugCurve(drawingStep, visibilityDyration);
        transform.position = c.Evaluate(distCovered);


        if (distCovered >= 1)
        {
            print("Updating Wp_id:.." + wp_id);
            wp_id++;
            startTime = Time.time;
            if (wp_id == way_points.Length - 1)
            {
                wp_id = 0;
            }
        }
    }
}
