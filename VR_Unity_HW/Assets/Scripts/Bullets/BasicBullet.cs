using UnityEngine;
using System.Collections;

public class BasicBullet : MonoBehaviour
{
	public float speed = 5.0f;
	public float DestroyTime = 10.0f;
	public Vector3 velocity;
	public Vector3 striaght;
	public Vector3 right;
	public int flag = 1;
	
	public void changeMode(int mode)
	{
		flag = mode;
		transform.Rotate(62 * transform.up);
	}
	public void changeVelocity(Vector3 v)
	{
		velocity = v;
		striaght = v;
	}
	public void changeRight(Vector3 r)
	{
		right = r;
	}

	void Start ()
	{
		Destroy (gameObject, DestroyTime);
	}


	void FixedUpdate ()
	{
		if (flag == 1)
		{
			transform.Translate(right * Time.deltaTime);
			transform.Rotate(40 * striaght * Time.deltaTime);
		}
		transform.position += velocity * Time.deltaTime;
		striaght += striaght * Time.deltaTime;
	}
	
}
