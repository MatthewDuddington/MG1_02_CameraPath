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
		Real = Quaternion(0,0,0,1);
		Dual = Quaternion(0,0,0,0);
	}

	DualQuaternion (Quaternion real, Quaternion dual) {
		// Real = real;
		//Real = real / (real * Quaternion.Inverse(real)); // Normalised needed?
		Real = real / Mathf.Sqrt(Quaternion.Dot(real, real));
		Dual = dual;
	}

	DualQuaternion (float real_w, float real_x, float real_y, float real_z,
					float dual_w, float dual_x, float dual_y, float dual_z) {
		Real = new Quaternion(real_x, real_y, real_z, real_w);
		Dual = new Quaternion(dual_x, dual_y, dual_z, dual_w);
	}

	// Addition
	static public DualQuaternion operator +(DualQuaternion lhs, DualQuaternion rhs) {
		Quaternion realAdded = lhs.Real + rhs.Real;
		Quaternion dualAdded = lhs.Dual + lhs.Dual;
		return new DualQuaternion(realAdded, dualAdded);
	}

	// Multiplication
	static public DualQuaternion operator *(DualQuaternion lhs, DualQuaternion rhs) {
		Quaternion realMultiplied = lhs.Real * rhs.Real;
		Quaternion dualMultiplied = (lhs.Real * rhs.Dual) + (lhs.Dual * rhs.Real);
		return new DualQuaternion(realMultiplied, dualMultiplied);
	}

	// Scalar Multiplication
	static public DualQuaternion operator *(DualQuaternion dualQuat, float scalar) {
		Quaternion realScaled = dualQuat.Real * scalar;
		Quaternion dualScaled = dualQuat.Dual * scalar;
		return new DualQuaternion(realScaled, dualScaled);
	}

	// Conjugate a.k.a. Inverse
	static public DualQuaternion Conjugate(DualQuaternion dualQuat) {
		Quaternion realConjugate = Quaternion.Inverse(dualQuat.Real);
		Quaternion dualConjugate = Quaternion.Inverse(dualQuat.Dual);
		return new DualQuaternion(realConjugate, dualConjugate);
	}

	// Magnitude
	static public float Magnitude(DualQuaternion dualQuat) {
		return dualQuat * DualQuaternion.Conjugate(dualQuat);
	}

	// Normalise
	static public DualQuaternion Normalise(DualQuaternion dualQuat) {
		float magnitude = Mathf.Sqrt(Quaternion.Dot(dualQuat.Real, dualQuat.Real));
		return new DualQuaternion(dualQuat.Real * (1 / magnitude), dualQuat.Dual * (1 / magnitude));
	}

}
