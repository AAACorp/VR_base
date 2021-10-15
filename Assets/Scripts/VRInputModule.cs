using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;

public class VRInputModule : BaseInputModule
{
    // Start is called before the first frame update
    public Camera _camera;
    public SteamVR_Input_Sources TargetSource;
    public SteamVR_Action_Boolean ClickAction;
    public GameObject CurrentObject = null;
    private PointerEventData _data = null;
    protected override void Awake()
    {
        base.Awake();

        _data = new PointerEventData(eventSystem);
    }
    public override void Process()
    {
        _data.Reset();
        _data.position = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2);


        eventSystem.RaycastAll(_data, m_RaycastResultCache);
        _data.pointerCurrentRaycast = FindFirstRaycast(m_RaycastResultCache);
        CurrentObject = _data.pointerCurrentRaycast.gameObject;

        m_RaycastResultCache.Clear();

        HandlePointerExitAndEnter(_data, CurrentObject);

        if (ClickAction.GetStateDown(TargetSource))
        {
            ProcessPress(_data);
        }
        if (ClickAction.GetStateUp(TargetSource))
        {
            ProcessRelease(_data);
        }



    }
    public PointerEventData GetData()
    {
        return _data;
    }
    private void ProcessPress(PointerEventData data)
    {
        _data.pointerCurrentRaycast = _data.pointerCurrentRaycast;
        GameObject newPointerPress = ExecuteEvents.ExecuteHierarchy(CurrentObject, _data, ExecuteEvents.pointerDownHandler);
        if (newPointerPress == null)
        {
            newPointerPress = ExecuteEvents.GetEventHandler<IPointerClickHandler>(CurrentObject);
        }

        data.pressPosition = data.position;
        data.pointerPress = newPointerPress;
        data.rawPointerPress = CurrentObject;

    }
    private void ProcessRelease(PointerEventData data)
    {
        ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerUpHandler);

        GameObject pointerUpHandler = ExecuteEvents.GetEventHandler<IPointerClickHandler>(CurrentObject);

        if (data.pointerPress == pointerUpHandler)
        {
            ExecuteEvents.Execute(data.pointerPress, data, ExecuteEvents.pointerClickHandler);
        }

        eventSystem.SetSelectedGameObject(null);

        data.pressPosition = Vector2.zero;
        data.pointerPress = null;
        data.rawPointerPress = null;
    }

}
