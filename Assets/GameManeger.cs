using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManeger : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;

    public void completeLevel()
    {
        Debug.Log("WON LEVEL");

    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game Over!");
            //Restart();
            Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        //SceneManager.LoadScene("level01");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
