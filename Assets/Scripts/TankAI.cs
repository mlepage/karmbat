using UnityEngine;
using System.Collections;

public class TankAI : MonoBehaviour {

	public GameObject target;

	private GameObject targetTurret;

	private GameObject body;
	private GameObject turret;

	void Start () {
		targetTurret = target.transform.GetChild(0).gameObject;

		body = gameObject;
		turret = transform.GetChild(0).gameObject;
	}
	
	void LateUpdate () {
		// Body position
		body.transform.position = -target.transform.position;

		// Body rotation
		body.transform.rotation = Quaternion.Euler(0f, 0f, target.transform.rotation.eulerAngles.z + 180f);

		// Turret rotation
		turret.transform.rotation = Quaternion.Euler(0f, 0f, targetTurret.transform.rotation.eulerAngles.z + 180f);
	}
}
