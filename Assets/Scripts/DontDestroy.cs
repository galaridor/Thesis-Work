using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static GameObject _gamemanagerInstance;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }
}