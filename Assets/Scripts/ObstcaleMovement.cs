using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstcaleMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    private float rigthEdge = 44f;
    private float leftEdge = -48f;
    Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (gameObject.tag.Equals("Car"))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            if (transform.position.x > rigthEdge)
            {
                transform.position = startPosition;
            }
        }

        else if (gameObject.tag.Equals("Log"))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x < leftEdge)
            {
                transform.position = startPosition;
            }
        }
    }
}
