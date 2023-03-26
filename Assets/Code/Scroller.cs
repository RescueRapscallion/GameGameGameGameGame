using UnityEngine;

public class PrefabScrolling : MonoBehaviour
{
    public GameObject prefab;
    public float scrollSpeed;
    public float respawnOffset;

    private GameObject[] prefabs;
    private int currentIndex = 0;

    void Start()
    {
        prefabs = new GameObject[2];
        prefabs[0] = Instantiate(prefab, transform.position, Quaternion.identity);
        prefabs[1] = Instantiate(prefab, transform.position + new Vector3(respawnOffset, 0, 0), Quaternion.identity);
    }

    void Update()
    {
        // Move the prefabs to the left
        foreach (GameObject obj in prefabs)
        {
            obj.transform.position -= new Vector3(scrollSpeed * Time.deltaTime, 0, 0);
        }

        // Check if the first prefab has moved off the screen
        if (prefabs[currentIndex].transform.position.x < -respawnOffset)
        {
            // Move the first prefab to the right of the second prefab
            prefabs[currentIndex].transform.position = prefabs[(currentIndex + 1) % 2].transform.position + new Vector3(respawnOffset, 0, 0);
            currentIndex = (currentIndex + 1) % 2;
        }
    }
}
