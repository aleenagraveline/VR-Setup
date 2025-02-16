using UnityEngine;
using TMPro;

public class DistanceDetection : MonoBehaviour
{
    public TextMeshPro scoreText;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            float distance = Vector3.Distance(Vector3.zero, collision.GetContact(0).point);
            scoreText.text = distance.ToString("#.00");
        }
    }
}
