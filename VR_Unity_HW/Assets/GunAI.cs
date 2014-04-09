using UnityEngine;
using System.Collections;

public class GunAI : MonoBehaviour {

	public GameObject rotator;
	public GameObject me;
	public Shoot shootScript;
	//public ParticleSystem fireEffect;

	public GameObject shootPoint;
	public GameObject fireEffect;

	bool once = false;

	//public bool hello;

	// Use this for initialization
	void Start () {
		//fireEffect.Play();
		//fireEffect.loop = true;
		me = GameObject.FindGameObjectWithTag ("Player");
		shootScript = me.GetComponent<Shoot>();
	}

	float animationTimer = 1;

	public float timer;
	
	// Update is called once per frame
	void Update () {

		animationTimer -= Time.deltaTime;
		timer -= Time.deltaTime;

		if(timer<0 && !once){
			once = true;
			GameObject.Destroy(this.gameObject);
			shootScript.Current_Num--;
		}
		
		rotator.transform.Rotate (new Vector3 (0, 0, 1));

		RaycastHit hitinfo;

		if (Physics.Raycast (shootPoint.transform.position, shootPoint.transform.forward, out hitinfo,100)) //forward is Z direction
		{
			Debug.Log(hitinfo.collider.gameObject.name);

			MonsterAI ai = hitinfo.collider.gameObject.GetComponent<MonsterAI>();
			if(ai) {
				ai.hurt();

				GameObject newfireEffect = GameObject.Instantiate(fireEffect) as GameObject;
				newfireEffect.transform.position = shootPoint.transform.position;
				newfireEffect.transform.parent = shootPoint.transform;

			}



		}
		


	}
}
