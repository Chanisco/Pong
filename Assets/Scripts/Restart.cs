using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {


	void Start () {
		Invoke("Redo",3);
	}

	void Redo(){
		for(int i = 0;i < Global.PlayerCount.Count;i++){
			Global.PlayerCount.RemoveAt(0);
		}
		Global.PlayerCount.Add(1);
		Global.PlayerCount.Add(2);
		Global.PlayerCount.Add(3);
		Application.LoadLevel(0);
	}
}
