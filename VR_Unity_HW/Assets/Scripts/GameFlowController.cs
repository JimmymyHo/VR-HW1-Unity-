using UnityEngine;
using System.Collections;

public class GameFlowController : MonoBehaviour 
{
	public int cubeNum;
	public GUIText winGUI;
	public GUIText loseGUI;
	public GameObject player;

	GameObject me;
	public Shoot shootScript;
	public UISlider HP_slider;
	public UISlider GUN_slider;

	//public MonoBehaviour controller;

	// Use this for initialization
	void Start () 
	{
		cubeNum = 10;
		this.guiText.text = "Cubes: " + cubeNum;

		me = GameObject.FindGameObjectWithTag ("Player");
		shootScript = me.GetComponent<Shoot>();
		//controller = me.GetComponent<MonoBehaviour>("ThirdPersonController");
	}
	
	// Update is called once per frame
	void Update () 
	{
//		if(cubeNum>0)
//			this.guiText.text = "Cubes: " + cubeNum;
//		else
//		{
//			winGUI.guiText.enabled = true;
//			this.guiText.enabled = false;
//		}

		if(shootScript.HP == 5){
			HP_slider.value = 1;
		}else if(shootScript.HP == 4){
			HP_slider.value = 0.8f;
		}else if(shootScript.HP == 3){
			HP_slider.value = 0.6f;
		}else if(shootScript.HP == 2){
			HP_slider.value = 0.4f;
		}else if(shootScript.HP == 1){
			HP_slider.value = 0.2f;
		}else {
			HP_slider.value = 0;
		}

		if(shootScript.Current_Num==3){
			GUN_slider.value = 0;
		}else if(shootScript.Current_Num==2){
			GUN_slider.value = 1 - 0.66f;
		}else if(shootScript.Current_Num==1){
			GUN_slider.value = 1 - 0.33f;
		}else {
			GUN_slider.value = 1;
		}
		
		if(player.transform.position.y < -3 || shootScript.HP<=0)
		{
//			player.SetActive(false);
			loseGUI.guiText.enabled = true;
			this.guiText.enabled = false;
		}
	}
}
