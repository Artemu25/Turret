using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public CharacterController controller;
    public float move_speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        if (controller.isGrounded)
        {
            controller.Move(transform.forward * vertical * move_speed * Time.deltaTime);
            controller.Move(transform.right * horizontal * move_speed * Time.deltaTime);
        }
        else
            controller.Move(Physics.gravity * Time.deltaTime);
    }
}
