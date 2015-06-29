using UnityEngine;

public class FactoryFly : MonoBehaviour{

	public void InstantiateFly(string nameFly, Vector3 pos){
//		switch(nameFly){
//		case "BlackFly": return new BlackFly();
//		case "BlueFly": return new BlueFly();
//		case "RedFly": return new RedFly();
//		default : return new RedFly();
//		}
		switch(nameFly){
		case "BlackFly": 
			GameObject BlackFly = Instantiate(Resources.Load("Prefabs/Fly/BlackFly", typeof(GameObject)), pos, Quaternion.identity) as GameObject;

			break ;
		case "BlueFly": 
			GameObject BlueFly = Instantiate(Resources.Load("Prefabs/Fly/BlueFly", typeof(GameObject)), pos, Quaternion.identity) as GameObject;

			break;
		case "RedFly":
			GameObject RedFly = Instantiate(Resources.Load("Prefabs/Fly/RedFly", typeof(GameObject)), pos, Quaternion.identity) as GameObject;

			break;
		default : 
			break;
		}

	}
}
