using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private Rigidbody2D rb;

    AudioSource audioSource;

    public Vector3 speed;
    public float MaxXClamp = 1;
    public float MinXClamp = 1;
    public float MaxYClamp = 1;
    public float MinYClamp = 1;

    // Use this for initialization
    void Start()
    {

        audioSource = GetComponent<AudioSource>();

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = speed;
        PositionClamp();
    }

    void PositionClamp()
    {
        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, MinXClamp, MaxXClamp), Mathf.Clamp(gameObject.transform.position.y, MinYClamp, MaxYClamp), gameObject.transform.position.z);
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("OnCollisionEnter2D");

        var relativeSpeed = collision.relativeVelocity;
        Debug.Log(collision.relativeVelocity);
        Debug.Log(string.Format("{0} transform:{1} velocity:{2} angularVelocity:{3}", collision.rigidbody.name, collision.rigidbody.transform, collision.rigidbody.velocity, collision.rigidbody.angularVelocity));
        Debug.Log(string.Format("{0} transform:{1} velocity:{2} angularVelocity:{3}", collision.otherRigidbody.name, collision.otherRigidbody.transform, collision.otherRigidbody.velocity, collision.otherRigidbody.angularVelocity));

        if (collision.rigidbody.name == "TopSide" || collision.rigidbody.name == "BottomSide")
            relativeSpeed.x *= -1;
        else
            relativeSpeed.y *= -1;

        speed = relativeSpeed;

        //if (collision.relativeVelocity.magnitude > 2)
            audioSource.Play();
    }
}
