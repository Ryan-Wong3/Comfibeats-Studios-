using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
        Destroy(other.gameObject);
    }
}
