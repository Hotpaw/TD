using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov_Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f; // Overall area of range for tower. 15 = Only 1 tile away.
    [SerializeField] float attackSpeed = 1f; // Current speed of Tower Projectiles
    [SerializeField] float attackTimer;
    Transform target;





    void start()
    {
        projectileParticles = GetComponent<ParticleSystem>();

    }
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
        var emission = projectileParticles.emission; // get hold of the emission of the particle system.
        emission.rateOverTime = attackSpeed; // change the emissionoverratetime to that of attackspeed.
    }
    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }
    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if (targetDistance < range)
        {
            StartCoroutine(Burn_Time(true));
        }
        else
        {
            StartCoroutine(Burn_Time(false));
        }
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }

    IEnumerator Burn_Time(bool isActive) // Probably not even working.
    {
       
            var emissionModule = projectileParticles.emission;
            emissionModule.enabled = isActive;
            yield return new WaitForSeconds(attackTimer);
           
     
    }
}
