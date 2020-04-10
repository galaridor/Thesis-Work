using UnityEngine;

public class ResetBombPosition : MonoBehaviour
{
    public GameObject bomb;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            bomb.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}