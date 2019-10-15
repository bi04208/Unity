using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Properties
    public Transform m_PlayerTransform;
    private Transform m_Transform;
    #endregion
    // Start is called before the first frame update

    #region Method
    void Start()
    {
        m_Transform = transform;

        Debug.Log("START");
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        m_Transform.position = new Vector3(m_PlayerTransform.position.x, m_PlayerTransform.position.y+2, m_Transform.position.z);
    }
    #endregion
}
