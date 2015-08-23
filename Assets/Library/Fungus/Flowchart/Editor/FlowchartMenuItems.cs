﻿using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;

namespace Fungus
{

	public class FlowchartMenuItems
	{
		[MenuItem("Tools/Fungus/Create/Flowchart", false, 0)]
		static void CreateFlowchart()
		{
			GameObject go = SpawnPrefab("Flowchart");
			go.transform.position = Vector3.zero;
		}

		public static GameObject SpawnPrefab(string prefabName)
		{
			GameObject prefab = Resources.Load<GameObject>(prefabName);
			if (prefab == null)
			{
				return null;
			}

			GameObject go = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
			PrefabUtility.DisconnectPrefabInstance(go);

			SceneView view = SceneView.currentDrawingSceneView;
			if (view != null)
			{
				Camera sceneCam = view.camera;
				Vector3 pos = sceneCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10f));
				pos.z = 0f;
				go.transform.position = pos;
			}

			Selection.activeGameObject = go;
			
			Undo.RegisterCreatedObjectUndo(go, "Create Object");

			return go;
		}
	}

}