using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BossSound : MonoBehaviour {

    [Serializable]
    public struct SpriteColors { public string name; public Sprite sprite; }

    public SpriteColors[] spriteColor;

    private Dictionary<string, Sprite> ColorSprite;
    private SpriteRenderer sprite;

    public float minRate;
    public float maxRate;
    public GameObject sound;
    private BossColorStatus color;
    private float timer;

    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        ColorSprite = new Dictionary<string, Sprite>();
        color = GetComponent<BossColorStatus>();

        foreach (SpriteColors sc in spriteColor)
        {
            ColorSprite.Add(sc.name, sc.sprite);
        }

        timer = Time.time + 10f;
    }
	

	void Update () {

        

        if (Time.time > timer)
        {
            timer = Time.time + UnityEngine.Random.Range(minRate, maxRate);
            Produce();
        }
	}

    void Produce()
    {
        Sound s = sound.GetComponent<Sound>();
        SpriteRenderer sr = sound.GetComponent<SpriteRenderer>();
        sound.transform.position = this.gameObject.transform.position;
        string c = color.color;

        s.color = c;
        sr.sprite = ColorSprite[c];
        sound.SetActive(true);
    }
}
