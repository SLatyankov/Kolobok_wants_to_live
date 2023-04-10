using UnityEngine;
using System.Runtime.InteropServices;
using System.Collections;

[System.Serializable]
public class DataStore
{
    public float maxTimeScore = 0;
}
public class DataBox : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SaveData(string playerInfo);

    [DllImport("__Internal")]
    private static extern void LoadData();

    [DllImport("__Internal")]
    private static extern void GetDevice();

    public DataStore dataStore;
    public static DataBox Instance { get; private set; }

    public bool isPC = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Start()
    {
        StartCoroutine(WaitAndLoad());
    }
    public void SaveToServer()
    {
        string jsonString = JsonUtility.ToJson(dataStore);
#if !UNITY_EDITOR && UNITY_WEBGL
        SaveData(jsonString);
#endif
    }
    public void LoadFromServer(string value)
    {
#if !UNITY_EDITOR && UNITY_WEBGL
         dataStore = JsonUtility.FromJson<DataStore>(value);       
#endif
    }
    public void SetDevice(string device)
    {
        if (device != "desktop")
        {
            isPC = false;
        }
    }
    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(0.2f);
#if !UNITY_EDITOR && UNITY_WEBGL
            LoadData();
            GetDevice();
#endif
    }
}