using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace _GAME_.Scripts.Character
{
	public class BladonEditorPanel : OdinEditorWindow
	{
		public static List<string> Logs = new List<string>();
		
		public static void AddLog(string log)
		{
			foreach (var logger in Logs)
			{
				if (string.Equals(log, logger, StringComparison.InvariantCultureIgnoreCase))
				{
					return;
				}
			}
			Logs.Add(log);
		}
		
		[MenuItem("Bladon/Editor Panel")]
		private static void OpenWindow()
		{
			GetWindow<BladonEditorPanel>().Show();
		}

		[Button]
		public void Clear()
		{
			Logs.Clear();
		}
		
		protected override void OnGUI()
		{
			foreach (var log in Logs)
			{
				GUILayout.Label(log);
			}
		}
		

	}
}