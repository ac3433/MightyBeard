using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	Quaternion CannonV;
	[SerializeField] GameObject player;

	[SerializeField] float msD = 15f;
	// Use this for initialization
	void Start () {
	
		CannonV = player.transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 cannonR = player.transform.position - transform.position;
		cannonR.y = 0f;
		CannonV = Quaternion.LookRotation (cannonR, Vector2.down);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, CannonV, msD * Time.deltaTime);

	

		//unity document explanation
		/*Vector3 targetDir = player.transform.position - transform.position;
		float step = msD * Time.deltaTime;
		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
		Debug.DrawRay(transform.position, newDir, Color.red);
		transform.rotation = Quaternion.LookRotation(newDir);*/

		//CannonV = new Vector3 (player.transform.position.x, transform.position.y, player.transform.position.z);

		//transform.LookAt (player, Vector3.up);
	
	}
}
