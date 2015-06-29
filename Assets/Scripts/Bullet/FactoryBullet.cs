using UnityEngine;
public class FactoryBullet: MonoBehaviour {
	public void InstantiateBullet(string nameBullet, Vector3 pos){
		switch(nameBullet){
		case "RedBullet" : 
			GameObject BlackFly = Instantiate(Resources.Load("Prefabs/Bullet/RedBullet", typeof(GameObject)), pos, Quaternion.identity) as GameObject;
			break ;
		case "BlueBullet" :
			GameObject BlueBullet = Instantiate(Resources.Load("Prefabs/Bullet/BlueBullet", typeof(GameObject)), pos, Quaternion.identity) as GameObject;
			break ;
		case "GrayBullet" : 
			GameObject GrayBullet = Instantiate(Resources.Load("Prefabs/Bullet/GrayBullet", typeof(GameObject)), pos, Quaternion.identity) as GameObject;
			break ;
		case "BlackBullet" : 
			GameObject BlackBullet = Instantiate(Resources.Load("Prefabs/Bullet/BlackBullet", typeof(GameObject)), pos, Quaternion.identity) as GameObject;
			break ;
		case "OrangeBullet" : 
			GameObject OrangeBullet = Instantiate(Resources.Load("Prefabs/Bullet/OrangeBullet", typeof(GameObject)), pos, Quaternion.identity) as GameObject;
			break ;
		default: 
			GameObject BlackFlyDefault = Instantiate(Resources.Load("Prefabs/Bullet/RedBullet", typeof(GameObject)), pos, Quaternion.identity) as GameObject;
			break ;
		}
	}
}
