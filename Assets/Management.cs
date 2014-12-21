using UnityEngine;
using System.Collections;

public class Management : MonoBehaviour {
	Transform[] Pieces;
	private bool player1,player2;
	public static bool ball;
	public GameObject _player1,_player2,_ball;
	// Use this for initialization
	void Start () {
		Checks();
	}

	void Checks(){
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
					_player1 = Instantiate(_player1,new Vector3(-8.5f,0,0),Quaternion.identity) as GameObject;
					_player1.name = "Player-1";
					player1 = true;
				}
				
				if(player2 == false){
					_player2 = Instantiate(_player2,new Vector3(8.5f,0,0),Quaternion.identity) as GameObject;
					_player2.name = "Player-2";
					player2 = true;
				}
				if(ball == false){
					_ball = Instantiate(_ball,new Vector3(0,0,0),Quaternion.identity) as GameObject;
					_ball.name = "Ball";
					ball = true;
				}
				break;
			}
		}
	}
}
