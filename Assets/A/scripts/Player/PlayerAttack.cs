using System.Collections;
using UnityEngine;


public class PlayerAttack : MonoBehaviour 
{

    private Player_input player_Input;

    private GameObject body;
    private GameObject attackPoint;

    private bool canattack;

    public E_Player_Wepon currentwepon;


    private float damage=5;
    public float attackRadious = 0.5f;
    public float attackDistance = 1;



    void Start()
    {

        //getting script 
        player_Input = GetComponent<Player_input>();

        //getting the child 
        body = transform.Find("body").gameObject;
        attackPoint = body.transform.Find("attack").gameObject; //just a simple arrow sprite to see which direction is player facing

        attackPoint.SetActive(false);


        canattack = true;

        currentwepon = E_Player_Wepon.Sword;



    }

     void Update()
    {
        Attack();

        weponswitch();

        }


    private void Attack()
    {
        if (player_Input.attackValue()!=0 && canattack == true)
        {
            attackPoint.SetActive(true);

            StartCoroutine(ExecuteAfterDelay(0.2f));

            AttackRaycaast();

        }
        else
        {
            attackPoint.SetActive(false);
        }

    }


    IEnumerator ExecuteAfterDelay(float delayInSeconds)
    {
        canattack = false;

        yield return new WaitForSeconds(delayInSeconds);

        canattack = true;
    }

    private void AttackRaycaast()
    {
      //  Debug.DrawRay(body.transform.position, body.transform.up, Color.red);
      //RaycastHit2D hit = Physics2D.Raycast(body.transform.position, body.transform.up, 1f, LayerMask.GetMask("Interactable")); 
        RaycastHit2D hit = Physics2D.CircleCast(body.transform.position, attackRadious, attackPoint.transform.up, attackDistance, LayerMask.GetMask("Interactable"));//to ignore player itself

        if (hit.collider != null)
        {

            Debug.Log("hit" + hit.collider.name);

            I_Interact interact = hit.collider.GetComponent<I_Interact>();

            if (interact != null)
            {
                interact.interact(currentwepon,damage);
                interact=null;  ///idk if this is right or wrong
            }
        }

    }

    private void weponswitch()  ///just a simple version will be done bettwer in inventory
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentwepon = E_Player_Wepon.Sword;

            Debug.Log(currentwepon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentwepon = E_Player_Wepon.Axe;

            Debug.Log(currentwepon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentwepon = E_Player_Wepon.PicAxe;

            Debug.Log(currentwepon);
        }


    }

}
