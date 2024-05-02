using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.SceneManagement;

[System.Serializable]
public struct PlaceablePrefabs
{
    public string name; // name corresponding to the tracked image name
    public GameObject prefab;
}


public class ARImageObjectSpawner : MonoBehaviour
{
    // Variable pointing to AR image tracking manager
    private ARTrackedImageManager imgManager;
    // Array containing available prefabs
    public PlaceablePrefabs[] prefabs;
    // Dictionary to manage created prefabs by name
    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    // Variable to store the audio source component
    private AudioSource audioSource;
    // Audio clip that stores the click sound
    public AudioClip clickSound;

    void Start()
    {
        // Get the AudioSource component from the game object this script is attached to.
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Awake()
    {
        imgManager = GetComponent<ARTrackedImageManager>();
        
        // Loop through each pre in the prefabs array.
        foreach (PlaceablePrefabs prefab in prefabs)
        {
            GameObject instantiated = Instantiate(prefab.prefab, Vector3.zero, Quaternion.identity);
            instantiated.name = prefab.name;
            spawnedPrefabs.Add(instantiated.name, instantiated);
            instantiated.SetActive(false);

        }
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            // About the first touch
            Touch touch = Input.GetTouch(0);

            // The state of the touch is Began (touch started state), and a raycast is fired from the location where the touch occurred.
            if (touch.phase == TouchPhase.Began)
            {
                // Fires a ray from the camera to the touched location.
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Raycast checks for collided objects
                if (Physics.Raycast(ray, out hit))
                {
                    // If the collided object is a created prefab, the object is processed.
                    GameObject touchedObject = hit.collider.gameObject;

                    // When you touch the Chito prefabricated structure, a sound is output and then switches to "stage2".
                    if (touchedObject.CompareTag("Chito"))
                    {
                        if (clickSound != null)
                        {
                            audioSource.PlayOneShot(clickSound);
                            SceneManager.LoadScene("stage2");
                        }

                    }
                    // When you touch the Flame prefabricated structure, a sound is output and then switches to "stage1".
                    if (touchedObject.CompareTag("Flame"))
                    { 
                        if (clickSound != null)
                        {
                            audioSource.PlayOneShot(clickSound);
                            SceneManager.LoadScene("stage1");
                        }

                    }
                    // When you touch the Final prefabricated structure, a sound is output and then switches to "stage3".
                    if (touchedObject.CompareTag("Final"))
                    {
                        if (clickSound != null)
                        {
                            audioSource.PlayOneShot(clickSound);
                            SceneManager.LoadScene("stage3");
                        }

                    }
                    
                }
            }
        }
    }

    // Register the OnImageChanged method in the trackedImagesChanged event of the AR image tracking manager (imgManager).
    private void OnEnable()
    {
        imgManager.trackedImagesChanged += OnImageChanged;
    }

    // Remove the OnImageChanged method registered in the trackedImagesChanged event.
    private void OnDisable()
    {
        imgManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        // Process the added images.
        foreach (ARTrackedImage img in args.added)
        {
            // Update the spawned (created as a prefab) object using the added image.
            UpdateSpawned(img);
        }
        // Process updated images.
        foreach (ARTrackedImage img in args.updated)
        {
            UpdateSpawned(img);
        }
        // Process the removed images.
        foreach (ARTrackedImage img in args.removed)
        {
            // Disable the prefab with the same name as the removed image.
            spawnedPrefabs[img.referenceImage.name].SetActive(false);
        }

    }


    private void UpdateSpawned(ARTrackedImage img)
    {
        string name = img.referenceImage.name;

        // Get the prefab with that name from the dictionary.
        GameObject spawned = spawnedPrefabs[name];

        // only update when tracking state is good
        if (img.trackingState == TrackingState.Tracking)
        {
            spawned.transform.position = img.transform.position;
            spawned.transform.rotation = img.transform.rotation;
            spawned.SetActive(true);
        }
        else
        {
            // poor or no tracking state
            spawned.SetActive(false);

        }
    }
}