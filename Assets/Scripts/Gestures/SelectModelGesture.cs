using UnityEngine;

public class SelectModelGesture : MonoBehaviour
{

    [SerializeField]
    private bool isInteractiveModel;

    [SerializeField]
    private bool selectRoot;

    [SerializeField]
    private bool selectChild;

    [SerializeField]
    private int childIndex;

    private void OnMouseDown()
    {

        GameObject selectedObject;

        if (selectRoot)
        {
            selectedObject = transform.root.gameObject;
        } else if (selectChild)
        {
            selectedObject = transform.GetChild(childIndex).gameObject;
        } else
        {
            selectedObject = transform.gameObject;
        }
        
        GameObject currentlySelectedObject = DataStore.getInstance().CurrentModel;

        if (currentlySelectedObject != selectedObject)
        {
            EventManager.current.OnModelSelected(selectedObject);

            DataStore.getInstance().CurrentModel = selectedObject;
            DataService.getInstance().UpdateCurrentModel(isInteractiveModel);

        }

        Debug.Log("Model Clicked: " + selectedObject.name);

    }

}
