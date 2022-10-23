using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public Rigidbody rb;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player" && other.gameObject.transform.position.z > 50)
        {
            //Destroy(other.gameObject);
            rb.AddForce(0,5,0,ForceMode.Impulse);
            rb.AddRelativeTorque(100,0,0);
            Debug.Log("Win!");
        }
    }
}
