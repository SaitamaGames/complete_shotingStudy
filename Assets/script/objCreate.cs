using UnityEngine;
using System.Collections;

/// <summary>
/// 敵の作成
/// </summary>
public class objCreate : MonoBehaviour {

	[SerializeField] GameObject obj;
	[SerializeField] float maxTimer = 0;
	float timer = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( GameOver.GameOverFlag )
		{
			return;
		}

		timer += Time.deltaTime;
		//一定時間経過したら
		if( timer >= maxTimer )
		{
			timer = 0;

			//1から3体作成
			int roop = 1 + Random.Range( 0 , 3 ); 
			for(int i = 0; i < roop ; i++)
			{
				GameObject objData = (GameObject)Instantiate( obj );
				//出現位置はランダム
				objData.transform.localPosition = new Vector3( Random.Range(-5.0f , 5.0f ) ,
				                                          Random.Range(1.0f , 5.0f ) ,
				                                          Random.Range(13.0f , 14.0f ) );
			}

		}

	}
}
