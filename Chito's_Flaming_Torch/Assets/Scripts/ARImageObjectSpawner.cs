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

    private ARTrackedImageManager imgManager;

    public PlaceablePrefabs[] prefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    private AudioSource audioSource;
    public AudioClip clickSound;
    void Start()
    {
        // Get the AudioSource component on the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Awake()
    {
        imgManager = GetComponent<ARTrackedImageManager>();

        foreach (PlaceablePrefabs prefab in prefabs)
        {
            // instantiate the prefab and store to the dictionary
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
            // ù ��° ��ġ�� ����
            Touch touch = Input.GetTouch(0);

            // ��ġ�� ���°� Began(��ġ�� ���۵� ����)�̰�, ��ġ�� �߻��� ��ġ���� ����ĳ��Ʈ�� �߻�
            if (touch.phase == TouchPhase.Began)
            {
                // ��ġ�� ������ �� �޽����� ����մϴ�.
                Debug.Log("Touch Detected at position: " + touch.position);

                // ���̸� ī�޶󿡼� ��ġ�� ��ġ�� �߻�
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // ����ĳ��Ʈ�� �浹�� ��ü�� �ִ��� Ȯ��
                if (Physics.Raycast(ray, out hit))
                {
                    // �浹�� ��ü�� ������ �������̸� �ش� ��ü�� ó��
                    GameObject touchedObject = hit.collider.gameObject;
                    if (touchedObject.CompareTag("Chito"))
                    {
                        // ������ �������� ��ġ�Ǿ����� �α׿� ���
                        Debug.Log("Spawned Prefab Touched: " + touchedObject.name);
                        if (clickSound != null)
                        {
                            audioSource.PlayOneShot(clickSound);
                            SceneManager.LoadScene("stage2");
                        }

                    }
                    if (touchedObject.CompareTag("Human"))
                    {
                        // ������ �������� ��ġ�Ǿ����� �α׿� ���
                        Debug.Log("Spawned Prefab Touched: " + touchedObject.name);
                        if (clickSound != null)
                        {
                            audioSource.PlayOneShot(clickSound);
                            SceneManager.LoadScene("stage1");
                        }

                    }
                    if (touchedObject.CompareTag("Ajou"))
                    {
                        // ������ �������� ��ġ�Ǿ����� �α׿� ���
                        Debug.Log("Spawned Prefab Touched: " + touchedObject.name);
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

    private void OnEnable()
    {
        imgManager.trackedImagesChanged += OnImageChanged;
    }

    // unsubscribing from events
    private void OnDisable()
    {
        imgManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {

        foreach (ARTrackedImage img in args.added)
        {
            UpdateSpawned(img);
        }

        foreach (ARTrackedImage img in args.updated)
        {
            UpdateSpawned(img);
        }

        foreach (ARTrackedImage img in args.removed)
        {
            // disable the prefab that has the same name than the image
            spawnedPrefabs[img.referenceImage.name].SetActive(false);
        }

    }


    private void UpdateSpawned(ARTrackedImage img)
    {
        string name = img.referenceImage.name;

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