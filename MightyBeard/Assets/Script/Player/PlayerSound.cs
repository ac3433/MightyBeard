using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerSound : MonoBehaviour {

    [Serializable]
    public struct SpriteColors { public string name; public Sprite sprite; public AudioClip ac; }

    public SpriteColors[] spriteColor;

    private Dictionary<string, Sprite> ColorSprite;
    private Dictionary<string, AudioClip> AudioClip;
    private SpriteRenderer sprite;
    public GameObject sound;
    public Transform spawn;
    private PlayerColorChange color;
    private AudioSource audioSource;

    public float rateoffire = 1f;

    void Start () {
        sprite = GetComponent<SpriteRenderer>();
        ColorSprite = new Dictionary<string, Sprite>();
        color = GetComponent<PlayerColorChange>();
        AudioClip = new Dictionary<string, UnityEngine.AudioClip>();
        audioSource = GetComponent<AudioSource>();

        foreach (SpriteColors sc in spriteColor)
        {
            ColorSprite.Add(sc.name, sc.sprite);
        }

        foreach (SpriteColors sc in spriteColor)
        {
            AudioClip.Add(sc.name, sc.ac);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
            Produce1();
    }

    void Produce1()
    {
        GameObject sr = (GameObject)Instantiate(sound, spawn.position, Quaternion.identity);
        sr.GetComponent<SpriteRenderer>().sprite = ColorSprite[color.GetColor()];
        sr.GetComponent<SoundP>().color = color.GetColor();
        AudioClip cs = AudioClip[color.GetColor()];
        audioSource.PlayOneShot(cs);
    }

    //void Produce()
    //{
    //    SoundP s = sound.GetComponent<SoundP>();
    //    SpriteRenderer sr = sound.GetComponent<SpriteRenderer>();
    //    sound.transform.position = this.gameObject.transform.position;
    //    string c = color.GetColor();

    //    if (c.Equals("white"))
    //        return;

    //    s.color = c;
    //    sr.sprite = ColorSprite[c];
    //    sound.SetActive(true);
    //}
}
