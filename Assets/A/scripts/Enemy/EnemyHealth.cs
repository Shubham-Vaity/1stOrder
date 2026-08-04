using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamage
{
  

public float MaxHP = 10;
    public float HP;

 
    private Rigidbody2D rb;
    private EnemyMovement enemyMovement;


    private void Awake()
    {
        
        enemyMovement= GetComponent<EnemyMovement>();   
    }


    void Start()
    {
        HP = MaxHP;
     //   rb = GetComponent<Rigidbody2D>();
    }



    public void applyDamage(float damage)
    {

        takeDamage(damage);
    }

  


    void takeDamage(float damage) //enemy has 2 colliders 1 with on trigger on with a large radious  and the other with small radious
    {

        if (enemyMovement.player != null)
        {
        HP -= damage;
        float forceMagnitude = 1f;

          //  rb.AddForce((transform.position - enemyMovement.player.transform.position).normalized * forceMagnitude, ForceMode2D.Impulse);// causing a problem where the enemy stops moving entirly or moves in an oposit direction and does not stops moving  and continues
            if (HP <= 0)
            {
                this.gameObject.SetActive(false);  //will eiter set active again in event manager after a set time 
            }
        }
    }
}
