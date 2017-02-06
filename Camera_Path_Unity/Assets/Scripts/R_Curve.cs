using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class R_Curve {


    //------------------------------------------------------------------------------//
    //																				//
    //								Lerp Implementation								//
    //																				//
    //------------------------------------------------------------------------------//

    // Mathew Duddington implementation 
    // Linear Interpolation between two points
    // Implementation adapted from: http://www.blueraja.com/blog/404/how-to-use-unity-3ds-linear-interpolation-vector3-lerp-correctly#comment-23334
    static public Vector3 lerp(Vector3 start, Vector3 end, float t)
    {
        // Ensure requested distance along interpolation is between 0 and 1
        t = UnityEngine.Mathf.Clamp01(t);
        // Method guarantees the return will equal the end position when t = 1
        return ((1 - t) * start) + (t * end);
    }

    //------------------------------------------------------------------------------//
    //																				//
    //						 Bezier Implementation									//
    //																				//
    //------------------------------------------------------------------------------//

    // From slides on interpolation 
    static public Vector3 bezier(Vector3 p0,Vector3 h0,Vector3 h1, Vector3 p1, float t)
    {
            Vector3 a = -p0+(3*h0)-(3*h1)+p1;
            Vector3 b = (3*p0) - (6*h0)+(3*h1);
            Vector3 c = -(3 * p0) + (3 * h0);
            Vector3 d = p0;

            Vector3 result = (a * (t * t * t)) + (b * (t * t)) + (c * (t)) + d;
            return result;
    }

    //------------------------------------------------------------------------------//
    //																				//
    //								B-Spline Implementation							//
    //																				//
    //------------------------------------------------------------------------------//

    // Nikita Implementation 
    static public Vector3 bSpline(Vector3 p0, Vector3 h0, Vector3 h1, Vector3 p1, float t)
    {
        p0 = 6 * p0 - 4 * h0 - h1;
        p1 = 6 * p1 - 4 * h1 - h0;

        float[] coeff = new float[4];
        coeff[0] = (1 - t) * (1 - t) * (1 - t);
        coeff[1] = 3 * (t * t * t) - 6 * (t * t) + 4;
        coeff[2] = -3 * (t * t * t) + 3 * (t * t) + 3 * t + 1;
        coeff[3] = t * t * t;

        Vector3 result = Vector3.zero;
        result += coeff[0] * p0;
        result += coeff[1] * h0;
        result += coeff[2] * h1;
        result += coeff[3] * p1;

        return result / 6;
    }

    //------------------------------------------------------------------------------//
    //																				//
    //						 Hermit Implementation									//
    //																				//
    //------------------------------------------------------------------------------//

    // Nikita Implementation 
    static public Vector3 hermit(Vector3 p0, Vector3 p1, Vector3 t0, Vector3 t1, float t)
    {
        float[] coeff = new float[4];
        coeff[0] = 1 - (3 * t * t) + (2 * t * t * t);
        coeff[1] = t * t * (3 - 2 * t);
        coeff[2] = t * (1 - 2 * t + t * t);
        coeff[3] = t * t * (1 - t);

        // More Efficient then for loop
        Vector3 result = Vector3.zero;
        result += coeff[0] * p0;
        result += coeff[1] * p1;
        result += coeff[2] * t0;
        result += coeff[3] * t1;

        return result;
    }

    //------------------------------------------------------------------------------//
    //																				//
    //						  Catmull-Rom Implementation							//
    //																				//
    //------------------------------------------------------------------------------//

    // Nikita Implementation
    static public Vector3 catmullRomCurve(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float[] coeff = new float[4];
        coeff[0] = -t * (1 - t) * (1 - t);
        coeff[1] = (2 - 5 * t * t + 3 * t * t * t);
        coeff[2] = t * (1 + 4 * t - 3 * t * t);
        coeff[3] = -t * t * (1 - t);

        Vector3 result = Vector3.zero;
        result += coeff[0] * p0;
        result += coeff[1] * p1;
        result += coeff[2] * p2;
        result += coeff[3] * p3;

        return 0.5f * result;
    }
}
