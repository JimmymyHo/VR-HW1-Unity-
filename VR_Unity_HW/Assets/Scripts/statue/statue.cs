using UnityEngine;
using System.Collections;

public class statue : MonoBehaviour {

	public GameObject fireworksPrefab;
	public float StartTime;
	// Use this for initialization
	void Start ()
	{
		StartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((Time.time - StartTime) % 5 == 0)
		{
			GameObject fireworksParticle = (GameObject)Instantiate (fireworksPrefab, transform.position + 4 * transform.up, Quaternion.identity);
			fireworksParticle.SetActive (true);
		}
	}
}
