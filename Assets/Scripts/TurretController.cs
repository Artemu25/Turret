using UnityEngine;
using System.Collections;
using System;

public class TurretController : MonoBehaviour {

    private float nextFire;
    private float deltaTime = 0.25f;

    public LineRenderer laserLine;
    public Transform gunEnd;
    private bool isActive = false;

    // Use this for initialization
    void Start () {
        laserLine.SetPosition(0, gunEnd.position);
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
        laserLine.enabled = true;

        yield return new WaitForSeconds(0.07f);

        laserLine.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        isActive = true;
        laserLine.enabled = true;
    }

    void OnTriggerExit(Collider other)
    {
        isActive = false;
        laserLine.enabled = false;
    }

    public void ChangeTarget(Vector3 target)
    {
        if (isActive)
        {
            laserLine.SetPosition(1, target);
        }
    }
}
