using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrickState {
	SPAWNED,
	DESTROYED,
	COLOR_NEUTRAL,
	COLOR_CHANGED
}

public enum BrickType {
	NONE,
	NORMAL,
	POWERUP_BRICK,
	MID_LAYER
}

public class BricksManager : MonoBehaviour {
	public GameObject m_brick;
	// public BrickLayers[] m_brickLayers;
	public Transform m_brickContainer;
	public BrickType m_bricktype;
	public float m_startZ;

	private int m_fieldHeight = 150;
	private int m_fieldWidth = 145;
	private string[ , ] m_playField;

	AudioSource m_audioSource;

	// Use this for initialization
	void Start () {
		m_audioSource = GetComponent<AudioSource>();
		m_audioSource.PlayOneShot(m_audioSource.clip, 0.556f);

		m_playField = new string[m_fieldHeight, m_fieldWidth];
		LevelStart();
		CreateLevel();
	}

	void LevelStart() {
		string block = "";
		for(int r = 0; r < m_fieldHeight; r++) {
			for (int c = 0; c < m_fieldWidth; c++) {
				switch (r) {					
					case 80:
						block = "C";
						break;

					case 85:
						block = "P";
						break;

					case 90:
						block = "W";
						break;

					case 95:
						block = "P";
						break;

					case 100:
						block = "C";
						break;
					
					default:
						block = " ";
						break;
				}

				m_playField[r, c] = block;
			}
		}
	
	}

	void CreateLevel() {
		GameObject tmpBrick;
		Vector3 tmpPos;

		tmpPos = Vector3.zero;

		for(float r = 0, z = m_startZ; r < m_fieldHeight; r++, z -= 0.5f) {
			for(int c = 0; c < m_fieldWidth; c += 8) {
				if(m_playField[(int)r,c] != " ") {
					tmpPos.x = c - 72;
					tmpPos.z = z;
					tmpBrick = Instantiate(m_brick, tmpPos, Quaternion.identity);
					tmpBrick.transform.Rotate(0, 90, 0);
					tmpBrick.name = "Brick";
					tmpBrick.transform.parent = m_brickContainer;
					GetBrickType(tmpBrick, (int) r, c);
				}
			}
		}
	}

	private BrickType GetBrickType(GameObject tmpObj, int r, int c) {
		BrickType retBrick = BrickType.NONE;

		switch(m_playField[r,c]) {
			case "W":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.white;
				tmpObj.tag = "MidBrick";
				retBrick = BrickType.MID_LAYER;
				break;

			case "P":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.green;
				retBrick = BrickType.POWERUP_BRICK;
				break;

			case "C":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.yellow;
				retBrick = BrickType.NORMAL;
				break;
		}
		return retBrick;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.O)){
			dBugField();
		}
	}

	// dBugging
	private void dBugField() {
		string outS = "";
		for(int r = 0; r < m_fieldHeight; r++) {
			for(int c = 0; c < m_fieldWidth; c++) {
				outS += "[" + m_playField[r, c] + "]";
			}
			outS += "\n";
		}
		Debug.Log(outS);
	}
}
