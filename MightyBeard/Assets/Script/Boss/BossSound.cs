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
    public Transform spawn;
    private BossColorStatus color;
    private BossHitState bhs;
    private float timer;

    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        ColorSprite = new Dictionary<string, Sprite>();
        color = GetComponent<BossColorStatus>();
        bhs = GetComponent<BossHitState>();

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
            if(bhs.health < 25)
            {
                spawner();
                spawner();
                spawner();
            }
            else if(bhs.health < 50)
            {
                spawner();
                spawner();
                
            }
            else
                Produce1();

        }
	}

    IEnumerator spawner()
    {
        Produce1();
        yield return new WaitForSeconds(1);
    }

    void Produce1()
    {
        if (color.color.Equals("white"))
            return;

        GameObject sr = (GameObject)Instantiate(sound, spawn.position, Quaternion.identity);
        sr.GetComponent<SpriteRenderer>().sprite = ColorSprite[color.color];
        sr.GetComponent<Sound>().color = color.color;
    }

    //void Produce()
    //{
    //    Sound s = sound.GetComponent<Sound>();
    //    SpriteRenderer sr = sound.GetComponent<SpriteRenderer>();
    //    sound.transform.position = this.gameObject.transform.position;
    //    string c = color.color;

    //    if (c.Equals("white"))
    //        return;

    //    s.color = c;
    //    sr.sprite = ColorSprite[c];
    //    sound.SetActive(true);
    //}
}
