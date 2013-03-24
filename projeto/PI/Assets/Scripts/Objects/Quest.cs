using UnityEngine;
using System.Collections;

public class Quest {
	
	private string questName;
	private string description;
	private QuestTimer timer;
	
	public string Name { get; set; }
	public string Description { get; set; }
	public QuestTimer Timer { get; set; }
	
	public Quest(string name, string description){
		this.Name = name;
		this.Description = description;
	}
	
	public Quest(string name, string description, int seconds){
		this.Name = name;
		this.Description = description;
		this.Timer = new QuestTimer(seconds);
	}
}
