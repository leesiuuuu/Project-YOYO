using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeUI : MonoBehaviour
{
    Player1 player1;
    Player2 player2;

    public Image P1ChargeGage;
    public Image P1Gage;

    public Image P2ChargeGage;
    public Image P2Gage;

    Vector3 offset = new Vector3(0, 120, 0);
    private void Awake()
    {
        player1 = GameObject.Find("Player1").GetComponent<Player1>();
        player2 = GameObject.Find("Player2").GetComponent<Player2>();

        P1ChargeGage = GameObject.Find("P1ChargeGage").GetComponent<Image>();
        P1Gage = GameObject.Find("P1Gage").GetComponent<Image>();

        P2ChargeGage = GameObject.Find("P2ChargeGage").GetComponent<Image>();
        P2Gage = GameObject.Find("P2Gage").GetComponent<Image>();
    }

    private void Start()
    {
        P1Gage.gameObject.SetActive(false);
        P2Gage.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            P1Gage.gameObject.SetActive(true);
        }
        else
        {
            P1Gage.gameObject.SetActive(false);
        }


        if(Input.GetKey(KeyCode.Slash))
        {
            P2Gage.gameObject.SetActive(true);
        }
        else
        {
            P2Gage.gameObject.SetActive(false);
        }


        Vector3 player1Pos = Camera.main.WorldToScreenPoint(player1.transform.position);
        Vector3 player2Pos = Camera.main.WorldToScreenPoint(player2.transform.position);

        P1Gage.rectTransform.position = player1Pos + offset;
        P1ChargeGage.fillAmount = player1.pushCharge / 35;

        P2Gage.rectTransform.position = player2Pos + offset;
        P2ChargeGage.fillAmount = player2.pushCharge / 35;
    }
}
