using System;
using UnityEngine;
public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameState currentState;
    public GameState CurrentState => currentState;

    public static Action finishEvent;
    private void Start()
    {
        ChangeState(GameState.MainMenu);
    }


    public void ChangeState(GameState newState)
    {
        currentState = newState;
        switch (newState)
        {
            case GameState.MainMenu:
                MainMenuState();
                break;
            case GameState.GamePlay:
                GamePlayState();
                break;
            case GameState.Victory:
                break;
            case GameState.Fail:
                break;
            case GameState.Finish:
                FinishState();
                break;

        }
    }

    private void MainMenuState()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_MainMenu>();
    }
    private void VictoryState()
    {

    }
    private void FailState()
    {

    }
    private void GamePlayState()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_GamePlay>();
    }

    private void FinishState()
    {
        UIManager.Instance.CloseAll();
        UIManager.Instance.OpenUI<Canvas_Finish>();
        finishEvent?.Invoke();
    }

}


public enum GameState
{
    MainMenu = 0,
    GamePlay = 1,
    Victory = 2,
    Fail = 3,
    Finish = 4,
}