using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Test helper: press Space to drop a Knight at the blue spawn point.
/// The spawned Knight pathfinds to the enemy (red) king tower.
/// Uses the new Input System so it works regardless of Active Input Handling.
/// </summary>
public class UnitSpawner : MonoBehaviour
{
    public GameObject knightPrefab;
    public Transform blueSpawn;
    public Transform enemyKingTower;

    void Update()
    {
        var kb = Keyboard.current;
        if (kb != null && kb.spaceKey.wasPressedThisFrame)
            SpawnKnight();
    }

    void SpawnKnight()
    {
        if (knightPrefab == null || blueSpawn == null) return;
        var go = Instantiate(knightPrefab, blueSpawn.position, Quaternion.identity);
        var kc = go.GetComponent<KnightController>();
        if (kc != null) kc.SetTarget(enemyKingTower);
    }
}
