using UnityEngine;
using System.Collections;

public class menuControls : MonoBehaviour {
	private bool loadLock = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return) && !loadLock) {
			LoadScene();
		}
	}


	void LoadScene(){
		loadLock = true;
		Application.LoadLevel ("main_menu");
	}
}
