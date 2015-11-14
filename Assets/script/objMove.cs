using UnityEngine;
using System.Collections;

public class objMove : MonoBehaviour {

	bool dead = false;
	float deadTimer = 0;
	public int life = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//げーむオーバー中は動かない
		if( GameOver.GameOverFlag )
		{
			return;
		}

		//死亡判定中は1秒で消滅
		if( dead )
		{
			deadTimer += Time.deltaTime;
			if( deadTimer >= 1.0f)
			{
				Destroy( gameObject);
			}
		}
		//移動
		Vector3 point = transform.localPosition;
		if( dead )
		{
			//死んでいるなら奥にふっとブ
			point.z += Time.deltaTime * 40 ;
		}else
		{
			//こちらに向かってくる
			point.z -= Time.deltaTime * 10 ;

			if( point.x <=  - 0.5f )
			{
				point.x += Time.deltaTime * 0.5f ;

			}else
				if( point.x >=  + 0.5f  )
			{
				point.x -= Time.deltaTime * 0.5f ;
			}
		}

		//接近されたらげーむオーバー
		if( point.z <= -9.1f)
		{
			GameOver.GameOverFlag = true;
		}
		//あまり上に行かないように
		if( point.y >= 5.0f)
		{
			point.y = 5.0f;
		}
		transform.localPosition = point ;

	}


	private void OnCollisionEnter(Collision collision)
	{
		//衝突で呼ばれます
		if( collision.gameObject.tag == "Player" )
		{
			life--;
			//ライフが0で死亡
			if( life <= 0 )
			{
				dead = true;
			}
			//実は死んでいても当てれば点数たまるよ
			Score.ScorePoint++;
			//SHOTのHIT関数を呼ぶ
			collision.transform.GetComponent<ShotMove>().shotHit();
		}
	}



}
