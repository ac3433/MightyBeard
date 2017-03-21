using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {

    [SerializeField]
    private float damage = 15f;

    [SerializeField]
    private float expandSpeed = 2f;

    public string color;

    private BossColorStatus bcs;
    private BossHitState bhs;

    void Update()
    {
        transform.localScale += new Vector3(expandSpeed, expandSpeed, 0) * Time.deltaTime;

        bcs = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossColorStatus>();
        bhs = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossHitState>();

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

        if(other.gameObject.tag.Equals("Sound"))
        {
            SoundP p = other.gameObject.GetComponent<SoundP>();

            if(color.Equals(p.color))
            {
                if(bcs.color.Equals("white"))
                {
                    bhs.setDarkMode();
                }


                Destroy(other.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
