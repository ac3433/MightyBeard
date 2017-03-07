using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class BossColorStatus : MonoBehaviour {

    public string color { set; get; }

    [Serializable]
    public struct Colors { public string name; public Sprite sprite; }

    public Colors[] sprites;

    [SerializeField]
    private float minRate = 2f;
    [SerializeField]
    private float maxRate = 5f;

    private Dictionary<string, Sprite> spriteColor;

    private SpriteRenderer sr;
    private float timer;


    void Start () {

        sr = GetComponent<SpriteRenderer>();
        spriteColor = new Dictionary<string, Sprite>();

        foreach(Colors sp in sprites)
        {
            spriteColor.Add(sp.name, sp.sprite);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (string.IsNullOrEmpty(color))
        //    return;

        if(Time.time > timer)
        {
            timer = Time.time + UnityEngine.Random.Range(minRate, maxRate);
            color = sprites[UnityEngine.Random.Range(0, sprites.Length - 1)].name;
            ChangeColor(color);
        }
	}

    public void ChangeColor(string color)
    {
        if(spriteColor.ContainsKey(color))
        {
            sr.sprite = spriteColor[color];
        }
    }

    public void ChangeSpriteColor(Dictionary<string, Sprite> update)
    {
        spriteColor = update;
    }

}
