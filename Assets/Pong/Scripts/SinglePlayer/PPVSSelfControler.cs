using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPVSSelfControler : MonoBehaviour
{
    //references
    Rigidbody rb;
    public GameObject BallOBJ;
    public GameObject Player1OBJ;
    public GameObject Player2OBJ;

    Color NuturalColor = Color.white;
    Color Player1Color = Color.blue;
    Color Player2Color = Color.red;

    //private variables
    Vector3 velocity;

    [SerializeField] [Range(0, 200)] public float movementSpeed;
    [SerializeField] public string playerControls;


    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayers();
        ChangeColors();
    }

    void MovePlayers()
    {
        if (BallOBJ.transform.position.x < 0)
        {
            Player2OBJ.GetComponent<Rigidbody>().velocity = Vector3.zero;

            velocity.y = Input.GetAxis(playerControls) * movementSpeed;
            Player1OBJ.GetComponent<Rigidbody>().velocity = velocity;
        }
        else if (BallOBJ.transform.position.x > 0)
        {
            Player1OBJ.GetComponent<Rigidbody>().velocity = Vector3.zero;

            velocity.y = Input.GetAxis(playerControls) * movementSpeed;
            Player2OBJ.GetComponent<Rigidbody>().velocity = velocity;
        }
    }

    void ChangeColors()
    {
        if (BallOBJ.transform.position.x < 0)
        {
            BallOBJ.GetComponent<Renderer>().material.color = Player1Color;

            Player1OBJ.GetComponent<Renderer>().material.color = Player1Color;
            Player2OBJ.GetComponent<Renderer>().material.color = NuturalColor;
        }
        else if (BallOBJ.transform.position.x > 0)
        {
            BallOBJ.GetComponent<Renderer>().material.color = Player2Color;

            Player1OBJ.GetComponent<Renderer>().material.color = NuturalColor;
            Player2OBJ.GetComponent<Renderer>().material.color = Player2Color;
        }

    }
}
