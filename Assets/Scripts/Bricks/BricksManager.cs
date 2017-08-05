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

// [System.Serializable]
// public class BrickLayers {
// 	public GameObject[] m_bricks;
// }

public class BricksManager : MonoBehaviour {
	public GameObject m_brick;
	// public BrickLayers[] m_brickLayers;
	public Transform m_brickContainer;
	public float m_startZ;

	private int m_fieldHeight = 26;
	private int m_fieldWidth = 13;
	private string[ , ] m_playField;

	// Use this for initialization
	void Start () {
		m_playField = new string[m_fieldHeight, m_fieldWidth];
		LevelStart();
		CreateLevel();
	}

	void LevelStart() {
		string block = "";
		for(int r = 0; r < m_fieldHeight; r++) {
			for (int c = 0; c < m_fieldWidth; c++) {
				switch (r) {
					case 1:
						block = "W";
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
			for(int c = 0; c < m_fieldWidth; c++) {
				if(m_playField[(int)r,c] != " ") {
					tmpPos.x = c + 1;
					tmpPos.z = z;
					tmpBrick = Instantiate(m_brick, tmpPos, Quaternion.identity);
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
				retBrick = BrickType.NORMAL;
				break;
		}
		return retBrick;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
