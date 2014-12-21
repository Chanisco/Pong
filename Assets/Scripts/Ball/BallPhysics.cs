using UnityEngine;
using System.Collections;

public class BallPhysics : MonoBehaviour {
	private float maxTop = 5f;
	private float maxBot = -4f;
	private float speed = 5;

	//true == Left false == right
	public bool directionX;
	public bool directionY;
	public bool goingBack;

	void Update () {
		if(goingBack == false){
			Movement(directionX,directionY);
			HittingBorders();
		}
		CheckPoints();

	}

	void OnCollisionEnter(Collision col){
		ChangeXDirection();
		speed = col.collider.GetComponent<Playermovement>().movingSpeed;
	}

	void Movement(bool dirX,bool dirY){
		if(dirX){
			transform.Translate(-speed * Time.deltaTime,0,0);
		}else{
			transform.Translate(speed * Time.deltaTime,0,0);
		}
		if(dirY){
			transform.Translate(0,-speed * Time.deltaTime,0);
		}else{
			transform.Translate(0,speed * Time.deltaTime,0);
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
		if(transform.position.x > 10){
			if(goingBack == false){
				goingBack = true;
				Global.LeftPoints += 1;
			}
		}
		if(transform.position.x < -10){
			if(goingBack == false){
				goingBack = true;
				Global.RightPoints += 1;
			}
		}
		if(goingBack == true){
			Goto (new Vector2(0,0));
		}
	}
	void Goto(Vector2 newPosition){
		transform.collider.isTrigger = true;
		if(transform.position.x < newPosition.x){
			transform.Translate(10 * Time.deltaTime,0,0);
			if(transform.position.x > newPosition.x){
				Invoke("ReturnToNormal",3);
			}
		}else if(transform.position.x > newPosition.x){
			transform.Translate(-10 * Time.deltaTime,0,0);
			if(transform.position.x < newPosition.x){
				Invoke("ReturnToNormal",3);
			}
		}
		if(transform.position.y > newPosition.y){
			transform.Translate(0,-10 * Time.deltaTime,0);
		}
		if(transform.position.y < newPosition.y){
			transform.Translate(0,10 * Time.deltaTime,0);
		}
	}

	void ReturnToNormal(){
		transform.collider.isTrigger = false;
		speed = 5;
		goingBack = false;
	}
}
