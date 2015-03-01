using UnityEngine;
using System.Collections;

public class commonZombie : MonoBehaviour {
	public string name = "Common Zombie";
	public int hp = 75;
	public int attack = 1;
	public float speed = 3f;
	public int defense = 1;
	public int spawnCost = 1;
	public GameObject[] humans;
	private Vector3 currentTarget;
	private int targetKilled = 1;
	private float rotateSpeed = 0.5f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		getCurrentTarget ();
		moveToCurrentTarget ();
		Rotate ();
	}

	void getCurrentTarget(){
		//TODO calc distance of array of humans
		if (targetKilled == 1) {
			float distance = 2000f;
			int human = 0;
			for(int i = 0; i < humans.Length; ++i){
				float tempDist = Vector2.Distance(transform.position,humans[i].transform.position);
				if(tempDist < distance){
					distance = tempDist;
					human = i;
				}
			}

			currentTarget = humans[human].transform.position;
			targetKilled = 0;
		}
	}

	void moveToCurrentTarget(){
		transform.position = Vector3.MoveTowards (transform.position, currentTarget, Time.deltaTime * speed);
	}

	void Rotate(){
		Vector2 dir = transform.InverseTransformPoint (currentTarget);
		float angle = Vector2.Angle (Vector2.right * 180f, dir);
		angle = dir.y < 0 ? -angle : angle;
		transform.Rotate (Vector3.back, Time.deltaTime * angle * rotateSpeed);

	}
}

