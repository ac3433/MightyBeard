using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {

    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private float damge = 25f;

	private TrailRenderer tail;
	/*[SerializeField] Material s0;
	[SerializeField] Material s1;
	[SerializeField] Material s2;
	[SerializeField] Material s3;*/

    private Rigidbody2D rb;
    private PlayerProjectile pp;

    public string Color { set; get; }

    void Start()
    {
		tail = GetComponent<TrailRenderer> ();
        rb = GetComponent<Rigidbody2D>();
        pp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerProjectile>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.MovePosition(rb.position + Vector2.up * speed * Time.deltaTime);

		/*if(Input.GetKey(KeyCode.Alpha1))
		{
			tail.material = s0;
		}

		if(Input.GetKey(KeyCode.Alpha2))
		{
			tail.material = s1;
		}

		if(Input.GetKey(KeyCode.Alpha3))
		{
			tail.material = s2;
		}

		if(Input.GetKey(KeyCode.Alpha4))
		{
			tail.material = s3;
		}*/

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Boss") || other.gameObject.tag.Equals("Wall"))
        {
            if(other.gameObject.tag.Equals("Boss"))
            {
                BossHitState bhs = other.gameObject.GetComponent<BossHitState>();
                BossColorStatus bcs = other.gameObject.GetComponent<BossColorStatus>();

                if(bcs.color.Equals(Color))
                    bhs.decreaseHealth(damge);
            }
            pp.deactiveObject(this.gameObject);
            this.transform.position = transform.parent.transform.position;

            gameObject.SetActive(false);
        }
    }


}
