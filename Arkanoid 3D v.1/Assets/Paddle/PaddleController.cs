using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StateManaging;

public partial class PaddleController : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    BoxCollider boxCollider;

    public List<Sprite> spriteList;

    public float moveSpeed;


    private float xMin, xMax;


    public bool SizeUp { get; set; }
    public bool SizeDown { get; set; }

    public bool ballLaunch = true;

    public StateMachine<PaddleController> StateMachine { get; set; }

    public SpriteRenderer SpriteRenderer
    {
        get { return spriteRenderer; }
        set { spriteRenderer = value; }
    }

    public BoxCollider BoxCollider
    {
        get { return boxCollider; }
        set { boxCollider = value; }
    }

    public float XMin
    {
        get { return xMin; }
        set
        {
            xMin = value;
        }
    }
    public float XMax
    {
        get { return xMax; }
        set
        {
            xMax = value;
        }
    }


    private void Awake()
    {
        if (FindObjectsOfType<PaddleController>().Length != 1) {
            Debug.LogError("There is more/less than one PaddleController!", gameObject);
        }
    }


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider>();

        StateMachine = new StateMachine<PaddleController>(this, false);
        StateMachine.ChangeState(SizeNormal.Instance);

        SizeDown = false;
        SizeUp = false;
    }

    private void FixedUpdate()
    {
        Movement();

        StateMachine.Update();

        if (ballLaunch = true && Input.GetKeyDown(KeyCode.Space)) {
            LaunchBall();
        }
    }

    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        transform.position += Vector3.right * moveHorizontal * moveSpeed;

        BoundaryClamp();
    }

    private void BoundaryClamp()
    {
        if (transform.position.x < xMin) {
            transform.position = new Vector3(xMin, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xMax) {
            transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
        }
    }

    public void LaunchBall()
    {
        GameObject ball = FindObjectOfType<BallController>().gameObject;
        float speed = ball.GetComponent<BallController>().speed;

        ball.GetComponent<BallController>().currentVelocity = new Vector3(speed, speed, 0.0f);

        ballLaunch = false;
    }

    public void MessagedSizeUp()
    {
        SizeUp = true;
    }
}
