using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlayerColorChange : MonoBehaviour {

    [Serializable]
    public struct SpriteColors { public string name; public Sprite sprite; }

    public SpriteColors[] spriteColor;

    private Dictionary<string, Sprite> ColorSprite;

	void Start ()
    {

        ColorSprite = new Dictionary<string, Sprite>();

        foreach(SpriteColors sc in spriteColor)
        {
            ColorSprite.Add(sc.name, sc.sprite);
        }
	}
	
	
	void Update ()
    {

    }
}
