using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject tank1;
	public GameObject tank2;

	public GameObject tankShot;

	private GameObject turret1;
	private GameObject turret2;

	void Start () {
		turret1 = tank1.transform.GetChild(0).gameObject;
		turret2 = tank2.transform.GetChild(0).gameObject;
	}
	
	void Update () {
	}

	public void Shoot () {
		GameObject shot1 = Instantiate(tankShot, turret1.transform.position, turret1.transform.rotation) as GameObject;
		(shot1.renderer as SpriteRenderer).color = (turret1.renderer as SpriteRenderer).color;
		shot1.AddComponent<ShotControl>();

		GameObject shot2 = Instantiate(tankShot, turret2.transform.position, turret2.transform.rotation) as GameObject;
		(shot2.renderer as SpriteRenderer).color = (turret2.renderer as SpriteRenderer).color;
		Doppelganger dop = shot2.AddComponent<Doppelganger>();
		dop.target = shot1;
	}
}
