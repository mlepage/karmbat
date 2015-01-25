using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public AudioClip shootSound;
	public AudioClip bounceSound;

	public GameObject gameOver;
	public GameObject youWin;
	public GameObject youLose;
	
	public GameObject tank1;
	public GameObject tank2;

	public GameObject tankShot;

	private GameObject turret1;
	private GameObject turret2;

	private Vector3 spawnPosition1;
	private Vector3 spawnPosition2;
	private Quaternion spawnRotation1;
	private Quaternion spawnRotation2;

	private AudioSource engineAudio;
	private AudioSource explosionAudio;
	private AudioSource shootAudio;

	private float disableTankTime;

	void Start () {
		engineAudio = GameObject.FindWithTag("Audio").transform.FindChild("Engine").gameObject.GetComponent<AudioSource>();
		explosionAudio = GameObject.FindWithTag("Audio").transform.FindChild("Explosion").gameObject.GetComponent<AudioSource>();
		shootAudio = GameObject.FindWithTag("Audio").transform.FindChild("Shoot").gameObject.GetComponent<AudioSource>();

		turret1 = tank1.transform.GetChild(0).gameObject;
		turret2 = tank2.transform.GetChild(0).gameObject;

		spawnPosition1 = tank1.transform.position;
		spawnPosition2 = tank2.transform.position;
		spawnRotation1 = tank1.transform.rotation;
		spawnRotation2 = tank2.transform.rotation;

		gameOver.SetActive(false);
	}
	
	void Update () {
		if (gameOver.activeSelf) {
			// Disable tank1 after a short time (so it can no longer be shot)
			if (disableTankTime <= Time.time) {
				tank1.SetActive(false);
			}

			// Restart game if button is pressed
			if (Input.anyKeyDown) {
				Restart();
			}
		}
	}

	public void Shoot () {
		// Ensure tank2 is synced to tank1
		tank2.GetComponent<Doppelganger>().UpdateDoppelganger();
		turret2.GetComponent<Doppelganger>().UpdateDoppelganger();

		// Spawn shot1
		GameObject shot1 = Instantiate(tankShot, turret1.transform.position, turret1.transform.rotation) as GameObject;
		(shot1.renderer as SpriteRenderer).color = (turret1.renderer as SpriteRenderer).color;
		shot1.tag = tank1.tag;
		shot1.AddComponent<ShotControl>();
		ShotCollider shotCollider1 = shot1.AddComponent<ShotCollider>();
		shotCollider1.targetTag = tank2.tag;

		// Spawn shot2
		GameObject shot2 = Instantiate(tankShot, turret2.transform.position, turret2.transform.rotation) as GameObject;
		(shot2.renderer as SpriteRenderer).color = (turret2.renderer as SpriteRenderer).color;
		shot2.tag = tank2.tag;
		shot2.AddComponent<ShotControl>();
		ShotCollider shotCollider2 = shot2.AddComponent<ShotCollider>();
		shotCollider2.targetTag = tank1.tag;

		// Play sound
		shootAudio.Play();
	}

	public void EngineIdle () {
		engineAudio.volume = 0.25f;
	}
	
	public void EngineLoud () {
		engineAudio.volume = 1f;
	}
	
	public void GameOver (bool lose) {
		disableTankTime = Time.time + 0.5f;

		gameOver.SetActive(true);
		youWin.SetActive(!lose);
		youLose.SetActive(lose);

		// Keep tank1 enabled (so it can be shot) but make it invisible
		tank1.renderer.enabled = false;
		turret1.renderer.enabled = false;

		// Disable tank2
		tank2.SetActive(false);

		explosionAudio.Play();
		EngineIdle();
	}

	public void Restart () {
		gameOver.SetActive(false);

		// Enable tank1 and make it visible
		tank1.SetActive(true);
		tank1.renderer.enabled = true;
		turret1.renderer.enabled = true;

		// Enable tank2
		tank2.SetActive(true);

		tank1.transform.position = spawnPosition1;
		tank2.transform.position = spawnPosition2;
		tank1.transform.rotation = spawnRotation1;
		tank2.transform.rotation = spawnRotation2;

		turret1.transform.localRotation = Quaternion.identity;
		turret2.transform.localRotation = Quaternion.identity;
	}
}
