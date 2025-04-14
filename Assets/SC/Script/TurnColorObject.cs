using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ColorType
{
    White,
    Black
}

public class TurnColorObject : MonoBehaviour
{
    public List<GameObject> whiteTileList;
    public List<GameObject> blackTileList;

    public Animator anim;
   
    ColorType colorType = ColorType.White;

    private void Start()
    {
        for (int i = 0; i < blackTileList.Count; i++)
        {
            blackTileList[i].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player1>(out var _) || collision.TryGetComponent<Player2>(out var _))
        {
            TurnColor();
        }
    }

    void TurnColor()
    {
        colorType = colorType == ColorType.White ? ColorType.Black : ColorType.White;

        if (colorType == ColorType.White)
        {
            for (int i = 0; i < whiteTileList.Count; i++)
            {
                whiteTileList[i].SetActive(true);
            }
            for (int i = 0; i < blackTileList.Count; i++)
            {
                blackTileList[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < whiteTileList.Count; i++)
            {
                whiteTileList[i].SetActive(false);
            }
            for (int i = 0; i < blackTileList.Count; i++)
            {
                blackTileList[i].SetActive(true);
            }
        }
    }
}
