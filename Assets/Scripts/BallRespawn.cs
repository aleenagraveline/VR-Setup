using UnityEngine;

public class BallRespawn : MonoBehaviour
{
    [SerializeField] private GameObject ceiling;
    [SerializeField] private Rigidbody basketball;

    public void OnTriggerExit(Collider collider)
    {
        if(collider == ceiling.GetComponent<Collider>())
        {
            basketball.constraints = RigidbodyConstraints.FreezeAll;
            transform.position = new Vector3(0.0f, 0.0f, 1.4f);
            basketball.constraints = RigidbodyConstraints.None;
        }
    }
}

