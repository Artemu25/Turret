using UnityEngine;
using System.Collections;
using System;

public class TurretController : MonoBehaviour {

    private float nextFire;
    private float deltaTime = 0.25f;

    public LineRenderer laserPointer;
    public Transform gunEnd;
    private bool isActive = false;
    public GameObject turrelGun;

    // Use this for initialization
    void Start () {
        laserPointer.SetPosition(0, gunEnd.position);
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public void Shoot()
    {
        /*if (Time.time > nextFire)
        {
            nextFire = Time.time + deltaTime;
            StartCoroutine(ShotEffect());
            RaycastHit hit;
            laserLine.SetPosition(0, gunEnd.position);
            if (Physics.Raycast(gunEnd.position, gunEnd.forward, out hit))
            {
                laserLine.SetPosition(1, gun.LaserTarget);
            }
            else
            {
                laserLine.SetPosition(1, gunEnd.position + gunEnd.forward * 50);
            }
        }*/
    }

    private IEnumerator ShotEffect()
    {
        laserPointer.enabled = true;

        yield return new WaitForSeconds(0.07f);

        laserPointer.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        isActive = true;
        laserPointer.enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        isActive = false;
        laserPointer.enabled = false;
    }

    public void ChangeTarget(Vector3 target)
    {
        if (isActive)
        {
            Vector3 v = Quaternion.FromToRotation(new Vector3(0, 0, 1), target - turrelGun.transform.position).eulerAngles;
            v.z = 0;
            Debug.Log(v.x + " " + v.y);
            if (v.x > 180)
            {
                v.x = v.x - 360;
            }
            if (v.y > 180)
            {
                v.y = v.y - 360;
            }

            v.x = Mathf.Clamp(v.x, -30, 30);
            v.y = Mathf.Clamp(v.y, -45, 45);
            turrelGun.transform.rotation = Quaternion.Euler(v);
            laserPointer.SetPosition(0, gunEnd.position);
            laserPointer.SetPosition(1, target);
        }
    }
}
