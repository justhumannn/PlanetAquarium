using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 30f;   // 이동 속도
    public float scrollSpeed = 5000f; // 줌 속도
    public float minY = 5f; // 최대 줌인
    public float maxY = 50f; // 최대 줌아웃

    void Update()
    {
        // 1. WASD 이동
        float x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; // A, D 키
        float z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;   // W, S 키

        // 현재 위치 가져오기
        Vector3 pos = transform.position;

        // 월드 좌표 기준으로 이동 (카메라가 회전해 있어도 땅과 수평하게 움직임)
        pos.x += x;
        pos.z += z;

        // 2. 마우스 휠로 줌 (Y축 이동)
        float scroll = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;
        pos.y -= scroll;
        pos.y = Mathf.Clamp(pos.y, minY, maxY); // 너무 가까워지거나 멀어지지 않게 제한

        // 위치 적용
        transform.position = pos;
    }
}