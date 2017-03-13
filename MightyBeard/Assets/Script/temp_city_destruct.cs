using UnityEngine;
using System.Collections;
using DG.Tweening;

public class temp_city_destruct : MonoBehaviour {

	Tween attack;
	Tween ScreenShakeTween;
	Sequence flashseq;
	Color defaultCamColor;

	[SerializeField] AudioSource destruct;
	// Use this for initialization

	void Start(){

		defaultCamColor = Camera.main.backgroundColor;
	}

	void OnCollisionEnter2D (Collision2D boom){

		if(boom.collider.tag == "Bomb"){

			destruct.Play ();
			if (attack != null && attack.IsPlaying ()) {

				attack.Complete ();

			}
			attack = transform.DOShakePosition (5f);

			if (flashseq != null && flashseq.IsPlaying ()) {

				flashseq.Complete ();
			}

			flashseq = DOTween.Sequence ().Append (Camera.main.DOColor (Color.magenta, 0.1f)).Append (Camera.main.DOColor (defaultCamColor, 0.1f));

		}

	}
}
