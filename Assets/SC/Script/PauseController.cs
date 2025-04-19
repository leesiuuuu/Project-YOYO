using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    GameObject pauseUI;

    GameObject go;
    [SerializeField]
    private BGMScript bs;

    private void Start()
    {
        StartCoroutine(UpdateCoroutine());
    }

    IEnumerator UpdateCoroutine()
    {
        while (true)
        {
            yield return null;
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                if(Time.timeScale == 1)
                {
                    go = Instantiate(pauseUI);
                    bs.FadeOutCustom(0.2f, 0.2f);
                    Time.timeScale = 0;
                }
                else if(Time.timeScale == 0)
                {
                    go.GetComponent<PauseMenu>().Resume();
					bs.FadeInCustom(0.2f);
					Time.timeScale = 1;
                }
            }
        }
    }
}
