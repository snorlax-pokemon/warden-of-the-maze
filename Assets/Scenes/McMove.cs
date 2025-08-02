using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class McMove : MonoBehaviour
{
    public Rigidbody2D MyRigidBody;
    public float MoveFactor = 5;
    private Animator anim;
    private bool IsFacingRight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsFacingRight = true;
        anim = GetComponent<Animator>();
  
    }
 
    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector2.right;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("IsAttacking", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("IsAttacking", false);
        }
        anim.SetBool("IsWalking", movement != Vector2.zero);
        if (!IsFacingRight && movement == Vector2.right)
        {
            Flip();
        }
        else if (IsFacingRight && movement == Vector2.left)
        {
            Flip();
        }

        // Normalise so diagonal movement isn't faster
        movement = movement.normalized;

        // Apply velocity
        MyRigidBody.linearVelocity = movement * MoveFactor;
    }
    public void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }

}

