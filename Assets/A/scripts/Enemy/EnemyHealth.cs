using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{


    [SerializeField] private float MaxHP = 10;
     private float currentHP;

 
    private Rigidbody2D rb;


    private void Awake()
    {
        
       rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentHP = MaxHP;
    }



    public void TakeDamage(SDamageData damage)
    {

        takeDamage(damage.amount);

        rb.AddForce( damage.direction * damage.knockbackForce,ForceMode2D.Impulse);
    }

  


    void takeDamage(float damage) 
    {

        currentHP -= damage;

          
          
            if (currentHP <= 0)
            {
                this.gameObject.SetActive(false);  //will eiter set active again in event manager after a set time 
            }
        
    }
}
