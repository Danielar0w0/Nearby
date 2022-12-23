using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSelectionController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When clicked
    void OnMouseDown()
    {

        GameObject gmObj = transform.parent.transform.parent.GetChild(1).gameObject;
        DataStore.getInstance().CurrentModel = Instantiate(gmObj);

        Debug.Log("Selected Game Object - " + gmObj);

    }

}
