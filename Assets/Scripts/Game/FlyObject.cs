using System.Collections.Generic;
using UnityEngine;

public class FlyObject : MonoBehaviour, Subject{
	List<Observer> listObserver;
	public FlyObject(){
		listObserver = new List<Observer> ();
	}
	public void Subscribe(Observer ob){
		listObserver.Add (ob);
	}
	public void Unsubscribe(Observer ob){
		listObserver.Remove (ob);
	}
	public void NotifyObserver(){
		foreach(Observer os in listObserver){
			os.GameEventClearScreen();
		}
	}
}
