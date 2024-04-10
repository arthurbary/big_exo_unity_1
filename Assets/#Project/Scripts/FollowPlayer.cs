using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] Transform target;
    [SerializeField] private float speed;

    // Update is called once per frame
    void Update()
    {
        float z = transform.position.z + speed * speed * Time.deltaTime;
        Vector3 position = transform.position;
        position.z = Mathf.Min(target.position.z + offset, z);
        transform.position = position;
    }
}
