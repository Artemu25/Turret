using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.forward * Time.deltaTime * 30f;	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
