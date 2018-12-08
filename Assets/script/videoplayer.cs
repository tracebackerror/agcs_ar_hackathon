using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Vuforia;

public class videoplayer : MonoBehaviour, ITrackableEventHandler  {
	public VideoClip videoClip;
        private TrackableBehaviour mTrackableBehaviour;
    void Start()
    {
        var videoPlayer = gameObject.AddComponent<VideoPlayer>();
        var audioSource = gameObject.AddComponent<AudioSource>();

        videoPlayer.playOnAwake = false;
        videoPlayer.clip = videoClip;
	videoPlayer.isLooping  = true;
        videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
        videoPlayer.targetMaterialRenderer = GetComponent<Renderer>();
        videoPlayer.targetMaterialProperty = "_MainTex";
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);

	mTrackableBehaviour = GetComponent<TrackableBehaviour>();
       if (mTrackableBehaviour) {
        mTrackableBehaviour.RegisterTrackableEventHandler(this);
       }	
    }

    void Update()
    {
	

    }

public void OnTrackableStateChanged(
    TrackableBehaviour.Status previousStatus,
    TrackableBehaviour.Status newStatus)
  { 
    if (newStatus == TrackableBehaviour.Status.DETECTED ||
        newStatus == TrackableBehaviour.Status.TRACKED ||
        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
    {
      OnTrackingFound();
    }
  } 
  private void OnTrackingFound()
  {
	VideoPlayer vp = GetComponent<VideoPlayer>();
	 vp.Play();
	if (!vp.isPlaying)
            {
                vp.Play();
            }

  }
}
