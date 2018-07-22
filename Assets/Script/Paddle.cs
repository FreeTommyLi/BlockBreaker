using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] bool autoPlay = false;
    private Ball ball;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay) {
            MoveWithMouse();
        } else {
            AutoPlay();
        }
	}

    public void ChooseType() {
        autoPlay = true;
    }

    void AutoPlay() {

        
        Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, -2f);
        float ballPos = ball.transform.position.x;
        paddlePos.x = Mathf.Clamp(ballPos, 1f, 15f);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse() {
        float mousePos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector3 paddlePos = new Vector3(transform.position.x, transform.position.y, -2f);
        paddlePos.x = Mathf.Clamp(mousePos, 1f, 15f);
        this.transform.position = paddlePos;
    }
}
