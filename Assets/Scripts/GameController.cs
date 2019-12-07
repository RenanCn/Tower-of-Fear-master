using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //SCENE 0 = MENU PRINCIPAL
    //SCENE 1 = GAME OVER
    //SCENE 2 = FIM
    //SCENE 3 = FASE 1

    public void LoadScene(int scene){
        SceneManager.LoadScene(scene);
    }

    public void GameOver(){
        LoadScene(1);
    }

    public void MenuPrincipal(){
        LoadScene(0);
    }

    public void Fim(){
        LoadScene(2);
    }
}
