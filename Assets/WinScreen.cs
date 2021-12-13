using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinScreen : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI score;
    Bank bank;

    private void Update()
    {
        score.text = bank.playerWealth + " Points";
    }
    private void Start()
    {
        bank = FindObjectOfType<Bank>();
    }
    private void OnEnable()
    {
     
    }
}
