using UnityEngine;
using System.Collections;

public class ShotCollider : MonoBehaviour {

	// The shot is only interested in hitting target with particular tag (Player or Enemy)
	public string targetTag;

	void Update () {
		Collider2D other = Physics2D.OverlapCircle(transform.position, 0.15f);
		if (other && other.CompareTag(targetTag)) {
			// Shot hit its target so destroy it
			Destroy(gameObject);
			// Game is won or lost depending on who got shot
			bool lose = targetTag.Equals("Player");
			GameObject.FindWithTag("GameController").GetComponent<GameController>().GameOver(lose);
		}
	}
}
