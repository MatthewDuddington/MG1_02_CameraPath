// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
using System;

public class Mathd {

	//------------------------------------------------------------------------------//
	//																				//
	//									Vector3										//
	//																				//
	//------------------------------------------------------------------------------//

	public class Vector3 {

		private float x_;
		private float y_;
		private float z_;

		public float x { get { return x_; } set { x_ = value; } }
		public float y { get { return y_; } set { y_ = value; } }
		public float z { get { return z_; } set { z_ = value; } }



		// CONSTRUCTORS //

		public Vector3 (float x, float y, float z) {
			x_ = x;
			y_ = y;
			z_ = z;
		}

		public Vector3 (Mathd.Vector3 vec3) {
			x_ = vec3.x;
			y_ = vec3.y;
			z_ = vec3.z;
		}

		static public Mathd.Vector3 zero	 { get { return new Mathd.Vector3( 0,  0,  0); } }
		static public Mathd.Vector3 one		 { get { return new Mathd.Vector3( 1,  1,  1); } }
		static public Mathd.Vector3 right	 { get { return new Mathd.Vector3( 1,  0,  0); } }
		static public Mathd.Vector3 left	 { get { return new Mathd.Vector3(-1,  0,  0); } }
		static public Mathd.Vector3 up		 { get { return new Mathd.Vector3( 0,  1,  0); } }
		static public Mathd.Vector3 down 	 { get { return new Mathd.Vector3( 0, -1,  0); } }
		static public Mathd.Vector3 forward  { get { return new Mathd.Vector3( 0,  0,  1); } }
		static public Mathd.Vector3 backward { get { return new Mathd.Vector3( 0,  0, -1); } }



		// ARETHMETIC OPERATIONS //

		// Add
		static public Mathd.Vector3 operator +(Mathd.Vector3 lhs, Mathd.Vector3 rhs) {
			float newX = lhs.x + rhs.x;
			float newY = lhs.y + rhs.y;
			float newZ = lhs.z + rhs.z;
			return new Mathd.Vector3(newX, newY, newZ);
		}

		// Subtract
		static public Mathd.Vector3 operator -(Mathd.Vector3 lhs, Mathd.Vector3 rhs) {
			float newX = lhs.x - rhs.x;
			float newY = lhs.y - rhs.y;
			float newZ = lhs.z - rhs.z;
			return new Mathd.Vector3(newX, newY, newZ);
		}

		// Multiply by scalar
		static public Mathd.Vector3 operator *(Mathd.Vector3 vec3, float scalar) {
			float newX = vec3.x * scalar;
			float newY = vec3.y * scalar;
			float newZ = vec3.z * scalar;
			return new Mathd.Vector3(newX, newY, newZ);
		}



		// ATTRIBUTES AND PRODUCTS //

		// Magnitude a.k.a. Norm
		public float magnitude { 
			// Inefficient sqrt version
			get { return (float) Math.Sqrt( (x_ * x_) + (y_ * y_) + (z_ * z_) ); } 
		}

		// Normalised a.k.a. Unit length
		public Mathd.Vector3 normalised {
			// Inefficient divide version
			get { 
				float this_magnitude = this.magnitude; 
				return new Mathd.Vector3( x_ / this_magnitude, y_ / this_magnitude, z_ / this_magnitude );
			}

			// Normalised vector calculation which avoids division (try this later?)
			// https://en.wikipedia.org/wiki/Fast_inverse_square_root
		}

		// Rotates a Vector3 by a Quaterion
		public Mathd.Vector3 Rotate(Mathd.Quaternion quatRotation) {
			Mathd.Matrix3 roatationMatrix = new Mathd.Matrix3(
				1 - (2 *  (quatRotation.y * quatRotation.y)) - (2 * (quatRotation.z * quatRotation.z)),
				2 * ((quatRotation.x * quatRotation.y) + (quatRotation.w * quatRotation.z)),
				2 * ((quatRotation.x * quatRotation.z) - (quatRotation.w * quatRotation.y)),

				2 * ((quatRotation.x * quatRotation.y) - (quatRotation.w * quatRotation.z)),
				1 - (2 *  (quatRotation.x * quatRotation.x)) - (2 * (quatRotation.z * quatRotation.z)),
				2 * ((quatRotation.x * quatRotation.z) + (quatRotation.w * quatRotation.y)),

				2 * ((quatRotation.x * quatRotation.z) + (quatRotation.w * quatRotation.y)),
				2 * ((quatRotation.y * quatRotation.z) - (quatRotation.w * quatRotation.x)),
				1 - (2 * (quatRotation.x * quatRotation.x)) - (2 * (quatRotation.y * quatRotation.y))
			);

			float newX = ( roatationMatrix.col0[0] + roatationMatrix.col0[1] + roatationMatrix.col0[2] ) * x_;
			float newY = ( roatationMatrix.col1[0] + roatationMatrix.col1[1] + roatationMatrix.col1[2] ) * y_;
			float newZ = ( roatationMatrix.col2[0] + roatationMatrix.col2[1] + roatationMatrix.col2[2] ) * x_;

			return new Mathd.Vector3(newX, newY, newZ);
		}

		// Rotates a Vector3 around axis X by degrees (Left handed)
		public Mathd.Vector3 RotateX(float degrees) {
			float sinTheta = (float) Math.Sin(degrees);
			float cosTheta = (float) Math.Cos(degrees);

			float newY = (y_ * cosTheta) - (z_ * sinTheta);
			float newZ = (y_ * sinTheta) + (z_ * cosTheta);

			return new Mathd.Vector3(x_, newY, newZ);
		}

		// Rotates a Vector3 around axis Y by degrees (Left handed)
		public Mathd.Vector3 RotateY(float degrees) {
			float sinTheta = (float) Math.Sin(degrees);
			float cosTheta = (float) Math.Cos(degrees);

			float newX =   (x_ * cosTheta) + (z_ * sinTheta);
			float newZ = - (x_ * sinTheta) + (z_ * cosTheta);

			return new Mathd.Vector3(newX, y_, newZ);
		}

		// Rotates a Vector3 around axis Z by degrees (Left handed)
		public Mathd.Vector3 RotateZ(float degrees) {
			float sinTheta = (float) Math.Sin(degrees);
			float cosTheta = (float) Math.Cos(degrees);

			float newX = (x_ * cosTheta) - (y_ * sinTheta);
			float newY = (x_ * sinTheta) + (y_ * cosTheta);

			return new Mathd.Vector3(newX, newY, z_);
		}

		static public float DotProduct(Mathd.Vector3 lhs, Mathd.Vector3 rhs) {
		  return ( (lhs.x * rhs.x) + (lhs.y * rhs.y) + (lhs.z * rhs.z) );
		}

		static public Mathd.Vector3 CrossProduct(Mathd.Vector3 lhs, Mathd.Vector3 rhs) {
			return new Mathd.Vector3( (lhs.y * rhs.z) - (lhs.z * rhs.y),
									  (lhs.z * rhs.x) - (lhs.x * rhs.z),
									  (lhs.x * rhs.y) - (lhs.y * rhs.x)  );
		}

	}

	//------------------------------------------------------------------------------//
	//																				//
	//									Matrix3										//
	//																				//
	//------------------------------------------------------------------------------//

	public class Matrix3 {

		private float[][] matrix3_ = new float[3][];

		public float[][] rowCol { get { return matrix3_; } set { matrix3_ = value; } }

		public float[] row0 { get { return matrix3_[0]; } set { matrix3_[0] = value; } }
		public float[] row1 { get { return matrix3_[1]; } set { matrix3_[1] = value; } }
		public float[] row2 { get { return matrix3_[2]; } set { matrix3_[2] = value; } }

		public float[] col0 {
			get { return new float[3] {row0[0], row1[0], row2[0]}; }
			set { row0[0] = value[0]; row1[0] = value[1]; row2[0] = value[2]; }
		}
		public float[] col1 {
			get { return new float[3] {row0[1], row1[1], row2[1]}; }
			set { row0[1] = value[0]; row1[1] = value[1]; row2[1] = value[2]; }
		}
		public float[] col2 {
			get { return new float[3] {row0[2], row1[2], row2[2]}; }
			set { row0[2] = value[0]; row1[2] = value[1]; row2[2] = value[2]; }
		}



		// CONSTRUCTORS //

		public Matrix3() {
			row0 = new float[4] {0,0,0,0};
			row1 = new float[4] {0,0,0,0};
			row2 = new float[4] {0,0,0,0};
		}

		public Matrix3(float[] r0, float[] r1, float[] r2) {
			row0 = r0;
			row1 = r1;
			row2 = r2;
		}

		public Matrix3(float[] c0, float[] c1, float[] c2, bool isColumn) {
			col0 = c0;
			col1 = c1;
			col2 = c2;
		}

		public Matrix3(float r0c0, float r0c1, float r0c2, float r0c3,
					   float r1c0, float r1c1, float r1c2, float r1c3,
					   float r2c0, float r2c1, float r2c2, float r2c3) {
			matrix3_[0][0] = r0c0; matrix3_[0][1] = r0c1; matrix3_[0][2] = r0c2; matrix3_[0][3] = r0c3;
			matrix3_[1][0] = r1c0; matrix3_[1][1] = r1c1; matrix3_[1][2] = r1c2; matrix3_[1][3] = r1c3;
			matrix3_[2][0] = r2c0; matrix3_[2][1] = r2c1; matrix3_[2][2] = r2c2; matrix3_[2][3] = r2c3;
		}

	}

	//------------------------------------------------------------------------------//
	//																				//
	//									Matrix4										//
	//																				//
	//------------------------------------------------------------------------------//

	public class Matrix4 {

		private float[][] matrix4_ = new float[4][];

		public float[][] rowCol { get { return matrix4_; } set { matrix4_ = value; } }

		public float[] row0 { get { return matrix4_[0]; } set { matrix4_[0] = value; } }
		public float[] row1 { get { return matrix4_[1]; } set { matrix4_[1] = value; } }
		public float[] row2 { get { return matrix4_[2]; } set { matrix4_[2] = value; } }
		public float[] row3 { get { return matrix4_[3]; } set { matrix4_[3] = value; } }

		public float[] col0 {
			get { return new float[4] {row0[0], row1[0], row2[0], row3[0]}; }
			set { row0[0] = value[0]; row1[0] = value[1]; row2[0] = value[2]; row3[0] = value[3]; }
		}
		public float[] col1 {
			get { return new float[4] {row0[1], row1[1], row2[1], row3[1]}; }
			set { row0[1] = value[0]; row1[1] = value[1]; row2[1] = value[2]; row3[1] = value[3]; }
		}
		public float[] col2 {
			get { return new float[4] {row0[2], row1[2], row2[2], row3[2]}; }
			set { row0[2] = value[0]; row1[2] = value[1]; row2[2] = value[2]; row3[2] = value[3]; }
		}
		public float[] col3 {
			get { return new float[4] {row0[3], row1[3], row2[3], row3[3]}; }
			set { row0[3] = value[0]; row1[3] = value[1]; row2[3] = value[2]; row3[3] = value[3]; }
		}



		// CONSTRUCTORS //

		public Matrix4() {
			row0 = new float[4] {0,0,0,0};
			row1 = new float[4] {0,0,0,0};
			row2 = new float[4] {0,0,0,0};
			row3 = new float[4] {0,0,0,0};
		}

		public Matrix4(float[] r0, float[] r1, float[] r2, float[] r3) {
			row0 = r0;
			row1 = r1;
			row2 = r2;
			row3 = r3;
		}

		public Matrix4(float[] c0, float[] c1, float[] c2, float[] c3, bool isColumn) {
			col0 = c0;
			col1 = c1;
			col2 = c2;
			col3 = c3;
		}

		public Matrix4(float r0c0, float r0c1, float r0c2, float r0c3,
					   float r1c0, float r1c1, float r1c2, float r1c3,
					   float r2c0, float r2c1, float r2c2, float r2c3,
					   float r3c0, float r3c1, float r3c2, float r3c3) {
			matrix4_[0][0] = r0c0; matrix4_[0][1] = r0c1; matrix4_[0][2] = r0c2; matrix4_[0][3] = r0c3;
			matrix4_[1][0] = r1c0; matrix4_[1][1] = r1c1; matrix4_[1][2] = r1c2; matrix4_[1][3] = r1c3;
			matrix4_[2][0] = r2c0; matrix4_[2][1] = r2c1; matrix4_[2][2] = r2c2; matrix4_[2][3] = r2c3;
			matrix4_[3][0] = r3c0; matrix4_[3][1] = r3c1; matrix4_[3][2] = r3c2; matrix4_[3][3] = r3c3;
		}

	}

	//------------------------------------------------------------------------------//
	//																				//
	//									Quaternion									//
	//																				//
	//------------------------------------------------------------------------------//

	public class Quaternion {

		private float scalar_;
		private Mathd.Vector3 vector_;

		public float scalar { get { return scalar_; } set { scalar_ = value; } }
		public float w		{ get { return scalar_; } set { scalar_ = value; } }

		public Mathd.Vector3 vector { get { return vector_;   } set { vector_   = value; } }
		public Mathd.Vector3 xyz	{ get { return vector_;   } set { vector_   = value; } } 
		public float 		 x 		{ get { return vector_.x; } set { vector_.x = value; } }
		public float 		 y 		{ get { return vector_.y; } set { vector_.y = value; } }
		public float 		 z 		{ get { return vector_.z; } set { vector_.z = value; } }



		// CONSRUCTORS //

		public Quaternion(float w, float x, float y, float z) {
			scalar_   = w;
			vector_.x = x;
			vector_.y = y;
			vector_.z = z;
		}

		public Quaternion(float w, Mathd.Vector3 xyz) {
			scalar_ = w;
			vector_ = xyz;
		}



		// ARETHMETIC OPERATIONS //

		// Add
		static public Mathd.Quaternion operator +(Mathd.Quaternion lhs, Mathd.Quaternion rhs) {
			return new Mathd.Quaternion (lhs.scalar + rhs.scalar, lhs.vector + rhs.vector);
		}

		// Subtract
		static public Mathd.Quaternion operator -(Mathd.Quaternion lhs, Mathd.Quaternion rhs) {
			return new Mathd.Quaternion (lhs.scalar - rhs.scalar, lhs.vector - rhs.vector);
		}

		// Multiply by scalar
		static public Mathd.Quaternion operator *(Mathd.Quaternion quat, float scalar) {
			return new Quaternion(quat.scalar * scalar, quat.vector * scalar);
		}

		// Multiply
		// Equation reference from: http://uk.mathworks.com/help/aeroblks/quaternionmultiplication.html
		static public Mathd.Quaternion operator *(Mathd.Quaternion lhs, Mathd.Quaternion rhs) {
			float newW = (lhs.w * rhs.w) - (lhs.x * rhs.x) - (lhs.y * rhs.y) - (lhs.z * rhs.z);
			float newX = (lhs.w * rhs.x) - (lhs.x * rhs.w) - (lhs.y * rhs.z) - (lhs.z * rhs.y);
			float newY = (lhs.w * rhs.y) - (lhs.x * rhs.z) - (lhs.y * rhs.w) - (lhs.z * rhs.x);
			float newZ = (lhs.w * rhs.z) - (lhs.x * rhs.y) - (lhs.y * rhs.x) - (lhs.z * rhs.w);

			return new Quaternion(newW, newX, newY, newZ);
		}
		
		// Divide
		// Equation referenced from: http://uk.mathworks.com/help/aeroblks/quaterniondivision.html
		static public Mathd.Quaternion operator /(Mathd.Quaternion lhs, Mathd.Quaternion rhs) {
			float divisor = lhs.magnitude;

			float newW = ( (lhs.w * rhs.w) + (lhs.x * rhs.x) + (lhs.y * rhs.y) + (lhs.z + rhs.z) ) / divisor;
			float newX = ( (lhs.w * rhs.x) + (lhs.x * rhs.w) + (lhs.y * rhs.z) + (lhs.z + rhs.y) ) / divisor;
			float newY = ( (lhs.w * rhs.y) + (lhs.x * rhs.z) + (lhs.y * rhs.w) + (lhs.z + rhs.x) ) / divisor;
			float newZ = ( (lhs.w * rhs.z) + (lhs.x * rhs.y) + (lhs.y * rhs.x) + (lhs.z + rhs.w) ) / divisor;

			return new Mathd.Quaternion(newW, newX, newY, newZ);
		}



		// ATTRIBUTES AND PRODUCTS //

		// Equation references: http://mathworld.wolfram.com/Quaternion.html

		// Magnitude a.k.a. Norm
		public float magnitude {
			get { return (float) Math.Sqrt( (scalar_ * scalar_) + (vector_.x * vector_.x) + (vector_.y * vector_.y) + (vector_.z * vector_.z) ); }
		}


		// Normalise
		// Equation referenced from: http://uk.mathworks.com/help/aeroblks/quaternionnormalize.html
		public Mathd.Quaternion normalised {
			get { 
				float this_magnitude = this.magnitude;

				float newW = scalar_   / this_magnitude;
				float newX = vector_.x / this_magnitude;
				float newY = vector_.y / this_magnitude;
				float newZ = vector_.z / this_magnitude;

				return new Mathd.Quaternion(newW, newX, newY, newZ);
			}
		}

		// Conjugate
		// Explanation of conjugation: http://math.stackexchange.com/questions/234825/what-exactly-does-conjugation-mean
		public Mathd.Quaternion conjugate {
			get {
				return new Mathd.Quaternion(scalar_, -vector_.x, -vector_.y, -vector.z);
			}
		}

		static public float DotProduct(Mathd.Quaternion lhs, Mathd.Quaternion rhs) {
			return 1;
		}

		static public Mathd.Quaternion CrossProduct(Mathd.Quaternion lhs, Mathd.Quaternion rhs) {
			return new Mathd.Quaternion(0, Mathd.Vector3.zero);
		}

	}

	//------------------------------------------------------------------------------//
	//																				//
	//								Dual Quaternion									//
	//																				//
	//------------------------------------------------------------------------------//

	public class DualQuaternion {

		private Mathd.Quaternion real_;
		private Mathd.Quaternion dual_;

		public Mathd.Quaternion real { get { return real_; } set { real_ = value; } }
		public Mathd.Quaternion dual { get { return dual_; } set { dual_ = value; } }



		// CONSTRUCTORS //

		DualQuaternion () {
			real = new Quaternion(0,0,0,1);
			dual = new Quaternion(0,0,0,0);
		}

		DualQuaternion (Quaternion real_part, Quaternion dual_part) {
			real = real_part * (1 / real_part.magnitude); // TODO Normalised needed?
			dual = dual_part;
		}

		DualQuaternion (float real_w, float real_x, float real_y, float real_z,
						float dual_w, float dual_x, float dual_y, float dual_z) {
			real = new Mathd.Quaternion(real_x, real_y, real_z, real_w);
			dual = new Mathd.Quaternion(dual_x, dual_y, dual_z, dual_w);
		}



		// ARETHMETIC OPERATIONS //

		// Addition
		static public DualQuaternion operator +(DualQuaternion lhs, DualQuaternion rhs) {
			return new DualQuaternion(lhs.real + rhs.real, lhs.dual + rhs.dual);
		}
		
		// Scalar Multiplication
		static public DualQuaternion operator *(DualQuaternion dualQuat, float scalar) {
			return new DualQuaternion(dualQuat.real * scalar, dualQuat.dual * scalar);
		}

		// Multiplication
		static public DualQuaternion operator *(DualQuaternion lhs, DualQuaternion rhs) {
			Quaternion realMultiplied = lhs.real * rhs.real;
			Quaternion dualMultiplied = (lhs.real * rhs.dual) + (lhs.dual * rhs.real);
			return new DualQuaternion(realMultiplied, dualMultiplied);
		}



		// ATTRIBUTES AND PRODUCTS //

		// Magnitude TODO Check
		public float magnitude {
			get {
				return (float) Math.Sqrt(Mathd.Quaternion.DotProduct(this.real, this.real));
			}
		}
		
		// Normalise
		public DualQuaternion normalise {
			get {
				float this_magnitude = this.magnitude;
				return new DualQuaternion(real * (1 / this_magnitude), dual * (1 / this_magnitude));
			}
		}

		/*
		// Conjugate a.k.a. Inverse - NO ITS NOT TODO
		static public DualQuaternion Conjugate(DualQuaternion dualQuat) {
			Quaternion realConjugate = Quaternion.Inverse(dualQuat.real);
			Quaternion dualConjugate = Quaternion.Inverse(dualQuat.dual);
			return new DualQuaternion(realConjugate, dualConjugate);
		}
		*/

	}

}
