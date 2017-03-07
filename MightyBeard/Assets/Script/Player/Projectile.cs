using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {

    [SerializeField]
    private float speed = 2f;

    private Rigidbody2D rb;
    private PlayerProjectile pp;

    public string Color { set; get; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProjectile>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Boss") || other.gameObject.tag.Equals("Wall"))
        {
            pp.deactiveObject(this.gameObject);
            this.transform.position = transform.parent.transform.position;

            gameObject.SetActive(false);
        }
    }


}
