using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BallController : MonoBehaviour
{
    SphereCollider ballCollider;

    LayerMask collisionLayer;

    public Vector3 currentVelocity;
    float currentVelocityMagnitude;

    RaycastHit objectHit;

    public float speed;


    private void Start()
    {
        ballCollider = GetComponent<SphereCollider>();

        SetLayerMask();
    }

    private void Update()
    {
        Vector3 newBallPosition = transform.position;
        Vector3 newVelocity = currentVelocity;
        currentVelocityMagnitude = currentVelocity.magnitude;

        CollisionCheck(newVelocity, newBallPosition);
    }

    private void CollisionCheck(Vector3 newVelocity, Vector3 newBallPosition)
    {
        Vector3 newDirectionNormalized = newVelocity.normalized;
        float newVelocityMagnitude = newVelocity.magnitude;
        float ballScaledRadius = ballCollider.radius * transform.localScale.x;

        bool raycastCollision = Physics.SphereCast(newBallPosition, ballScaledRadius, newDirectionNormalized, out objectHit, newVelocityMagnitude, collisionLayer, QueryTriggerInteraction.Collide);
        

        if (raycastCollision) {
            //Collision
            if (objectHit.collider.gameObject.CompareTag("Brick")) {
                DamageBrick();
            }
            Movement(objectHit, newDirectionNormalized, newBallPosition, newVelocityMagnitude);

        }
        else {
            //No collision
            Movement(newVelocity, newBallPosition);
        }


    }

    private void Movement(RaycastHit objectHit, Vector3 newDirectionNormalized, Vector3 newBallPosition, float newVelocityMagnitude)
    {
        float moveInitial = objectHit.distance;
        float moveDistanceAfterCollision = newVelocityMagnitude - moveInitial;

        newBallPosition += newDirectionNormalized * moveInitial;

        Vector3 newDirection = Vector3.Reflect(newDirectionNormalized, objectHit.normal);
        Vector3 newVelocity = newDirection * moveDistanceAfterCollision;

        newVelocity = newDirection * newVelocityMagnitude;

        CollisionCheck(newVelocity, newBallPosition);
    }

    private void Movement(Vector3 newVelocity, Vector3 newBallPosition)
    {
        newBallPosition += newVelocity;
        currentVelocity = newVelocity.normalized * currentVelocityMagnitude;
        transform.position = newBallPosition;
    }

    void DamageBrick()
    {
        objectHit.collider.gameObject.SendMessage("TakeDamage");
    }

    private void SetLayerMask()
    {
        LayerMask layerMaskPaddle = 1 << LayerMask.NameToLayer("Paddle");
        LayerMask layerMaskBrick = 1 << LayerMask.NameToLayer("Brick");
        LayerMask layerMaskWall = 1 << LayerMask.NameToLayer("Wall");

        collisionLayer = layerMaskBrick | layerMaskPaddle | layerMaskWall;
    }
}
