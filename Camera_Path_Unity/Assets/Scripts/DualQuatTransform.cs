using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mathd;

public class DualQuatTransform : MonoBehaviour {

	public Transform start;
	public Transform end;
	public UnityEngine.Vector3 endRotationV3;

	private UnityEngine.Quaternion endRotation;
	
	void Start () {
		transform.position = start.position;
		endRotation = UnityEngine.Quaternion.Euler(endRotationV3);
		StartCoroutine(DelayTheMovement());
	}

	void LerpWithDualQuat (UnityEngine.Vector3 t_position, UnityEngine.Quaternion t_rotation) {
		// Translate Unity Vector3 position and Unity Quaternion rotation into Mathd Dual Quaternion.
		Mathd.DualQuaternion point = new Mathd.DualQuaternion(new Mathd.Vector3(transform.position), new Mathd.Quaternion(transform.rotation));

		// Setup a transform within another Dual Quaternion. This will be the 'portal'.

//		Mathd.Vector3 newPosition = new Mathd.Vector3(end.position);
//		Mathd.Quaternion newRotation = new Mathd.Quaternion(UnityEngine.Quaternion.Euler(new UnityEngine.Vector3(0,0,0)));
		Mathd.Vector3 newPosition = new Mathd.Vector3(t_position);
		Mathd.Quaternion newRotation = new Mathd.Quaternion(t_rotation);
		Mathd.DualQuaternion transformToApply = new Mathd.DualQuaternion(newPosition, newRotation);

		// Now perform the paralelle dual quaternion universe awesome sidestepping movement!!
		// Mathd.DualQuaternion step1 = (transformToApply * point);
		// Mathd.DualQuaternion step2 = transformToApply.conjugate;
		Mathd.DualQuaternion transformedPoint = (transformToApply * point) * transformToApply.conjugate;

		// Read back out from the warped point and convert into Unity Vector3 and Quaternion.
		transform.position = transformedPoint.position.toUnityVec3;
		transform.rotation = transformedPoint.rotation.toUnityQuat;
	}

	IEnumerator DelayTheMovement() {
		yield return new WaitForSeconds(3);
		LerpWithDualQuat(end.position, endRotation);
	}

}
