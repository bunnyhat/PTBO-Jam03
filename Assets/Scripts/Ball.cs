using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
	private bool m_activeBall;
	private Rigidbody m_rgb;
	private Vector3 m_ballPosition;
	private Vector3 m_ballForce;
	public GameObject m_player;

	// Use this for initialization
	void Start () {
		m_rgb = GetComponent<Rigidbody>();
		m_ballForce = new Vector3(500.0f, 0.0f, 3500.0f);
		m_activeBall = false;
		m_ballPosition = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!m_activeBall && m_player !=null){
			m_ballPosition.x = m_player.transform.position.x;
			transform.position = m_ballPosition;
		}

			float velz = m_rgb.velocity.z;
			velz = Mathf.Clamp(m_rgb.velocity.z, 0.1f, 5.0f);

			Debug.Log(velz);

		// if(m_activeBall && transform.position.z < - 6){
		// 	m_activeBall = false;
		// 	m_ballPosition.x = m_player.transform.position.x;
		// 	m_ballPosition.z = -0.95f;
		// 	transform.position = m_ballPosition;

		// 	m_rgb.isKinematic = true;
		// 	m_player.GetComponent<Player>().HaveBall();
		// }
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Walls"){
			// Debug.Log("Hit a Wall");
			// m_rgb.AddForce(0, 0, 8000f);
		}
	}

	public void MakeInactive(){
		m_activeBall = false;
	}

	public void Release(){
		if(!m_activeBall){
			m_rgb.isKinematic = false;
			m_rgb.AddForce(m_ballForce);
			m_activeBall = true;
		}
	}


		
}
