using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PoolElement {
	public GameObject gameObject;
	public IPoolable entity;

	public PoolElement(GameObject go, IPoolable entity) {
		this.gameObject = go;
		this.entity = entity;
	}
}

public class Pool : MonoBehaviour
{
	private List<PoolElement> elements = new List<PoolElement>();
	private static GameObject goSample;

	public static Pool Create(GameObject sample) {
		goSample = sample;
		GameObject go = new GameObject(goSample.name + " pool");
		return go.AddComponent<Pool>();
	}

	private void OnDestroy() {
		elements = null;
		goSample = null;
		Destroy(gameObject);
	}

	public PoolElement GetElement() {
		foreach (PoolElement elem in elements) {
			if (!elem.gameObject.activeSelf) {
				return elem;
			}
		}
		PoolElement element = CreateElement();
		return element;
	}

	private PoolElement CreateElement() {
		GameObject go = Instantiate(goSample, gameObject.transform);
		go.SetActive(false);
		IPoolable entity = go.GetComponent<IPoolable>();
		PoolElement element = new PoolElement(go, entity);
		elements.Add(element);
		return element;
	}

	public void ReturnObject(GameObject obj) {
		obj.SetActive(false);
	}
}
