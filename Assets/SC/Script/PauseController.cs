using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    GameObject pauseUI;

    GameObject go;

    private void Start()
    {
        StartCoroutine(UpdateCoroutine());
    }

    IEnumerator UpdateCoroutine()
    {
        while (true)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(Time.timeScale == 1)
                {
                    go = Instantiate(pauseUI);
                    Time.timeScale = 0;
                }
                else if(Time.timeScale == 0)
                {
                    Destroy(go);
                    Time.timeScale = 1;
                }
            }
        }
    }
}
