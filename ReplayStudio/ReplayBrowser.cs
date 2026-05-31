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
				lineToPrint += entry.IsFolder + ", ";
				lineToPrint += entry.Name + ", ";
				lineToPrint += entry.header.Title + ", ";
				lineToPrint += entry.header.Players[0].Name + ", ";
			}
			catch (Exception ex) { }
			Debug.Log(lineToPrint);
		}

		Debug.Log(explorer.currentlySelectedEntry.Name);
	}
}
