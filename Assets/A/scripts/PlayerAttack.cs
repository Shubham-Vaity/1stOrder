using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Player_input player_Input;

    private GameObject body;
    private GameObject attackPoint;
    void Start()
    {

        //getting script 
        player_Input = GetComponent<Player_input>();

        //getting the child 
        body = transform.Find("body").gameObject;
        attackPoint = body.transform.Find("attack").gameObject; //just a simple arrow sprite to see which direction is player facing

        attackPoint.SetActive(false);


    }

     void FixedUpdate()
    {
        attack();
    
        }


    private void attack()
    {
        if (player_Input.attackValue()!=0)
        {
            attackPoint.SetActive(true);
        }
        else
        {
            attackPoint.SetActive(false);
        }

    }
}
