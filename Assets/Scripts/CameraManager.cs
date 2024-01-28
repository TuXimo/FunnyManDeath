using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCameraxCamera;
    [SerializeField]  Transform followGameObject;

    [SerializeField] private float smoothMouse;
    [SerializeField] private float mouseSpeed = 0.5f;

    public bool isReadingAText;

    public void SetIsReading(bool isReading)
    {
        isReadingAText = isReading;
    }

    private void Update()
    {
        if (Input.mousePosition.x > 800 && Input.mousePosition.x < 1120 || isReadingAText) return;
        
        float mouseInput = Mathf.InverseLerp(0, 1920, Input.mousePosition.x);
        smoothMouse = Mathf.Lerp(smoothMouse, mouseInput, mouseSpeed * Time.deltaTime);
        
        var position = followGameObject.position;
        position = new Vector3(Mathf.Lerp(15,225,smoothMouse), position.y, position.z);
        followGameObject.position = position;
    }
}
