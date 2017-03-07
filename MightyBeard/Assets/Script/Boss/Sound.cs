using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

    [SerializeField]
    private float damage = 20f;

    [SerializeField]
    private float expandSpeed = 2f;

    public string color;

    void Update()
    {
        transform.localScale += new Vector3(expandSpeed, expandSpeed, 0) * Time.deltaTime;

    }

    //sooo many redundant code!! I HATE THIS, but too tired to think.
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            PlayerStatus ps = other.GetComponent<PlayerStatus>();

            ps.decreaseHealth(damage);

            transform.localPosition = Vector3.zero;
            transform.localScale = new Vector3(1, 1, 1);
            gameObject.SetActive(false);
        }

        if(other.gameObject.tag.Equals("SpecialWall"))
        {
            transform.localPosition = Vector3.zero;
            transform.localScale = new Vector3(1, 1, 1);
            gameObject.SetActive(false);
        }

        if(other.gameObject.tag.Equals("Bullet"))
        {
            Projectile p = other.gameObject.GetComponent<Projectile>();

            if(color.Equals(p.Color))
            {
                transform.localPosition = Vector3.zero;
                transform.localScale = new Vector3(1, 1, 1);
                gameObject.SetActive(false);
            }
        }
    }
}
