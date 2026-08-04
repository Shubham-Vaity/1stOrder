using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    
    float vertical;
    float shift;
    float attack;

   public float horizontalValue()
    {
        
        return Input.GetAxis("Horizontal");

    }
    public float verticalValue()
    {


        return Input.GetAxis("Vertical");

    }
    public float shiftValue()
    {
        

        return Input.GetAxis("shift");

    }



    public bool attackValue()
    {
        
        
      //  return Input.GetAxis("attack");
        return Input.GetKeyDown(KeyCode.Mouse0);    

    }

}
