using UnityEngine;

public class DamageModule : MonoBehaviour, ICharacterModule
{
    [SerializeField] private GameObject _hotKeyText;
    private Character _character;
    private bool _inArea;

    public void Initialize(Character character)
    {
        _character = character;
    }

    public void UpdateModule()
    {
        // Логика для проверки возможности получения урона
        if (Input.GetKeyDown(KeyCode.E) && _inArea)
        {
            Debug.Log("Character took damage"); // Логика для получения урона
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("enter");
            _hotKeyText.SetActive(true);
            _inArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("exit");
            _hotKeyText.SetActive(false);
            _inArea = false;
        }
    }
}