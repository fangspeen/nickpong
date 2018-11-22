using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    private Rigidbody2D rb;

    public Vector3 speed;
    public float MaxXClamp = 1;
    public float MinXClamp = 1;
    public float MaxYClamp = 1;
    public float MinYClamp = 1;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = speed;
        PositionClamp();
	}

    void PositionClamp()
    {
        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, MinXClamp, MaxXClamp), Mathf.Clamp(gameObject.transform.position.y, MinYClamp, MaxYClamp), gameObject.transform.position.z);
    }

    // called when the cube hits the floor
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("TopPaddle"))
        {
            var relativeSpeed = col.relativeVelocity;
            relativeSpeed.x *= -1;
            speed = relativeSpeed;
            Debug.Log("OnCollisionEnter2D");
        }
    }
}
