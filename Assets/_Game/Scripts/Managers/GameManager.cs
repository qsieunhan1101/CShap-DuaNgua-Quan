using System.Xml.Serialization;

public class GameManager : Singleton<GameManager>
{
    private GameState currentState;
    public GameState CurrentState => currentState;




    public void ChangeState(GameState newState)
    {
        currentState = newState;
        switch (newState)
        {
            case GameState.MainMenu:
                break;
            case GameState.GamePlay:
                break;
            case GameState.Victory:
                break;
            case GameState.Fail:
                break;
        }
    }

    private void MainMenuState()
    {

    }
    private void VictoryState()
    {

    }
    private void FailState()
    {

    }
    private void GamePlayState()
    {

    }



}


public enum GameState
{
    MainMenu = 0,
    GamePlay = 1,
    Victory = 2,
    Fail = 3,
}