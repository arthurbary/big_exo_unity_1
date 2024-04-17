using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("IT'S AN OBSTACLE");
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
