using System.Collections;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private PlayerInput player_Input;

    [SerializeField] private GameObject body;
    [SerializeField] private GameObject attackPoint;

    private bool canattack;


   // [SerializeField] private SDamageData damageData;  


    [SerializeField] private WeaponData currentWeapon;
    [SerializeField] private WeaponData[] WeaponList;   //just a place holder for inventory 



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

        if (!currentWeapon && WeaponList.Length > 0)
        {

            currentWeapon= WeaponList[0];
        }

    }


    void Start()
    {

       

        attackPoint.SetActive(false);


        canattack = true;

    

        

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


            

            StartCoroutine(ExecuteAfterDelay(currentWeapon.attackCooldown));
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
      
        RaycastHit2D hit = Physics2D.CircleCast(body.transform.position, currentWeapon.attackRadius, attackPoint.transform.up, currentWeapon.attackDistance, LayerMask.GetMask("Interactable"));//to ignore player itself

        if (hit.collider != null)
        {

            Debug.Log("hit" + hit.collider.name);

            IDamageable idamage = hit.collider.GetComponent<IDamageable>();

            if (idamage != null)
            {
                SDamageData damageData;
                Vector2 direction = (hit.transform.position - transform.position).normalized;
                damageData.direction = direction;
                damageData.amount = currentWeapon.damage;
                damageData.knockbackForce = currentWeapon.Knockback;

                idamage.TakeDamage(damageData);
                
            }
        }

    }

    private void weponswitch()  ///just a simple version will be done bettwer in inventory
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
        
            getWepon(EPlayerWeaponType.Sword);

          
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
            getWepon(EPlayerWeaponType.Axe);


            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            
            getWepon(EPlayerWeaponType.PicAxe);

            
        }


    }


    void getWepon(EPlayerWeaponType weaponType)
    {

        for (int i=0; i< WeaponList.Length; i++)
        {
            if (WeaponList[i].weponType == weaponType)
            {
                currentWeapon = WeaponList[i];
                return;
            }
           
        }

        Debug.LogWarning($"Weapon {weaponType} was not found.");

    }


}
