using UnityEngine;

public class LevelExitTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Shark>())
        {
            _winScreen.SetActive(true);
        }
    }
}
