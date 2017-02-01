// References for operator mathematics and implementation from:
// http://wscg.zcu.cz/wscg2012/short/A29-full.pdf
// Additional understanding of Quaternions from:
// http://developerblog.myo.com/quaternions/
// http://www.3dgep.com/understanding-quaternions/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualQuaternion : MonoBehaviour {

	private Quaternion real;
	private Quaternion dual;

	public Quaternion Real { get { return real; } set { real = value; } }
	public Quaternion Dual { get { return dual; } set { real = value; } }

	DualQuaternion () {
		Real = new Quaternion(0,0,0,1);
		Dual = new Quaternion(0,0,0,0);
	}

	DualQuaternion (Quaternion real, Quaternion dual) {
		// Real = real;
		//Real = real / (real * Quaternion.Inverse(real)); // Normalised needed?
		float magnitudeOfReal = Mathf.Sqrt(Quaternion.Dot(real, real));
		Real = MultiplyQuaternionByScaler(real, (1 / magnitudeOfReal)); // Normalised?
		Dual = dual;
	}

	DualQuaternion (float real_w, float real_x, float real_y, float real_z,
					float dual_w, float dual_x, float dual_y, float dual_z) {
		Real = new Quaternion(real_x, real_y, real_z, real_w);
		Dual = new Quaternion(dual_x, dual_y, dual_z, dual_w);
	}

	// Addition
	static public DualQuaternion operator +(DualQuaternion lhs, DualQuaternion rhs) {
		Quaternion realAdded = AddQuaternions(lhs.Real, rhs.Real);
		Quaternion dualAdded = AddQuaternions(lhs.Dual, lhs.Dual);
		return new DualQuaternion(realAdded, dualAdded);
	}

	// Multiplication
	static public DualQuaternion operator *(DualQuaternion lhs, DualQuaternion rhs) {
		Quaternion realMultiplied = MultiplyQuaternions(lhs.Real, rhs.Real);
		Quaternion dualMultiplied = AddQuaternions( MultiplyQuaternions(lhs.Real, rhs.Dual) ,
													MultiplyQuaternions(lhs.Dual, rhs.Real) );
		return new DualQuaternion(realMultiplied, dualMultiplied);
	}

	// Scalar Multiplication
	static public DualQuaternion operator *(DualQuaternion dualQuat, float scalar) {
		Quaternion realScaled = MultiplyQuaternionByScaler(dualQuat.Real, scalar);
		Quaternion dualScaled = MultiplyQuaternionByScaler(dualQuat.Dual, scalar);
		return new DualQuaternion(realScaled, dualScaled);
	}

	// Conjugate a.k.a. Inverse
	static public DualQuaternion Conjugate(DualQuaternion dualQuat) {
		Quaternion realConjugate = Quaternion.Inverse(dualQuat.Real);
		Quaternion dualConjugate = Quaternion.Inverse(dualQuat.Dual);
		return new DualQuaternion(realConjugate, dualConjugate);
	}

	/* TODO
	// Magnitude
	static public float Magnitude(DualQuaternion dualQuat) {
		float newW = dualQuat.


	}
	*/

	// Normalise
	static public DualQuaternion Normalise(DualQuaternion dualQuat) {
		float magnitude = Mathf.Sqrt(Quaternion.Dot(dualQuat.Real, dualQuat.Real));
		DualQuaternion normalised = new DualQuaternion( MultiplyQuaternionByScaler(dualQuat.Real, (1 / magnitude)) ,
													    MultiplyQuaternionByScaler(dualQuat.Dual, (1 / magnitude)) );
		return normalised;
	}

	// Quaternion arithmetic operations (as Unity doesn't have them?!)
	static public Quaternion AddQuaternions(Quaternion lhs, Quaternion rhs) {
		float newW = lhs.w + rhs.w;
		float newX = lhs.x + rhs.x;
		float newY = lhs.y + rhs.y;
		float newZ = lhs.z + rhs.z;
		return new Quaternion(newW, newX, newY, newZ);
	}

	// https://uk.mathworks.com/help/aeroblks/quaternionmultiplication.html
	static public Quaternion MultiplyQuaternions(Quaternion lhs, Quaternion rhs) {
		float newW = (lhs.w * rhs.w) - (lhs.x * rhs.x) - (lhs.y * rhs.y) - (lhs.z * rhs.z);
		float newX = (lhs.w * rhs.x) - (lhs.x * rhs.w) - (lhs.y * rhs.z) - (lhs.z * rhs.y);
		float newY = (lhs.w * rhs.y) - (lhs.x * rhs.z) - (lhs.y * rhs.w) - (lhs.z * rhs.x);
		float newZ = (lhs.w * rhs.z) - (lhs.x * rhs.y) - (lhs.y * rhs.x) - (lhs.z * rhs.w);
		return new Quaternion(newW, newX, newY, newZ);
	}

	static public Quaternion MultiplyQuaternionByScaler(Quaternion quat, float scaler) {
		float newW = quat.w * scaler;
		float newX = quat.x * scaler;
		float newY = quat.y * scaler;
		float newZ = quat.z * scaler;
		return new Quaternion(newW, newX, newY, newZ);
	}

	/* TODO
	static public Quaternion NormalisedQuaternion(Quaternion quat) {
		
	}
	*/
	 
}
