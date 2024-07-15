using TMPro;
using UnityEngine;

public class HealthPickupModule : MonoBehaviour, ICharacterModule
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
        // Логика для проверки возможности подбора аптечки
        if (Input.GetKeyDown(KeyCode.E) && _inArea) {
            Debug.Log("Health picked up"); // Логика для подбора аптечки
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