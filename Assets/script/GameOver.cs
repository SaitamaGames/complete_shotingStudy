using UnityEngine;
using System.Collections;

/// <summary>
/// Game over表示
/// </summary>
public class GameOver : MonoBehaviour {
	public static bool GameOverFlag = false; 
	[SerializeField] GameObject text ;
	// Use this for initialization
	void Start()
	{
		GameOverFlag = false;
	}


	void OnGUI()
	{
		//げーむおーばーの場合
		if( GameOverFlag )
		{
			text.gameObject.SetActive(true);
			//ボタンを表示
			if(GUI.Button(new Rect(Screen.width/2 -75, Screen.height/2  ,150, 90), "Retry"))
			{
				GameOverFlag = false;
				//最初に戻る
				Application.LoadLevel("main");
			}
		}else
		{
			text.gameObject.SetActive(false);
		}
	}



}
