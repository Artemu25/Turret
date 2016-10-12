using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {

    private LineRenderer laserLine;
    public Camera camera;
    private float nextFire;
    public Transform gunEnd;

    // Use this for initialization
    void Start () {
        laserLine = GetComponent<LineRenderer>();
	}
	
    public void Shoot()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + 0.25f;
            StartCoroutine(ShotEffect());
            Vector3 rayOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;
            laserLine.SetPosition(0, gunEnd.position);
            if (Physics.Raycast(rayOrigin, camera.transform.forward, out hit))
            {
                laserLine.SetPosition(1, hit.point);
            }
            else
            {
                laserLine.SetPosition(1, rayOrigin + (camera.transform.forward * 50));
            }
        }
    }

	// Update is called once per frame
	void Update () {
        Vector3 lineOrigin = camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        Debug.DrawRay(lineOrigin, camera.transform.forward * 50, Color.green);
    }

    private IEnumerator ShotEffect()
    {
        laserLine.enabled = true;

        yield return new WaitForSeconds(0.07f);

        laserLine.enabled = false;
    }
}
