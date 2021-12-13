using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    [SerializeField] int particleDamage = 1;
    [SerializeField] float multiplier;
    [SerializeField] int armorPiercePerHit;
    public bool Slow;
    public bool Burn;

    [Tooltip(" Physical, Energy or Fire ")]
    [SerializeField] string damageType;
    // Start is called before the first frame update

    public int GetDamage()
    {
        return particleDamage;

    }
    public int GetarmorPiercing()
    {
        return armorPiercePerHit;
    }
    public float Multiplier()
    {
        return multiplier;
    }
    public string GetType()
    {
        return damageType;
    }
    public string Damage_Effect()
    {
        if (Slow == true)
        {

            return "Slow";
        }
        else if (Burn == true)
        {
            return "Burn";
        }

        else
        {
            return "";
        }
    }
}