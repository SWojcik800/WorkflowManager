using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkflowManager.App.Helpers
{
    public class NestedFormHelper
    {
        public static void OpenBelowControl(Control control, Form form)
        {
            var loc = control.PointToScreen(Point.Empty);
            var loc2 = new Point(loc.X, loc.Y + control.Height);

            //form.FormBorderStyle = FormBorderStyle.None;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.ControlBox = false;
            form.Text = string.Empty;
            form.Deactivate += Form_Deactivate;
            form.StartPosition = FormStartPosition.Manual;
            //form.BackColor = control.BackColor;

            form.Location = loc2;
            form.Focus();
            form.Show();

        }

        public static bool OpenInGrid(DataGridView control, Form form, bool isNewRow = false, int newRowIdx = 0, bool closeOnLostFocus = false)
        {
            if(isNewRow)
            {
                var rowRect = control.GetRowDisplayRectangle(newRowIdx, false);
                return ShowForm(control, form, closeOnLostFocus, rowRect);
            }

            if (control.CurrentRow is not null)
            {
                var rowRect = control.GetRowDisplayRectangle(control.CurrentRow.Index, false);
                return ShowForm(control, form, closeOnLostFocus, rowRect);

            }
            return false;
        }

        private static bool ShowForm(DataGridView control, Form form, bool closeOnLostFocus, Rectangle rowRect)
        {
            Point rowLocation = rowRect.Location;

            Point controlLocation = control.PointToScreen(Point.Empty);

            var loc = new Point(controlLocation.X, rowLocation.Y + controlLocation.Y + rowRect.Height);

            //form.FormBorderStyle = FormBorderStyle.None;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.ControlBox = false;
            form.Text = string.Empty;
            if (closeOnLostFocus)
                form.Deactivate += Form_Deactivate;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = loc;
            form.Width = rowRect.Width;
            form.Focus();
            return form.ShowDialog() == DialogResult.OK;
        }

        private static void Form_Deactivate(object? sender, EventArgs e)
        {
            var form = sender as Form;
            form.Close();
        }
    }
}
