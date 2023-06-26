using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [NonSerialized] public int _health;
    [NonSerialized] public bool isBlocking;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _damage;
    [SerializeField] private Slider slider;


    private void Start()
    {
        SliderMaxHealth();
        SetHP();
    }
    public void TakeDamage()
    {
        if (!isBlocking)
        {
            _health -= _damage;
            slider.value = _health;
            SoundManager.instance.HurtSound();
        }
    }
    public void SetHP()
    {
        _health = _maxHealth;
        slider.value = _health;
    }
    public void SliderMaxHealth()
    {
        slider.maxValue = _maxHealth;
    }
}
