using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float motionSpeed = 0.3f;
    [SerializeField] ParticleSystem parSystem;
    [SerializeField] GameObject gameOver;
    private Vector3 playerPosition;
    private Vector3 endPosition;
    private bool isLog = false;
    //event
    public static event Action UpArrowClick;


    // Start is called before the first frame update
    void Start()
    {
        playerPosition = transform.position;
        endPosition = playerPosition;
       // anm = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        moveWithLog();
    }

    private void movePlayer()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           // anm.Play("Walk");
            endPosition.z++;
            UpArrowClick.Invoke();
            detectLog(new Vector3 (endPosition.x, endPosition.y, endPosition.z));
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //anm.Play("Walk");
            endPosition.z--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //anm.Play("Walk");
            endPosition.x++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //anm.Play("Walk");
            endPosition.x--;
        }

        transform.position = Vector3.Lerp(transform.position, endPosition, motionSpeed);
    }

    private void detectLog(Vector3 targetPosition)
    {
        if(Physics.Raycast(targetPosition, Vector3.down, out RaycastHit hitInfo))
        {
            if (hitInfo.collider.tag.Equals("Log"))
            {
                isLog = true;
            }

            else
            {
                isLog = false;
            }
        }

        else
        {
            isLog = false;
        }
    }

    //private void detectCars(Vector3 targetPosition)
    //{
    //    if (Physics.Raycast(targetPosition, Vector3.forward, out RaycastHit hitInfo))
    //    {
    //        if (hitInfo.collider.tag.Equals("Car"))
    //        {
    //            print("car move!");
    //        }

    //    }
    //}

    // To detect collision with bird
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag.Equals("Car"))
        {
            parSystem.transform.position = transform.position;
            parSystem.Play();
            gameOver.SetActive(true);

        }
    }

    private void moveWithLog()
    {
        if (isLog)
        {
            endPosition.x += -1f * 5f * Time.deltaTime;
        }
    }
}
