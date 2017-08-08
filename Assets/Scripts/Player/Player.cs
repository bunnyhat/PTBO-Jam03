using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public GameObject m_ball;

	private Rigidbody m_ballRGB;

	private bool m_haveBall;

	//Player's Color
	public Color m_color;

	//Player's paddle width. Will change depending on power-ups.
	public int m_playerWidth;

	//Player's movement speed. Will change depending on power-ups.
	public float m_speed = 30f;

	private Vector3 m_position = new Vector3(0f, 0f, 0f);

	public int m_score;

	public Text m_scoreText;

	public Slider m_slider;

	public LerpDerp m_lerp;

	

	

	//Player's current power-up
	//TODO:Fix dis
	//public Powerup m_powerup;


	// Use this for initialization
	void Start () {
		m_ballRGB = m_ball.GetComponent<Rigidbody>();
		m_haveBall = true;
		m_scoreText.text = m_score.ToString();
		m_slider.value = m_score;
		// m_lerp = this.GetComponent<LerpDerp>();

		if(this.gameObject.tag == "Player 1") {
			m_color = Color.red;
			
		} else if(this.gameObject.tag == "Player 2") {
			m_color = Color.blue;
		}
	}

	public void HaveBall(){
		m_haveBall = true;
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Ball"){
			// m_ballRGB.AddForce(0 , 0, 10f);			
		}
	}

	public void SetScore(int score){
		m_score += score;
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.tag == "Player 2"){
			//Keyboard Controls
			float xPos = transform.position.x + ((Input.GetAxis("Horizontal 2") * m_speed) * Time.deltaTime);

			//Xbox Controller
			//  float xPos = transform.position.x + ((Input.GetAxis("JoystickHoriz_2") * m_speed) * Time.deltaTime);

			m_position = new Vector3(xPos, 0, 0);
			m_position = new Vector3(Mathf.Clamp(xPos, -68, 68), 0.5f, 48f);
			transform.position = m_position;

			if(Input.GetAxis("A_2") == 1 && m_haveBall || Input.GetKey(KeyCode.Return)){			
				m_ballRGB.isKinematic = false;
				m_ball.transform.parent = null;
				m_ball.GetComponent<Ball>().Release();
				m_haveBall = false;
			}
		} else {

			//Keyboard Controls
			float xPos = transform.position.x + ((Input.GetAxis("Horizontal") * m_speed) * Time.deltaTime);

			//Xbox Controller
			//  float xPos = transform.position.x + ((Input.GetAxis("JoystickHoriz") * m_speed) * Time.deltaTime);


			m_position = new Vector3(xPos, 0.5f, -47.19f);
			m_position = new Vector3(Mathf.Clamp(xPos, -68, 68), 0.5f, -48f);
			transform.position = m_position;

			if( (Input.GetAxis("A") == 1 && m_haveBall) || Input.GetKey(KeyCode.Space) ){			
				m_ballRGB.isKinematic = false;
				m_ball.transform.parent = null;
				m_ball.GetComponent<Ball>().Release();
				m_haveBall = false;
			}

		}

		m_scoreText.text = m_score.ToString();
		m_slider.value = m_score;
		if(m_slider.value >= 38){
			m_lerp.m_isBarFull = true;
			m_lerp.BarFull();
			
		}
	}
}