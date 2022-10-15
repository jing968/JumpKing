using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscManager : MonoBehaviour
{
    public GameObject escObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake() {
        escObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) ) {
            toggleEsc();
        }
    }


    public void toggleEsc(){
        if (escObj.activeSelf) {
            escObj.SetActive(false);
        } else {
            escObj.SetActive(true);
        }
    }

    public void backToMenu() {
        GameManager.gm.gameState = GameManager.GameStates.Menu;
        SceneManager.LoadScene (0);
    }
}
