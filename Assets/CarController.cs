using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class CarController : MonoBehaviour
{
    public InputManager manager;
    public List<WheelCollider> throttleWheels;
    public List<GameObject> steeringWheels;
    public List<GameObject> meshes;
    public float strengthCoefficient = 20000f;
    public float maxTurn = 20f;
    public Rigidbody Rigidbody;

    private void Start()
    {
        manager = GetComponent<InputManager>();
        Rigidbody = GetComponent<Rigidbody>();

        
    }
    private void Update()
    {
        foreach (WheelCollider wheelCollider in throttleWheels)
        {
            wheelCollider.motorTorque = strengthCoefficient * Time.deltaTime * manager.throttle;
        }
        foreach (GameObject wheelCollider in steeringWheels)
        {
            wheelCollider.GetComponent<WheelCollider>().steerAngle = maxTurn * manager.steer;
            wheelCollider.transform.localEulerAngles = new Vector3 (0, manager.steer * maxTurn, 0);
        }

        foreach(GameObject meshe in meshes)
        {
            meshe.transform.Rotate(Rigidbody.velocity.magnitude * (transform.InverseTransformDirection(Rigidbody.velocity).z >= 0? 1: -1) / (2*Mathf.PI * 0.33f),0f,0f);
        }
    }
}
