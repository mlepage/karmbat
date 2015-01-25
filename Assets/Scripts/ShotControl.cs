using UnityEngine;
using System.Collections;

public class ShotControl : MonoBehaviour {

	public float speed = 0.2f;

	void Start () {
	}
	
	void Update () {
		transform.Translate(Vector3.up * speed);
	}
}
