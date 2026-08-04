using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{


    private GameObject attackPoint;
    public float attackRadious = 1;
    public float attackDistance = 1;
    private bool attacking;


    private float damage=5;


    void Start()
    {
        attackPoint = transform.Find("attackPoint").gameObject;
    
    
    }



    public void startattackCorutin()
    {
        if (!attacking)
        {
            //Debug.Log("attacking player ");
            StartCoroutine(attackDelay(1f));
        }
    }



    void attackPlayer()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, attackRadious, attackPoint.transform.up, attackDistance, LayerMask.GetMask("Player"));
        if (hit.collider != null)
        {
            Debug.Log("player hit");

            I_playerInterface playerInterface = hit.collider.GetComponent<I_playerInterface>();

            if (playerInterface != null)
            {
                playerInterface.takeDamage(damage);
                playerInterface = null;  ///idk if this is right or wrong
            }

        }

        // Debug.DrawLine(transform.position, transform.position + (attackPoint.transform.up * attackDistance), Color.green);
    }




    IEnumerator attackDelay(float delayInSeconds)
    {
        attacking = true;
        attackPlayer();

        yield return new WaitForSeconds(delayInSeconds);

        attacking = false;
    }
}
