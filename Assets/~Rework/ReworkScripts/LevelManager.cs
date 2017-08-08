using UnityEngine;

public enum BrickTypes { NONE = 0, WHITE = 50, ORANGE = 60, CYAN = 70, GREEN = 80, RED = 90, BLUE = 100, MAGENTA = 110, YELLOW = 120, SILVER = 130 , BLACK = 140}

public class LevelManager : MonoBehaviour {

	public GameObject m_brickPrefab;
	public Transform m_brickContainer;
	private float startZ = 1.0f;
	private float startX = -6.40f;


	private const int m_fieldHeight = 5;
	private const int m_fieldWidth = 13;
	private string[,] m_playField;


	void Start () {
		m_playField = new string[m_fieldHeight,m_fieldWidth];
		LoadLevel();
		CreateLevel();
	}

	private void LoadLevel() {

		string block = "";
		for(int r = 0; r < m_fieldHeight; r++) {
			for(int c = 0; c < m_fieldWidth; c++) {

				switch(r) {
					case 0:
						block = "Y"; // Grey
						break;

					case 1:
						block = "G"; // Red
						break;

					case 2:
						block = "W"; // Yellow
						break;

					case 3:
						block = "G"; // Cyan
						break;

					case 4:
						block = "Y"; // Magenta
						break;

					// case 18:
					// 	block = "E"; // Green
					// 	break;

					default:
						block = " ";
						break;
				}

				m_playField[r, c] = block;
			}
		}
	}

	private void CreateLevel() {
		GameObject tmpBrick;
		Vector3 tmpPos;

		tmpPos = Vector3.zero;

		for(float r = 0, z = startZ; r < m_fieldHeight; r++, z -= 0.5f) {
			for(float c = 0, x = startX; c < m_fieldWidth; c++, x += 0.9f) {

				if(m_playField[(int)r,(int)c] != " ") {
					tmpPos.x = x + 1;
					tmpPos.y = 0.2f;
					tmpPos.z = z;
					tmpBrick = Instantiate(m_brickPrefab, tmpPos, Quaternion.identity);
					tmpBrick.name = "Brick";
					tmpBrick.transform.parent = m_brickContainer;
					GetBrickType(tmpBrick, (int)r, (int)c);
				}
			}
		}
	}

	private BrickTypes GetBrickType(GameObject tmpObj, int r, int c) {
		BrickTypes retBrick = BrickTypes.NONE;

		switch (m_playField[r, c]) {
			case "E":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.grey;
				retBrick = BrickTypes.SILVER;
				break;

			case "R":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.red;
				retBrick = BrickTypes.RED;
				break;

			case "Y":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.yellow;
				retBrick = BrickTypes.YELLOW;
				break;

			case "C":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.cyan;
				retBrick = BrickTypes.CYAN;
				break;

			case "M":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.magenta;
				retBrick = BrickTypes.MAGENTA;
				break;

			case "G":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.green;
				retBrick = BrickTypes.GREEN;
				break;

			case "W":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.white;
				retBrick = BrickTypes.WHITE;
				break;

			case "K":
				tmpObj.GetComponent<MeshRenderer>().material.color = Color.black;
				retBrick = BrickTypes.BLACK;
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
