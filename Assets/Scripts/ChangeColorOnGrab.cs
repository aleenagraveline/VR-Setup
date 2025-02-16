using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChangeColorOnGrab : MonoBehaviour
{
    public GameObject sphereHand;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rayInteractor;

    private void OnEnable()
    {
        rayInteractor.selectEntered.AddListener(PickUpObject);
        rayInteractor.selectExited.AddListener(DropObject);
    }

    private void OnDisable()
    {
        rayInteractor.selectEntered.RemoveListener(PickUpObject);
        rayInteractor.selectExited.RemoveListener(DropObject);
    }

    public void PickUpObject(SelectEnterEventArgs args)
    {
        //args.interactableObject.transform.GetComponent<MeshRenderer>().material.color = Color.white;
        sphereHand.SetActive(false);
    }
    public void DropObject(SelectExitEventArgs args)
    {
        //args.interactableObject.transform.GetComponent<MeshRenderer>().material.color = Color.red;
        sphereHand.SetActive(true);
    }
}
