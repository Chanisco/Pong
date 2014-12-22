using UnityEngine;
using System.Collections;

public class Management : MonoBehaviour {
	Transform[] Pieces;
	private bool player1,player2,player3,player4,Enemy;
	public static bool ball = false;
	private GameObject _player;
	private GameObject _ball;


	void Awake () {
		_ball 	= Resources.Load("Ball") as GameObject;
		_player = Resources.Load("Player") as GameObject;
		Global.LeftPoints = 0;
		Global.RightPoints = 0;
		player1 = false;
		player2 = false;
		player3 = false;
		player4 = false;
		ball 	= false;
		Checks();
	}


	void Update(){
		if(ball == false){
			ball = true;
			Invoke("newBall",3);
		}
		if(Global.LeftPoints > 5){
			Application.LoadLevel("RightWins");
		}else if(Global.RightPoints > 5){
			Application.LoadLevel("LeftWins");
		}
	}

	public void Checks(){
		Transform[] Pieces = GetComponentsInChildren<Transform>();
		for(int i = 0;i < Pieces.Length + 1;i++){
			if(Pieces[i].name == "Player-1"){
				player1 = true;
			}	
			if(Pieces[i].name == "Player-2"){
				player2 = true;
			}
			if(Pieces[i].name == "Ball"){
				ball = true;
			}
			if(Pieces[Pieces.Length - 1]){
				if(Global.WantedPlayers == 3){
					if(player1 == false){
						_player = Instantiate(_player,new Vector3(-21f,0,0),Quaternion.identity) as GameObject;
						_player.transform.parent = transform;
						_player.name = "Player";
						player1 = true;
					}
					
					if(player2 == false){
						_player = Instantiate(_player,new Vector3(21f,0,0),Quaternion.identity) as GameObject;
						_player.transform.parent = transform;
						_player.name = "Player";
						player2 = true;
					}
				}else if(Global.WantedPlayers == 4){
					if(player1 == false){
						_player = Instantiate(_player,new Vector3(-21f,0,0),Quaternion.identity) as GameObject;
						_player.transform.parent = transform;
						_player.name = "Player";
						player1 = true;
					}
					
					if(player2 == false){
						_player = Instantiate(_player,new Vector3(-7f,0,0),Quaternion.identity) as GameObject;
						_player.transform.parent = transform;
						_player.name = "Player";
						player2 = true;
					}
					if(player3 == false){
						_player = Instantiate(_player,new Vector3(7.5f,0,0),Quaternion.identity) as GameObject;
						_player.transform.parent = transform;
						_player.name = "Player";
						player3 = true;
					}
					
					if(Enemy == false){
						_player = Instantiate(_player,new Vector3(-7.5f,0,0),Quaternion.identity) as GameObject;
						_player.transform.parent = transform;
						_player.renderer.material.color = new Color(100,0,0);
						_player.name = "Player";
						
						_player = Instantiate(_player,new Vector3(7f,0,0),Quaternion.identity) as GameObject;
						_player.transform.parent = transform;
						_player.renderer.material.color = new Color(100,0,0);
						_player.name = "Player";
						
						_player = Instantiate(_player,new Vector3(21f,0,0),Quaternion.identity) as GameObject;
						_player.transform.parent = transform;
						_player.renderer.material.color = new Color(100,0,0);
						_player.name = "Player";
						Enemy = true;
					}

				}
				break;
			}
		}

	}

	 void newBall(){
		_ball 	= Resources.Load("Ball") as GameObject;
		_ball = Instantiate(_ball,new Vector3(0,0,0),Quaternion.identity) as GameObject;
		_ball.name = "Ball";
		_ball.transform.parent = transform;
		ball = true;
	}

}
