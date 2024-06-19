using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour
{
   // Public variables
   public float speed;
   public float floatTimer_max;
  
   // Private variables
   Rigidbody2D rigidbody2d;

   private bool floatUp = false;
   private float floatTimer;

   // Awake is called when the Projectile GameObject is instantiated
   void Awake()
   {
      rigidbody2d = GetComponent<Rigidbody2D>();
   }


   // Start is called before the first frame update
   void Start()
   {
      floatTimer = floatTimer_max;
   }


   // Update is called every frame
   void Update()
   { 
      floatTimer -= Time.deltaTime;

      if (floatTimer <= 0)
      {
        floatUp = !floatUp;
        floatTimer = floatTimer_max;
      }
     
   }

  // FixedUpdate has the same call rate as the physics system
  void FixedUpdate()
  {    
    Vector2 position = rigidbody2d.position;
     
    position.x = position.x - speed * Time.deltaTime;

    if (floatUp)
    {
      position.y = position.y + 0.1f * Time.deltaTime;
    }
    else
    {
      position.y = position.y - 0.1f * Time.deltaTime;
    }

    rigidbody2d.MovePosition(position);
  }

  /*
  void OnCollisionEnter2D(Collision2D other)
  {
    GameObject touched = other.gameObject;
    if (touched != null)
    {
      Destroy(touched);
    }
  }
  */

}