using UnityEngine;
using System.Collections;

public class BossBullet : MonoBehaviour {

    [SerializeField]
    private float speed = 1f;

    private Rigidbody2D rb;

    private BossShooting bs;   

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        bs = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossShooting>();
	}
	
	// Update is called once per frame
	void Update () {
        rb.MovePosition(rb.position + Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") || other.gameObject.tag.Equals("Wall"))
        {
            bs.disableBullet(this.gameObject);
            this.transform.position = transform.parent.transform.position;

            gameObject.SetActive(false);
        }
    }
}
