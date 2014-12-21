using UnityEngine;
using System.Collections;

public class Playermovement : MonoBehaviour {
	private float maxTop = 5f;
	private float maxBot = -3f;
	private int speed = 15;
	public float movingSpeed = 10;
	public int playerNumber = 0;
	private KeyCode up,down;
	private bool assigment = false;

	void Start(){
		movingSpeed = 10;
		GetAssigment();
	}
	void Update () {
		PlayerControlls(up,down);

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
			movingSpeed += 30 * Time.deltaTime;
		}else if(Input.GetKey(chosenDown)){
			Movement("down",speed,transform);
			movingSpeed += 30 * Time.deltaTime;
		}
		if(Input.GetKeyUp(chosenUp) || Input.GetKeyUp(chosenDown)){
			movingSpeed = 10;
		}
	}

	void GetAssigment(){
		if(Global.WantedPlayers > Global.PlayerCount.Count && assigment == false){
			playerNumber = Global.PlayerCount[0];
			Global.PlayerCount.RemoveAt(0);
			assigment = true;
			SetButtons();
		}
	}

	void SetButtons(){
		if(assigment == true){
			if(playerNumber == 1){
				up = KeyCode.W;
				down = KeyCode.S;
				
			}
			if(playerNumber == 2){
				up = KeyCode.UpArrow;
				down = KeyCode.DownArrow;
			}
		}
	}
}
