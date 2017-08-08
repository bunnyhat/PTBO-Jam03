using UnityEngine;

public class BricksController : MonoBehaviour {

// White 	- 50 points, add 10 per brick
// Orange
// Cyan
// Green
// Red
// Blue
// Violet
// Yellow	- 120 points

	private int m_hitsToKill;
	private int m_numberOfHits;
	private int m_points;

	void Start() {
		m_hitsToKill = 1;
		m_numberOfHits = 0;
	}


	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Ball") {
			m_numberOfHits++;
			if(m_numberOfHits == m_hitsToKill) {
				Destroy(this.gameObject);
			}
		}
	}

}
