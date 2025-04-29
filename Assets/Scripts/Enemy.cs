using System;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Character
{
    public bool _isPlayerInView = false;
    public NavMeshAgent _agent;
    private State _currentState;
    
    [Header("Shooting")]
    public GameObject projectilePrefab;
    public Transform firePoint;

    [Obsolete]
    public void AttackPlayer()
    {
    if (projectilePrefab == null || firePoint == null) return;

        // ยิงกระสุนไปยังตำแหน่งของผู้เล่น
        Vector3 direction = (PlayerController.Instance.transform.position - firePoint.position).normalized;

        GameObject bullet = GameObject.Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = direction * 10f;// ความเร็วกระสุน

        Debug.Log("AttackPlayer called"); // ตรวจสอบว่าเข้าฟังก์ชันไหม
    }
    
    private void Awake()
    {
    _agent = GetComponent<NavMeshAgent>();
    _currentState = new Idle(this, _agent);

    }

    private void FixedUpdate()
    {
        _currentState = _currentState.Process();
    }
}
