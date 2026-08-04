using UnityEngine;

public class Obstical : MonoBehaviour,I_Interact
{

    //this script mostly for obsticals of differnt type but same machanic
    public E_Player_Wepon RequiredWepon; //setting type of tool/wepon so the player is able to deal damage  , eg: axe for wood , picaxe for stone , if the type maches then only damage goes through

    public float MaxHP=10;
    public float HP;

    private void Start()
    {
        HP = MaxHP;
    }

    public void interact(E_Player_Wepon Ewepon, float damage)
    {
        if(Ewepon == RequiredWepon)
        {
            takeDamage(damage); 
          Debug.Log("Right werpon");

        }
        else
        {
            Debug.Log("Wrong werpon");
        }


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
