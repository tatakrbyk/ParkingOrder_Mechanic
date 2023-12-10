using PathCreation;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

[ExecuteInEditMode]

public class CarManager : PathFollower
{

    private Rigidbody _rigidbody;
    private Collider _collider;
    protected override void Start()
    {
        base.Start();
        AddComponent();
    }

    private void AddComponent()
    {
        if(!GetComponent<Rigidbody>())
            gameObject.AddComponent<Rigidbody>().isKinematic = true;

        if (!GetComponent<BoxCollider>())
        {
            gameObject.AddComponent<BoxCollider>().size = new Vector3(2f, 2f, 4f);
            GetComponent<BoxCollider>().center = Vector3.up; // new vector3 (0f, 1f, 0f)
            GetComponent<BoxCollider>().isTrigger = true;
        }
            

        gameObject.tag = "Car";
        endOfPathInstruction = EndOfPathInstruction.Stop; // path Follover properties change

        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) // accident
        {
            moveCar = false;
            GameManager.gameManagerInstance._lose = true;
            GameManager.gameManagerInstance.Lose();

            _rigidbody.isKinematic = _collider.isTrigger = false;
            other.GetComponent<Rigidbody>().AddForceAtPosition(other.transform.position * 4f, other.transform.position);
        }
    }
}
