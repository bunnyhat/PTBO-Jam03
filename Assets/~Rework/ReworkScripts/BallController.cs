using UnityEngine;

public class BallController : MonoBehaviour {

	private bool m_ballIsActive;
	private Vector3 m_ballPosition;
	private Vector3 m_ballInitialForce;
	public GameObject m_playerObject;
	private Rigidbody m_RB;

	public AudioClip m_brickBounce;
	public AudioClip m_wallBounce;
	public AudioClip m_vausBounce;

	void Start() {
		m_RB = GetComponent<Rigidbody>();
		m_ballInitialForce = new Vector3(35.0f, 0.0f, 150.0f);
		m_ballIsActive = false;
		m_ballPosition = transform.position;
	}

	void Update() {
		if(!m_ballIsActive && m_playerObject != null) {
			m_ballPosition.x = m_playerObject.transform.position.x;
			transform.position = m_ballPosition;
		}

		if(m_ballIsActive && transform.position.z < -6) {
			m_ballIsActive = false;
			m_ballPosition.x = m_playerObject.transform.position.x;
			m_ballPosition.z = -0.95f;
			transform.position = m_ballPosition;

			m_RB.isKinematic = true;
			m_playerObject.GetComponent<PlayerController>().Haveball();
		}
	}

	public void MakeInactive() {
		m_ballIsActive = false;
	}

	public void Release() {
		if(!m_ballIsActive) {
			m_RB.isKinematic = false;
			m_RB.AddForce(m_ballInitialForce);
			m_ballIsActive = true;
		}
	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Walls") {
			PlaySound("Wall");
		}
	}

	public void PlaySound(string soundToPlay) {
		switch(soundToPlay) {

			case "Brick":
				GetComponent<AudioSource>().clip = m_brickBounce;
				break;

			case "Wall":
				GetComponent<AudioSource>().clip = m_wallBounce;
				break;

			case "Vaus":
				GetComponent<AudioSource>().clip = m_vausBounce;
				break;
		}

		GetComponent<AudioSource>().Play();
	}
}
