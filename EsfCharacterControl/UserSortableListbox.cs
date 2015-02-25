//Author: Marcin Sas-Szymański (synek317@gmail.com)
//License: CPOL 1.02 http://www.codeproject.com/info/cpol10.aspx

using System;
using System.ComponentModel;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

//based on
//http://stackoverflow.com/questions/805165/reorder-a-winforms-listbox-using-drag-and-drop

namespace UserSortableListbox
{
    /// <summary>
    /// Listbox control that allows user to reorder elements using drag'n'drop
    /// </summary>
    public class UserSortableListBox : ListBox
    {
        /// <summary>
        /// Reordered elements indices
        /// </summary>
        public class ReorderEventArgs : EventArgs
        {
            public int index1, index2;
        }
        /// <summary>
        /// Reorder event handler
        /// </summary>
        public delegate void ReorderHandler(object sender, ReorderEventArgs e);
        public event ReorderHandler Reorder;

        //AllowDrop must be set to true in order to make drag'n'drop working
        [Browsable(false)]
        new public bool AllowDrop
        {
            get { return true; }
            set { }

        }
        public UserSortableListBox()
        {
            base.AllowDrop = true;
            base.SelectionMode = SelectionMode.One;
        }

        [Browsable(false)]
        new public SelectionMode SelectionMode
        {
            get { return SelectionMode.One; }
            set { }
        }
        /// <summary>
        /// Index of dragged element
        /// </summary>
        private int sourceIndex = 0;
        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);
            Point point = PointToClient(new Point(e.X, e.Y));
            int index = IndexFromPoint(point); //destination index
            //allow DataSource, i.e. BindingList
            IList items = DataSource != null ? DataSource as IList : Items;
            if (index < 0) index = items.Count - 1;
            if (index != sourceIndex)
            {
                if (index > sourceIndex) //destination is below source
                {
                    items.Insert(index + 1, items[sourceIndex]);
                    items.RemoveAt(sourceIndex);
                }
                else //destination is above source
                {
                    items.Insert(index, items[sourceIndex]);
                    items.RemoveAt(sourceIndex + 1);
                }
                if (null != Reorder) Reorder(this, new ReorderEventArgs() { index1 = sourceIndex, index2 = index });
            }
            //selectedIndex was lost during reorder
            SelectedIndex = index;
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);
            e.Effect = DragDropEffects.Move | DragDropEffects.Scroll;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (SelectedItem == null)
            {
                return;
            }
            sourceIndex = SelectedIndex;
            //OnSelectedIndexChanged is not launched while using MouseDown :(
            OnSelectedIndexChanged(e);
            DoDragDrop(SelectedItem, DragDropEffects.Move);
        }
    }


    /// <summary>
    /// Listbox control that allows user to reorder elements using drag'n'drop
    /// </summary>
    public class UserSortableCheckedListBox : CheckedListBox
    {
        /// <summary>
        /// Reordered elements indices
        /// </summary>
        public class ReorderEventArgs : EventArgs
        {
            public int index1, index2;
        }
        /// <summary>
        /// Reorder event handler
        /// </summary>
        public delegate void ReorderHandler(object sender, ReorderEventArgs e);
        public event ReorderHandler Reorder;

        //AllowDrop must be set to true in order to make drag'n'drop working
        [Browsable(false)]
        new public bool AllowDrop
        {
            get { return true; }
            set { }

        }
        public UserSortableCheckedListBox()
        {
            base.AllowDrop = true;
            base.SelectionMode = SelectionMode.One;
        }

        [Browsable(false)]
        new public SelectionMode SelectionMode
        {
            get { return SelectionMode.One; }
            set { }
        }
        /// <summary>
        /// Index of dragged element
        /// </summary>
        private int sourceIndex = 0;
        protected override void OnDragDrop(DragEventArgs e)
        {
            base.OnDragDrop(e);
            Point point = PointToClient(new Point(e.X, e.Y));
            int index = IndexFromPoint(point); //destination index
            //allow DataSource, i.e. BindingList
            IList items = DataSource != null ? DataSource as IList : Items;
            if (index < 0) index = items.Count - 1;
            if (index != sourceIndex)
            {
                bool itemChecked = GetItemChecked(sourceIndex);
                if (index > sourceIndex) //destination is below source
                {
                    items.Insert(index + 1, items[sourceIndex]);
                    items.RemoveAt(sourceIndex);
                }
                else //destination is above source
                {
                    items.Insert(index, items[sourceIndex]);
                    items.RemoveAt(sourceIndex + 1);
                }
                SetItemChecked(index, itemChecked);
                if (null != Reorder) Reorder(this, new ReorderEventArgs() { index1 = sourceIndex, index2 = index });
            }
            //selectedIndex was lost during reorder
            SelectedIndex = index;
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);
            e.Effect = DragDropEffects.Move | DragDropEffects.Scroll;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (SelectedItem == null)
            {
                return;
            }
            sourceIndex = SelectedIndex;
            //OnSelectedIndexChanged is not launched while using MouseDown :(
            OnSelectedIndexChanged(e);
            DoDragDrop(SelectedItem, DragDropEffects.Move);
        }
    }
}
