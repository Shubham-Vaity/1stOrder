using System;
using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{


    [SerializeField] private GameObject attackPoint;
     private bool attacking;

    public EnemyMovement movement;


    public float attackRadious=1;    
    public float attackDistance=1;

    private Vector2 direction;

    [SerializeField] private SDamageData damageData;



    private void Awake()
    {
        movement = GetComponent<EnemyMovement>();
        if (!attackPoint)
        {

        attackPoint = transform.Find("attackPoint").gameObject;
        }

            
    }

    private void Start()
    {
        damageData.amount = 5f;
        damageData.knockbackForce = 1f;
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
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, attackRadious, attackPoint.transform.up, attackDistance, LayerMask.GetMask("Player"));
        if (hit.collider != null)
        {
           

            IDamageable idamage = hit.collider.GetComponent<IDamageable>();

            if (idamage != null)
            {

                direction = (hit.transform.position - transform.position).normalized;
                damageData.direction = direction;
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
