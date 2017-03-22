using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class randomEvent : MonoBehaviour {

	[SerializeField] AudioSource drop;
	public GameObject bomb;

    public float bombRate = 5f;

    private float timer;

	void Start () {

		//bomb = GetComponent<GameObject> ();
		bomb.SetActive(false);
        //gameObject.SetActive (false);
        timer = Time.time + bombRate;

	}

	void Update () {

        if(Time.time > timer)
        {
            timer = Time.time + bombRate;
            for (int i = 0; i <= 2; i++)
            {
                bomb.SetActive(true);
                GameObject obj = (GameObject)Instantiate(bomb, transform.position, Quaternion.identity);
                Destroy(obj, 5f);
                drop.Play();
            }
        }



		
	
	}

		
}
