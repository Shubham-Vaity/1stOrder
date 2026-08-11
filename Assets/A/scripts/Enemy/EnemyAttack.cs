using System;
using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{


    [SerializeField] private GameObject attackPoint;
     private bool attacking;

    [SerializeField] private EnemyMovement movement;


    [SerializeField] private SDamageData damageData;
    /*[SerializeField] private float attackRadious = 1;
    [SerializeField] private float attackDistance = 1;*/

    private Vector2 direction;


    [SerializeField] private WeaponData currentWeapon; //will be mostly setting wepon via editor

    private void Awake()
    {
        movement = GetComponent<EnemyMovement>();
        if (!attackPoint)
        {

        attackPoint = transform.Find("attackPoint").gameObject;
        }

            
    }




    private void OnEnable()         ////is this how it works ??  I tried looking it up 
    {
        movement.AttackRangeReached += startAttackCorutin;
    }
    private void OnDisable()
    {
        movement.AttackRangeReached -= startAttackCorutin;
    }


    private void startAttackCorutin()
    {
        if (!attacking)
        {
          
            StartCoroutine(attackDelay(1f));
        }
    }



  


    void attackPlayer()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, currentWeapon.attackRadius , attackPoint.transform.up, currentWeapon.attackDistance, LayerMask.GetMask("Player"));
        if (hit.collider != null)
        {
           

            IDamageable idamage = hit.collider.GetComponent<IDamageable>();

            if (idamage != null)
            {

                direction = (hit.transform.position - transform.position).normalized;
                damageData.direction = direction;
                damageData.amount = currentWeapon.damage;
                damageData.knockbackForce = currentWeapon.Knockback;
                idamage.TakeDamage(damageData);
                
            }

        }

        // Debug.DrawLine(transform.position, transform.position + (attackPoint.transform.up * attackDistance), Color.green);
    }




    IEnumerator attackDelay(float delayInSeconds)
    {
        attacking = true;
        movement.isattacking = attacking;
        attackPlayer();

        yield return new WaitForSeconds(delayInSeconds);

        attacking = false;
        movement.isattacking = attacking;
    }
}
