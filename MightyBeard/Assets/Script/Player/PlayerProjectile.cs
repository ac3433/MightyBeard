using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerColorChange))]
public class PlayerProjectile : MonoBehaviour
{
	
    [Serializable]
    public struct SpriteColors { public string name; public Sprite sprite; }

    public SpriteColors[] spriteColor;
    [SerializeField]
    private float fireRate = 2f;
    [SerializeField]
    private Transform bulletSpawnArea;

    private Dictionary<string, Sprite> ColorSprite;

    private PlayerColorChange playerColor;

    private List<GameObject> inactiveBullet;
    private List<GameObject> activeBullet;

    private float nextFire = 0f;


    void Start () {
        playerColor = GetComponent<PlayerColorChange>();

        inactiveBullet = new List<GameObject>();
        activeBullet = new List<GameObject>();

        ColorSprite = new Dictionary<string, Sprite>();

        foreach (SpriteColors sc in spriteColor)
        {
            ColorSprite.Add(sc.name, sc.sprite);
        }

        GameObject bulletSpawn = GameObject.FindGameObjectWithTag("PlayerBulletSpawn");

        foreach(Transform obj in bulletSpawn.GetComponentInChildren<Transform>())
        {
            inactiveBullet.Add(obj.gameObject);
        }

    }
	

	void Update () {

        if (playerColor.GetColor() == null)
            return;

        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Spawn();
        }

    }


    private void Spawn()
    {
        if (inactiveBullet.Count == 0)
            return;

        GameObject obj = inactiveBullet[0];

        obj.transform.position = bulletSpawnArea.position;
        obj.GetComponent<SpriteRenderer>().sprite = ColorSprite[playerColor.GetColor()];
        obj.GetComponent<Projectile>().Color = playerColor.GetColor();
        activeBullet.Add(obj);
        inactiveBullet.RemoveAt(0);
        obj.SetActive(true);
    }

    public void deactiveObject(GameObject obj)
    {
        if(activeBullet.Contains(obj))
        {
            inactiveBullet.Add(obj);
            activeBullet.Remove(obj);
        }
    }

}
