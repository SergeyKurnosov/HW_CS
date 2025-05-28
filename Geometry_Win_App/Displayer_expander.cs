using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Win_App
{
	internal class Displayer_expander
	{
		public static Label create_Label(string text, int pos_x, int pos_y)
		{
			Label label = new Label();
			label.Text = text;
			label.AutoSize = true;
			label.Location = new Point(pos_x, pos_y);
			return label;
		}

		public static TextBox create_TextBox(string text, int pos_x, int pos_y)
		{
			TextBox textBox = new TextBox();
			textBox.Text = text;
			textBox.Width = 50;
			textBox.Location = new Point(pos_x, pos_y);
			return textBox;
		}

		public static Button create_Button(string text, int pos_x, int pos_y)
		{
			Button button = new Button();
			button.Text = text;
			button.Location = new Point(pos_x, pos_y);
			return button;
		}

		public static ComboBox create_ComboBox(string[] items , int pos_x, int pos_y , int width, int height)
		{
			ComboBox comboBox = new ComboBox();
			comboBox.Location = new Point(pos_x , pos_y);
			comboBox.Width = width;
			comboBox.Height = height;
			comboBox.Items.AddRange(items);
			return comboBox;
		}


	}
}
