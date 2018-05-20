using System;
using System.Collections;
using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.Events;

public class VRIneractiveItemEvent : MonoBehaviour
{
    public UnityEvent OnOver;
	public UnityEvent OnLeave;
	public float timeOverToActivate = 1f;
	public UnityEvent OnTimedOver;

    [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.

    private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.

    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        //m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        //m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
    }


    private void HandleOver()
    {
        // When the user looks at the rendering of the scene, show the radial.
		SelectionRadial.instance.Show(timeOverToActivate);

		OnOver.Invoke ();

		gazeTime = 0f;

        m_GazeOver = true;
    }


    private void HandleOut()
    {
        // When the user looks away from the rendering of the scene, hide the radial.
		SelectionRadial.instance.Hide();

		OnLeave.Invoke ();

        m_GazeOver = false;
    }

    float gazeTime = 0f;

	private void Update()
	{
        if(m_GazeOver) {
			if(gazeTime < timeOverToActivate) {
                gazeTime += Time.unscaledDeltaTime;
				if(gazeTime >= timeOverToActivate) {
					OnTimedOver.Invoke ();
                }
            }
        }
	}


	//private void HandleSelectionComplete()
    //{
    //    // If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
    //    if (m_GazeOver)
    //        StartCoroutine(ActivateButton());
    //}
}