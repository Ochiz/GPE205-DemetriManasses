
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public KeyCode titleKey;
    public KeyCode optionsKey;
    public KeyCode creditsKey;
    public MapGenerator level;
    public static GameManager instance;
    public GameObject playerControllerPrefab;
    public GameObject aiControllerPrefab;
    public GameObject tankPawnPrefab;
    public Transform playerSpawnTransform;
    public Transform aiSpawnTransform;
    public List<PlayerController> players;
    public List<AIController> aiPlayers;
    public List<Powerup> allPowerups;
    public List<PlayerSpawnPoint> playerSpawns;
    public List<AISpawnPoint> aiSpawns;
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
        StateDecisions();
        
    }
    public void StateDecisions()
    {
       switch (currentState)

        {
            
            case GameState.TitleScreen:
                DoTitleScreen();
                break;
            case GameState.MainMenu:
                DoMainMenu();
              
                break;
            case GameState.Options:
                DoOptions();
             
                break;
        
            case GameState.GamePlay:
                DoGamePlay();
                int count = 0;
                foreach(PlayerController player in players)
                {
                    if(player.playerLives <= 0)
                    {
                        count++;
                    }
                }
                if(count == players.Count)
                {
                    ChangeState(GameState.GameOver);
                }
                else
                {
                    count = 0;
                }
                break;
                
            case GameState.GameOver:
                DoGameOver();
                
                break;
            case GameState.Credits:
                DoCredits();
               
                break;
                
        }
    }
    public virtual void ChangeState(GameState newState)
    {
        currentState = newState;
    }
    public void SpawnPlayerControllers()
    {
        GameObject newPlayerObject = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        //GameObject newPawnObject = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;

        Controller newController = newPlayerObject.GetComponent<Controller>();

        PlayerController newPlayerController = newPlayerObject.GetComponent<PlayerController>();
        
        
        //Pawn newPawn = newPawnObject.GetComponent<Pawn>();
        //PlayerController newPlayerController = newPawn.playerController;

        //newController.pawn = newPawn;
        //newController.pawn.playerController = newPlayerController;
    }
    public Transform RandomPlayerSpawn()
    {
        Debug.Log(playerSpawns.Count);
        return playerSpawns[Random.Range(0, playerSpawns.Count)].transform;
    }
    public Transform RandomAISpawn()
    {
        Debug.Log(aiSpawns.Count);
        return aiSpawns[Random.Range(0, aiSpawns.Count)].transform; 
    }
    public void SpawnAi()
    {
        aiSpawnTransform = RandomAISpawn();
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
        if (allPowerups != null)
        {
            allPowerups.Clear();
        }
        if (aiPlayers != null)
        {
            foreach (AIController ai in aiPlayers)
            {
                Destroy(ai.pawn);
                Destroy(ai);
            }
            aiPlayers.Clear();
        }
        if (players != null)
        {
            foreach (PlayerController player in players)
            {
                Destroy(player.pawn);
            }
        }
        level.DestroyMap();
        level.GenerateMap();
        if (players != null)
        { 
            SpawnPlayerPawns();
        }
        else
        {
            
            SpawnPlayerControllers();
            SpawnPlayerPawns();
        }
        foreach(PlayerController player in players)
        {
            player.pawn.playerController.playerScore = 0;
        }
       
        SpawnAi();
        
    }
    public void SpawnPlayerPawns()
    {
        foreach (PlayerController player in players)
        {
            if (player.playerLives > 0)
            {
                playerSpawnTransform = RandomPlayerSpawn();
                GameObject newPawnObject = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation) as GameObject;
                Pawn newPawn = newPawnObject.GetComponent<Pawn>();
                player.pawn = newPawn;
                player.pawn.playerController = player;
            }
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
