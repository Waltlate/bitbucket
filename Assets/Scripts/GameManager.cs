using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Character character;
    public HealthPickupModule healthPickupModule;
    public DamageModule damageModule;

    void Start()
    {
        healthPickupModule.Initialize(character);
        damageModule.Initialize(character);

        character.AddModule(healthPickupModule);
        character.AddModule(damageModule);
    }
}