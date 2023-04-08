using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> groundList = new List<GameObject>();
    private Vector3 goundPosition = new Vector3(0, 0, 0);
    private GameObject currentGround;
    public ObstcaleGenerator obstcaleObj;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            generateGround();
        }

        PlayerMovement.UpArrowClick += generateGround;
    }

    private void generateGround()
    {
        int x = Random.Range(0, groundList.Count);

        currentGround = Instantiate(groundList[x], goundPosition, Quaternion.identity);
        goundPosition.z = goundPosition.z + 5.5f;

        obstcaleObj.generateObstcale(currentGround);
    }

}


