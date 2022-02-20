﻿#if UNITY_EDITOR

using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

namespace AC
{
	
	public abstract class SoundtrackStorageWindow : EditorWindow
	{

		protected Vector2 scrollPos;
		protected bool showOptions = true;
		protected bool showTracks = true;


		protected static void Init <T> (string title) where T : SoundtrackStorageWindow
		{
			T window = (T) GetWindow (typeof (T));
			window.position = new Rect (300, 200, 350, 440);
			window.titleContent.text = title;
			window.minSize = new Vector2 (300, 260);
		}


		protected virtual List<MusicStorage> Storages
		{
			get
			{
				return null;
			}
			set
			{}
		}


		protected virtual string APIPrefix
		{
			get
			{
				return string.Empty;
			}
		}


		protected void SharedGUI (string headerLabel)
		{
			SettingsManager settingsManager = AdvGame.GetReferences ().settingsManager;

			EditorGUILayout.BeginVertical (CustomStyles.thinBox);
			showTracks = CustomGUILayout.ToggleHeader (showTracks, headerLabel);
			if (showTracks)
			{
				List<MusicStorage> storages = Storages;

				bool showMixerOptions = settingsManager.volumeControl == VolumeControl.AudioMixerGroups;
				scrollPos = EditorGUILayout.BeginScrollView (scrollPos);

				for (int i=0; i<storages.Count; i++)
				{
					CustomGUILayout.BeginVertical ();

					EditorGUILayout.BeginHorizontal ();
					EditorGUILayout.LabelField (storages[i].ID.ToString () + ":", EditorStyles.boldLabel);
					if (GUILayout.Button ("-", GUILayout.MaxWidth (20f)))
					{
						Undo.RecordObject (settingsManager, "Delete entry");
						storages.RemoveAt (i);
						i=0;
						return;
					}
					EditorGUILayout.EndHorizontal ();

					storages[i].ShowGUI (APIPrefix + "[" + i + "]", showMixerOptions);

					CustomGUILayout.EndVertical ();
				}

				EditorGUILayout.EndScrollView ();

				if (GUILayout.Button ("Add new clip"))
				{
					Undo.RecordObject (settingsManager, "Delete music entry");
					storages.Add (new MusicStorage (GetIDArray (storages.ToArray ())));
				}

				Storages = storages;
			}
			CustomGUILayout.EndVertical ();

			if (GUI.changed)
			{
				EditorUtility.SetDirty (settingsManager);
			}
		}


		protected int[] GetIDArray (MusicStorage[] musicStorages)
		{
			List<int> idArray = new List<int>();
			foreach (MusicStorage musicStorage in musicStorages)
			{
				idArray.Add (musicStorage.ID);
			}
			idArray.Sort ();
			return idArray.ToArray ();
		}

	}
	
}

#endif