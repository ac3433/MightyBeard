using UnityEngine;
using System.Collections;

public class RainPukeDamage : MonoBehaviour {

    private PlayerStatus ps;
    public float fallSpeed;
    public float damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            PlayerStatus ps = other.gameObject.GetComponent<PlayerStatus>();
            ps.decreaseHealth(damage);
        }
    }
}
