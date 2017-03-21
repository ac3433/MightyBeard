using UnityEngine;
using System.Collections;

public class particlesy : MonoBehaviour {

	public ParticleSystem part;
	public ParticleSystem part2;
    public GameObject RainbowPuke;
    public Transform spawnLoc;
    public Vector3 posoff;
    GameObject puke;

    public float pukeLife;
    public float timeToVomit;

    private bool fireCheck;
	// Use this for initialization
	void Start () {
	
		part = GetComponent<ParticleSystem> ();
		part2 = GetComponent<ParticleSystem> ();
        fireCheck = true;
        //rb = puke.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        timeToVomit -= Time.deltaTime;

        if (GetComponent<BossHitState>().health < 50 && (timeToVomit <=0))
        {
                puke = (GameObject)Instantiate(RainbowPuke, spawnLoc.position + posoff, spawnLoc.rotation);
                Debug.Log("F");
                Destroy(puke, pukeLife);
                timeToVomit = 10;
        }


    }

    /*void OnParticleCollision (GameObject other){

		Rigidbody2D rigged = other.GetComponent<Rigidbody2D> ();

		if (rigged) {
			Vector3 direction = other.transform.position - transform.position;
			direction = direction.normalized;
			rigged.AddForce(direction * 5);
			Debug.Log ("I hit you");
		}
	}*/
}
