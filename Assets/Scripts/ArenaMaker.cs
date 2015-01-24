using UnityEngine;
using System.Collections;

public class ArenaMaker : MonoBehaviour {

	void Start () {
		// Clone arena
		GameObject clone = GameObject.Instantiate(gameObject) as GameObject;

		// Reflect it along x
		Vector3 scale = clone.transform.localScale;
		scale.x = -scale.x;
		clone.transform.localScale = scale;

		// Remove this script from the clone
		Destroy(clone.GetComponent<ArenaMaker>());
	}

}
