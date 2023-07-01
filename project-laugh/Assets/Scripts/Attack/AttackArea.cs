using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 10;

    private void OnTriggerEnter2D(Collider2D collider) {
        collider.gameObject.SetActive(false);
    }
}
