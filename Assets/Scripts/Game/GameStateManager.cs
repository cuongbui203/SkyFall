
public enum GameState{
	Playing,
	Endgame
}

public static class GameStateManager{
	public static GameState GameState {
		get;
		set;
	}
	static GameStateManager(){
		GameState = GameState.Playing;
	}

}
