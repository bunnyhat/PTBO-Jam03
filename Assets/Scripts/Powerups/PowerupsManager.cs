using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfPowerUp {
	EXTEND_PADDLE,
	SHRINK_PADDLE,
	ADD_3_BALLS,
	INCREASE_BALL_SPEED,
	DECREASE_BALL_SPEED,
	DOUBLE_POINTS
}

public class PowerupsManager : MonoBehaviour {
	public float m_pUpTimer;
	public float m_resetPupTimer;
	public float m_pUpSpeed;
	public TypeOfPowerUp m_typeOfPowerUp;
	public bool m_hasGainedPowerup;
	Ball m_ball;
	Player m_player1, m_player2;

	// Use this for initialization
	void Start () {
		m_ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Ball>();
		m_player1 = GameObject.FindGameObjectWithTag("Player 1").GetComponent<Player>();
		m_player2 = GameObject.FindGameObjectWithTag("Player 2").GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(m_ball.m_speed);
		this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.transform.position.z - m_pUpSpeed * Time.deltaTime);
		if(m_hasGainedPowerup) {
			switch(m_typeOfPowerUp) {
				case TypeOfPowerUp.INCREASE_BALL_SPEED:
					m_ball.m_speed = 80;
					break;
			}
		}

	}
	
}
