using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth;
    private int _currentHealth;
    public Transform healthbar;
    void Start()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        healthbar.localScale = new Vector3((float)_currentHealth / maxHealth, 1, 1);
    }
}
