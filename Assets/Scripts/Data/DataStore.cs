using UnityEngine;

public class DataStore
{

    private static DataStore instance;

    // Data fields
    public GameObject CurrentPrefab { get; set; }
    public GameObject CurrentModel { get; set; }

    private DataStore() { }
    
    public static DataStore getInstance()
    {
        if (instance == null)
            instance = new DataStore();
        return instance;
    }

}
