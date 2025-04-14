using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewChargeUI : MonoBehaviour
{
    NewPlayer1 player1;
    NewPlayer2 player2;

    public Image P1ChargeGage;
    public Image P1Gage;

    public Image P2ChargeGage;
    public Image P2Gage;

    public GameObject P1GrabRange;
    public GameObject P2GrabRange;

    [Header("SkillObjects")]
    public GameObject PushGlove1;
    public GameObject PushGlove2;

    public GameObject Player1Grab;
    public GameObject Player2Grab;


    Vector3 offset = new Vector3(0, 120, 0);
    private void Awake()
    {
        player1 = GameObject.Find("Player1").GetComponent<NewPlayer1>();
        player2 = GameObject.Find("Player2").GetComponent<NewPlayer2>();

        P1ChargeGage = GameObject.Find("P1ChargeGage").GetComponent<Image>();
        P1Gage = GameObject.Find("P1Gage").GetComponent<Image>();

        P2ChargeGage = GameObject.Find("P2ChargeGage").GetComponent<Image>();
        P2Gage = GameObject.Find("P2Gage").GetComponent<Image>();

        P1GrabRange = GameObject.Find("P1GrabRange");
        P2GrabRange = GameObject.Find("P2GrabRange");

        PushGlove1 = GameObject.FindWithTag("Player1Glove");
        PushGlove2 = GameObject.FindWithTag("Player2Glove");

        Player1Grab = GameObject.FindWithTag("Player1Grab");
        Player2Grab = GameObject.FindWithTag("Player2Grab");
    }

    private void Start()
    {
        P1Gage.gameObject.SetActive(false);
        P2Gage.gameObject.SetActive(false);

        P1GrabRange.SetActive(false);
        P2GrabRange.SetActive(false);
    }

    private void Update()
    {
        Player1UI();
        Player2UI();


        Vector3 player1Pos = Camera.main.WorldToScreenPoint(player1.transform.position);
        Vector3 player2Pos = Camera.main.WorldToScreenPoint(player2.transform.position);

        P1Gage.rectTransform.position = player1Pos + offset;
        P1ChargeGage.fillAmount = player1.pushCharge / 35;

        P2Gage.rectTransform.position = player2Pos + offset;
        P2ChargeGage.fillAmount = player2.pushCharge / 35;
    }

    void Player1UI()
    {
        //ÁÖ¸Ô UI
        if (PushGlove1.activeSelf)
        {
            if (!player1.IsGamePad)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    P1Gage.gameObject.SetActive(true);
                }
                else
                {
                    P1Gage.gameObject.SetActive(false);
                }
            }
            else
            {
                if (Input.GetButton("Push1"))
                {
                    P1Gage.gameObject.SetActive(true);
                }
                else
                {
                    P1Gage.gameObject.SetActive(false);
                }
            }
        }

        //±×·¦ UI
        if (Player1Grab.activeSelf)
        {
            if (!player1.IsGamePad)
            {
                if (Input.GetKey(KeyCode.R))
                {
                    P1GrabRange.SetActive(true);
                }
                else
                {
                    P1GrabRange.SetActive(false);
                }
            }
            else
            {
                if (Input.GetButton("Pull1"))
                {
                    P1GrabRange.SetActive(true);
                }
                else
                {
                    P1GrabRange.SetActive(false);
                }
            }
        }
    }

    void Player2UI()
    {
        //ÁÖ¸Ô UI
        if (PushGlove2.activeSelf)
        {
            if (!player2.IsGamePad)
            {
                if (Input.GetKey(KeyCode.Slash))
                {
                    P2Gage.gameObject.SetActive(true);
                }
                else
                {
                    P2Gage.gameObject.SetActive(false);
                }
            }
            else
            {

            }
        }


        //±×·¦ UI
        if (Player2Grab.activeSelf)
        {
            if (!player2.IsGamePad)
            {
                if (Input.GetKey(KeyCode.Period))
                {
                    P2GrabRange.SetActive(true);
                }
                else
                {
                    P2GrabRange.SetActive(false);
                }
            }
            else
            {

            }
        }

    }
}
