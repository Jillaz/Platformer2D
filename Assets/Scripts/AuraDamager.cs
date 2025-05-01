using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraDamager : MonoBehaviour
{
    [SerializeField] private CharacterAttackPower _attackPower;
    [SerializeField] private Health _health;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _activeTime;
    [SerializeField] private float _cooldownTime;
    [SerializeField] private float _delay = 0.1f;
    private bool _isReady = true;
    private HashSet<Health> _enemies = new HashSet<Health>();

    public event Action<float> AuraActive;
    public event Action<float> AuraCooldown;
    public event Action AuraIsReady;

    private void OnEnable()
    {
        _playerInput.AuraActivated += ActivateAura;
    }

    private void OnDisable()
    {
        _playerInput.AuraActivated -= ActivateAura;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health enemy))
        {
            _enemies.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health enemy))
        {
            _enemies.Remove(enemy);
        }
    }

    private IEnumerator Active(float time)
    {
        _isReady = false;
        var delay = new WaitForSeconds(_delay);

        while (time > 0)
        {
            time -= _delay;
            DrainHealth();
            AuraActive?.Invoke(time);

            yield return delay;
        }

        StartCoroutine(Cooldown(_cooldownTime));
    }

    private IEnumerator Cooldown(float time)
    {
        var delay = new WaitForSeconds(_delay);

        while (time > 0)
        {
            time -= _delay;
            AuraCooldown?.Invoke(time);

            yield return delay;
        }

        _isReady = true;
        AuraIsReady?.Invoke();
    }
    private void ActivateAura()
    {
        if (_isReady)
        {
            StartCoroutine(Active(_activeTime));
        }
    }

    private void DrainHealth()
    {
        if (_enemies.Count == 0)
        {
            return;
        }

        foreach (Health enemy in _enemies)
        {
            float damage = _attackPower.AttackPower / (_activeTime / _delay);
            enemy.TakeDamage(damage);
            _health.Healing(damage);
        }
    }
}
