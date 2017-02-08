
namespace Mathd {

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

		public Matrix3(float r0c0, float r0c1, float r0c2,
					   float r1c0, float r1c1, float r1c2,
					   float r2c0, float r2c1, float r2c2) {
			matrix3_[0][0] = r0c0; matrix3_[0][1] = r0c1; matrix3_[0][2] = r0c2;
			matrix3_[1][0] = r1c0; matrix3_[1][1] = r1c1; matrix3_[1][2] = r1c2;
			matrix3_[2][0] = r2c0; matrix3_[2][1] = r2c1; matrix3_[2][2] = r2c2;
		}

		public static Matrix3 zero {
			get {
				return new Matrix3(0,0,0,
								   0,0,0,
								   0,0,0);
			}
		}
		public static Matrix3 intentity {
			get {
				return new Matrix3(1,0,0,
								   0,1,0,
								   0,0,1);
			}
		}

	}



	//------------------------------------------------------------------------------//
	//																				//
	//									Matrix4										//
	//																				//
	//------------------------------------------------------------------------------//

	public class Matrix4 {

		private float[][] matrix4_ = new float[4][];
//		private Mathd.Vector4[] matrix4_ = new Vector4[4];

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

		public static Matrix4 zero {
			get {
				return new Matrix4(0,0,0,0,
								   0,0,0,0,
								   0,0,0,0,
								   0,0,0,0);
			}
		}

		public static Matrix4 intentity {
			get {
				return new Matrix4(1,0,0,0,
								   0,1,0,0,
								   0,0,1,0,
								   0,0,0,1);
			}
		}



		// ARETHMETIC OPERATIONS //

		// Add
//		static public Matrix4 operator* (Mathd.Matrix4 lhs, Mathd.Matrix4 rhs) {
//
//		}

		// Subtract
//		static public Matrix4 operator* (Mathd.Matrix4 lhs, Mathd.Matrix4 rhs) {
//
//		}

		// Multiply by Scalar
//		static public Matrix4 operator* (Mathd.Matrix4 lhs, float scalar) {
//
//		}

		// Multiply by Vector4
//		static public Matrix4 operator* (Mathd.Matrix4 lhs, Mathd.Vector4 rhs) {
//
//		}

		// Multiply by Matrix4
//		static public Matrix4 operator* (Mathd.Matrix4 lhs, Mathd.Matrix4 rhs) {
//
//		}
		
	}



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

		public Vector3 () {
			x_ = 0;
			y_ = 0;
			z_ = 0;
		}

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
		public Vector3 (UnityEngine.Vector3 vec3) {
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

		public UnityEngine.Vector3 toUnityVec3 {
			get { 
				return new UnityEngine.Vector3(x, y, z);
			}
		}



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
		static public Mathd.Vector3 operator *(float scalar, Mathd.Vector3 vec3) {
			return vec3 * scalar;
		}
		static public Mathd.Vector3 operator /(Mathd.Vector3 vec3, float scalar) {
			return vec3 * (1 / scalar);
		}



		// ATTRIBUTES AND PRODUCTS //

		// Magnitude a.k.a. Norm
		public float magnitude { 
			// Inefficient sqrt version
			get { return (float) System.Math.Sqrt( (x * x) + (y * y) + (z * z) ); } 
		}

		// Normalised a.k.a. Unit length
		public Mathd.Vector3 normalised {
			// Inefficient divide version
			get { 
				float this_magnitude = this.magnitude; 
				return new Mathd.Vector3( x / this_magnitude, y / this_magnitude, z / this_magnitude );
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

			float newX = ( roatationMatrix.col0[0] + roatationMatrix.col0[1] + roatationMatrix.col0[2] ) * x;
			float newY = ( roatationMatrix.col1[0] + roatationMatrix.col1[1] + roatationMatrix.col1[2] ) * y;
			float newZ = ( roatationMatrix.col2[0] + roatationMatrix.col2[1] + roatationMatrix.col2[2] ) * x;

			return new Mathd.Vector3(newX, newY, newZ);
		}

		// Rotates a Vector3 around axis X by degrees (Left handed)
		public Mathd.Vector3 RotateX(float degrees) {
			float sinTheta = (float) System.Math.Sin(degrees);
			float cosTheta = (float) System.Math.Cos(degrees);

			float newY = (y * cosTheta) - (z * sinTheta);
			float newZ = (y * sinTheta) + (z * cosTheta);

			return new Mathd.Vector3(x, newY, newZ);
		}

		// Rotates a Vector3 around axis Y by degrees (Left handed)
		public Mathd.Vector3 RotateY(float degrees) {
			float sinTheta = (float) System.Math.Sin(degrees);
			float cosTheta = (float) System.Math.Cos(degrees);

			float newX =   (x * cosTheta) + (z * sinTheta);
			float newZ = - (x * sinTheta) + (z * cosTheta);

			return new Mathd.Vector3(newX, y, newZ);
		}

		// Rotates a Vector3 around axis Z by degrees (Left handed)
		public Mathd.Vector3 RotateZ(float degrees) {
			float sinTheta = (float) System.Math.Sin(degrees);
			float cosTheta = (float) System.Math.Cos(degrees);

			float newX = (x * cosTheta) - (y * sinTheta);
			float newY = (x * sinTheta) + (y * cosTheta);

			return new Mathd.Vector3(newX, newY, z);
		}

		// Dot Product
		// The angle between two vectors
		// If the same vector is used both sides = magnitude of the vector, squared
		static public float DotProduct(Mathd.Vector3 lhs, Mathd.Vector3 rhs) {
		  return ( (lhs.x * rhs.x) + (lhs.y * rhs.y) + (lhs.z * rhs.z) );
		}

		// Cross Product (Left handed)
		// Normal to the plane defined by the two vectors
		// Has length = to the area of the parallelogram formed by the two vectors
		static public Mathd.Vector3 CrossProduct(Mathd.Vector3 lhs, Mathd.Vector3 rhs) {
			return new Mathd.Vector3( (lhs.y * rhs.z) - (lhs.z * rhs.y),
									  (lhs.z * rhs.x) - (lhs.x * rhs.z),
									  (lhs.x * rhs.y) - (lhs.y * rhs.x)  );
		}

		// Distance between two points
		static public float Distance(Mathd.Vector3 start, Mathd.Vector3 end) {
			return new Mathd.Vector3(end - start).magnitude;
		}

		// Linear Interpolation between two points
		// Implementation adapted from: http://www.blueraja.com/blog/404/how-to-use-unity-3ds-linear-interpolation-vector3-lerp-correctly#comment-23334
		static public Mathd.Vector3 Lerp(Mathd.Vector3 start, Mathd.Vector3 end, float t) {
			// Ensure requested distance along interpolation is between 0 and 1
			t = UnityEngine.Mathf.Clamp01(t);
			// Method guarantees the return will equal the end position when t = 1
			return new Mathd.Vector3((1 - t) * start) + (t * end);
		}

	}



	//------------------------------------------------------------------------------//
	//																				//
	//									Vector4										//
	//																				//
	//------------------------------------------------------------------------------//

	public class Vector4 {

		private float w_;
		private float x_;
		private float y_;
		private float z_;

		public float w { get { return w_; } set { w_ = value; } }
		public float x { get { return x_; } set { x_ = value; } }
		public float y { get { return y_; } set { y_ = value; } }
		public float z { get { return z_; } set { z_ = value; } }



		// CONSTRUCTORS //

		public Vector4 () {
			w_ = 0;
			x_ = 0;
			y_ = 0;
			z_ = 0;
		}

		public Vector4 (float w, float x, float y, float z) {
			w_ = w;
			x_ = x;
			y_ = y;
			z_ = z;
		}

		public Vector4 (Mathd.Vector4 vec4) {
			w_ = vec4.w;
			x_ = vec4.x;
			y_ = vec4.y;
			z_ = vec4.z;
		}
		public Vector4 (UnityEngine.Vector4 vec4) {
			w_ = vec4.w;
			x_ = vec4.x;
			y_ = vec4.y;
			z_ = vec4.z;
		}

		static public Mathd.Vector4 zero	 { get { return new Mathd.Vector4( 0,  0,  0,  0); } }
		static public Mathd.Vector4 one		 { get { return new Mathd.Vector4( 1,  1,  1,  1); } }
		static public Mathd.Vector4 wPos1	 { get { return new Mathd.Vector4( 1,  0,  0,  0); } }
		static public Mathd.Vector4 wNeg1	 { get { return new Mathd.Vector4(-1,  0,  0,  0); } }
		static public Mathd.Vector4 right	 { get { return new Mathd.Vector4( 0,  1,  0,  0); } }
		static public Mathd.Vector4 left	 { get { return new Mathd.Vector4( 0, -1,  0,  0); } }
		static public Mathd.Vector4 up		 { get { return new Mathd.Vector4( 0,  0,  1,  0); } }
		static public Mathd.Vector4 down 	 { get { return new Mathd.Vector4( 0,  0, -1,  0); } }
		static public Mathd.Vector4 forward  { get { return new Mathd.Vector4( 0,  0,  0,  1); } }
		static public Mathd.Vector4 backward { get { return new Mathd.Vector4( 0,  0,  0, -1); } }

		public UnityEngine.Vector4 toUnityVec4 {
			get { 
				return new UnityEngine.Vector4(x, y, z, w);
			}
		}



		// ARETHMETIC OPERATIONS //

		// Add
		static public Mathd.Vector4 operator +(Mathd.Vector4 lhs, Mathd.Vector4 rhs) {
			float newW = lhs.w + rhs.w;
			float newX = lhs.x + rhs.x;
			float newY = lhs.y + rhs.y;
			float newZ = lhs.z + rhs.z;
			return new Mathd.Vector4(newW, newX, newY, newZ);
		}

		// Subtract
		static public Mathd.Vector4 operator -(Mathd.Vector4 lhs, Mathd.Vector4 rhs) {
			float newW = lhs.w - rhs.w;
			float newX = lhs.x - rhs.x;
			float newY = lhs.y - rhs.y;
			float newZ = lhs.z - rhs.z;
			return new Mathd.Vector4(newW, newX, newY, newZ);
		}

		// Multiply by scalar
		static public Mathd.Vector4 operator *(Mathd.Vector4 vec4, float scalar) {
			float newW = vec4.w * scalar;
			float newX = vec4.x * scalar;
			float newY = vec4.y * scalar;
			float newZ = vec4.z * scalar;
			return new Mathd.Vector4(newW, newX, newY, newZ);
		}
		static public Mathd.Vector4 operator *(float scalar, Mathd.Vector4 vec4) {
			return vec4 * scalar;
		}
		static public Mathd.Vector4 operator /(Mathd.Vector4 vec4, float scalar) {
			return vec4 * (1 / scalar);
		}



		// ATTRIBUTES AND PRODUCTS //

		// Magnitude a.k.a. Norm
		public float magnitude { 
			// Inefficient sqrt version
			get { return (float) System.Math.Sqrt( (w * w) + (x * x) + (y * y) + (z * z) ); } 
		}

		// Normalised a.k.a. Unit length
		public Mathd.Vector4 normalised {
			// Inefficient divide version
			get { 
				float this_magnitude = this.magnitude; 
				return new Mathd.Vector4( w / this_magnitude, x / this_magnitude, y / this_magnitude, z / this_magnitude );
			}
		}

		// Dot Product
		// The angle between two vectors
		// If the same vector is used both sides = magnitude of the vector, squared
		static public float DotProduct(Mathd.Vector4 lhs, Mathd.Vector4 rhs) {
		  return ( (lhs.w * rhs.w) + (lhs.x * rhs.x) + (lhs.y * rhs.y) + (lhs.z * rhs.z) );
		}

		// Cross Product (Left handed)
		// Normal to the plane defined by the two vectors
		// Has length = to the area of the parallelogram formed by the two vectors
		static public Mathd.Vector3 CrossProduct(Mathd.Vector3 lhs, Mathd.Vector3 rhs) {
			return new Mathd.Vector3( (lhs.y * rhs.z) - (lhs.z * rhs.y),
									  (lhs.z * rhs.x) - (lhs.x * rhs.z),
									  (lhs.x * rhs.y) - (lhs.y * rhs.x)  );
		}

		// Distance between two points
		static public float Distance(Mathd.Vector3 start, Mathd.Vector3 end) {
			return new Mathd.Vector3(end - start).magnitude;
		}

		// Linear Interpolation between two points
		// Implementation adapted from: http://www.blueraja.com/blog/404/how-to-use-unity-3ds-linear-interpolation-vector3-lerp-correctly#comment-23334
		static public Mathd.Vector3 Lerp(Mathd.Vector3 start, Mathd.Vector3 end, float t) {
			// Ensure requested distance along interpolation is between 0 and 1
			t = UnityEngine.Mathf.Clamp01(t);
			// Method guarantees the return will equal the end position when t = 1
			return new Mathd.Vector3((1 - t) * start) + (t * end);
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
			vector_ = new Mathd.Vector3();

			scalar_   = w;
			vector_.x = x;
			vector_.y = y;
			vector_.z = z;
		}

		public Quaternion(float w, Mathd.Vector3 xyz) {
			scalar_ = w;
			vector_ = xyz;
		}

		public Quaternion(Mathd.Quaternion quat) {
			vector_ = new Mathd.Vector3();

			scalar_   = quat.w;
			vector_.x = quat.x;
			vector_.y = quat.y;
			vector_.z = quat.z;
		}
		public Quaternion(UnityEngine.Quaternion quat) {
			vector_ = new Mathd.Vector3();

			scalar_   = quat.w;
			vector_.x = quat.x;
			vector_.y = quat.y;
			vector_.z = quat.z;
		}

		static public Quaternion zero { get { return new Quaternion(0,0,0,0); } }
		static public Quaternion identity { get { return new Quaternion(1,0,0,0); } }

		public  UnityEngine.Quaternion toUnityQuat {
			get { return new UnityEngine.Quaternion(x, y, z, w); }
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
		static public Mathd.Quaternion operator *(float scalar, Mathd.Quaternion quat) {
			return quat * scalar;
		}
		static public Mathd.Quaternion operator /(Mathd.Quaternion quat, float scalar) {
			return quat * (1 / scalar);
		}

		// Multiple a.k.a. Quaternion Product
		// Note: Non-commutative!
		static public Mathd.Quaternion operator *(Mathd.Quaternion lhs, Mathd.Quaternion rhs) {
			/*/ Toggle

			float newScalarPart = (lhs.scalar * rhs.scalar) - (Mathd.Vector3.DotProduct(lhs.vector, rhs.vector));
			Mathd.Vector3 newVectorPart = new Mathd.Vector3((lhs.scalar * rhs.vector) + (rhs.scalar * lhs.vector) + Mathd.Vector3.CrossProduct(lhs.vector, rhs.vector));

			return new Quaternion(newScalarPart, newVectorPart);

			/*/ 

			// Equation reference from: http://uk.mathworks.com/help/aeroblks/quaternionmultiplication.html
			float newW = (lhs.w * rhs.w) - (lhs.x * rhs.x) - (lhs.y * rhs.y) - (lhs.z * rhs.z);
			float newX = (lhs.w * rhs.x) - (lhs.x * rhs.w) - (lhs.y * rhs.z) - (lhs.z * rhs.y);
			float newY = (lhs.w * rhs.y) - (lhs.x * rhs.z) - (lhs.y * rhs.w) - (lhs.z * rhs.x);
			float newZ = (lhs.w * rhs.z) - (lhs.x * rhs.y) - (lhs.y * rhs.x) - (lhs.z * rhs.w);

			return new Mathd.Quaternion(newW, newX, newY, newZ);

			//*/
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

		// Magnitude a.k.a. Norm
		public float magnitude {
			get { 
				return (float) System.Math.Sqrt( Mathd.Quaternion.DotProduct(this, this) );
				// (float) Math.Sqrt( (scalar_ * scalar_) + (vector_.x * vector_.x) + (vector_.y * vector_.y) + (vector_.z * vector_.z) );
			}
		}

		// Normalise
		// Equation referenced from: http://uk.mathworks.com/help/aeroblks/quaternionnormalize.html
		public Mathd.Quaternion normalised {
			get { 
				float this_magnitude = this.magnitude;

				if (this_magnitude == 0) { return Mathd.Quaternion.identity; }

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

		// Invert
		// Multiplicative inverse 
		public Mathd.Quaternion invert {
			get {
				float this_DotProduct = Mathd.Quaternion.DotProduct(this, this);
				return new Mathd.Quaternion( scalar / this_DotProduct, -1f * (vector * (1 / this_DotProduct)) );
			}
		}

		// Dot Product
		// The angle between two quaternions
		// If the same quaternion is used both sides = magnitude of the quaternion, squared
		static public float DotProduct(Mathd.Quaternion lhs, Mathd.Quaternion rhs) {
			return (lhs.scalar * rhs.scalar) + Mathd.Vector3.DotProduct(lhs.vector, rhs.vector);
			// (lhs.w * rhs.w) + (lhs.x * rhs.x) + (lhs.y * rhs.y) + (lhs.z + rhs.z);
		}

		// Cross Product (Left handed)
		// Note: Not the same as the quaternion product
		static public Mathd.Quaternion CrossProduct(Mathd.Quaternion lhs, Mathd.Quaternion rhs) {
			return new Mathd.Quaternion(0, Mathd.Vector3.CrossProduct(lhs.vector, rhs.vector));
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

		public DualQuaternion () {
			real = new Quaternion(1,0,0,0);
			dual = new Quaternion(0,0,0,0);
		}

		public DualQuaternion (Quaternion real_part, Quaternion dual_part) {
			// real = real_part * (1 / real_part.magnitude);
			real = real_part.normalised;
			dual = dual_part;
		}

		public DualQuaternion (float real_w, float real_x, float real_y, float real_z,
							   float dual_w, float dual_x, float dual_y, float dual_z) {
			real = new Mathd.Quaternion(real_x, real_y, real_z, real_w).normalised;
			dual = new Mathd.Quaternion(dual_x, dual_y, dual_z, dual_w);
		}

		// This is the one to use for building a transform
		// Based on example from: http://wscg.zcu.cz/wscg2012/short/A29-full.pdf
		public DualQuaternion (Mathd.Vector3 position, Mathd.Quaternion rotation) {
			real = rotation.normalised;
			dual = 0.5f * (new Mathd.Quaternion(0, position) * real);
		}
//		public DualQuaternion (UnityEngine.Vector3 position, UnityEngine.Quaternion rotation) {
//			Mathd.Vector3 mathdPos = new Mathd.Vector3(position.x, position.y, position.z);
//			Mathd.Quaternion mathdQuat = new Mathd.Quaternion(rotation.w, rotation.x, rotation.y, rotation.z);
//		}



		// ARETHMETIC OPERATIONS //

		// Addition
		static public Mathd.DualQuaternion operator +(Mathd.DualQuaternion lhs, Mathd.DualQuaternion rhs) {
			Mathd.Quaternion newRealPart = lhs.real + rhs.real;
			Mathd.Quaternion newDualPart = lhs.dual + rhs.dual;
			return new Mathd.DualQuaternion(newRealPart, newDualPart);
		}
		
		// Scalar Multiplication
		static public Mathd.DualQuaternion operator *(Mathd.DualQuaternion dualQuat, float scalar) {
			Mathd.Quaternion newRealPart = dualQuat.real * scalar;
			Mathd.Quaternion newDualPart = dualQuat.dual * scalar;
			return new Mathd.DualQuaternion(newRealPart, newDualPart);
		}
		static public Mathd.DualQuaternion operator *(float scalar, Mathd.DualQuaternion dualQuat) {
			return dualQuat * scalar;
		}

		// Multiplication
		// (lhs and rhs need to be oposite way around for left handed ?)
		static public Mathd.DualQuaternion operator *(Mathd.DualQuaternion lhs, Mathd.DualQuaternion rhs) {
			Mathd.Quaternion newRealPart =  rhs.real * lhs.real;
			Mathd.Quaternion newDualPart = (rhs.real * lhs.dual) + (rhs.dual * lhs.real);
			return new Mathd.DualQuaternion(newRealPart, newDualPart);
		}



		// ATTRIBUTES AND PRODUCTS //

		// Magnitude
		public float magnitude {
			get {
				float this_real_magnitude = this.real.magnitude;
				return this_real_magnitude + ( Mathd.Quaternion.DotProduct(this.real, this.dual) / this_real_magnitude );
//				return this * this.conjugate;  // This would also work?
			}
		}
		
		// Normalise
		public Mathd.DualQuaternion normalise {
			get {
				float this_magnitude = this.magnitude;
				Mathd.Quaternion newRealPart = this.real / this_magnitude;
				Mathd.Quaternion newDualPart = this.dual / this_magnitude;
				return new Mathd.DualQuaternion(newRealPart, newDualPart);

//				Mathd.Quaternion newReal = this.real / this_magnitude;
//				Mathd.Quaternion newDuel = new Mathd.Quaternion(this.real / this_magnitude,
			}
		}
		
		// Conjugate
		public Mathd.DualQuaternion conjugate {
			get {
				Mathd.Quaternion newRealPart = this.real.conjugate;
				Mathd.Quaternion newDualPart = this.dual.conjugate;
				return new Mathd.DualQuaternion(newRealPart, newDualPart);
			}
		}

//		// Conjugate 
//		static public DualQuaternion Conjugate(DualQuaternion dualQuat) {
//			Quaternion realConjugate = Quaternion.Inverse(dualQuat.real);
//			Quaternion dualConjugate = Quaternion.Inverse(dualQuat.dual);
//			return new DualQuaternion(realConjugate, dualConjugate);
//		}



		// TRANSFORM METHODS //

		public Mathd.Vector3 position {
			get { 
				Mathd.Quaternion transformQuaternion =  (2 * this.dual) * this.real.conjugate;
				return new Mathd.Vector3(transformQuaternion.xyz);
			}
		}

		public Mathd.Quaternion rotation {
			get { return real; }
		}

		// 
		public UnityEngine.Transform Transform( UnityEngine.Transform unityTransform,
												UnityEngine.Vector3 endPosition,
												UnityEngine.Quaternion endRotation ) {
			// Construct the dualquarternions from the transfrom values
			Mathd.DualQuaternion startTransformDualQuat = new Mathd.DualQuaternion(new Mathd.Vector3(unityTransform.position), new Mathd.Quaternion(unityTransform.rotation));
			Mathd.DualQuaternion endTransformDualQuat = new Mathd.DualQuaternion(new Mathd.Vector3(endPosition), new Mathd.Quaternion(endRotation));

			// Perform the transform
			Mathd.DualQuaternion resultingDualQuat = (endTransformDualQuat * startTransformDualQuat) * endTransformDualQuat.conjugate;

			// Extract transform values
			UnityEngine.Transform resultingTransform = new UnityEngine.GameObject().transform;
			resultingTransform.position = resultingDualQuat.position.toUnityVec3;
			resultingTransform.rotation = resultingDualQuat.rotation.toUnityQuat;

			return resultingTransform;
		}

	}

}
