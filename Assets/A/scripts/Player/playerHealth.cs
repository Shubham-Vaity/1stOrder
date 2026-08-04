using UnityEngine;

public class playerHealth : MonoBehaviour,I_playerInterface 
{

    public float HP;
    public float MaxHP=20;

   
    void Start()
    {
        HP = MaxHP;  //thiss will be set in save game i beleve   
    }


    public void Heal(int healing)
    {
        HP += healing;
        if(HP > MaxHP)
        { 
            HP = MaxHP; 
        }
    }

    public void takeDamage(float damage)
    {
     HP-= damage;

        if (HP <= 0) 
        {
            Dead();
        }

    }


    public void Dead()
    {

        Application.Quit();  //just a simple u ded function and can be done better while doing UI i guss

    }



}
