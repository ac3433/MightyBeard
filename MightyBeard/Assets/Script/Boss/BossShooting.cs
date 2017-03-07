using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BossShooting : MonoBehaviour {

    private float timer;

    public float minRate;
    public float maxRate;

    public Transform spawnLoc;
    public GameObject bulletList;
    private List<GameObject> inactiveBullets;
    private List<GameObject> activeBullets;

    void Start () {

        inactiveBullets = new List<GameObject>();
        activeBullets = new List<GameObject>();

        foreach(Transform t in bulletList.GetComponentInChildren<Transform>())
        {
            inactiveBullets.Add(t.gameObject);
        }
        timer = Time.time + minRate;
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time > timer)
        {
            timer = Time.time + UnityEngine.Random.Range(minRate, maxRate);
            Shoot();
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
            obj.SetActive(true);
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
