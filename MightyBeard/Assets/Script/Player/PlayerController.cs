using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 2f;

    private PlayerMotor motor;

	void Start () {
        motor = GetComponent<PlayerMotor>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float _xMov = Input.GetAxisRaw("Horizontal");

        Vector2 _velocity = new Vector2(_xMov, 0).normalized * speed;

        motor.Move(_velocity);
	}
}
