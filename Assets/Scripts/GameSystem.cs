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

    void Start()
    {
        startPos = playerMove.transform.position;
        modal.SetActive(false);
    }

    public void ReplayGame()
    {
        playerMove.transform.position = startPos;
        modal.SetActive(false);
        playerMove.SetIsMoving(true);
    }

    public void DisplayModal(string text)
    {
        modalText.text = text;
        modal.SetActive(true);
        playerMove.SetIsMoving(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        DisplayModal("Goal");
    }
}
