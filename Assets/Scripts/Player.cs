using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player status
    public bool jumping;
    public bool airBorn;
    public bool bouncy;
    float movements;
    Rigidbody2D player;
    public LayerMask ground;
    [Header("Player configurations")]
    public float moveSpeed;
    public float jumpSpeed;
    public float maxJumpValue;
    public float jumpValue;
    public float defaultJumpValue;
    public float jumpValueIncrements;
    [Header("Physics Materials")]
    public PhysicsMaterial2D airbornedPhysics;
    public PhysicsMaterial2D groundedPhysics;
    // Variables only useful for the learner
    public float validationTimeFrame;
    Learner learner;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        // Get refernce to the learner
        GameObject learnerObj = GameObject.Find("GameLearner");
        learner = learnerObj.GetComponent<Learner>();
    }

    // Update is called once per frame
    void Update()
    {
        checkAirBorn();
        handleMovement();
        handleJump();
    }

    void checkAirBorn() {
        // Check if player is airBorned
        airBorn = ! Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),
            new Vector2(0.9f, 0.4f), 0f, ground);
    }

    void handleMovement(){
        // Get desired movements from player inputs
        movements = Input.GetAxisRaw("Horizontal");
        // Approve moveent request only if NOT airBorn and not holding down jump button
        if (jumpValue == defaultJumpValue && !airBorn) {
            player.velocity = new Vector2(moveSpeed * movements, player.velocity.y);
        }
    }

    void handleJump(){
        // Increment jumpValue when player hold down jump button
        if(Input.GetKey("space") && (!airBorn) && (!jumping)) {
            // Cap jump value at certain point
            if (jumpValue < maxJumpValue)jumpValue += jumpValueIncrements;
        }

        // Disable movements when jump button is held down
        if(Input.GetKeyDown("space") && (!airBorn) && (!jumping) ) {
            player.velocity= new Vector2(0.0f, player.velocity.y);
        }

        // Apply bouncy phycis if player is jumping
        if (airBorn) {
            player.sharedMaterial = airbornedPhysics;
            bouncy = true;
        } else {
            player.sharedMaterial = groundedPhysics;
            bouncy = false;
        }

        // Force a jump if jump value exceed 20
        if (jumpValue >= 20f && (!airBorn)) {
            float newX = moveSpeed * movements;
            float newY = jumpSpeed * jumpValue;
            player.velocity = new Vector2(newX, newY);
            Invoke("resetJump", 0.2f);
        }

        // Manually release space bar to trigger jump
        if (Input.GetKeyUp("space") ){
            if (!airBorn) {
                player.velocity = new Vector2(moveSpeed * movements, jumpSpeed * jumpValue);
                jumpValue = defaultJumpValue;
            }
            jumping = false;
        }
    }

    void resetJump(){
        jumping = true;
        jumpValue = defaultJumpValue;
    }


    // TO DO : Change to bool function, return true if collided with a collectable
    // to indicate a good jump. return false otherwised
    public void randomJump(){
        float initialPos = transform.position.y;
        print("Initial y: " + Mathf.Round(initialPos * 100.0f) * 0.1f);
        float randMovement = randomDirection();
        float randJump = randomJumpForce();
        triggerJump(randMovement, randJump);
        IEnumerator coroutine =  validateJump(initialPos, randMovement, randJump);
        StartCoroutine(coroutine); 
    }


    void triggerJump(float movements, float jumpValue) {
        // print(player);
        if (player == null) player = gameObject.GetComponent<Rigidbody2D>();
        // Trigger jump
        if (!airBorn) {
            player.velocity = new Vector2(moveSpeed * movements, jumpSpeed * jumpValue);
            jumpValue = defaultJumpValue;
        }
        jumping = false;
        // Reset Jump
    }

    IEnumerator validateJump(float initialPos, float movement, float jumpValue) {
        yield return new WaitForSeconds(validationTimeFrame);
        float currentPos = transform.position.y;
        float roundedInitial = Mathf.Round(initialPos * 100.0f) * 0.1f ;
        float roundedCurrent = Mathf.Round(currentPos * 100.0f) * 0.1f;
        bool goodJump = roundedCurrent >= roundedInitial;
        print("Initial pos: " + roundedInitial + ", Current pos: " + roundedCurrent);
        if (goodJump) {
            // Update pos
            print("Good Jump");
            learner.saveJumpInfo(movement,jumpValue);
            learner.updateSpawnPos(transform.position);
        } else {
            // Do nothing
            print("Bad Jump");
        }

        // Destory the player either way to save resouces
        Destroy(this.gameObject);
    }


    float randomDirection() {
        return Random.Range(-2f, 2f);
    }

    float randomJumpForce() {
        return Random.Range(0f, 20f);
    }
}
