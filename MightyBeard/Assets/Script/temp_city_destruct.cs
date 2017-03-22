using UnityEngine;
using System.Collections;
using DG.Tweening;

public class temp_city_destruct : MonoBehaviour
{

    Tween attack;
    Tween ScreenShakeTween;
    Sequence flashseq;
    Color defaultCamColor;

    private int colorRan1;
    private int numChoose;
    private int colorRan2;
    private int colorRan3;
    private int colorRan4;
    private Color cor;
    private SpriteRenderer ren;
    [SerializeField]
    AudioSource destruct;
    // Use this for initialization

    void Start()
    {

        defaultCamColor = Camera.main.backgroundColor;

        ren = GetComponent<SpriteRenderer>();


    }

    void Update()
    {

        colorRan1 = Random.Range(0, 24);
        colorRan2 = Random.Range(0, 24);
        colorRan3 = Random.Range(0, 24);
        colorRan4 = Random.Range(0, 24);
        numChoose = Random.Range(0, 24);

        if (colorRan1 == numChoose)
        {

            ren.color = Color.red;

        }

        if (colorRan2 == numChoose)
        {

            ren.color = Color.green;

        }

        if (colorRan3 == numChoose)
        {

            ren.color = Color.yellow;

        }

        if (colorRan4 == numChoose)
        {

            ren.color = Color.blue;

        }
    }

    void OnCollisionEnter2D(Collision2D boom)
    {

        if (boom.collider.tag == "Bomb")
        {

            destruct.Play();
            if (attack != null && attack.IsPlaying())
            {

                attack.Complete();

            }
            attack = transform.DOShakePosition(5f);

            if (flashseq != null && flashseq.IsPlaying())
            {

                flashseq.Complete();
            }

            flashseq = DOTween.Sequence().Append(Camera.main.DOColor(Color.magenta, 0.1f)).Append(Camera.main.DOColor(defaultCamColor, 0.1f));

        }

    }
}
