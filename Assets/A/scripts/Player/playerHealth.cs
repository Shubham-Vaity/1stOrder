using UnityEngine;

public class playerHealth : MonoBehaviour,IDamageable ,Iheal
{

    [SerializeField] private float MaxHP=20;
     private float currentHP;

   
    void Start()
    {
        currentHP = MaxHP;  //thiss will be set in save game i beleve   
    }



    public void TakeDamage(SDamageData damage)
    {
        currentHP -= damage.amount;

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
