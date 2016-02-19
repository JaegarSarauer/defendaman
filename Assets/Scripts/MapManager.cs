using UnityEngine;
using System.Collections;
using SimpleJSON;

public class MapManager : MonoBehaviour {
	/* A set of constant map update event types. */
	enum EventType {
		CREATE_MAP =        0,
		RESOUCE_TAKEN =     1,
		RESOURCE_DEPLETED = 2,
		ITEM_DROPPED =      3,
		ITEM_PICKEDUP =     4,
		BUILDING_HIT =      5,
		BUILDING_DSTR =     6
	};
	/* ID of map update event, i.e. its event type. */
	EventType _id;
	/* 2D int array containing map values. */
	string _string_map;
	/* 2D int array containing map values. */
	private int[][] _map;
	/* Ancillary data about the map update event. */
	private string _data;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// message = Carson's send call from Networking Manager
		string message = "dummy string";
		receive_message(message);
	}

	/**
	 * Decode the received message and handle its event.
	 * A message's "data" component can be broken down into its event type, 
	 * the terrain/building type, and the terrain/building property values.
	 * @param message 	received JSON message from NetworkingManager
	 */ 
	private void receive_message(string message) {
		decode_message (message);
		handle_event(_map, _id, _data);
	}

	/**
	 * Set the MapManager's private variables based on the parsed JSON string.
	 * A message's "data" component can be broken down into its event type, 
	 * the terrain/building type, and the terrain/building property values.
	 * @param message 	received JSON message from NetworkingManager
	 */
	private void decode_message(string message) {
		var msgObjects = JSON.Parse (message).AsArray;

		foreach (var node in msgObjects.Children) {
			var obj = node.AsObject;
			_string_map = obj ["map"];
			_id = (EventType) (obj ["ID"].AsInt);
			_data = obj ["data"];
		}
	}

	/**
	 * Deserialize JSON string into 2d int array.
	 */
	private int[][] parse_string_map(string map) {
		// _map = json.deserialization<int>(map)
		return _map;
	}

	/**
	 * Execute the appropriate action given a received event.
	 * @param map 	2d int array of map values
	 * @param id 	id of received event, i.e. its event type 
	 * @param data 	ancillary data of map event
	 */
	private void handle_event(int[][] map, EventType id, string data) {
		// Enums are not ints in C# :(
		switch (id) {
			case EventType.CREATE_MAP:
				create_map (map);
				break;
			case EventType.RESOUCE_TAKEN:
				break;
			case EventType.RESOURCE_DEPLETED:
				break;
			case EventType.ITEM_DROPPED:
				break;
			case EventType.ITEM_PICKEDUP:
				break;
		}
	}

	/**
	 * Render map sprites to scene given a 2d map array. 
	 * @param map 	2d int array of map values
	 */
	private void create_map(int[][] map) {
		// Thomas/Jaegar's map generation function goes here
		// draw(map);
	}
}
