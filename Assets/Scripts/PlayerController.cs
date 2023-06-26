using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Health _enemyHealth;
    [SerializeField] private Animator _playerAnim;
    [SerializeField] private Animator _enemyAnim;
    [SerializeField] private GameManager gameManager;
    public Image blockButton;

    private bool _blockCooldown = false;
    private bool _canAttack;

    private float _attackCooldown;
    private float _startCooldown = 1;

    private void Start()
    {
        _attackCooldown = _startCooldown;
    }
    private void Update()
    {
        if(_attackCooldown <= 0)
        {
            _canAttack = true;
        }
        else
        {
            _canAttack = false;
            _attackCooldown -= Time.deltaTime;
        }


        if (_playerHealth._health <= 0)
        {
            gameManager.Lose();
            _playerHealth.SetHP();
            _enemyHealth.SetHP();
        }
        if (_enemyHealth._health <= 0)
        {
            gameManager.Win();
            _playerHealth.SetHP();
            _enemyHealth.SetHP();
        }
    }

    public void Block()
    {
        if(!_blockCooldown)
            StartCoroutine(BlockTimer());
    }
    public IEnumerator BlockTimer()
    {
        _canAttack = false;
        _blockCooldown = true;
        _playerHealth.isBlocking = true;
        _playerAnim.Play("GloveBlock");
        blockButton.color = Color.red;
        yield return new WaitForSeconds(1f);
        _canAttack = true;
        _playerHealth.isBlocking = false;
        yield return new WaitForSeconds(1f);
        blockButton.color = Color.white;
        _blockCooldown = false;
        yield return null;
    }

    public void Hit()
    {
        if (_canAttack && !_playerHealth.isBlocking)
        {
            _attackCooldown = _startCooldown;
            _playerAnim.Play("GloveHit");
            if (!_enemyHealth.isBlocking)
            {
                _enemyHealth.TakeDamage();
                SoundManager.instance.HitSound();
                _enemyAnim.Play("EnemyDamage");
            }
        }
    }
}
