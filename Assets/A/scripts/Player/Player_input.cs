using UnityEngine;

public class Player_input : MonoBehaviour
{

    float horizontal; 
    float vertical;
    float shift;
    float attack;

   public float horizontalValue()
    {
        horizontal= Input.GetAxis("Horizontal");

        return horizontal;

    }
    public float verticalValue()
    {
        vertical = Input.GetAxis("Vertical");

        return vertical;

    }
    public float shiftValue()
    {
        shift = Input.GetAxis("shift");

        return shift;

    }



    public float attackValue()
    {
        attack = Input.GetAxis("attack");

        return attack;

    }

}
