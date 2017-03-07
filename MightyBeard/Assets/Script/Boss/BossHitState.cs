using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BossHitState : MonoBehaviour {

    public float health = 100f;

    [Serializable]
    public struct Short { public string name; public Sprite sprite; }
    [Serializable]
    public struct Med { public string name; public Sprite sprite; }

    public Short[] s;
    public Med[] m;


    private Dictionary<string, Sprite> shortFace;
    private Dictionary<string, Sprite> medFace;

    bool updates = false;

    private BossColorStatus bcc;

	void Start () {
        shortFace = new Dictionary<string, Sprite>();
        medFace = new Dictionary<string, Sprite>();
        bcc = GetComponent<BossColorStatus>();

        foreach(Short st in s)
        {
            shortFace.Add(st.name, st.sprite);
        }

        foreach(Med mt in m)
        {
            medFace.Add(mt.name, mt.sprite);
        }
	}
	
	// Update is called once per frame
	void Update () {

	    if(health < 25)
        {
            bcc.ChangeSpriteColor(shortFace);
        }
        else if (health < 50)
        {
            bcc.ChangeSpriteColor(medFace);
        }

	}


    public void decreaseHealth(float num)
    {
        health -= num;
    }
}
