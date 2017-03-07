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

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        color = GetComponent<BossColorStatus>();
    }
	
	void Update () {
	    if(string.IsNullOrEmpty(color.color))
        {

        }

	}
}
