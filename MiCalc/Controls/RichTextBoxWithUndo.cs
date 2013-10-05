using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MiCalc.Controls
{
	public partial class RichTextBoxWithUndo : RichTextBox
	{
		private const int _defaultMaxUndoHistory = 500;
		private int _maxUndoHistory;

		private bool _isUndoRedoMode = false;

		/// <summary>
		/// Text changing history.
		/// </summary>
		private List<UndoItem> _history = new List<UndoItem>();

		/// <summary>
		/// Position in history to the current text state.
		/// (0) and (-1) means that no undo is possible.
		/// (history.Count-1) means no redo is possible.
		/// </summary>
		private int _historyPosition = -1;

		private class UndoItem
		{
			public UndoItem(string text, int selectionStart, int selectionLength)
			{
				Text = text;
				SelectionStart = selectionStart;
				SelectionLength = selectionLength;
			}

			public string Text;
			public int SelectionStart;
			public int SelectionLength;
		}


		public RichTextBoxWithUndo() : this(_defaultMaxUndoHistory)
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="maxUndoHistory">Zero or above.</param>
		public RichTextBoxWithUndo(int maxUndoHistory)
		{
			InitializeComponent();

			InitUndoRedo(maxUndoHistory);
		}

		private void InitUndoRedo(int maxUndoHistory)
		{
			_maxUndoHistory = maxUndoHistory >= 0 ? maxUndoHistory : _defaultMaxUndoHistory;
			if (_maxUndoHistory > 0)
			{
				_history.Add(new UndoItem(Text, SelectionStart, SelectionLength));
				_historyPosition = _history.Count - 1;
			}
			TextChanged += RichTextBoxWithUndo_TextChanged;
		}

		private void RichTextBoxWithUndo_TextChanged(object sender, EventArgs e)
		{
			if (_maxUndoHistory > 0 && !_isUndoRedoMode)
			{
				if (_history.Count == 0 || _historyPosition == _history.Count - 1)
				{
					// _historyPosition points to the end of _history

					if (_history.Count >= _maxUndoHistory)
					{
						_history.RemoveAt(0);
					}
				}
				else
				{
					// _historyPosition points NOT to the end of _history

					_history.RemoveRange(_historyPosition + 1, _history.Count - 1 - _historyPosition);
				}

				_history.Add(new UndoItem(Text, SelectionStart, SelectionLength));
				_historyPosition = _history.Count - 1;
			}
		}

		private void MakeUndo()
		{
			try
			{
				_isUndoRedoMode = true;

				// undo
				if (_historyPosition > 0)
				{
					Text = _history[_historyPosition - 1].Text;
					SelectionStart = _history[_historyPosition - 1].SelectionStart;
					SelectionLength = _history[_historyPosition - 1].SelectionLength;

					// move position
					--_historyPosition;
				}
			}
			finally
			{
				_isUndoRedoMode = false;
			}
		}

		private void MakeRedo()
		{
			if (_maxUndoHistory == 0)
			{
				return;
			}

			try
			{
				_isUndoRedoMode = true;

				// redo
				if (_historyPosition < _history.Count - 1)
				{
					Text = _history[_historyPosition + 1].Text;
					SelectionStart = _history[_historyPosition + 1].SelectionStart;
					SelectionLength = _history[_historyPosition + 1].SelectionLength;

					// move position
					++_historyPosition;
				}
			}
			finally
			{
				_isUndoRedoMode = false;
			}
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.Z)
			{
				e.Handled = true;
			}
			else if (e.Control && e.KeyCode == Keys.Y)
			{
				e.Handled = true;
			}
			else
			{
				base.OnKeyUp(e);
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.Z)
			{
				// undo
				MakeUndo();
				e.Handled = true;
			}
			else if (e.Control && e.KeyCode == Keys.Y)
			{
				// redo
				MakeRedo();
				e.Handled = true;
			}
			else
			{
				base.OnKeyDown(e);
			}
		}
	}
}
