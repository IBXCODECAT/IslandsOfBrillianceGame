using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Audio;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject player;
    public List<GameObject> islands;
    public List<Transform> spawnpoint;
    public string[] VolumeList;
    public string[] PlayerPrefList;
    public AudioMixer Mixer;

    int island;

    private void Awake()
    {
        instance = this;

        island = PlayerPrefs.GetInt("IslandCount");
        islands[island].SetActive(true);
        RespawnPlayer(PlayerPrefs.GetInt("IslandCount"));

        StartCoroutine(LoadVolumeSettings());
    }

    public void RespawnPlayer(int i) 
    {
        player.transform.position = new Vector3(spawnpoint[i].position.x, spawnpoint[i].position.y, spawnpoint[i].position.z);
    }

    private IEnumerator LoadVolumeSettings()
    {
        yield return new WaitForSeconds(.01f);

        for (int i = 0; i < VolumeList.Length; i++)
        {
            Mixer.SetFloat(VolumeList[i], Mathf.Log10(PlayerPrefs.GetFloat(PlayerPrefList[i])) * 20);
        }
    }

    public void GameSave(Dictionary<GameObject, int> worldState) 
    {
        int template = PlayerPrefs.GetInt("IslandCount");
        islands[template].SetActive(true);
        List<Vector3> positions = new List<Vector3>();
        List<Quaternion> rotations = new List<Quaternion>();
        List<Vector3> scales = new List<Vector3>();
        List<int> objectIndex = new List<int>();

        foreach(KeyValuePair<GameObject, int> gO in worldState) 
        {
            positions.Add(gO.Key.transform.position);
            rotations.Add(gO.Key.transform.rotation);
            scales.Add(gO.Key.transform.localScale);
            objectIndex.Add(gO.Value);
        }

        PlayerPrefsX.SetVector3Array("objectPositions"+ island, positions.ToArray());
        PlayerPrefsX.SetQuaternionArray("objectRotations" + island, rotations.ToArray());
        PlayerPrefsX.SetVector3Array("objectScales" + island, scales.ToArray());
        PlayerPrefsX.SetIntArray("objectsIndex" + island, objectIndex.ToArray());
    }
     
    public Dictionary<GameObject, int> GameLoad(List <GameObject> buildingOptions) 
    {
        Dictionary<GameObject, int> worldState = new Dictionary<GameObject, int>();
        List<Vector3> positions = PlayerPrefsX.GetVector3Array("objectPositions" + island).ToList();
        List<Quaternion> rotations = PlayerPrefsX.GetQuaternionArray("objectRotations" + island).ToList();
        List<Vector3> scales = PlayerPrefsX.GetVector3Array("objectScales" + island).ToList();
        List<int> objectIndex = PlayerPrefsX.GetIntArray("objectsIndex" + island).ToList();

        for (int currentIndex = 0; currentIndex < objectIndex.Count; currentIndex++)
        {
            GameObject loadedObject = Instantiate(buildingOptions[objectIndex[currentIndex]]);
            loadedObject.transform.position = positions[currentIndex];
            loadedObject.transform.rotation = rotations[currentIndex];
            loadedObject.transform.localScale = scales[currentIndex];

            worldState.Add(loadedObject, objectIndex[currentIndex]);
        }
        return worldState;
    }

    public void ResetIsland()
    {
        PlayerBuilding playerBuilding = GameObject.Find("Player").GetComponent<PlayerBuilding>();

        if(playerBuilding)
        {
            List<GameObject> activeObjects = new List<GameObject>();

            foreach(KeyValuePair<GameObject, int> go in playerBuilding.worldState)
                activeObjects.Add(go.Key);

            playerBuilding.worldState.Clear();

            foreach(GameObject go in activeObjects)
                Destroy(go);

            activeObjects.Clear();
        }

        List<Vector3> positions = new List<Vector3>();
        List<Quaternion> rotations = new List<Quaternion>();
        List<Vector3> scales = new List<Vector3>();
        List<int> objectIndex = new List<int>();

        PlayerPrefsX.SetVector3Array("objectPositions" + island, positions.ToArray());
        PlayerPrefsX.SetQuaternionArray("objectRotations" + island, rotations.ToArray());
        PlayerPrefsX.SetVector3Array("objectScales" + island, scales.ToArray());
        PlayerPrefsX.SetIntArray("objectsIndex" + island, objectIndex.ToArray());
    }
}
 