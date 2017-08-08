using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float m_speed;
	public GameObject m_ball;

	private Rigidbody m_ballRB;
	private Vector3 m_playerPos;
	private bool m_haveBall;
	public Color m_color;
	private Vector3 m_position = new Vector3(0f, 0f, 0f);

	// private SuperPower m_currentPower;

	// private SuperPower powerUpType;

	void Start() {
		m_ballRB = m_ball.GetComponent<Rigidbody>();
		m_haveBall = true;
		m_playerPos = transform.position;
		// m_color = GetComponent<Mesh>();
		// m_currentPower = SuperPower.NONE;
	}

	// void Update () {
	// 	if(this.gameObject.tag == "Player 2"){
	// 		//Keyboard Controls
	// 		float xPos = transform.position.x + ((Input.GetAxis("Horizontal 2") * m_speed) * Time.deltaTime);

	// 		//Xbox Controller
	// 		//  float xPos = transform.position.x + ((Input.GetAxis("JoystickHoriz_2") * m_speed) * Time.deltaTime);

	// 		m_position = new Vector3(xPos, 0.2f, 4.5f);
	// 		m_playerPos = new Vector3(Mathf.Clamp(xPos, -5.65f, 5.65f), 0.2f, 4.5f);
	// 		transform.position = m_position;

	// 		if(Input.GetAxis("A_2") == 1 && m_haveBall || Input.GetKey(KeyCode.Return)){			
	// 			m_ballRB.isKinematic = false;
	// 			m_ball.transform.parent = null;
	// 			m_ball.GetComponent<Ball>().Release();
	// 			m_haveBall = false;
	// 		}
	// 	} else if(this.gameObject.tag == "Player 1") {

	// 		//Keyboard Controls
	// 		float xPos = transform.position.x + ((Input.GetAxis("Horizontal") * m_speed) * Time.deltaTime);

	// 		//Xbox Controller
	// 		//  float xPos = transform.position.x + ((Input.GetAxis("JoystickHoriz") * m_speed) * Time.deltaTime);


	// 		m_position = new Vector3(xPos, 0.2f, -4.5f);
	// 		m_playerPos = new Vector3(Mathf.Clamp(xPos, -5.65f, 5.65f), 0.2f, -4.5f);
	// 		transform.position = m_position;

	// 		if( (Input.GetAxis("A") == 1 && m_haveBall) || Input.GetKey(KeyCode.Space) ){			
	// 			m_ballRB.isKinematic = false;
	// 			m_ball.transform.parent = null;
	// 			m_ball.GetComponent<BallController>().Release();
	// 			m_haveBall = false;
	// 		}

	// 	}

	// 	// // m_scoreText.text = m_score.ToString();
	// 	// // m_slider.value = m_score;
	// 	// // if(m_slider.value >= 38){
	// 	// // 	m_lerp.m_isBarFull = true;
	// 	// // 	m_lerp.BarFull();
			
	// 	// }
	// }

	void Update() {
		float xPos = transform.position.x + (Input.GetAxis("Horizontal") * m_speed) * Time.deltaTime;
		m_playerPos = new Vector3(Mathf.Clamp(xPos, -5.65f, 5.65f), 0.2f, -4.5f);
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
