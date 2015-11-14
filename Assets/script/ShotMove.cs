using UnityEngine;
using System.Collections;

/// <summary>
/// 射撃の動き
/// </summary>
public class ShotMove : MonoBehaviour {

	[SerializeField] GameObject Effect;
	float lifeTimer = 1.0f ;
	bool collisionFlag = false;
	float normalTimer = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//ぶつかったらなら早めに一定時間で消えるよ
		if( collisionFlag )
		{
			lifeTimer -= Time.deltaTime;
			if( lifeTimer <= 0 )
			{
				Destroy( gameObject );
			}
		}
		normalTimer += Time.deltaTime;
		//一定時間で消えるよ
		if( normalTimer >= 3 )
		{
			Destroy( gameObject);
		}
	}

	//エフェクトと　ぶつかったフラグを立てる
	public void shotHit()
	{
		collisionFlag = true;
		if( Effect != null )
		{
			Effect.SetActive( true );
		}
	}


}
