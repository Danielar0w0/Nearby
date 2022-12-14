using UnityEngine;

public class DataStore
{

    private static DataStore instance;

    private GameObject currentPrefab;
    private GameObject currentModel;

    private DataStore() { }

    public GameObject CurrentPrefab { get; set; }

    public GameObject CurrentModel { get; set; }
    
    public static DataStore getInstance()
    {
        if (instance == null)
        {
            instance = new DataStore();
        }
        return instance;
    }

}
