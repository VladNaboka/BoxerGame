using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Health _enemyHealth;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private Animator _enemyAnim;
    [SerializeField] private Animator _uiAnim;
    [SerializeField] private float _startActionTime;
    private float _actionTimer;

    private int _prevNum;

    private void Awake()
    {
        _actionTimer = _startActionTime;
    }
    private void Update()
    {
        if(_actionTimer <= 0)
        {
            ChooseAction();
        }
        else
        {
            _actionTimer -= Time.deltaTime;
        }
    }
    private void Attack()
    {
        _enemyAnim.Play("EnemyHit");
        if (!_playerHealth.isBlocking)
        {
            _uiAnim.Play("GetHit");
            _playerHealth.TakeDamage();
        }
        _actionTimer = _startActionTime;
    }
    private IEnumerator Blocking()
    {
        _enemyHealth.isBlocking = true;
        _enemyAnim.Play("EnemyBlock");
        yield return new WaitForSeconds(2);
        _enemyHealth.isBlocking = false;
        _actionTimer = _startActionTime;
        yield return null;
    }
    private void Idle()
    {
        _actionTimer = _startActionTime;
    }
    private void ChooseAction()
    {
        int randomNum = Random.Range(0, 3);
        while (randomNum == _prevNum)
        {
            randomNum = Random.Range(0, 3);
        }
        _prevNum = randomNum;
        switch (randomNum)
        {
            case 0:
                StartCoroutine(Blocking());
                break;
            case 1:
                Idle();
                break;
            case 2:
                Attack();
                break;
        }
    }
}
