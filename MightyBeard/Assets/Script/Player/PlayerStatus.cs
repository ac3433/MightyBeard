using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PlayerStatus : MonoBehaviour {

	//Sequence flashseq;
	//Color defaultCamColor;

    [SerializeField]
    private float health = 100f;

	void Start(){

		//defaultCamColor = Camera.main.backgroundColor;

	}
	// Update is called once per frame
	void Update () {
	    if(health < 0)
        {
            Destroy(gameObject);
        }
	}

    public void decreaseHealth(float number)
    {
        health -= number;
    }

	// for screen flash but can't find the boss weapon
	/*void OnCollisionEnter2D (Collision2D col){

		//if (col.collider.tag == "Dandruff") {

			if ( flashseq != null && flashseq.IsPlaying ()) {

				flashseq.Complete ();
			}

			flashseq = DOTween.Sequence ().Append (Camera.main.DOColor (Color.white, 0.1f)).Append (Camera.main.DOColor (defaultCamColor, 0.1f));

		//}*/
	

}
