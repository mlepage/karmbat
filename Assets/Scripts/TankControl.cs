﻿using UnityEngine;
using System.Collections;

public class TankControl : MonoBehaviour {

	public float speed = 0.1f;

	private GameObject body;
	private GameObject turret;

	void Start () {
		// Assume game object is body and first child is turret
		body = gameObject;
		turret = transform.GetChild(0).gameObject;
	}
	
	void Update () {
		{
			// Control body with left stick
			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");
			Vector3 move = new Vector3(h, v, 0f);
			if (0f < move.magnitude) {
				// Rotate
				float rot = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
				body.transform.rotation = Quaternion.Euler(0f, 0f, rot - 90f);
				// Move
				Vector3 position = body.transform.position;
				body.transform.Translate(move * speed, Space.World);
				if (body.transform.position.magnitude < 1f) {
					// Revert position if too close to center
					body.transform.position = position;
				}
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
