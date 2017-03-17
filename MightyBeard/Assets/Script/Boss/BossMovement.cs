using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BossColorStatus))]
public class BossMovement : MonoBehaviour {

    [SerializeField]
    private float movementRate = 4f;

    [SerializeField]
    private float speed = 50f;

    [SerializeField]
    private float ClampXDir = 45f;

    private GameObject target;

    private BossColorStatus color;

    private Rigidbody2D rb;

    private float timer;

    private float playerOldPosX;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        color = GetComponent<BossColorStatus>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update () {

        Move();

        if(Time.time > timer)
        {
            timer = Time.time + movementRate;
            playerOldPosX = target.transform.position.x;
        }
        
       
    }

    private void Move()
    {
        Vector2 dest = new Vector2(playerOldPosX, transform.position.y);
        transform.position = Vector2.MoveTowards(rb.position, dest, speed * Time.deltaTime);

        

    }
}
