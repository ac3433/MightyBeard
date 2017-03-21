using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerColorChange : MonoBehaviour {

    [Serializable]
    public struct SpriteColors { public string name; public Sprite sprite; }

    public SpriteColors[] spriteColor;

    private Dictionary<string, Sprite> ColorSprite;

    private SpriteRenderer sprite;

    private string color;

    private bool SwitchControl = false;

	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        ColorSprite = new Dictionary<string, Sprite>();

        foreach(SpriteColors sc in spriteColor)
        {
            ColorSprite.Add(sc.name, sc.sprite);
        }

        SetSpriteColor("blue");
        color = "blue";
	}
	
	
	void Update ()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            SetSpriteColor(color = spriteColor[0].name);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            SetSpriteColor(color = spriteColor[1].name);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            SetSpriteColor(color = spriteColor[2].name);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            SetSpriteColor(color = spriteColor[3].name);
        }

    }

    public string GetColor()
    {
        return color;
    }

    public void SetSpriteColor(string color)
    {
        if (!ColorSprite.ContainsKey(color))
            return;

        sprite.sprite = ColorSprite[color];
    }
}
