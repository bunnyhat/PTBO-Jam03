using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	//Player's Color
	public string m_color;

	//Player's paddle width. Will change depending on power-ups.
	public int m_playerWidth;

	//Player's movement speed. Will change depending on power-ups.
	public float m_speed = 30f;

	private Vector3 m_position = new Vector3(0f, 0f, 0f);

	

	//Player's current power-up
	//TODO:Fix dis
	//public Powerup m_powerup;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
void Update () {

	if(this.gameObject.tag == "Player 2"){
		float xPos = transform.position.x + ((Input.GetAxis("Horizontal 2") * m_speed) * Time.deltaTime);
		m_position = new Vector3(xPos, 0, 0);
		m_position.y = Mathf.Clamp(this.gameObject.transform.position.y, 0.5f ,0.5f);
		m_position.z = Mathf.Clamp(this.gameObject.transform.position.z, 45.7f, 45.7f);
		transform.position = m_position;
	} else {
		float xPos = transform.position.x + ((Input.GetAxis("Horizontal") * m_speed) * Time.deltaTime);
		m_position = new Vector3(xPos, 0, 0);
		m_position.y = Mathf.Clamp(this.gameObject.transform.position.y, 0.5f ,0.5f);
		m_position.z = Mathf.Clamp(this.gameObject.transform.position.z, -47.19f, -47.19f);
		transform.position = m_position;

		}
	}
}
