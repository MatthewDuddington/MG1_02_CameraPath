using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour {

    Curve c;

    public GameObject[] way_points;
    public int wp_id; 

    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    public float distCovered;

    public enum curveType { lerp, bezier, bspline, hermit, catmullrom }
    public curveType curveState; 

    void Start(){
        startTime = Time.time;
        //journeyLength = Vector3.Distance(startMarker.position, endMarker.position)

    }

    void Update()
    {

        distCovered = (Time.time - startTime) * speed;
        switch (curveState){
            case curveType.lerp:
                //do lerp
                float fracJourney = distCovered / Vector3.Distance(way_points[wp_id].transform.position, way_points[wp_id + 1].transform.position);
                transform.position = Vector3.Lerp(way_points[wp_id].transform.position,way_points[wp_id+1].transform.position, fracJourney);
                break;
            case curveType.bezier:
                // do bezier

                break;
            case curveType.bspline:
                // do bspline
                break;
            case curveType.hermit:
                // do hermit
                c = new HermitCurve(way_points[wp_id].transform.position, way_points[wp_id + 1].transform.position, -way_points[wp_id].transform.forward*10,way_points[wp_id+1].transform.forward*10);
                c.DrawDebugCurve(0.1f, 100);
                transform.position = c.Evaluate(distCovered);
                break;
            case curveType.catmullrom:
                //do catmullrom
                break;
            default:
                //do lerp
                break; 

        }

        if (distCovered >= 1)
        {
            print("Updating Wp_id:.." + wp_id);
            wp_id++;
            startTime = Time.time;
            if (wp_id == way_points.Length-1)
            {
                wp_id = 0;
            }
        }

    }
}
