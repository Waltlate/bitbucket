using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float _speed; //number of steps per unitblock
    private float _sizeField = 20;
    private List<ICharacterModule> _modules = new List<ICharacterModule>();

    public void Move(Vector3 direction)
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + direction.x, -(_sizeField / 2 - 0.5f), _sizeField / 2 - 0.5f),
                                         transform.position.y,
                                         Mathf.Clamp(transform.position.z + direction.z, -(_sizeField / 2 - 1), _sizeField / 2 - 1));
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

    public void Interact()
    {
        Debug.Log("Character interacts");
        UpdateModules();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) Move(Vector3.forward / _speed);
        if (Input.GetKey(KeyCode.S)) Move(Vector3.back / _speed);
        if (Input.GetKey(KeyCode.A)) Move(Vector3.left / _speed);
        if (Input.GetKey(KeyCode.D)) Move(Vector3.right / _speed);
        if (Input.GetKeyDown(KeyCode.E)) Interact();
    }
}
