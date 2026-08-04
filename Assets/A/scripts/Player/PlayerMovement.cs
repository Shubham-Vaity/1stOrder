using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{

    private Player_input player_Input;

    private Vector3 input;

    public float speed;
    private float Current_speed;
    private float Sprint_speed;

    private GameObject body;

    void Start()
    {

        //getting script 
        player_Input= GetComponent<Player_input>();

        //getting the child 
        body= transform.Find("body").gameObject; //just a simple arrow sprite to see which direction is player facing


        //setting veluse
        Current_speed=speed;
        Sprint_speed=speed*1.5f;


    }

    
    void FixedUpdate() // sicnce its ligter then update and works mostly the same 
    {

        sprint();

        move();
    
        RotatePlayer();

    }


    private void sprint()
    {

        //sprint
        if (player_Input.shiftValue() != 0)
        {
            Current_speed = Sprint_speed;

        }
        else
        {
            Current_speed = speed;
        }

    }

    private void move()
    {
        //movement
        input = new Vector3(player_Input.horizontalValue(), player_Input.verticalValue(), 0);
        transform.Translate(input.normalized * Current_speed * Time.deltaTime);

    }

    private void RotatePlayer()
    {
        //rotation // might be the part for animation script 
        if (input != Vector3.zero)
        {
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
            {
                // Horizontal movement
                if (input.x > 0)
                    body.transform.rotation = Quaternion.Euler(0, 0, -90);   // Right
                else
                    body.transform.rotation = Quaternion.Euler(0, 0, 90);    // Left
            }
            else
            {
                // Vertical movement
                if (input.y > 0)
                    body.transform.rotation = Quaternion.Euler(0, 0, 0);     // Up
                else
                    body.transform.rotation = Quaternion.Euler(0, 0, 180);   // Down
            }
        }
    }
}
