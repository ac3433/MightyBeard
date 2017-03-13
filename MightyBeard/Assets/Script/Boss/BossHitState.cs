using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using DG.Tweening;

public class BossHitState : MonoBehaviour {

	Tween shake;
	Tween ScreenShakeTween;
	[SerializeField] AudioSource gotHit;

    public float health = 100f;

	public ParticleSystem hairps;

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

		//hairps = GetComponent<ParticleSystem> ();
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

	void OnCollisionEnter2D (Collision2D col)
	{

		if (col.collider.tag == "Bullet") {

			hairps.Play ();
			gotHit.Play ();

			if (shake != null && shake.IsPlaying ()) {

				shake.Complete ();

			}
			shake = transform.DOShakePosition (1f);


			if (ScreenShakeTween != null && ScreenShakeTween.IsPlaying ()) {

				ScreenShakeTween.Complete ();

			}
			ScreenShakeTween = Camera.main.transform.DOShakePosition (0.1f);


		}
	}
}
