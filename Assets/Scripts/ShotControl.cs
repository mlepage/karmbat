using UnityEngine;
using System.Collections;

public class ShotControl : MonoBehaviour {

	public float speed = 0.2f;

	private bool inBlock;

	private int life = 3;

	void Start () {
	}
	
	void Update () {
		// Old position
		Vector3 position = transform.position;

		// Move
		transform.Translate(Vector3.up * speed);

		// Check for collision
		Collider2D collider = Physics2D.OverlapCircle(transform.position, 0.1f);
		if (collider) {
			if (collider.name == "ArenaBlock") {
				if (!inBlock) {
					// Reduce life
					if (--life == 0) {
						Destroy(gameObject);
						return;
					}
					// Find vector to block center (normalized for stretched blocks)
					Vector3 v = collider.transform.position - position;
					v.x /= collider.transform.localScale.x;
					v.y /= collider.transform.localScale.y;
					Vector3 forward = transform.up;
					if (Mathf.Abs(v.x) < Mathf.Abs(v.y)) {
						forward.y = -forward.y; // bounce vertically
					} else {
						forward.x = -forward.x; // bounce horizontally
					}
					transform.up = forward;
				}
				inBlock = true;
			}
		} else {
			inBlock = false;
		}
	}
}
