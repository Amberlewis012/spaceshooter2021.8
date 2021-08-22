using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlayerDeath()
    {
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Update() //TUTORIAL ONLY!
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Level01");
            Debug.Log("Loading first level");
        }
    }
}
