using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;

public class BossHitState : MonoBehaviour {

	Tween shake;
	Tween ScreenShakeTween;
	[SerializeField] AudioSource gotHit;
    

    public float health = 100f;
    public float darkThreshold = 15f;

    private float darkCheck;

	public ParticleSystem hairps;

    [Serializable]
    public struct Short { public string name; public Sprite sprite; }
    [Serializable]
    public struct Med { public string name; public Sprite sprite; }
    [Serializable]
    public struct None { public string name; public Sprite sprite; }

    public DarkMechanic dm;

    public Short[] s;
    public Med[] m;
    public None[] n;

    public Transform medCannon1;
    public Transform medCannon2;
    public Transform shortCannon1;
    public Transform shortCannon2;

    public GameObject cannon1;
    public GameObject cannon2;

    private BoxCollider2D collider;


    private Dictionary<string, Sprite> shortFace;
    private Dictionary<string, Sprite> medFace;
    private Dictionary<string, Sprite> noneFace;

    bool updates = false;

    private BossColorStatus bcc;

    public Image imageHealth;

	void Start () {

		//hairps = GetComponent<ParticleSystem> ();
        shortFace = new Dictionary<string, Sprite>();
        medFace = new Dictionary<string, Sprite>();
        noneFace = new Dictionary<string, Sprite>();
        bcc = GetComponent<BossColorStatus>();
        collider = GetComponent<BoxCollider2D>();

        darkCheck = darkThreshold;
        foreach(Short st in s)
        {
            shortFace.Add(st.name, st.sprite);
        }

        foreach(Med mt in m)
        {
            medFace.Add(mt.name, mt.sprite);
        }

        foreach (None nt in n)
        {
            noneFace.Add(nt.name, nt.sprite);
        }
    }
	
	// Update is called once per frame
	void Update () {

        if(darkCheck < 0)
        {
            dm.setDark(false);
            darkCheck = darkThreshold;
        }

        if(health < 0)
        {
            GetComponent<BossMovement>().enabled = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<BossShooting>().enabled = false;
            GetComponent<BossSound>().enabled = false;
            GetComponent<BossHitState>().enabled = false;
            Physics2D.gravity = new Vector2(0, -9.8f);
            dm.enabled = false;
        }

        else if(health < 25)
        {
            bcc.ChangeSpriteColor(noneFace);
        }
        else if (health < 50)
        {
            bcc.ChangeSpriteColor(shortFace);
            collider.size = new Vector2(collider.size.x, 5);
            cannon1.transform.position = shortCannon1.position;
            cannon2.transform.position = shortCannon2.position;
        }
        else if (health < 75)
        {
            bcc.ChangeSpriteColor(medFace);
            collider.size = new Vector2(collider.size.x, 15);
            cannon1.transform.position = medCannon1.position;
            cannon2.transform.position = medCannon2.position;

        }

	}


    public void decreaseHealth(float num)
    {
        if (dm.getDarkState())
        {
            darkCheck -= num;
            if (darkCheck > darkThreshold)
                darkCheck = darkThreshold;
        }
        else
        {
            health -= num;
            if (health > 100)
                health = 100;
            imageHealth.fillAmount = (health * .01f);
        }
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
