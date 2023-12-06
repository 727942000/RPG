using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{

    //�����
    private Transform m_Transform;
    //��������
    private Transform player_Transform;

    private Vector3 offset;

    void Start()
    {
        m_Transform = gameObject.GetComponent<Transform>();
        player_Transform = GameObject.Find("Player").GetComponent<Transform>();
        //offset�������������������ǵ����λ��
        offset = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        //ֱ�Ӹı��������λ�ã����ַ�ʽ�Ƚ���Ӳ������ʹ����һ�ֲ�ֵ�ķ�ʽ��
        //m_Transform.position = player_Transform.position + offset;

        //��ֵ�ķ�ʽ����������ĸ���
        m_Transform.position = Vector3.Lerp(m_Transform.position, player_Transform.position + offset, Time.deltaTime * 2);
    }

}

