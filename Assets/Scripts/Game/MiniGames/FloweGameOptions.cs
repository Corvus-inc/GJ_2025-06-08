using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloweGameOptions : MonoBehaviour
{
    [Header("Water Animation")]
    [SerializeField] private float waterMinY = -750f; // ����������� ������� ����
    [SerializeField] private float waterMaxY = -150f;  // ������������ ������� ����
    [SerializeField] private float waterHorizontalRange = 50f; // �������� ��������������� ��������
    [SerializeField] private float waterHorizontalSpeed = 2f; // �������� ��������������� ��������
    [Header("Game Settings")]
    public float indicatorSpeed = 100f;
    public float trackHeight = 300f; // ������ ���� ��� ����
    public float zoneHeight = 75f;
    public int maxAttempts = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
