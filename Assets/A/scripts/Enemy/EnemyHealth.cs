using UnityEngine;

public class EnemyHealth : MonoBehaviour, I_Interact
{


    public float MaxHP = 10;
    public float HP;

 
    private Rigidbody2D rb;
    private EnemyMovement enemyMovement;

    public void interact(E_Player_Wepon wepon, float damage)
    {

        rb = GetComponent<Rigidbody2D>();
        enemyMovement= GetComponent<EnemyMovement>();   
        takeDamage(damage);
    }


    void Start()
    {
        HP = MaxHP;
    }


    void takeDamage(float damage) //enemy has 2 colliders 1 with on trigger on with a large radious  and the other with small radious
    {

        if (enemyMovement.player != null)
        {
        HP -= damage;
        float forceMagnitude = 1f;

            rb.AddForce((transform.position - enemyMovement.player.transform.position).normalized * forceMagnitude, ForceMode2D.Impulse);
            if (HP <= 0)
            {
                this.gameObject.SetActive(false);  //will eiter set active again in event manager after a set time 
            }
        }
    }
}
