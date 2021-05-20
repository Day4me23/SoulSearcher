using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed; //Enemy move speed
    public float stoppingDistance; //This shows how far the enemy will stop from the player
    public float retreatDistance; //This is used to show when the enemy will retreat from the 

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    private Transform player;

    public Rigidbody2D rb;



    void Start()
    {
        player = GameManager.instance.playerCurrent.transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        
        

        Vector2 lookDir = player.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;


        if (Vector2.Distance(transform.position, player.position) > stoppingDistance) //checks how far the player is from ranged enemy
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //Make ranged enemy move towards player
            
        } //end if
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance) //Checks to see if ranged enemy is close enough to stop moving
        {
            
            transform.position = this.rb.position; //sets enemy position to repeat to prevent movement
        } //end else if
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance) //checks to see if the ranged enemy is to close to player
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime); //retreats the ranged enemy
        } //end else if

        


        if (timeBtwShots <=0)
        {
            GameObject bone = Instantiate(projectile, transform.position, Quaternion.identity); //Bone spawn
            Rigidbody2D boneRB = bone.GetComponent<Rigidbody2D>();
            boneRB.AddForce(transform.up*8f, ForceMode2D.Impulse);
            timeBtwShots = startTimeBtwShots; //Prevents the ranged AI from shooting every frame and gives the shot a cooldown
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }



    } //end update
} //end class
