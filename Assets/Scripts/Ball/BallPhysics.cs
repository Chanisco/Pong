﻿using UnityEngine;
using System.Collections;

public class BallPhysics : MonoBehaviour {
	private float maxTop = 12.5f;
	private float maxBot = -11f;
	private float speedX = 5;
	private float speedY = 5;

	//true == Left false == right
	public bool directionX;
	public bool directionY;
	public bool goingBack;

	public float volumeSFX;
	public AudioClip SFX1,SFX2,SFX3,SFX4,SFX5;

	
	void Update () {
		if(goingBack == false){
			Movement(directionX,directionY);
			HittingBorders();
		}
		CheckPoints();

	}

	void OnTriggerEnter(Collider col){
		if(col.collider.name == "Player"){
			CollideSound();
			float playerY = col.collider.transform.position.y;
			float difference = transform.position.y - playerY;
			float altitude;
			if(difference > 0.9f || difference < -0.9f){
				altitude = 1;
			}else if(difference > 0.5f || difference < -0.5f){
				altitude = 0.5f;
			}else{
				altitude = 0.1f;
			}
			ChangeXDirection();
		
			speedX = col.collider.GetComponent<Playermovement>().movingSpeed;
			speedY = speedX * altitude;
		}
	}

	void Movement(bool dirX,bool dirY){
		if(dirX){
			transform.Translate(-speedX * Time.deltaTime,0,0);
		}else{
			transform.Translate(speedX * Time.deltaTime,0,0);
		}
		if(dirY){
			transform.Translate(0,-speedY * Time.deltaTime,0);
		}else{
			transform.Translate(0,speedY * Time.deltaTime,0);
		}
	}

	void ChangeXDirection(){
		if(directionX){
			directionX = false;
		}else{
			directionX = true;
		}


	}

	void HittingBorders(){
		if(transform.position.y > maxTop){
			directionY = true;
		}
		if(transform.position.y < maxBot){
			directionY = false;
		}
	}

	void CheckPoints(){
		if(transform.position.x > 23){
			if(goingBack == false){
				goingBack = true;
				Global.RightPoints += 1;
			}
		}

		if(transform.position.x < -23){
			if(goingBack == false){
				goingBack = true;
				Global.LeftPoints += 1;
			}
		}

		if(goingBack == true){
			Management.ball = false;
			goingBack = false;
			GameObject.Destroy(gameObject);
		}
	}

	void CollideSound(){
		int switchStatement = Random.Range(1,5);
		switch(switchStatement){
		case 1:
			AudioSource.PlayClipAtPoint(SFX1,new Vector3(0,0,0),volumeSFX);
			break;
		case 2:
			AudioSource.PlayClipAtPoint(SFX2,new Vector3(0,0,0),volumeSFX);
			break;
		case 3:
			AudioSource.PlayClipAtPoint(SFX3,new Vector3(0,0,0),volumeSFX);
			break;
		case 4:
			AudioSource.PlayClipAtPoint(SFX4,new Vector3(0,0,0),volumeSFX);
			break;
		case 5:
			AudioSource.PlayClipAtPoint(SFX5,new Vector3(0,0,0),volumeSFX);
			break;
		}
		
	}
}
