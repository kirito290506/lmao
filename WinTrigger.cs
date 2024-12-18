using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemSwitchScene : MonoBehaviour
{
    public Vector3 spinRotationSpeed = new Vector3(0, 180, 0); // Tốc độ xoay
    public string sceneToLoad = "Win";

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng chạm vào là Player
        if (other.CompareTag("Player"))
        {
            // Chuyển sang màn chơi khác
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        // Kiểm tra nếu tên scene hợp lệ
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Scene name is empty! Please assign a scene name.");
        }
    }
    private void Update()
    {
        // Xoay đối tượng pickup
        transform.eulerAngles += spinRotationSpeed * Time.deltaTime;
    }
}
