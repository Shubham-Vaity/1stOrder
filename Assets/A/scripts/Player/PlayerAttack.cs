using System.Collections;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{

    private PlayerInput player_Input;

    private GameObject body;
    private GameObject attackPoint;

    private bool canattack;

    public EPlayerWeaponType currentwepon;



    [SerializeField] private SDamageData damageData;  //I think i am doing this damage data thing very wrong 



    void Start()
    {

        //getting script 
        player_Input = GetComponent<PlayerInput>();

        //getting the child 
        body = transform.Find("body").gameObject;
        attackPoint = body.transform.Find("attack").gameObject; //just a simple arrow sprite to see which direction is player facing

        attackPoint.SetActive(false);


        canattack = true;

        currentwepon = EPlayerWeaponType.Sword;



    }

     void Update()
    {
        Attack();

        weponswitch();

        }


    private void Attack()
    {
        if (player_Input.attackValue() && canattack == true)
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
      
        RaycastHit2D hit = Physics2D.CircleCast(body.transform.position, damageData.attackRadious, attackPoint.transform.up, damageData.attackDistance, LayerMask.GetMask("Interactable"));//to ignore player itself

        if (hit.collider != null)
        {

            Debug.Log("hit" + hit.collider.name);

            IDamage idamage = hit.collider.GetComponent<IDamage>();

            if (idamage != null)
            {
                idamage.applyDamage(damageData.amount);
                
            }
        }

    }

    private void weponswitch()  ///just a simple version will be done bettwer in inventory
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentwepon = EPlayerWeaponType.Sword;

            Debug.Log(currentwepon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentwepon = EPlayerWeaponType.Axe;

            Debug.Log(currentwepon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentwepon = EPlayerWeaponType.PicAxe;

            Debug.Log(currentwepon);
        }


    }

}
