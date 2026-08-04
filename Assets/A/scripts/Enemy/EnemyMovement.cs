using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using static UnityEngine.UI.Image;

public class EnemyMovement : MonoBehaviour
{



    public float Speed=1;
    public float StopingDistance=1;
    
    public GameObject player;
    private EnemyAttack enemyAttack;


    private void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
    }





    void Update()
    {
        if (player != null) {

            lookAtplayer();


            if (Vector2.Distance(transform.position,player.transform.position)> StopingDistance)
            {

            transform.position = Vector2.MoveTowards(transform.position,player.transform.position,Speed*Time.deltaTime);

            }
            else if(Vector2.Distance(transform.position, player.transform.position) <= StopingDistance)
            {
                if (enemyAttack)
                {

                    enemyAttack.startattackCorutin();             //i beleve insted of doing all this we do the anouncing things 
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
            Speed = 2; 

        }
    }
    private void OnTriggerExit2D(Collider2D collision) 
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player not in range");
            player = null;
            Speed = 0;
        }
    }

}



