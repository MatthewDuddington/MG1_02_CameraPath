// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

public class Mathd {

	public class Vector3 {

		private float x_;
		private float y_;
		private float z_;

		public float x { get { return x_; } set { x_ = value; } }
		public float y { get { return y_; } set { y_ = value; } }
		public float z { get { return z_; } set { z_ = value; } }

		public enum Vector3Types { zero, one, right, left, up, down, forward, backward }

		// Constructors
		Vector3 (float x, float y, float z) {
			x_ = x;
			y_ = y;
			z_ = z;
		}

		Vector3 (Vector3Types type) {
			switch (type) {
				case Vector3Types.zero:
				{
					x_ = 0;
					y_ = 0;
					z_ = 0;
					break;
				}
				case Vector3Types.one:
				{
					x_ = 1;
					y_ = 1;
					z_ = 1;
					break;
				}
				case Vector3Types.right:
				{
					x_ = 1;
					y_ = 0;
					z_ = 0;
					break;
				}
				case Vector3Types.left:
				{
					x_ = -1;
					y_ = 0;
					z_ = 0;
					break;
				}
				case Vector3Types.up:
				{
					x_ = 0;
					y_ = 1;
					z_ = 0;
					break;
				}
				case Vector3Types.down:
				{
					x_ = 0;
					y_ = -1;
					z_ = 0;
					break;
				}
				case Vector3Types.forward:
				{
					x_ = 0;
					y_ = 0;
					z_ = 1;
					break;
				}
				case Vector3Types.backward:
				{
					x_ = 0;
					y_ = 0;
					z_ = -1;
					break;
				}
			}
		}



		// Arethmetic operations
		// Addition
		static public Mathd.Vector3 operator +(Mathd.Vector3 lhs, Mathd.Vector3 rhs) {
			float newX = lhs.x + rhs.x;
			float newY = lhs.y + rhs.y;
			float newZ = lhs.z + rhs.z;
			return new Mathd.Vector3(newX, newY, newZ);
		}

		// Subtraction
		static public Mathd.Vector3 operator -(Mathd.Vector3 lhs, Mathd.Vector3 rhs) {
			float newX = lhs.x - rhs.x;
			float newY = lhs.y - rhs.y;
			float newZ = lhs.z - rhs.z;
			return new Mathd.Vector3(newX, newY, newZ);
		}

		// Multiply
		static public Mathd.Vector3 operator *(Mathd.Vector3 lhs, Mathd.Vector3 rhs) {
			float newX = lhs.x * rhs.x;
			float newY = lhs.y * rhs.y;
			float newZ = lhs.z * rhs.z;
			return new Mathd.Vector3(newX, newY, newZ);
		}

		// Multiply by scalar
		static public Mathd.Vector3 operator *(Mathd.Vector3 lhs, float rhs) {
			float newX = lhs.x * rhs;
			float newY = lhs.y * rhs;
			float newZ = lhs.z * rhs;
			return new Mathd.Vector3(newX, newY, newZ);
		}

		// Divide
		static public Mathd.Vector3 operator /(Mathd.Vector3 lhs, Mathd.Vector3 rhs) {
			float newX = lhs.x / rhs.x;
			float newY = lhs.y / rhs.y;
			float newZ = lhs.z / rhs.z;
			return new Mathd.Vector3(newX, newY, newZ);
		}


	}

	public class Quaternion {

		private float w_ = 1;
		private Mathd.Vector3 xyz_ = new Mathd.Vector3(0,0,0);

		public float w { get { return w_; } set { w_ = value; } }
		public Mathd.Vector3 xyz { get { return xyz_; } set { xyz_ = value; } }
		public float x { get { return xyz_.x; } set { xyz_.x = value; } }
		public float y { get { return xyz_.y; } set { xyz_.y = value; } }
		public float z { get { return xyz_.z; } set { xyz_.z = value; } }



		Quaternion() {

		}

	}

	public class DualQuaternion {



	}

}
