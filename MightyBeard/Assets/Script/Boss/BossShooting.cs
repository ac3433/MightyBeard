using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossShooting : MonoBehaviour {

    private float timer;

    public float minRate;
    public float maxRate;

    public Transform spawnLoc;
    public Transform spawnLoc2;
    public GameObject bulletList;
    private List<GameObject> inactiveBullets;
    private List<GameObject> activeBullets;

    private GameObject player;

    void Start () {

        inactiveBullets = new List<GameObject>();
        activeBullets = new List<GameObject>();

        foreach(Transform t in bulletList.GetComponentInChildren<Transform>())
        {
            inactiveBullets.Add(t.gameObject);
        }
        timer = Time.time + minRate;

        player = GameObject.FindGameObjectWithTag("Player");
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > timer)
        {
            timer = Time.time + UnityEngine.Random.Range(minRate, maxRate);
            Shoot();
        }

        if(GetComponent<BossHitState>().health < 75)
        {
            minRate = 0;
            maxRate = 3;
        }
        else if(GetComponent<BossHitState>().health < 35)
        {
            maxRate = 2;
        }

    }

    void Shoot()
    {
        if(inactiveBullets.Count != 0)
        {
            GameObject obj = inactiveBullets[0];
            obj.transform.position = spawnLoc.transform.position;

            activeBullets.Add(obj);
            inactiveBullets.RemoveAt(0);

            BossBullet bb = obj.GetComponent<BossBullet>();
            Vector3 target = player.transform.position;
            bb.SetDirection(target);

            obj.SetActive(true);

            GameObject obj1 = inactiveBullets[0];
            obj1.transform.position = spawnLoc2.transform.position;

            activeBullets.Add(obj1);
            inactiveBullets.RemoveAt(0);

            bb = obj1.GetComponent<BossBullet>();
            bb.SetDirection(target);
            obj1.SetActive(true);
        }
    }


    public void disableBullet(GameObject obj)
    {
        if(activeBullets.Contains(obj))
        {
            inactiveBullets.Add(obj);
            activeBullets.Remove(obj);
        }
    }
}
