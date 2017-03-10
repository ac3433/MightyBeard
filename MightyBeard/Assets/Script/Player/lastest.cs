using UnityEngine;
using System.Collections;

public class lastest : MonoBehaviour {

	//laser
	RaycastHit2D hit;
	LineRenderer laser;

	//sprites
	//PlayerColorChange colorS;
	//private SpriteRenderer sR;
	//[SerializeField] Renderer rend;

	public Material s0;
	public Material s1;
	public Material s2;
	public Material s3;
	// Use this for initialization
	void Start () {


		laser = GetComponent<LineRenderer> ();
		laser.enabled = false;

		//rend = GetComponent<Renderer> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.L)) {

			StopCoroutine("ShootDamnLaser");
			StartCoroutine ("ShootDamnLaser");
		}

		if(Input.GetKey(KeyCode.Alpha1))
		{
			laser.material = s0;
		}

		if(Input.GetKey(KeyCode.Alpha2))
		{
			laser.material = s1;
		}

		if(Input.GetKey(KeyCode.Alpha3))
		{
			laser.material = s2;
		}

		if(Input.GetKey(KeyCode.Alpha4))
		{
			laser.material = s3;
		}
	
	}

	IEnumerator ShootDamnLaser()
	{
		laser.enabled = true;

		while (Input.GetKey (KeyCode.L)) {

		
			Ray2D beam = new Ray2D(transform.position, transform.up);
			 
			laser.SetPosition (0, beam.origin);

			if (Physics2D.Raycast (transform.position, Vector2.up)) {

				laser.SetPosition (1, hit.point);
				if(hit.rigidbody)
				{

					hit.rigidbody.AddForceAtPosition (transform.up * 5, hit.point);
				}
			} 

			else {

				laser.SetPosition (1, beam.GetPoint(100));
			}
			laser.SetPosition (1, beam.GetPoint(100));

			yield return null;
		}


		laser.enabled = false;
	}
}
