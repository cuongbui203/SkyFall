
public interface Subject{
	void Subscribe(Observer  observer);
	void Unsubscribe(Observer  observer);
	void NotifyObserver();
}
