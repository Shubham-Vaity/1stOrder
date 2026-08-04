using System;
using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{


    private GameObject attackPoint;
     private bool attacking;

    public EnemyMovement movement;



    [SerializeField] private SDamageData damageData;



    private void Awake()
    {
        movement = GetComponent<EnemyMovement>();   
            
        attackPoint = transform.Find("attackPoint").gameObject;
    }
    


    private void OnEnable()         ////is this how it works ??  I tried looking it up 
    {
        movement.AttackPlayer += startAttackCorutin;
    }
    private void OnDisable()
    {
        movement.AttackPlayer -= startAttackCorutin;
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
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, damageData.attackRadious, attackPoint.transform.up, damageData.attackDistance, LayerMask.GetMask("Player"));
        if (hit.collider != null)
        {
           

            IDamage idamage = hit.collider.GetComponent<IDamage>();

            if (idamage != null)
            {
                idamage.applyDamage(damageData.amount);
                
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
