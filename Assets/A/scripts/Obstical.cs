using UnityEngine;

public class Obstical : MonoBehaviour, IDamageable
{

    //this script mostly for obsticals of differnt type but same machanic
  //  public PlayerInput RequiredWepon; //setting type of tool/wepon so the player is able to deal damage  , eg: axe for wood , picaxe for stone , if the type maches then only damage goes through

    public float MaxHP=10;
    public float HP;

    private void Start()
    {
        HP = MaxHP;
    }

    public void TakeDamage(SDamageData damage)
    {
       
            takeDamage(damage.amount); 
        
    }


  

    private void takeDamage(float damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            this.gameObject.SetActive(false);  //will eiter set active again in event manager after a set time 
        }
    }



}
