using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataStoreAccessor : MonoBehaviour
{

    private static DataStoreAccessor instance;

    private readonly DataStore dataStore; 

    private DataStoreAccessor() {
        dataStore = DataStore.getInstance();
    }

    public GameObject InstantiateCurrentModel()
    {
        
        GameObject modelNewInstance = Instantiate(dataStore.CurrentModel);
        modelNewInstance.name = "3D_Interactive_Model";
        return modelNewInstance;

    }

    public static DataStoreAccessor getInstance()
    {
        if (instance == null)
            instance = new DataStoreAccessor();
        return instance;
    }

}
