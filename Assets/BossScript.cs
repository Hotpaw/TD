using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(Enemy))]
public class BossScript : MonoBehaviour
{
    [SerializeField] int maxHitpoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies. ")]
    public int MaxArmor;
    int Armor;
    int armorPiercing;
    string damageType;
    string effect;
    float multiplier;
    int damage;
    bool burn_Active = false;
    [SerializeField] bool hasResistance;
    [SerializeField] bool physicalRes = false;
    [SerializeField] bool energyRes = false;
    [SerializeField] bool fireRess = false;
    public ParticleSystem burn_particle;

    public GameObject Resistances;
    public GameObject resistancePos;
    int typeSize;
    private bool stopped = false;
    [SerializeField] int CurrentHitpoints = 0;
    Bank bank;

    Enemy enemy;
    WinScreen ws;
    EnemyMover e_Mover;
    // Start is called before the first frame update
    void OnEnable()
    {
        Armor = MaxArmor;
        StopCoroutine("Burn_Effect");
        stopped = false;
        burn_particle.Stop();// make into own function for all these types
        CurrentHitpoints = maxHitpoints + bank.difficultyRamp;// + bank.difficultyRamp;
        burn_Active = false;
        Debug.Log(" burnA: " + burn_Active);

    }
    private void OnDisable()
    {
        stopped = true;
        burn_particle.Stop();
        burn_Active = false;
        StopAllCoroutines();

    }
    public void Awake()
    {
        burn_particle = FindObjectOfType<ParticleSystem>();
        bank = FindObjectOfType<Bank>();
    }
    private void Start()
    {

        enemy = GetComponent<Enemy>();
        e_Mover = GetComponent<EnemyMover>();

        if (hasResistance == true)
        {
            Instantiate(Resistances, resistancePos.transform.position, resistancePos.transform.rotation, resistancePos.transform.parent);
        }
    }
    void OnParticleCollision(GameObject other)
    {

        damage = other.GetComponent<ParticleScript>().GetDamage();
        damageType = other.GetComponent<ParticleScript>().GetType();
        effect = other.GetComponent<ParticleScript>().Damage_Effect();
        multiplier = other.GetComponent<ParticleScript>().Multiplier();
        armorPiercing = other.GetComponent<ParticleScript>().GetarmorPiercing();
        ProcessHit(damage);
      

    }
    void ProcessHit(int damage)
    {
        Armor -= armorPiercing;
        if (Armor <= 0)
        {
            Armor = 0;
        }
        Debug.Log("Armor: " + Armor);
        if (damageType == "Energy" && energyRes == true)
        {
            damage = damage / 5 - Armor;
            if (damage <= 0) { damage = 0; };
            CurrentHitpoints -= damage;

        }
        else if (damageType == "Physical" && physicalRes == true)
        {
            damage = damage / 5 - Armor;
            if (damage <= 0) { damage = 0; };
            CurrentHitpoints -= damage;

        }
        else if (damageType == "Fire" && fireRess == true)
        {

            damage = damage / 5;
            if (damage <= 0) { damage = 0; };
            CurrentHitpoints -= damage;
            Debug.Log(CurrentHitpoints);

            if (effect == "Burn")
            {
                Burn();

            }
            else if (damageType == "Fire" && fireRess == false)
            {

                damage = damage - Armor;
                if (damage <= 0) { damage = 0; };
                CurrentHitpoints -= damage;
                Debug.Log(CurrentHitpoints);

                if (effect == "Burn")
                {
                    Burn();




                }
                else
                {
                    damage = damage - Armor;
                    if (damage <= 0) { damage = 0; };
                    CurrentHitpoints -= damage;
                    Debug.Log(CurrentHitpoints);
                };
                // Effects made by particles call for functions in either movement or Enemy.
                if (effect == "Slow")
                {
                    e_Mover.Slow_hit(multiplier);
                };
                if (CurrentHitpoints <= 0)
                {
                    stopped = true;
                    enemy.RewardGold();
                    burn_Active = false;

                    Death();



                };


            }
        }
    }
            // Update is called once per frame

            public void Burn() // If target is not burning, take the damage from projectile and start couroutine.
            {

                StartCoroutine("Burn_Effect");
            }
            IEnumerator Burn_Effect() // Calculate damage for burn individually from tower damage.
            {
                Debug.Log(" I HAVE STARTERD BURNING");
                int a = damage;

                if (burn_Active == false)
                {

                    burn_Active = true;
                    if (stopped)
                    {
                        yield break;
                    }
                    burn_particle.Play();
                    burnDamage(a);
                    yield return new WaitForSeconds(1f);
                    if (stopped)
                    {
                        yield break;
                    }
                    burn_particle.Play();
                    burnDamage(a);
                    yield return new WaitForSeconds(1f);
                    if (stopped)
                    {
                        yield break;
                    }
                    burn_particle.Play();
                    burnDamage(a);
                    yield return new WaitForSeconds(1f);

                    // return speed to start speed



                }
                burn_Active = false;
            }
            void burnDamage(int a) // Amount of burn damage is divided by tower fire damage and changed depending on resistance.
            {
                if (damageType == "Fire" && fireRess == true)
                {
                    CurrentHitpoints -= a / 2;
                    if (damage <= 0) { damage = 0; }
                }
                else
                {
                    CurrentHitpoints -= a; if (damage <= 0) { damage = 0; }
                };
                if (CurrentHitpoints <= 0)
                {
                    Death();



                };

            }

            void Death()
            {
                if (CurrentHitpoints <= 0)
                {
                    StopCoroutine("Burn_Effect");
                    enemy.RewardGold();
                    burn_Active = false;
                    stopped = true;

                    gameObject.SetActive(false);

                    bank.Win();

                };



            }
        }
    



