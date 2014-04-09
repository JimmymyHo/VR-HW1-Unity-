using UnityEngine;
using System.Collections;

public class BasicBomb : MonoBehaviour
{
	public GameObject explosionPrefab;
	public float StartTime;
	public Vector3 velocity;

	public void changeVelocity(Vector3 v)
	{
		velocity = v;
	}

	void Start ()
	{
		StartTime = Time.time;
	}
	
	void FixedUpdate ()
	{
		transform.position += velocity * Time.deltaTime;
		if (Time.time - StartTime >= 2.0f)
		{
			GameObject explosionParticle = (GameObject)Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			explosionParticle.SetActive(true);
			Destroy(gameObject);
		}
	}

	void OnTriggerStay(Collider other)
	{
		float radius = 25.0f;
		float power = 150.0f;
		Vector3 explosionPos = other.transform.position;

		if (other.attachedRigidbody && other.name != "firstPlatform")
		{
			other.attachedRigidbody.AddForce(transform.forward * 25f);
			other.attachedRigidbody.AddExplosionForce(power, explosionPos, radius);
			GameObject explosionParticle = (GameObject)Instantiate(explosionPrefab, explosionPos, Quaternion.identity);
			explosionParticle.SetActive(true);
			Destroy(gameObject);
		}
	}
}
