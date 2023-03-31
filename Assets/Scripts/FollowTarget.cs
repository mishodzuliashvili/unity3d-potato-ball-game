using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] Transform m_target;
    [SerializeField] float m_speed = 1000f;
    [SerializeField] float m_retargetingSpeed = 2f;

    RollingMovement m_rollingMovement;


    private void Start()
    {
        m_rollingMovement = GetComponent<RollingMovement>();

    }

    private void FixedUpdate()
    {
        Vector3 m_tagetDirection = m_target.position - transform.position;

        float retargetSpeed = Vector3.SqrMagnitude(m_tagetDirection) < 0.1f ? m_speed : m_retargetingSpeed;

        m_rollingMovement.m_movementDirection = Vector3.Lerp(m_rollingMovement.m_movementDirection,
                                                             m_tagetDirection.normalized,
                                                             retargetSpeed * Time.fixedDeltaTime);
    }
}
