using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject playerControllerPrefab;
    public GameObject aiControllerPrefab;
    public GameObject tankPawnPrefab;
    public Transform playerSpawnTransform;
    public Transform aiSpawnTransform;
    public List<PlayerController> players;
    public GameObject TitleScreenStateObject;
    public GameObject MainMenuStateObject;
    public GameObject OptionsScreenStateObject;
    public GameObject CreditsSceneStateObject;
    public GameObject GameplayStateObject;
    public GameObject GameOverScreenStateObject;
    public enum GameState {TitleScreen, MainMenu, Options, GamePlay, GameOver, Credits }
    public GameState currentState;
    private void Awake()
    {

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
        ChangeState(GameState.GamePlay);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void StateDecisions()
    {
       switch (currentState)

        {
            /*
            case GameState.TitleScreen:
                DoTitleScreen();
                break;
            case GameState.MainMenu:
                DoMainMenu();
                if()
                /{

                }
                break;
               
            case GameState.Options:
                DoOptions;
                if()
                {

                }
                break;
               */
            case GameState.GamePlay:
                DoGamePlay();
                if (players[0].pawn.health.currentHealth <= 0)
                {
                    ChangeState(GameState.GameOver);
                }
                break;
                /*
            case GameState.GameOver:
                DoGameOver();
                if()
                {

                }
                break;
            case GameState.Credits:
                DoCredits();
                if()
                {

                }
                break;
                */
        }
    }
    public virtual void ChangeState(GameState newState)
    {
        currentState = newState;
    }
    public void SpawnPlayer()
    {
        GameObject newPlayerObject = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        GameObject newPawnObject = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

        Controller newController = newPlayerObject.GetComponent<Controller>();
        Pawn newPawn = newPawnObject.GetComponent<Pawn>();

        newController.pawn = newPawn;
    }
    public void SpawnAi()
    {
        GameObject newAiObject = Instantiate(aiControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        GameObject newAiPawnObject = Instantiate(tankPawnPrefab, aiSpawnTransform.position, Quaternion.identity) as GameObject;

        AIController newAIController = newAiObject.GetComponent<AIController>();
        Pawn newAIPawn = newAiPawnObject.GetComponent<Pawn>();

        newAIController.pawn = newAIPawn;
    }
    private void DeactivateAllStates()
    {
        TitleScreenStateObject.SetActive(false);
        MainMenuStateObject.SetActive(false);
        OptionsScreenStateObject.SetActive(false);
        CreditsSceneStateObject.SetActive(false);
        GameplayStateObject.SetActive(false);
        GameOverScreenStateObject.SetActive(false);
    }
    public void ActivateTitleScreen()
    {
        DeactivateAllStates();
        TitleScreenStateObject.SetActive(true);
    }
    public void ActivateMainMenu()
    {
        DeactivateAllStates();
        MainMenuStateObject.SetActive(true);
    }
    public void ActivateOptionsScreen()
    {
        DeactivateAllStates();
        OptionsScreenStateObject.SetActive(true);
    }
    public void ActivateCreditsScene()
    {
        DeactivateAllStates();
        CreditsSceneStateObject.SetActive(true);
    }
    public void ActivateGamePlay()
    {
        DeactivateAllStates();
        GameplayStateObject.SetActive(true);
        foreach (PlayerController player in players)
        {
            player.pawn.health.currentHealth = player.pawn.health.maxHealth;
        }
    }
    public void ActivateGameOverScreen()
    {
        DeactivateAllStates();
        GameOverScreenStateObject.SetActive(true);
    }
    protected void TitleScreen()
    {
        ActivateTitleScreen();
    }
    public void DoTitleScreen()
    {
        TitleScreen();
    }
    protected void MainMenu()
    {
        ActivateMainMenu();
    }
    public void DoMainMenu()
    {
        MainMenu();
    }
    protected void Options()
    {
        ActivateOptionsScreen();
    }
    public void DoOptions()
    {
        Options();
    }
    protected void GamePlay()
    {
        ActivateGamePlay();

    }
    public void DoGamePlay()
    {
        GamePlay();
    }
    protected void GameOver()
    {
        ActivateGameOverScreen();
    }
    public void DoGameOver()
    {
        GameOver();
    }
    protected void Credits()
    {
        ActivateCreditsScene();
    }
    public void DoCredits()
    {
        Credits();
    }

}
