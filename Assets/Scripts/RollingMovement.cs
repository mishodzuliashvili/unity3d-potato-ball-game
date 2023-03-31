using UnityEngine;

public class RollingMovement : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    Rigidbody m_rigidbody;
    [HideInInspector] public Vector3 m_movementDirection;
    Vector3 m_startPosition;


    void Start()
    {

        // Gather components and variables that will be needed later
        m_rigidbody = GetComponent<Rigidbody>();
        m_startPosition = transform.position;
    }

    void FixedUpdate()
    {
        // Move the object
        m_rigidbody.AddForce(m_movementDirection * speed);

        // If the Y position is below the respawn height, reset the position
        if (transform.position.y < GameManager.RespawnHeight)
        {
            ResetPosition();
        }
    }

    public void ResetPosition()
    {
        // Reset velocity and position back to start
        m_rigidbody.velocity = Vector3.zero;
        m_rigidbody.angularVelocity = Vector3.zero;
        transform.position = m_startPosition;
    }
}
