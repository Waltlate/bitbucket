using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _speed; //number of steps per unitblock
    private readonly float _sizeField = 20;
    private List<ICharacterModule> _modules = new();
    private bool _inArea;

    void Start()
    {
        StartCoroutine(CheckForInteraction());
    }

    IEnumerator CheckForInteraction()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.W)) Move(Vector3.forward);
            if (Input.GetKey(KeyCode.S)) Move(Vector3.back);
            if (Input.GetKey(KeyCode.A)) Move(Vector3.left);
            if (Input.GetKey(KeyCode.D)) Move(Vector3.right);
            if (Input.GetKeyDown(KeyCode.E) && _inArea) Interact();
            yield return new WaitForSeconds(0.001f);
        }
    }

    public void Move(Vector3 direction)
    {
        direction *= _speed * Time.deltaTime; 
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + direction.x, -(_sizeField / 2 - 0.5f), _sizeField / 2 - 0.5f),
                                         transform.position.y,
                                         Mathf.Clamp(transform.position.z + direction.z, -(_sizeField / 2 - 0.5f), _sizeField / 2 - 0.5f));
    }

    public void AddModule(ICharacterModule module)
    {
        _modules.Add(module);
    }

    public void UpdateModules()
    {
        foreach (var module in _modules)
        {
            module.UpdateModule();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interact"))
        {
            _inArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interact"))
        {
            _inArea = false;
        }
    }

    public void Interact()
    {
        Debug.Log("Character interacts");
        UpdateModules();
    }
}
