public enum PlayerState{
	Fly,
	Die,
	Idle
}

public static class PlayerStateManager{
	public static PlayerState PlayerState {
		get;
		set;
	}
	static PlayerStateManager(){
		PlayerState = PlayerState.Idle;
	}
}
