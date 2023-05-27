using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement player;
    float lastFrameFingerPositionX;
    float moveFactorX;
    public float swerveSpeed = 1f;
    private void Awake()
    {
        player = this;
    }
    void Update()
    {
        SwerveSystem();
        Move();
    }
    public void SwerveSystem()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
    }
    public void Move()
    {
        float swerveAmount = Time.deltaTime * swerveSpeed * moveFactorX;
        transform.Translate(x: swerveAmount, y: 0, z: 1 * swerveSpeed * Time.deltaTime * 3);
        float posX = Mathf.Clamp(transform.position.x, -4, 4);
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}
