using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public CharacterController controller;
    public float move_speed;
    private float currentY;
    public float speedRotate = 180;
    public float minY = -20;
    public float maxY = 20;
    public RayCast gun;
    public TurretController turret;

    // Use this for initialization
    void Start () {
        currentY = Camera.main.transform.eulerAngles.x;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");

        if (Input.GetKeyDown(KeyCode.L))
        {
            turret.Shoot();
        }

        if (controller.isGrounded)
        {
            controller.Move(transform.forward * vertical * move_speed * Time.deltaTime);
            controller.Move(transform.right * horizontal * move_speed * Time.deltaTime);
        }
        else
        {
            controller.Move(Physics.gravity * Time.deltaTime);
        }
     
        transform.Rotate(transform.up * mx * speedRotate * Time.deltaTime);
        currentY = Mathf.Clamp(currentY - my * speedRotate * Time.deltaTime, minY, maxY);
        Vector3 camrot = Camera.main.transform.rotation.eulerAngles;
        Camera.main.transform.rotation = Quaternion.Euler(currentY, camrot.y, camrot.z);
        //Camera.main.transform.Rotate(Camera.main.transform.right * my * speedRotate * Time.deltaTime);


        if (Input.GetMouseButton(0))
        {
            gun.Shoot();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        gun.turrets.Add(other.gameObject);
        gun.SwitchToLaser();
    }

    void OnTriggerExit(Collider other)
    {
        gun.turrets.Remove(other.gameObject);
        if (gun.turrets.Count==0) {
            gun.SwitchToShooting();
        }
    }


}
