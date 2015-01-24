using UnityEngine;
using System.Collections;

public class TankControl : MonoBehaviour {

	public float speed = 0.1f;

	private GameObject turret;

	void Start () {
		// Assume first child is turret
		turret = transform.GetChild(0).gameObject;
	}
	
	void Update () {
		{
			// Control base with left stick
			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");
			Vector3 move = new Vector3(h, v, 0f);
			if (0f < move.magnitude) {
				// Rotate
				float rot = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.Euler(0f, 0f, rot - 90f);
				// Move
				transform.Translate(move * speed, Space.World);
			}
		}

		{
			// Control turret with right stick
			float h = Input.GetAxis("RightHorizontal");
			float v = Input.GetAxis("RightVertical");
			Vector3 move = new Vector3(h, v, 0f);
			if (0f < move.magnitude) {
				// Rotate
				float rot = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
				turret.transform.rotation = Quaternion.Euler(0f, 0f, rot - 90f);
			}
		}
	}

}
