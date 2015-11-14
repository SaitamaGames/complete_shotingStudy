using UnityEngine;
using System.Collections;

/// <summary>
/// ボタン押したら射撃とか
/// </summary>
public class ShotControl : MonoBehaviour {

	[SerializeField] GameObject shot;
	float shotWait = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if( shotWait > 0 )
		{
			shotWait-=Time.deltaTime;
			return;
		}

		if( GameOver.GameOverFlag )
		{
			return;
		}

		//ボタンを押したら
		if( Input.GetMouseButton(0))
		{
			shotWait = 0.1f;

			//多少ランダムのが面白い
			Vector3 point = transform.localPosition;


			//マウスカーソルからRay放射
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Vector3 hitPoint ;
			//z=100までにオブジェクトがあるか
			if(Physics.Raycast(ray, out hit,100))
			{
				//オブジェクトがなければ終了
				if( hit.collider.gameObject == null ) return;
				
				
//				if( hit.collider.gameObject.tag == "MainCamera" ||
//					   hit.collider.gameObject.tag == "GameController") 
//				{
//				}else
//				{
//					return;
//				}
				//RaycastHitが衝突した座標を取得
				hitPoint= hit.point;
			}else
			{
				return;
			}
			//生成　座標を設定
			point.x += Random.Range(0.5f,-0.5f);
			point.y += Random.Range(0.5f,-0.5f);
			point.z += Random.Range(1.5f,0.5f);
			GameObject obj = (GameObject)Instantiate( shot );
			obj.transform.localPosition = point;


			//指定位置とターゲットの位置を設定（ターゲット座標ーコントロール座標）
			Vector3 nVec = Vector3.Normalize( hitPoint - obj.transform.position);
			
			//ターゲットの方向を向く
			obj.transform.LookAt(hitPoint);
			
			//ターゲットを指定位置に飛ばす
			obj.transform.GetComponent<Rigidbody>().AddForce (nVec * 3500);

			
		}
	}
}
