using UnityEngine;
using System.Collections;

public class BreakerControl : MonoBehaviour {

	public Transform[] path;

	public float speed = 0.1f;

	private int index;
	private Transform target;

	void Start () {
		index = 0;
		target = path[index];
	}
	
	void Update () {
		Vector3 move = target.transform.position - transform.position;
		move.Normalize();
		transform.Translate(move * speed, Space.World);
		if ((target.transform.position - transform.position).magnitude <= speed) {
			// Next target
			index = (index+1) % path.Length;
			target = path[index];
		}
	}
}
