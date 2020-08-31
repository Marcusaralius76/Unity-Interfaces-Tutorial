using System.Collections.Generic;
using UnityEngine;
public class DoorController : MonoBehaviour
{
    public List<Transform> hinges = new List<Transform>();
    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void CheckHinges()
    {
        if (hinges.Count == 0)
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}