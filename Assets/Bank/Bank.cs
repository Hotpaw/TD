using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Bank : MonoBehaviour
{

    [SerializeField] int startingBalance = 150;
    [SerializeField] int colonyStructure;
    [SerializeField] int currentBalance;
    [SerializeField] public int difficultyRamp = 1;
    [SerializeField] public int CurrentBalance { get { return currentBalance; }    }

    [SerializeField] TextMeshProUGUI displayBalance;
    [SerializeField] TextMeshProUGUI ColonyStructure;
    [SerializeField] TextMeshProUGUI ThreatLevel;

    public GameObject ObjectPool;
    public ObjectPool objectpool;
    bool boss;
    bool miniBoss;
    float ObjectPoolActivation;
 
   public int playerWealth = 0;

    public Slider slider;
    public Image Fill;

    public GameObject Winscreen;
    private void Awake()
    {
        miniBoss = false;
        boss = false;

        currentBalance = startingBalance;
       
        UpdateDisplay();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Win();
        }

            ObjectPoolActivation += Time.deltaTime;
        if (ObjectPoolActivation >= 10f) // ACtivate The object pool afetr 10 seonds.
        {
         
        }
        difficultyRamp = playerWealth / 5;

        if (Input.GetKeyDown(KeyCode.M))
        {
            Deposit(1000);
        }
    }
    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
        playerWealth += amount;
    }
    public void WithDraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();

        if (currentBalance < 0)
        {
            currentBalance = 0;
        }
    }
    public void StructuralDamage(int amount)
    {
        colonyStructure -= Mathf.Abs(amount);
        UpdateDisplay();

        if (colonyStructure < 0)
        {
            SceneManager.LoadScene("menu");
        }
    }
    void UpdateDisplay()
    {
        displayBalance.text = "Units: " + currentBalance;
        ColonyStructure.text = colonyStructure + " %";
        slider.value = colonyStructure;
        Fill.color = Color.Lerp(Color.red, Color.green, slider.value / 100);
        if(playerWealth >= 500 && playerWealth <= 2000)
        {
           
            ThreatLevel.SetText("Medium");
            ThreatLevel.color = Color.yellow;

        }
        if (playerWealth >= 2001 && playerWealth <= 5000)
        {
            ThreatLevel.SetText("Hard");
            if(miniBoss == false)
            {
                miniBoss = true;
                objectpool.SpawnMiniboss(1);
            }
            
            ThreatLevel.color = Color.red;
           
        }
        if (playerWealth >= 5001)
        {
            ThreatLevel.SetText("Extermination");
            ThreatLevel.color = Color.black;
            if (boss == false)
            {
                boss = true;
                objectpool.SpawnBoss(1);
            }
        }

    }
    void ReloadScene()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentscene.buildIndex);
    }

    public void Win()
    {
       
       

        Winscreen.SetActive(true);
        Time.timeScale = 0;
        

        //Add loot and Highscore
        //Scene currentscene = SceneManager.GetActiveScene();
        //SceneManager.LoadScene("Menu");
    }
    
}
