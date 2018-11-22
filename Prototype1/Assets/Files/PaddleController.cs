using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        _rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        Movement();
	}

    void Movement()
    {
        if (Input.GetKey(leftMovement))
        {
            gameObject.transform.position += direction1 * Time.deltaTime * speed;
        }
        if (Input.GetKey(rightMovement))
        {
            gameObject.transform.position -= direction1*Time.deltaTime*speed;
        }
        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x,MinXClamp, MaxXClamp), Mathf.Clamp(gameObject.transform.position.y, MinYClamp, MaxYClamp), gameObject.transform.position.z);
    }

    private Rigidbody2D _rb;
    public float speed =1;
    public KeyCode leftMovement;
    public KeyCode rightMovement;
    public Vector3 direction1;
    public float MaxXClamp = 1;
    public float MinXClamp = 1;
    public float MaxYClamp = 1;
    public float MinYClamp = 1;
}
