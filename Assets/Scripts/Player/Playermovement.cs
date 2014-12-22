using UnityEngine;
using System.Collections;

public class Playermovement : MonoBehaviour {
	private float maxTop = 11f;
	private float maxBot = -9f;
	private int speed = 15;
	public float movingSpeed;
	public int playerNumber = 0;
	public KeyCode up,down;
	private bool assigment = false;
	public bool CPU = false;
	private int difficultySpeed;

	void Start(){
		if(Global.Vs == "Computer"){
			if(Global.Difficulty == "Hard"){
				difficultySpeed = 40;
				speed = 50;
			}else{
				difficultySpeed = 30;
				speed = 25;
			}
		}else{
			difficultySpeed = 20;
			speed 			= 20;
		}
		movingSpeed = difficultySpeed;
		GetAssigment();
	}
	void Update () {
		if(CPU == false){
			PlayerControlls(up,down);
		}else{
			Computer();
		}


	}

	void Movement(string Direction, int speed,Transform character){
		if(Direction == "up"){
			if(character.position.y < maxTop){
				character.Translate(0,speed * Time.deltaTime,0);
		
			}
		}else if(Direction == "down"){
			if(character.position.y > maxBot){
				character.Translate(0,-speed * Time.deltaTime,0);

			}

		}
	}

	void PlayerControlls(KeyCode chosenUp,KeyCode chosenDown){
		if(Input.GetKey(chosenUp)){
			Movement("up",speed,transform);
			movingSpeed += 20 * Time.deltaTime;
		}else if(Input.GetKey(chosenDown)){
			Movement("down",speed,transform);
			movingSpeed += 20 * Time.deltaTime;
		}
		if(Input.GetKeyUp(chosenUp) || Input.GetKeyUp(chosenDown)){
			movingSpeed = difficultySpeed;
		}
	}

	void GetAssigment(){
		if(assigment == false){
			if(Global.PlayerCount.Count != 0){
				playerNumber = Global.PlayerCount[0];
				Global.PlayerCount.RemoveAt(0);
				assigment = true;
				SetButtons();
			}else{
				CPU = true;
			}
		}
	}

	void SetButtons(){
		if(assigment == true){
			if(playerNumber == 1){
				up 			= KeyCode.W;
				down 		= KeyCode.S;

			}
			if(Global.Vs == "Player"){
				if(playerNumber == 2){
					up 		= KeyCode.UpArrow;
					down 	= KeyCode.DownArrow;
				}
				if(playerNumber == 3){
					up 		= KeyCode.Keypad9;
					down 	= KeyCode.Keypad6;
				}
			}else if(Global.Vs == "Computer" && playerNumber != 1){
				CPU = true;
				if(Global.Difficulty == "Hard"){
					speed = 40;
				}
			}
		}
	}

	void Computer(){
		GameObject Ball = GameObject.Find("Ball");
		if(Ball != null){
			float BallY = Ball.transform.position.y;
			float BallX = Ball.transform.position.x;
			if(BallX > transform.position.x - 10 && Ball.GetComponent<BallPhysics>().directionX == false){
				if(BallY - transform.position.y > 1 + (Random.Range(0,3) / 10)|| BallY - transform.position.y < -1 - (Random.Range(0,3) / 10)){
					if(BallY <= transform.position.y){	
						Movement("down",speed,transform);
					}else{
						Movement("up",speed,transform);
					}
				}
			}
		}
	}
}
