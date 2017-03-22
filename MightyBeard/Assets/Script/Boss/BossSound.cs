using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BossSound : MonoBehaviour {

    [Serializable]
    public struct SpriteColors { public string name; public Sprite sprite; public AudioClip AC; }

    public SpriteColors[] spriteColor;

    private Dictionary<string, Sprite> ColorSprite;
    private Dictionary<string, AudioClip> audioClip;
    private SpriteRenderer sprite;

    public float minRate;
    public float maxRate;
    public GameObject sound;
    public Transform spawn;
    private BossColorStatus color;
    private BossHitState bhs;
    private float timer;

    private List<string> colorList;

    private AudioSource AS;

    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        ColorSprite = new Dictionary<string, Sprite>();
        audioClip = new Dictionary<string, AudioClip>();
        color = GetComponent<BossColorStatus>();
        bhs = GetComponent<BossHitState>();

        foreach (SpriteColors sc in spriteColor)
        {
            ColorSprite.Add(sc.name, sc.sprite);
        }

        foreach (SpriteColors sc in spriteColor)
        {
            audioClip.Add(sc.name, sc.AC);
        }

        colorList = new List<string>(ColorSprite.Keys);//terrible way
        AS = GetComponent<AudioSource>();
        timer = Time.time + 10f;
    }
	

	void Update () {

        if (Time.time > timer)
        {
            timer = Time.time + UnityEngine.Random.Range(minRate, maxRate);
                Produce1();
        }
	}



    void Produce1()
    {
        if (color.color.Equals("white"))
        {
            GameObject sr = (GameObject)Instantiate(sound, spawn.position, Quaternion.identity);
            sr.GetComponent<SpriteRenderer>().sprite = ColorSprite["grey"];
            string c = colorList[UnityEngine.Random.Range(0, colorList.Count - 2)];
            sr.GetComponent<Sound>().color = c;
            AS.PlayOneShot(audioClip[c]);
        }
        else
        {
            GameObject sr = (GameObject)Instantiate(sound, spawn.position, Quaternion.identity);
            sr.GetComponent<SpriteRenderer>().sprite = ColorSprite[color.color];
            sr.GetComponent<Sound>().color = color.color;
            AS.PlayOneShot(audioClip[color.color]);
        }
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
