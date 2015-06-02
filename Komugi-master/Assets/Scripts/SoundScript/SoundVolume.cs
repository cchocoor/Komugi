using UnityEngine;
using System.Collections;

// 音量クラス
public class SoundVolume
{
 public float BGM = 1.0f;
 public float Voice = 1.0f;
 public float SE = 1.0f;
 public bool Mute = false;
  
 public void Init(){
  BGM = 1.0f;
  Voice = 1.0f;
  SE = 1.0f;
  Mute = false;
 }
}