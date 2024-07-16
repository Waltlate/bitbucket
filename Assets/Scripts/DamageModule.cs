using TMPro;
using UnityEngine;

public class DamageModule : MonoBehaviour, ICharacterModule
{
    private Character _character;
    [SerializeField] private GameObject _hotKeyText;
    [SerializeField] private TextMeshProUGUI _messageText;
    private readonly string _messageInteract = "Character took damage";
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
            _messageText.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            _messageText.text = _messageInteract;
            Debug.Log(_messageInteract); // Логика для получения урона
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