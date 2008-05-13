//
// EnumerableRowCollection_1.cs
//
// Author:
//   Atsushi Enomoto  <atsushi@ximian.com>
//
// Copyright (C) 2008 Novell, Inc. http://www.novell.com
//

//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections;
using System.Collections.Generic;

namespace System.Data
{
	public class EnumerableRowCollection<TRow> : EnumerableRowCollection, IEnumerable<TRow>
	{
		IEnumerable<TRow> source;

		internal EnumerableRowCollection (DataTable source)
			: this (new DataRowGenericCollection (source))
		{
		}

		internal EnumerableRowCollection (IEnumerable<TRow> source)
		{
			this.source = source;
		}

		public IEnumerator<TRow> GetEnumerator ()
		{
			foreach (TRow row in source)
				yield return row;
		}

		IEnumerator IEnumerable.GetEnumerator ()
		{
			return GetEnumerator ();
		}

		class DataRowGenericCollection : IEnumerable<TRow>
		{
			DataTable source;

			public DataRowGenericCollection (DataTable source)
			{
				this.source = source;
			}

			public IEnumerator<TRow> GetEnumerator ()
			{
				foreach (TRow row in source.Rows)
					yield return row;
			}

			IEnumerator IEnumerable.GetEnumerator ()
			{
				return GetEnumerator ();
			}
		}
	}
}
