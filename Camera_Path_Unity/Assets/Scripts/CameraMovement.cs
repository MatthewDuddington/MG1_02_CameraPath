using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour {

    [Header("Waypoints")]

    public GameObject waypoints_holder;
    public GameObject[] way_points;
    public int wp_id; 


    [Header("Overview")]
    public float speed = 1.0F;
    public enum curveType { lerp, bezier, bspline, hermit, catmullrom }
    public curveType curveState;

    private float startTime;
    private float distCovered;



    [Header("Lerp")]


    [Header("Bezier")]


    [Header("B-Spline")]


    [Header("Hermit")]
    public float h_angular_scale = 10; 

    [Header("Catmull-Rom")]


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

        distCovered = (Time.time - startTime) * speed;
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
        c = new BezierCurve(way_points[wp_id].transform.position,
                            way_points[wp_id].transform.GetChild(1).transform.position,
                            way_points[wp_id+1].transform.GetChild(0).transform.position,
                            way_points[wp_id+1].transform.position);
        c.DrawDebugCurve(0.1f, 100);

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

    void createBSpline()
    {
        c = new B3SplineCurve(way_points[wp_id].transform.position,
                           way_points[wp_id].transform.GetChild(1).transform.position,
                           way_points[wp_id + 1].transform.GetChild(0).transform.position,
                           way_points[wp_id + 1].transform.position);
        c.DrawDebugCurve(0.1f, 100);

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
        c = new HermitCurve(way_points[wp_id].transform.position, way_points[wp_id + 1].transform.position, -way_points[wp_id].transform.forward * h_angular_scale, way_points[wp_id + 1].transform.forward * h_angular_scale);
        c.DrawDebugCurve(0.1f, 100);
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
        c = new CatmullRomCurve(way_points[wp_id].transform.GetChild(1).transform.position,
                                way_points[wp_id].transform.position,
                                way_points[wp_id + 1].transform.position,
                                way_points[wp_id + 1].transform.GetChild(0).transform.position);
        c.DrawDebugCurve(0.1f, 100);
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
