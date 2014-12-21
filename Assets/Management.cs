using UnityEngine;
using System.Collections;

public class Management : MonoBehaviour {
	Transform[] Pieces;
	private bool player1,player2;
	public static bool ball;
	public GameObject _player;
	public GameObject _ball;
	// Use this for initialization
	void Start () {
		_ball 	= Resources.Load("Ball") as GameObject;
		_player = Resources.Load("Player") as GameObject;
		Checks();
	}
	void Update(){
		if(ball == false){
			ball = true;
			Invoke("newBall",3);
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
				if(player1 == false){
					_player = Instantiate(_player,new Vector3(-10f,0,0),Quaternion.identity) as GameObject;
					_player.transform.parent = transform;
					_player.name = "Player";
					player1 = true;
				}
				
				if(player2 == false){
					_player = Instantiate(_player,new Vector3(10f,0,0),Quaternion.identity) as GameObject;
					_player.transform.parent = transform;
					_player.name = "Player";
					player2 = true;
				}
				if(ball == false){
					_ball = Instantiate(_ball,new Vector3(0,0,0),Quaternion.identity) as GameObject;
					_ball.name = "Ball";
					_ball.transform.parent = transform;
					ball = true;
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
