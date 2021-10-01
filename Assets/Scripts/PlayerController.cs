using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 100.0f;
    private Rigidbody _body;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float hForce = Input.GetAxis("Horizontal");
        float vForce = Input.GetAxis("Vertical");
        Vector3 forceToApply = new Vector3(hForce, 0, vForce) * moveSpeed;
        _body.AddForce(forceToApply * Time.fixedDeltaTime);
    }

}