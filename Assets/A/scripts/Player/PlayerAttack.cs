using System.Collections;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{

    private PlayerInput player_Input;

    [SerializeField] private GameObject body;
    [SerializeField] private GameObject attackPoint;

    private bool canattack;


    public float attackRadious=1;    
    public float attackDistance = 1;
    private Vector2 direction;

    public EPlayerWeaponType currentwepon;




    [SerializeField] private SDamageData damageData;  //I think i am doing this damage data thing very wrong 



    private void Awake()
    {
        player_Input = GetComponent<PlayerInput>();

        //getting the child 
        if (!body )
        {
        body = transform.Find("body").gameObject;
                    }

        if (!attackPoint)
        {
        attackPoint = body.transform.Find("attack").gameObject; //just a simple arrow sprite to see which direction is player facing

        }

    }


    void Start()
    {

       

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
      
        RaycastHit2D hit = Physics2D.CircleCast(body.transform.position, attackRadious, attackPoint.transform.up, attackDistance, LayerMask.GetMask("Interactable"));//to ignore player itself

        if (hit.collider != null)
        {

            Debug.Log("hit" + hit.collider.name);

            IDamageable idamage = hit.collider.GetComponent<IDamageable>();

            if (idamage != null)
            {

                direction = (hit.transform.position - transform.position).normalized;
                damageData.direction = direction;

                idamage.TakeDamage(damageData);
                
            }
        }

    }

    private void weponswitch()  ///just a simple version will be done bettwer in inventory
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentwepon = EPlayerWeaponType.Sword;
            damageData.amount = 5;
            damageData.knockbackForce = 2;  
          
            

            Debug.Log(currentwepon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentwepon = EPlayerWeaponType.Axe;
            damageData.amount = 6;
            damageData.knockbackForce = 1f; 
          


            Debug.Log(currentwepon);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentwepon = EPlayerWeaponType.PicAxe;
            damageData.amount = 3;
            damageData.knockbackForce = 1.5f;
          


            Debug.Log(currentwepon);
        }


    }

}
