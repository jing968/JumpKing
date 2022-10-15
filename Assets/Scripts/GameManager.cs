using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager GM;
    public static GameManager gm { get { return GM; } }
    public enum GameStates { Menu, Learn, Test, Play }
    public Learner learner;
    public GameStates gameState = new GameStates();

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        if (GM == null)
        {
            GM = this;
            DontDestroyOnLoad(this);
            gameState = GameStates.Menu;
        }
        else Destroy(gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.L) && gameState == GameStates.Learn) {
            learner.Learn();
        } else if(Input.GetKeyUp(KeyCode.G) && gameState == GameStates.Test) {
            learner.reproduceGoodJumps();
        }
    }

    public void setGameState(string gameState) {
        switch(gameState) {
            case "learn":
                this.gameState = GameStates.Learn;
                break;
            case "test":
                this.gameState = GameStates.Test;
                break;
            case "play":
                this.gameState = GameStates.Play;
                break;
        }
    }
}
