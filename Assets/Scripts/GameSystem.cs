using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    public PlayerMove playerMove;
    public GameObject modal;
    public Text modalText;
    private Vector3 startPos;

    public static int hp = 0;
    public int initHP = 100;
    public Text hpText;

    void Start()
    {
        hp = initHP;
        SetHPText(hp);

        startPos = playerMove.transform.position;
        modal.SetActive(false);
    }

    public void ReplayGame()
    {
        hp = initHP;
        SetHPText(hp);

        playerMove.transform.position = startPos;
        modal.SetActive(false);
        playerMove.SetIsMoving(true);
    }

    public void HitDamage(int damage)
    {
        hp -= damage;

        if (hp < 0)
        {
            SetHPText(0);
            DisplayModal("FAILD");
        }
        else
        {
            SetHPText(hp);
        }
    }

    public void SetHPText(int currentHP)
    {
        hpText.text = currentHP + " / " + initHP;
    }

    public void DisplayModal(string text)
    {
        modalText.text = text;
        modal.SetActive(true);
        playerMove.SetIsMoving(false);
    }

   
    private void OnTriggerEnter(Collider other)
    {
        DisplayModal("GOAL");
    }
}
