﻿using System;
//using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Utilities
{
	public class Util
	{
		public static void SetDefaultLocalTransform(GameObject obj)
		{
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localRotation = Quaternion.identity;
			obj.transform.localScale = Vector3.one;
		}

		public static GameObject FindChildObject(GameObject go, string nodeName)
		{
			Transform[] ts = go.GetComponentsInChildren<Transform>();
			foreach (Transform transform in ts)
			{
				if (transform.gameObject.name == nodeName)
				{
					return transform.gameObject;
				}
			}
			return null;
		}
	}
}
