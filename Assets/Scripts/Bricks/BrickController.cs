using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

	public GameObject m_ball;

	private Rigidbody m_ballRGB;

	// Use this for initialization
	void Start () {
		m_ballRGB = m_ball.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag == "Ball") {
			// Destroy(this.gameObject);
			m_ballRGB.AddForce(0, 0, 6000f);
			
		}
	}
}
