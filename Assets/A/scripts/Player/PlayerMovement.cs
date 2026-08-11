using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{

    private PlayerInput player_Input;

    private Vector2 input;

    [SerializeField] private float speed;
    private float Current_speed;
    private float Sprint_speed;

   [SerializeField] private GameObject body;
    private Rigidbody2D rb;


    private void Awake()
    {
        //getting script 
        player_Input= GetComponent<PlayerInput>();

        //getting the child 
        if (!body)
        {
        body= transform.Find("body").gameObject; //just a simple arrow sprite to see which direction is player facing
        }

        rb = GetComponent<Rigidbody2D>();
        
    }

    void Start()
    {


        //setting veluse
        Current_speed=speed;
        Sprint_speed=speed*1.5f;


    }



    private void Update()
    {
        sprint();
        RotatePlayer();
        
    }


    void FixedUpdate() 
    {


        move();
    

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
        input = new Vector2(player_Input.horizontalValue(), player_Input.verticalValue()).normalized;
        //transform.Translate(input.normalized * Current_speed * Time.deltaTime);
        rb.MovePosition(rb.position + input * Current_speed * Time.fixedDeltaTime);

    }

    private void RotatePlayer()
    {
        //rotation // might be the part for animation script 
        if (input != Vector2.zero)
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
