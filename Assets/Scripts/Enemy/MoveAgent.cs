﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 내비게이션 기능을 사용하기 위해 추가해야 하는 네임스페이스
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    // 순찰 지점들을 저장하기 위한 List 타입 변수
    public List<Transform> wayPoints;
    // 다음 순찰 지점의 배열의 Index
    public int nextIdx;

    // NavMeshAgent 컴포넌트를 저장할 변수
    private NavMeshAgent agent;

    private void Start()
    {
        // NavMeshAgent 컴포넌트를 추출한 후 변수에 저장
        agent = GetComponent<NavMeshAgent>();
        // 목적지에 가까워질수록 속도를 줄이는 옵션을 비활성화
        agent.autoBraking = false;

        // 하이러키 뷰의 WayPointGroup 게임오브젝트를 추출
        var group = GameObject.Find("Waypoint");
        if (group != null)
        {
            // Waypoint 하위에 있는 모든 Transform 컴포넌트를 추출한 후
            // List 타입의 wayPoints 배열에 추가
            group.GetComponentsInChildren<Transform>(wayPoints);
            // 배열의 첫 번째 항목 삭제
            wayPoints.RemoveAt(0);
        }

        MoveWayPoint();
    }

    // 다음 목적지까지 이동 명령을 내리는 함수
    void MoveWayPoint()
    {
        // 최단거리 경로 계산이 끝나지 않았으면 다음을 수행하지 않음
        if (agent.isPathStale) return;

        // 다음 목적지를 wayPoints 배열에서 추출한 위치로 다음 목적지를 지정
        agent.destination = wayPoints[nextIdx].position;
        // 내비게이션 기능을 활성화해서 이동을 시작함
        agent.isStopped = false;
    }

    private void Update()
    {
        // NavMeshAgent가 이동하고 있고 목적지에 도착했는지 여부를 계산
        if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f && agent.remainingDistance <= 0.5f)
        {
            // 다음 목적지의 배열 첨자를 계산
            nextIdx = ++nextIdx % wayPoints.Count;
            // 다음 목적지로 이동 명령을 수행
            MoveWayPoint();
        }

    }
}
