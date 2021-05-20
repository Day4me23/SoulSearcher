using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed; //Enemy move speed
    public float stoppingDistance; //This shows how far the enemy will stop from the player
    public float retreatDistance; //This is used to show when the enemy will retreat from the 
    public Rigidbody2D rb;
    private Transform player;
    public GameObject playerObject;


    void Start()
    {
        
        playerObject = GameManager.instance.playerCurrent;
        player = playerObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerObject.GetComponent<AbilityInvisable>().invisProc == true ||  playerObject.GetComponent<ObjectHealth>().invincibilityTimer != 0)
        {

        }
        else if (Vector2.Distance(transform.position, player.position) > stoppingDistance) //checks how far the player is from ranged enemy
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //Make ranged enemy move towards player
            Vector2 lookDir = player.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
        } //end if
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) //Checks to see if ranged enemy is close enough to stop moving
        {
            transform.position = this.transform.position; //sets enemy position to repeat to prevent movement
        } //end else if
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance) //checks to see if the ranged enemy is to close to player
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime); //retreats the ranged enemy
        } //end else if
    } //end update
} //end class