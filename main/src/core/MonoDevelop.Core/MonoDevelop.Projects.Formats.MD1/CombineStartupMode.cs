// CombineStartupMode.cs
//
// Author:
//   Lluis Sanchez Gual <lluis@novell.com>
//
// Copyright (c) 2008 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//

using System;
using System.Collections.Generic;
using MonoDevelop.Projects;
using MonoDevelop.Core.Serialization;

namespace MonoDevelop.Projects.Formats.MD1
{
	class CombineStartupMode
	{
		[ItemProperty ("startupentry")]
		public string StartEntryName;
		
		[ItemProperty ("single")]
		public bool SingleStartup = true;
		
		[ExpandedCollection]
		[ItemProperty ("Execute", ValueType=typeof(CombineStartupEntry))]
		public List<CombineStartupEntry> Entries = new List<CombineStartupEntry> ();
		
		public void AddEntry (string name)
		{
			CombineStartupEntry e = new CombineStartupEntry ();
			e.Entry = name;
			e.Type = "None";
			Entries.Add (e);
		}
		
		public CombineStartupEntry FindEntry (string name)
		{
			foreach (CombineStartupEntry cse in Entries)
				if (cse.Entry == name)
					return cse;
			return null;
		}
		
		public void MakeExecutable (string name)
		{
			FindEntry (name).Type = "Execute";
		}
	}
	
	class CombineStartupEntry
	{
		[ItemProperty ("type")]
		public string Type;
		
		[ItemProperty ("entry")]
		public string Entry;
	}
}
