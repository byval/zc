using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
	public string scene;
	private bool loadLock = false;
	public Sprite[] textures;

	public int menuSelect = 0;
	Sprite option;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			if(menuSelect == 3){
				menuSelect = 0;
				GetComponent <SpriteRenderer>().sprite = textures[menuSelect];
			}
			else{
				menuSelect++;
				GetComponent <SpriteRenderer>().sprite = textures[menuSelect];
			}
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			if(menuSelect == 0){
				menuSelect = 3;
				GetComponent <SpriteRenderer>().sprite = textures[menuSelect];
			}
			else{
				menuSelect--;
				GetComponent <SpriteRenderer>().sprite = textures[menuSelect];
			}
		}

		if (Input.GetKeyDown(KeyCode.Return) && !loadLock) {
			LoadScene();
		}
	}


	void LoadScene(){
		if (scene == null)
			return;
		switch (menuSelect) {
		case 0:
			loadLock = true;
			Application.LoadLevel ("lvl_01");
			break;
		case 1:
			loadLock = true;
			Application.LoadLevel ("lvl_00");
			break;

		case 2:
			return;
			break;

		case 3:
			Application.Quit();
			break;

		default:
			return;
			break;


		}

	}
}
