using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {


	[SerializeField] GameObject player;
	
	// Update is called once per frame
	void Update () {

        Vector2 dirRot =  player.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(0, 0, dirRot.x);

	
	}
}
