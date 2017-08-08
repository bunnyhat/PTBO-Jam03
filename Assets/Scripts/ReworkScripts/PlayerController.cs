using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float m_speed;
	public GameObject m_ball;

	private Rigidbody m_ballRB;
	private Vector3 m_playerPos;
	private bool m_haveBall;

	// private SuperPower m_currentPower;

	// private SuperPower powerUpType;

	void Start() {
		m_ballRB = m_ball.GetComponent<Rigidbody>();
		m_haveBall = true;
		m_playerPos = transform.position;
		// m_currentPower = SuperPower.NONE;
	}

	void Update() {
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * m_speed) * Time.deltaTime;
		m_playerPos = new Vector3(Mathf.Clamp(xPos, 294.35f, 305.65f), 0.2f, -4.5f);
		transform.position = m_playerPos;

		if(Input.GetKeyDown(KeyCode.Space) && m_haveBall) {
			m_ballRB.isKinematic = false;
			m_ball.transform.parent = null;
			Vector3 velocity = GetComponent<Rigidbody>().velocity;
			m_ball.GetComponent<BallController>().Release();
			m_haveBall = false;
		}

	}

	// public void AddSuperPower(SuperPower powerUpType) {

	// 	switch (powerUpType) {
	// 		case SuperPower.DISRUPT:
	// 			// split into 3

	// 			break;

	// 		case SuperPower.CATCH:
	// 			m_currentPower = SuperPower.CATCH;
				
	// 			break;
	// 	}
	// }

	public void Haveball() {
		m_haveBall = true;
	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Ball") {
			// if(m_currentPower == SuperPower.CATCH) {
			// 	m_ballRB.isKinematic = true;
			// 	m_ball.transform.parent = this.transform;
			// 	Vector3 newPos = transform.position;
			// 	newPos.z = -0.95f;

			// 	m_ball.transform.position = newPos;
			// 	m_haveBall = true;
			// 	other.gameObject.GetComponent<BallController>().MakeInactive();

			// // 	m_ballIsActive = false;
			// // m_ballPosition.x = m_playerObject.transform.position.x;
			// // m_ballPosition.z = -0.95f;
			// // transform.position = m_ballPosition;

			// // m_RB.isKinematic = true;
			// // m_playerObject.GetComponent<PlayerController>().Haveball();
			// }
			// other.gameObject.GetComponent<BallController>().PlaySound("Vaus");
		}
	}
}
