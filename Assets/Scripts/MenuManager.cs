using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.gm;
    }

    void Awake() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handlePlay() {
        gm.setGameState("play");
        SceneManager.LoadScene (1);
    }

    public void handleLearn() {
        gm.setGameState("learn");
        SceneManager.LoadScene (1);
    }

    public void handleTest() {
        gm.setGameState("test");
        SceneManager.LoadScene (1);
    }
}
