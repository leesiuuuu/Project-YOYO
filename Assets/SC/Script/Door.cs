using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    bool enteredPlayer1;
    bool enteredPlayer2;

    int keyCount;
    LevelLoader levelLoader;
    KeyCounter keyCounter;

    private void Start()
    {
        keyCounter = FindObjectOfType<KeyCounter>();
        levelLoader = FindObjectOfType<LevelLoader>();
        Key[] currentKeys = FindObjectsOfType<Key>();
        keyCount = currentKeys.Length;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<NewPlayer1>() != null)
        {
            enteredPlayer1 = true;
        }
        if(collision.GetComponent<NewPlayer2>() != null)
        {
            enteredPlayer2 = true;
        }

        if (enteredPlayer1 && enteredPlayer2)
            NextStage();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<NewPlayer1>() != null)
        {
            enteredPlayer1 = false;
        }
        if (collision.GetComponent<NewPlayer2>() != null)
        {
            enteredPlayer2 = false;
        }
    }

    void NextStage()
    {
        if(keyCounter.KeyCount == keyCount)
        {
            levelLoader.LoadNextLevel(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
