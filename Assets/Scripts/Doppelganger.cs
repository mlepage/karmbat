using UnityEngine;
using System.Collections;

public class Doppelganger : MonoBehaviour {

	public GameObject target;

	public bool updatePosition = true;
	public bool reflectX = true;
	public bool reflectY = true;

	public bool updateRotation = true;
	public int rotationOffset = 180;

	void LateUpdate () {
		UpdateDoppelganger();
	}

	public void UpdateDoppelganger () {
		if (target == null || target.Equals(null)) {
			Destroy(gameObject);
			return;
		}

		if (updatePosition) {
			Vector3 position = target.transform.position;
			if (reflectX) position.x = -position.x;
			if (reflectY) position.y = -position.y;
			transform.position = position;
		}

		if (updateRotation) {
			transform.rotation = Quaternion.Euler(0f, 0f, target.transform.rotation.eulerAngles.z + rotationOffset);
		}
	}
}
