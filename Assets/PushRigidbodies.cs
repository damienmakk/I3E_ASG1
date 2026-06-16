using UnityEngine;

public class PushRigidbodies : MonoBehaviour
{
    [SerializeField]
    float pushPower = 2f;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if(body == null)
        {
            return;
        }

        if(body.isKinematic)
        {
            return;
        }

        if(!hit.collider.CompareTag("Pushable"))
        {
            return;
        }

        if(hit.moveDirection.y < -0.3f)
        {
            return;
        }

        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0f, hit.moveDirection.z);

        body.AddForce(pushDirection * pushPower, ForceMode.Impulse);
    }
}