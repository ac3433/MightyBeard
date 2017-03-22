using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {

	//[SerializeField] AudioSource drop;
	private Rigidbody2D r2D;
    // Use this for initialization
    float randomX;
    void Start () {
	
		r2D = GetComponent<Rigidbody2D> ();
        randomX = Random.Range(-6, 6);

    }
	
	// Update is called once per frame
	void Update () {

		transform.position += new Vector3(randomX, -5f, 0);

	
	}

	void OnCollisionEnter2D (Collision2D boom){

		if(boom.collider.tag == "City"){

			Destroy (gameObject, 1f);

		}

	}
}
