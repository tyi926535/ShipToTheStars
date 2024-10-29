using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartedGame : MonoBehaviour
{
    public void GameType(int gameType)
    {
        if (gameType == 1)
        {
            SceneManager.LoadScene("Type1");
        }
        if (gameType == 2)
        {
            SceneManager.LoadScene("Type2");
        }
        if (gameType == 3)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void OnDestroy()
    {
        //PlayerPrefs.DeleteKey("goodResult1");
        //PlayerPrefs.DeleteKey("goodResult2");
        Application.Quit();
    }


}
