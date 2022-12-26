using UnityEngine;

public class Select3DModel : MonoBehaviour
{

    private void OnMouseDown()
    {

        GameObject childObject = transform.GetChild(0).gameObject;
        GameObject currentlySelectedObject = DataStore.getInstance().CurrentModel;

        if (currentlySelectedObject != childObject)
        {
            EventManager.current.OnModelSelected(childObject);

            DataStore.getInstance().CurrentModel = childObject;
            DataService.getInstance().UpdateCurrentModel();
        }

        Debug.Log("Model Clicked: " + childObject.name);

    }

}
