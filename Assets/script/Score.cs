using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {

	public static int ScorePoint = 0;
	[SerializeField] Text ScoreText;
	// Use this for initialization
	void Start () {
		ScorePoint = 0;
		Time.timeScale = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		//点数の更新
		ScoreText.text = "ScorePoint:"+ ScorePoint;
		//げーむ時間をスコアに比例して加速
		Time.timeScale = 1.0f + (float)ScorePoint / 150 ;
	}

}
