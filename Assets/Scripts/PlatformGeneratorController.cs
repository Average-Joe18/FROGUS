using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorController : MonoBehaviour
{

    //public variables
    public GameObject MedLog1Prefab;
    public GameObject MedLog2Prefab;

    public float generateCooldownMax;

    //private variables
    Rigidbody2D rigidbody2d;

    private float generateCooldown;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        generateCooldown -= Time.deltaTime;

        if (generateCooldown <= 0)
        {
            if (Random.value < 0.2)
            {
                CreateMedLog1();
            }
            else
            {
                CreateMedLog2();
            }
            generateCooldown = generateCooldownMax;
            generateCooldown -= Random.value * 2.5f;
        }
    }

    void CreateMedLog1()
    {
        GameObject projectileObject = Instantiate(MedLog1Prefab, rigidbody2d.position + Vector2.down * 7.5f, Quaternion.identity);
    }

    void CreateMedLog2()
    {
        GameObject projectileObject = Instantiate(MedLog2Prefab, rigidbody2d.position + Vector2.down * 7.0f, Quaternion.identity);
    }
}
