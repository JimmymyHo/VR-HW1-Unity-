using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {

	Shoot shootScript;
	public GameObject me;
	public float moveSpeed;
	public int HP;
	public float disappearTimer;
	float hurtTimer = 1.2f;

	bool attack = false;

	// Use this for initialization
	void Start () {
		me = GameObject.FindGameObjectWithTag ("Player");
		shootScript = me.GetComponent<Shoot>();
	}
	
	// Update is called once per frame
	void Update () {

		if (HP >= 0) {
			if(!attack){
				Vector3 moveDirection = (me.transform.position - this.transform.position).normalized;
				this.transform.position += moveDirection * moveSpeed;
				this.transform.LookAt (me.transform.position);
				this.animation.Play ("Run");
			}

			if((this.transform.position - me.transform.position).magnitude < 1.5f){
				//			Vector3 moveDirection = (me.transform.position - this.transform.position).normalized;
				//			me.transform.position += moveDirection * moveSpeed * 10;
				attack = true;
				this.transform.LookAt (me.transform.position);
				this.animation.Play ("Attack_01");
				//Debug.Log(this.animation.IsPlaying("Attack_01"));
				hurtTimer -= Time.deltaTime;
				if(hurtTimer < 0){
					shootScript.HP--;
					hurtTimer = 1.2f;
				}

			}else {
				attack = false;
			}
		}
		else{
			disappearTimer -= Time.deltaTime;
			if(disappearTimer<0){
				GameObject.Destroy(this.gameObject);
			}
		}

	}

	bool killed=false;

	public void hurt (){
		HP--;
		if (HP < 0 && !killed) {
			killed=true;
			this.animation["Die"].wrapMode = WrapMode.ClampForever;
			this.animation.Play ("Die");
			//this.animation.CrossFade(null);
			//GameObject.Destroy(this.gameObject);		
		}
	}
}
