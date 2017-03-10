using UnityEngine;
using System.Collections;
using DG.Tweening;
public class player_gun : MonoBehaviour {

	Tween gun;
	Vector3 hit = new Vector3 (0f, -2f, 0f);

	Color colorR = Color.red;
	Color colorG = Color.green;
	Color colorB = Color.blue;
	Color colory = Color.yellow;
	private SpriteRenderer sR;
	// Use this for initialization
	void Start () {

		sR = GetComponent<SpriteRenderer> ();

		//gun = transform.DOPunchPosition(hit, 0.2f, 5, 1f, false);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton("Fire1"))
		{
			if ( gun != null && gun.IsPlaying ()) {

				gun.Complete ();
			}

			gun = transform.DOPunchPosition(hit, 0.2f, 5, 1f, false);

			//gun.Play ();
		}


		if(Input.GetKey(KeyCode.Alpha1))
		{
			sR.color = colorG;
		}

		if(Input.GetKey(KeyCode.Alpha2))
		{
			sR.color = colorB;
		}

		if(Input.GetKey(KeyCode.Alpha3))
		{
			sR.color = colory;
		}

		if(Input.GetKey(KeyCode.Alpha4))
		{
			sR.color = colorR;
		}
	}
}
