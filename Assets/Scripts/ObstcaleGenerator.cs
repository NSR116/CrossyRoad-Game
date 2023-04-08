using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstcaleGenerator : MonoBehaviour
{
    [SerializeField] private GameObject log;
    [SerializeField] private List<GameObject> carList = new List<GameObject>();
    [SerializeField] private List<GameObject> treeList = new List<GameObject>();
    private Vector3 position;
    private Vector3 carPosition;

    public void generateObstcale(GameObject currentGround)
    {
        int x = Random.Range(5, 20);
        position = new Vector3(currentGround.tag.Equals("Grass")? -22f : 44f, 0, currentGround.transform.position.z);
        carPosition = new Vector3(currentGround.transform.position.x-44f, 0.2f, currentGround.transform.position.z);

        for (int i = 0; i < x; i++)
        {
            if (currentGround.tag.Equals("Grass"))
            {
                position.y = 0.2f;
                Instantiate(treeList[Random.Range(0, treeList.Count)], position, Quaternion.identity);
                position.x = position.x + 5f;

            }

            if (currentGround.tag.Equals("Road"))
            {
                Instantiate(carList[Random.Range(0, carList.Count)], carPosition, Quaternion.Euler(0f,90f,0f));
                carPosition.x = carPosition.x + 5f;

            }

            if (currentGround.tag.Equals("Water"))
            {
                position.y = -0.65f;
                Instantiate(log, position, Quaternion.identity);
                position.x = position.x - 14f;

            }
        }

    }
}
