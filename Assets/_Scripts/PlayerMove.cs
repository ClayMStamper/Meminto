using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Vector3 velocity;

    public float runSpeed = 2;
    public float runAcceleration = 0.01f;

    public Vector3 fallAcceleration = new Vector3(0, -10, 0);
    public float jumpForce = 500;
    private Rigidbody rb;
    private int maxJumps = 3;
    private int jumpsUsed = 0;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        Run();
        Jump();
    }

    void Run() {
        
        if (GetInput.Forward()) {
            float xVelocity = Mathf.Clamp(velocity.x + runAcceleration * Time.deltaTime, 0, runSpeed);
            velocity = velocity.WithValues(x: xVelocity);
        } else if (GetInput.Back()) {
            float xVelocity = Mathf.Clamp(velocity.x - runAcceleration * Time.deltaTime, -runSpeed, 0);
            velocity = velocity.WithValues(x: xVelocity);
        }
        else {
            velocity = velocity.Lerp(Vector3.zero, Time.deltaTime * 3);
        }
        
        transform.Translate(velocity * Time.deltaTime);

    }

    private void Jump() {
        Vector3 velocity = GetVerticalMovement(fallAcceleration);
        rb.AddForce(velocity);
    }

    //adds _force to velocity
    public Vector3 GetVerticalMovement(Vector3 acc) {
        
        if (jumpsUsed >= maxJumps)
            return acc;
        
        if (GetInput.Up()) {
            jumpsUsed++;
            rb.velocity = Vector3.zero;
            return acc + new Vector3(0,jumpForce);
        }

        return acc;

    }
    
    private void OnCollisionEnter(Collision other) {
        
        //check if other is the ground
        // not a platform
        if (other.gameObject.layer != 9)
            return; 
        
        //below platform
        if (other.transform.position.y - transform.position.y > 0)
            return;

        OnLanded();

    }

    private void OnLanded() {
        jumpsUsed = 0;
    }
}
