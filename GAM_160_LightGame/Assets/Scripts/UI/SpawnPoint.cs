using UnityEngine;
using System.Collections;

public enum Icon { Player, Enemy }

public class SpawnPoint : MonoBehaviour {

    public Icon icon = Icon.Player;

    void OnDrawGizmos()
    {
        switch (icon)
        {
            case Icon.Player:
                Gizmos.DrawIcon(transform.position, "Player_Spawn_Icon.png", true);
                break;
            case Icon.Enemy:
                Gizmos.DrawIcon(transform.position, "Enemy_Spawn_Icon.png", true);
                break;
        }
    }
}
