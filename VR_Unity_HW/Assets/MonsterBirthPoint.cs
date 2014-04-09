using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterBirthPoint : MonoBehaviour {

	public List<GameObject> monsterList;
	public float timer;
	float localTimer;

	// Use this for initialization
	void Start () {
		localTimer = timer;
		GameObject.Instantiate(monsterList[0],this.transform.position,Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		localTimer -= Time.deltaTime;
		if(localTimer<0){
			GameObject.Instantiate(monsterList[0],this.transform.position,Quaternion.identity);
			localTimer = timer;
		}

	}
}
