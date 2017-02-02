using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPatterns : MonoBehaviour {

     public enum Types {Bezier, BSpline3, Hermit, CatmullRom}
     public Types curveType;
     public Vector3[] way_points;

     public float debugVisibilityDuration;
     public float debugDrawingStep;

     // Use this for initialization
     void Start () {
          GameObject[] way_objects = GetComponent<CameraMovement>().waypoints;
          way_points = new Vector3[way_objects.Length];
          for (int i = 0; i != way_objects.Length; i++)
               way_points[i] = way_objects[i].transform.position;

          Curve c;
          switch (curveType)
          {
               case Types.Bezier:
                    {
                         c = new BezierCurve(way_points);
                         c.DrawDebugCurve(debugDrawingStep, debugVisibilityDuration);
                    }
                    break;
               case Types.BSpline3:
                    if (way_points.Length >= 4)
                    {
                         c = new B3SplineCurve(way_points[0], way_points[1], way_points[2], way_points[3]);
                         c.DrawDebugCurve(debugDrawingStep, debugVisibilityDuration);
                    }
                    break;
               case Types.Hermit:
                    if (way_points.Length >= 2)
                    {
                         c = new HermitCurve(way_points[0], way_points[1], new Vector3(0, 0, 0), new Vector3(-10, 0, 0));
                         c.DrawDebugCurve(debugDrawingStep, debugVisibilityDuration);
                    }
                    break;
               case Types.CatmullRom:
                    if (way_points.Length >= 4)
                    {
                         c = new CatmullRomCurve(way_points[0], way_points[1], way_points[2], way_points[3]);
                         c.DrawDebugCurve(debugDrawingStep, debugVisibilityDuration);
                    }
                    break;
               default:
                    break;
          }


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

//abstract interface
public abstract class Curve
{
     public List<Vector3> points;
     public int degree;

     public Curve() {  }
     public abstract Vector3 Evaluate(float t);


     public static float fact(float n)
     {
          float result = 1;
          for (int i = 1; i <= n; i++)
               result *= i;
          return result;
     }

     public void DrawDebugCurve(float drawingStep, float visibilityDuration)
     {
          int limit = Convert.ToInt32(1.0f / drawingStep);
          for (int i = 1; i <= limit; i += 1)
          {
               float t = (float)i / (float)(limit);
               Debug.DrawLine(Evaluate(t - drawingStep), Evaluate(t),
                    Color.black, visibilityDuration);
          }
     }
}

public class BezierCurve: Curve
{ 
     public BezierCurve(Vector3[] Points)
     {
          points = new List<Vector3>();
          foreach (Vector3 point in Points)
               points.Add(point);
          degree = points.Count;
     }

    public BezierCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        points = new List<Vector3>();
        points.Add(p0);
        points.Add(p1);
        points.Add(p2);
        points.Add(p3);
          degree = points.Count;
    }

     //override public Vector3 Evaluate(float t)
     //{

     //    Vector3 a = -points[0]+(3*points[1])-(3*points[2])+points[3];
     //    Vector3 b = (3*points[0]) - (6*points[1])+(3*points[2]);
     //    Vector3 c = -(3 * points[0]) + (3 * points[1]);
     //    Vector3 d = points[0];


     //    Vector3 result = (a * (t * t * t)) + (b * (t * t)) + (c * (t)) + d;

     //    return result;
     //}

     //get value in point t
    override public Vector3 Evaluate(float t)
     {
          Vector3 result = Vector3.zero;
          for (float i = 0; i != degree; i++)
          {
               float CnK = fact(degree - 1) / (fact(i) * fact(degree - i - 1)),
                    bernstPoly = CnK * Mathf.Pow(t, i) * Mathf.Pow(1 - t, degree - i - 1);
               result += bernstPoly * points[(int)i];
          }
          return result;
     }
}

// B spline - 3rd degree
//the curve, that i've been given during my BSc Computer Graphics module
public class B3SplineCurve:Curve
{
     public B3SplineCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
     {
          points = new List<Vector3>();
          points.Add(p0);
          points.Add(p1);
          points.Add(p2);
          points.Add(p3);

          // B-spline doesn't go directly through the starting and ending point,
          // so an adjustment required
          // this is called 'imaginary point method'

          p0 = 2 * p0 - p1;
          p3 = 2 * p3 - p2;
     }

     //get value in point t    
     public override Vector3 Evaluate(float t)
     {
          float[] coeff = new float[4];
          coeff[0] = (1 - t) * (1 - t) * (1 - t);
          coeff[1] = 3 * t * t * t - 6 * t * t + 4;
          coeff[2] = -3 * t * t * t - 3 * t * t - 3 * t + 1;
          coeff[3] = t * t * t;

          Vector3 result = Vector3.zero;

          for (int i = 0; i != points.Count; i++)
               result += coeff[i] * points[i];

          return result / 6;
     }
}

//Hermit curve is based on 2 points and 2 direction vectors
public class HermitCurve:Curve
{
     // Q0, Q1 - direction (tangent) vectors
     public HermitCurve(Vector3 P0, Vector3 P1, Vector3 Q0, Vector3 Q1)
     {
          points = new List<Vector3>();
          points.Add(P0);
          points.Add(P1);
          //I add them to the same array, because the loop algorithm is the same
          // in the evaluation function
          // P.S. But they are not points!
          points.Add(Q0);
          points.Add(Q1);
     }

     public override Vector3 Evaluate(float t)
     {
          float[] coeff = new float[4];
          coeff[0] = 1 - (3 * t * t) + (2 * t * t * t);
          coeff[1] = t * t * (3 - 2 * t);
          coeff[2] = t * (1 - 2 * t + t * t);
          coeff[3] = t * t * (1 - t);

          Vector3 result = Vector3.zero;

          for (int i = 0; i != points.Count; i++)
               result += coeff[i] * points[i];

          return result;
     }
}

// this curve is always starts in p1 and ends in p2
// p0 and p3 are responsible for the tangent and direction
public class CatmullRomCurve:Curve
{
     public CatmullRomCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
     {
          points = new List<Vector3>();
          points.Add(p0);
          points.Add(p1);
          points.Add(p2);
          points.Add(p3);
     }

     public override Vector3 Evaluate(float t)
     {
          float[] coeff = new float[4];
          coeff[0] = -t*(1 - t) * (1 - t);
          coeff[1] = (2 - 5 * t * t + 3 * t * t * t);
          coeff[2] = t * (1 + 4 * t - 3 * t * t);
          coeff[3] = -t * t * (1 - t);

          Vector3 result = Vector3.zero;

          for (int i = 0; i != points.Count; i++)
               result += coeff[i] * points[i];

          return 0.5f*result;
     }
}
