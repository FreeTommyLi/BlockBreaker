using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 10f;

    public bool launchBall = false;
    public Vector3 paddleToBall = new Vector3(0, 0.5f, -1);

	// Use this for initialization
	void Start () {

        paddle = GameObject.FindObjectOfType<Paddle>();


    }
	
	// Update is called once per frame
	void Update () {
        if (!launchBall)
        {
            LockBallPos();

            if (Input.GetMouseButtonDown(0))
            {
                launchBall = true;
                LaunchOnMouseClick();

            }
        }
        
		
	}
    public void OnCollisionEnter2D(Collision2D collision) {
        Vector2 tweak = new Vector2(Random.Range(-0.05f, 0.2f), Random.Range(-0.05f, 0.2f));
        GetComponent<Rigidbody2D>().velocity += tweak;
    }


    private void LaunchOnMouseClick() {

        GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
        

    }

    void LockBallPos() {
        Vector3 ballPos = new Vector3(paddle.transform.position.x, paddle.transform.position.y, -1);
        this.transform.position = ballPos + paddleToBall;
    }


    
    
}
