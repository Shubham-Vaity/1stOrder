using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using static UnityEngine.UI.Image;

public class EnemyMovement : MonoBehaviour
{



    [SerializeField] private float speed=1;
    [SerializeField] private float StopingDistance=1;

    [SerializeField] private GameObject player;
    public event Action AttackRangeReached;
    [SerializeField] private Rigidbody2D rb;


    public bool isattacking;



    private Vector2 direction;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }




    void FixedUpdate()
    {
        enemymove();
        
    }


    void enemymove()
    {
        if (player != null)
        {

            lookAtplayer();


            if (Vector2.Distance(transform.position, player.transform.position) > StopingDistance)
            {
                //  transform.position = Vector2.MoveTowards(transform.position,player.transform.position,Speed*Time.deltaTime);


                direction = ((Vector2)player.transform.position - rb.position).normalized;
                rb.linearVelocity = direction * speed;


            }
            else
            {
                rb.linearVelocity = Vector2.zero;
                if (!isattacking)
                {

                    AttackRangeReached?.Invoke();    //if not this method how do u recomend me attack player ?? uisng another collider that's not goood..
                    Debug.Log("attacking player ");
                }

            }



        }
    }


    void lookAtplayer()
    {
        Vector2 direction = player.transform.position - transform.position;


        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Face Left or Right
            if (direction.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);      // Right
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);    // Left
            }
        }
        else
        {
            // Face Up or Down
            if (direction.y > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);     // Up
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);    // Down
            }
        }
    }
   


   




    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            player= collision.gameObject;
            speed = 2; 

        }
    }
    private void OnTriggerExit2D(Collider2D collision) 
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player not in range");
            player = null;
            speed = 0;
        }
    }

}



