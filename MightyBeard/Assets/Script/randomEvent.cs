using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class randomEvent : MonoBehaviour {

	[SerializeField] AudioSource drop;
	public GameObject bomb;
	private float rE;
	private float AppearE;
	Vector3 move;
	Vector3 done;

	void Start () {

		//bomb = GetComponent<GameObject> ();
		bomb.SetActive(false);
		//gameObject.SetActive (false);
		rE = Random.Range (0,4);
		move = new Vector3(3f, 0f, 0f);
		done = new Vector3 (66f, 0f, 0f);

	}

	void Update () {

		AppearE = Random.Range (0,15);
		transform.position += move;

		if(rE == AppearE && bomb != null){

			for (int i = 0; i<= 2; i++ ){
				
				bomb.SetActive(true);
				Instantiate(bomb, transform.position, Quaternion.identity);
				drop.Play ();
			}
				
				Destroy(gameObject, 2f);

		}
	
	}

		
}
