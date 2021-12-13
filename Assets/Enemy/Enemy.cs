using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int StructureDamage = 25;
    

    Bank bank;
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }
    private void Update()
    {
     
    }
    public void RewardGold()
    {
        
        if (bank == null) { return; }
        bank.Deposit(goldReward);
    }

    public void DamageStructure()
    {
        if (bank == null) { return; }
        bank.StructuralDamage(StructureDamage);
    }

}
