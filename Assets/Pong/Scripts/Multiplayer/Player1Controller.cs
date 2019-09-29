using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    //references
    Rigidbody rb;
    

    //private variables
    Vector3 velocity;


    [SerializeField] [Range(0,200)] public float movementSpeed;
    [SerializeField] public string playerControls;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        velocity.y = Input.GetAxis(playerControls) * movementSpeed;

        rb.velocity = velocity;
    }

}
