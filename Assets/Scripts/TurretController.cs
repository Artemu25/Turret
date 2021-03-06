﻿using UnityEngine;
using System.Collections;
using System;

public class TurretController : MonoBehaviour {

    private float nextFire;
    private float deltaTime = 0.25f;

    public LineRenderer laserPointer, laserShoot;
    public Transform gunEnd;
    private bool isActive = false;
    public GameObject turrelGun;
    private Vector3 vec;
    private Vector3 target;
    public Transform TestTarget;
    public GameObject m_shotPrefab;

    // Use this for initialization
    void Start () {
        laserPointer.SetPosition(0, gunEnd.position);
        vec = gunEnd.transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(turrelGun.transform.localEulerAngles);
        //Debug.Log("ROT " + turrelGun.transform.eulerAngles);
        //Debug.Log(TestTarget.localPosition);
        
        //turrelGun.transform.localRotation = Quaternion.FromToRotation(transform.forward, transform. target - turrelGun.transform.position);
        
    }

    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + deltaTime;
            StartCoroutine(ShotEffect());
            RaycastHit hit;
            laserShoot.SetPosition(0, gunEnd.position);
            if (Physics.Raycast(gunEnd.position, gunEnd.forward, out hit))
            {
                laserShoot.SetPosition(1, target);
                GameObject go = GameObject.Instantiate(m_shotPrefab, gunEnd.position, laserShoot.transform.rotation) as GameObject;
                GameObject.Destroy(go, 3f);
            }
            else
            {
                laserShoot.SetPosition(1, gunEnd.position + gunEnd.forward * 50);
                GameObject go = GameObject.Instantiate(m_shotPrefab, gunEnd.position, laserShoot.transform.rotation) as GameObject;
                GameObject.Destroy(go, 3f);
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        //laserShoot.enabled = true;

        yield return new WaitForSeconds(0.07f);

        laserShoot.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isActive = true;
            laserPointer.enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isActive = false;
            laserPointer.enabled = false;
        }
    }

    //Problem method
    public void ChangeTarget(Vector3 target)
    {
        if (isActive)
        {
            this.target = target;

            //Working code
            /*turrelGun.transform.rotation = Quaternion.LookRotation(target - turrelGun.transform.position);
            Vector3 v = turrelGun.transform.localEulerAngles;
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
            turrelGun.transform.localRotation = Quaternion.Euler(v);*/


            //Not working. Why?

            //turrelGun.transform.localRotation = Quaternion.FromToRotation(transform.forward, target - turrelGun.transform.position);

            turrelGun.transform.localRotation = Quaternion.FromToRotation(new Vector3(0,0,1),  transform.worldToLocalMatrix.MultiplyVector(target - turrelGun.transform.position));
            

            laserPointer.SetPosition(0, turrelGun.transform.position);
            laserPointer.SetPosition(1, target);
        }
    }
}
