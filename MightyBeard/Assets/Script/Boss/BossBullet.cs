using UnityEngine;
using System.Collections;

public class BossBullet : MonoBehaviour {

    [SerializeField]
    private float speed = 1f;

    private Rigidbody2D rb;

    private BossShooting bs;

    private Vector3 target;

    public float damage = 15f;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        bs = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossShooting>();
	}
	
	// Update is called once per frame
	void Update () {
        //rb.MovePosition(rb.position + Vector2.down * speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") || other.gameObject.tag.Equals("Wall") || other.gameObject.tag.Equals("City"))
        {
            bs.disableBullet(this.gameObject);
            this.transform.position = transform.parent.transform.position;

            if(other.gameObject.tag.Equals("Player"))
            {
                PlayerStatus ps = other.gameObject.GetComponent<PlayerStatus>();
                ps.decreaseHealth(damage);
            }


            gameObject.SetActive(false);
        }
    }

    public void SetDirection(Vector3 r)
    {
        target = r;
    }
}
