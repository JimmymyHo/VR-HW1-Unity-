using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	public AudioClip shootAudio;
	private AudioSource audioSource;
	public GameObject bombPrefab;
	public GameObject bulletPrefab;
	public GameObject fireParticle;
	public Light light1;
	public Light light2;
	public float fireRate = 1.0f;
	public int MAX_Num;
	public int Current_Num;
	public int HP;


	//public float timer;
	
	private float nextFire = 0.0f;
	private bool shooting = false;
	private int gunMode = 1;

	public GameObject[] bullets = new GameObject[3];
	public BasicBullet[] bulletsComp = new BasicBullet[3];
	
	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update ()
	{
		//use mouse to fire
		if (Input.GetButtonDown ("Fire1"))
			shooting = true;
		if (Input.GetButtonUp ("Fire1"))
			shooting = false;

		//use keyboard to turn on/off lights
		if (Input.GetKey ("7"))
			light1.intensity = 0.0f;
		else if (Input.GetKey("8"))
			light1.intensity = 0.4f;
		if (Input.GetKey ("9"))
			light2.intensity = 0.0f;
		else if (Input.GetKey("0"))
			light2.intensity = 0.4f;

		//use keyboard to change gun type
		if (Input.GetKey("1"))
			gunMode = 1;
		else if(Input.GetKey("2"))
			gunMode = 2;
		else if(Input.GetKey("3"))
			gunMode = 3;
		else if(Input.GetKey("4"))
			gunMode = 4;
		
		if (shooting)
		{
			if(gunMode == 1  && Time.time > nextFire)
			{

				fireParticle.SetActive(false);

				if(Current_Num < MAX_Num){
					audioSource.PlayOneShot(shootAudio);
					GameObject bullet = (GameObject)Instantiate(bulletPrefab,this.transform.position + this.transform.forward*2.5f + this.transform.up, Quaternion.identity);
					Current_Num++;
					
					//				BasicBullet bulletComp = bullet.GetComponent<BasicBullet>();
					//				bulletComp.changeMode(gunMode);
					//				bulletComp.changeVelocity(this.transform.forward * 20f);
					//				bulletComp.changeRight(this.transform.right * 20f);
					
					nextFire = Time.time + fireRate;
				}

			}
			else if(gunMode == 2)
			{
				fireParticle.SetActive(true);
			}
			else if(gunMode == 3  && Time.time > nextFire)
			{
				fireParticle.SetActive(false);
				audioSource.PlayOneShot(shootAudio);

				for (int i=0;i<3;i++)
				{
					bullets[i] = (GameObject)Instantiate(bulletPrefab,this.transform.position + this.transform.forward + this.transform.up, Quaternion.identity);
					bulletsComp[i] = bullets[i].GetComponent<BasicBullet>();
					bulletsComp[i].changeMode(gunMode);
				}

				bulletsComp[0].changeVelocity((this.transform.forward - this.transform.right) * 30f);
				bulletsComp[1].changeVelocity(this.transform.forward * 30f);
				bulletsComp[2].changeVelocity((this.transform.forward + this.transform.right) * 30f);
				
				nextFire = Time.time + fireRate;
			}
			else if(gunMode == 4  && Time.time > nextFire)
			{
				fireParticle.SetActive(false);
				audioSource.PlayOneShot(shootAudio);

				GameObject bomb = (GameObject)Instantiate(bombPrefab, this.transform.position + this.transform.forward + this.transform.up, Quaternion.identity);
				
				BasicBomb bombComp = bomb.GetComponent<BasicBomb>();
				bombComp.changeVelocity(this.transform.forward * 15f);

				nextFire = Time.time + fireRate;
			}
		}
		else
		{
			if(gunMode == 2)
			{
				fireParticle.SetActive(false);
			}
		}
	}
	
	void OnTriggerStay(Collider other)
	{
		//for Flamethrower
		if(gunMode == 2)
		{
			if (other.attachedRigidbody)
        	other.attachedRigidbody.AddForce(this.transform.forward * 50f);
		}
    }
}
