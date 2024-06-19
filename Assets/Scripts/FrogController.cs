using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;  
using UnityEngine.InputSystem;

public class FrogController : MonoBehaviour
{
    //public variables
    public float jumpCooldownMax;

    //private variables
    private bool grounded;
    private float jumpCooldown;
    private int groundMask;

    PlayerInput input;
    Mouse mouse;
    Rigidbody2D rigidbody2d;
    Collider2D coll;
    Animator anim;
    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        groundMask = LayerMask.GetMask("ground");
        coll = GetComponent<Collider2D>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        jumpCooldown = 0;

        mainCam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        mouse = Mouse.current;

    }

    // Update is called once per frame
    void Update()
    {
        jumpCooldown = Mathf.Clamp(jumpCooldown - Time.deltaTime, 0, jumpCooldownMax);

        if (isGrounded()) 
        {
            grounded = true;
            anim.SetBool("isGrounded", true);
        }
        else
        {
            grounded = false;
            anim.SetBool("isGrounded", false);
        }
    }

    void FixedUpdate()
    {
        if (grounded && (jumpCooldownMax - jumpCooldown > 1.0f))
        {
            rigidbody2d.velocity = Vector2.zero;
        }
    }

    public void clickJump(InputAction.CallbackContext context)
    {
        if (context.started != true)
        {
            return;
        }

        Ray ray = mainCam.ScreenPointToRay(mouse.position.ReadValue());

        Vector2 dest = new Vector2(ray.origin.x, ray.origin.y);
        Vector2 jumpdir = dest - rigidbody2d.position;

        jumpdir.x *= 1.0f;
        jumpdir.y *= 2.0f;

        if (grounded && jumpCooldown <= 0)
        {
            grounded = false;
            jumpCooldown = jumpCooldownMax;
            Leap(jumpdir);
        } 
    }

    void Leap(Vector2 jumpVector)
    {
        UIHandler.Instance.AlterScore(1.0f);
        rigidbody2d.AddForce(jumpVector, ForceMode2D.Impulse);
    }

    bool isGrounded()
    {
        return Physics2D.BoxCast(rigidbody2d.position, coll.bounds.size, 0f, Vector2.down, .08f, groundMask);
    }

    void OnDestroy()
    {
        GameoverUIHandler.Instance.showGameover();
    }
}
