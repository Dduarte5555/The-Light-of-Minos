using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// This script is based on the tutorial from Sunny Valley Studio
// at https://www.youtube.com/watch?v=RXhTD8YZnY4&list=PLcRSafycjWFcwCxOHnc83yA0p4Gzx0PTM&index=7
public class Knockback : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D rigidBody2D;

    [SerializeField] 
    private float strength = 16f, delay = 0.15f;
    public UnityEvent OnBegin, OnDone;

    public void PlayFeedback(GameObject sender)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rigidBody2D.AddForce(direction*strength, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset() 
    {
        yield return new WaitForSeconds(delay);
        rigidBody2D.velocity = Vector3.zero;
        OnDone?.Invoke();
    }

}
