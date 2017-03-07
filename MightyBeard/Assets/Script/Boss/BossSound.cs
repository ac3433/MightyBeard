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

    public Transform soundSpawnLoc;

    public float minRate;
    public float maxRate;

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

    }
}
