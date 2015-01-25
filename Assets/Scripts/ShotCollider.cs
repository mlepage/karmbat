﻿using UnityEngine;
using System.Collections;

public class ShotCollider : MonoBehaviour {

	public string targetTag;

	void Update () {
		Collider2D other = Physics2D.OverlapCircle(transform.position, 0.15f);
		if (other && other.CompareTag(targetTag)) {
			// Destroy the shot
			Destroy(gameObject);
			GameObject.FindWithTag("GameController").GetComponent<GameController>().GameOver();
		}
	}
}
