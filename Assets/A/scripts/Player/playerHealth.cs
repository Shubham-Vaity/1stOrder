using UnityEngine;

public class playerHealth : MonoBehaviour,IDamageable ,Iheal
{

    [SerializeField] private float MaxHP=20;
    [SerializeField] private float currentHP;

    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentHP = MaxHP;  //thiss will be set in save game i beleve   
    }



    public void TakeDamage(SDamageData damage)
    {
        currentHP -= damage.amount;
        rb.AddForce(damage.direction * damage.knockbackForce, ForceMode2D.Impulse);
        if (currentHP <= 0)
        {
            Dead();
        }
    }

    public void Heal(int healing)
    {
        currentHP += healing;
        if (currentHP > MaxHP)
        {
            currentHP = MaxHP;
        }
    }


    public void Dead()
    {

        Application.Quit();  //just a simple u ded function and can be done better while doing UI i guss

    }

  
}
