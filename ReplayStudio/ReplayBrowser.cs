namespace ReplayStudio;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;
using ReplayMod;
using ReplayMod.Replay.Files;
using ReplayMod.Replay;
using Il2CppSystem.Runtime.Remoting.Messaging;

internal static class ReplayBrowser
{
	internal static ReplayExplorer explorer;
	internal static void ListReplays()
	{
		List<ReplayExplorer.Entry> entries = (List<ReplayExplorer.Entry>)ReplayAPI.Entries;
		
		foreach (ReplayExplorer.Entry entry in entries)
		{
			if (entry.IsFolder)
			{
				Debug.Log("Entry is folder");
				continue;
			}
			string lineToPrint = "";
			try
			{
				lineToPrint = $"{entry.Name}, {entry.header.Players[0].Name} vs {entry.header.Players[1].Name}, {entry.header.Players[0].WasHost}, {entry.header.Scene}, {entry.header.Date}";
			}
			catch (Exception ex) { Debug.Log($"{ex}"); }
			Debug.Log(lineToPrint);
		}

		Debug.Log(explorer.currentlySelectedEntry.Name);
	}
}

internal class Session
{
	internal string Opponent;
	internal List<ReplayExplorer.Entry> Entries;
	internal int MarkerCount;
	internal DateTime Date;
		
}
