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

        if (!string.IsNullOrEmpty(color.color))
        {
            if(Time.time > timer)
            {
                timer = Time.time + movementRate;
                playerOldPosX = target.transform.position.x;
            }
        }
       
    }

    private void Move()
    {
        Debug.Log(playerOldPosX);
        Vector2 dest = new Vector2(playerOldPosX, rb.position.y);
        rb.MovePosition(dest + Vector2.right  * speed * Time.deltaTime);
    }
}
