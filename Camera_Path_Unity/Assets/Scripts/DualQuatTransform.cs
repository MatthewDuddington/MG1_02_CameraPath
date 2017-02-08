using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mathd;

public class DualQuatTransform : MonoBehaviour {

	// Start and end points for the transformation - set in the inspector
	public Transform start;
	public Transform end;
	// Desired rotation for the object after the transformation - set in the inspector
	public UnityEngine.Vector3 endRotationV3;
	// Tick this in the inspector to run the transform
	public bool runDualQuaternionMove = false;

	// Time coroutine should wait to give user a chance to observe the object resetting to the start position
	private float delayTime = 2f;

	void Start () {
		StartCoroutine(MovementLoop());
	}

	// Takes in a Unity Vector3 and Unity Quaternion (for ease of use with GameObject.Transform to avoid multiple conversions, for now)
	// TODO Doesnt yet work propperly: Translation is 2x the corrrect vector; Rotation causes a translation as well as a rotation.
	// TODO Not sure how to combine this with interpolation (how would we use t?), does it require SLERP plus somthing else, where to apply this?
	void MoveWithDualQuat (UnityEngine.Vector3 t_position, UnityEngine.Quaternion t_rotation) {
		// Translate Unity Vector3 position and Unity Quaternion rotation into Mathd Dual Quaternion.
		Mathd.DualQuaternion point = new Mathd.DualQuaternion(new Mathd.Vector3(transform.position), new Mathd.Quaternion(transform.rotation));

		// Setup a transform within another Dual Quaternion. This will be the 'portal'.
		Mathd.Vector3 newPosition = new Mathd.Vector3(t_position);
		Mathd.Quaternion newRotation = new Mathd.Quaternion(t_rotation);
		Mathd.DualQuaternion transformToApply = new Mathd.DualQuaternion(newPosition, newRotation);

		// Now perform the dual quaternion, awesome paralelle universe, movement!!
		// p' = qpq`
		// Where:
		// q  is the translation and rotation wrapped up in a dual quaternion
		// q` is the conjugate of q
		// p  is the transform of the point to transform by q
		// p' is the resulting transformation
		Mathd.DualQuaternion transformedPoint = (transformToApply * point) * transformToApply.conjugate;

		// Read back out from the transformed point and convert into Unity Vector3 and Quaternion.
		transform.position = transformedPoint.position.toUnityVec3;
		UnityEngine.MonoBehaviour.print("Returned position " + transformedPoint.position.toUnityVec3);
		transform.rotation = transformedPoint.rotation.toUnityQuat;
		UnityEngine.MonoBehaviour.print("Returned rotation " + transformedPoint.rotation.toUnityQuat.eulerAngles);
	}

	// Coroutine that provides delays to observe and react to the movement
	IEnumerator MovementLoop() {
		// Give time to observe result and change position of start, end and rotation
		// by waiting for interface boolian to be ticked 
		while (!runDualQuaternionMove) {
			yield return new WaitForFixedUpdate(); 
		}

		// Reset for new movement
		runDualQuaternionMove = false;
		transform.position = start.position;
		transform.rotation = UnityEngine.Quaternion.Euler(Mathd.Vector3.zero.toUnityVec3);
		// Store the converted the Vec3 interface input rotation into a quaternion for use with the movement function
		UnityEngine.Quaternion endRotation = UnityEngine.Quaternion.Euler(endRotationV3);

		// Give user feedback while there is a short wait
		StartCoroutine(MoveCountdown());
		yield return new WaitForSeconds(delayTime);
		MoveWithDualQuat(end.position, endRotation);

		// Begin fresh loop
		StartCoroutine(MovementLoop());
	}

	// Simple feedback countdown of movement
	IEnumerator MoveCountdown() {
		UnityEngine.MonoBehaviour.print("Moving in:");
		UnityEngine.MonoBehaviour.print("3...");
		yield return new WaitForSeconds(delayTime / 3f);
		UnityEngine.MonoBehaviour.print("2...");
		yield return new WaitForSeconds(delayTime / 3f);
		UnityEngine.MonoBehaviour.print("1...");
	}

}
