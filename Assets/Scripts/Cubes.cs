using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    [SerializeField]
    private GameObject cube;
    [SerializeField]
    private GameObject cube2;
    [SerializeField]
    private GameObject door;
    [SerializeField]
    private GameObject enemy;

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Cube"))
        {
            // When "Cube" is clicked, toggle the visibility of objects as described.
            cube.SetActive(false);
            door.SetActive(false);
        }
        if (gameObject.CompareTag("Cube2"))
        {
            cube2.SetActive(false);
            enemy.SetActive(true);
            cube.SetActive(false);
        }
    }
}
