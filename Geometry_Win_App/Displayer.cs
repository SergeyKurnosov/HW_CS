using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Win_App
{
	enum type_shape
	{
		Ellipse = 0, Rectangle = 1, Triangle = 2,
	}
	internal class Displayer : Form
	{
		private Button drawButton;

		Shape shape;

		private TextBox Param1TextBox;
		private TextBox Param2TextBox;
		private TextBox Param3TextBox;
		private Label Param1Label;
		private Label Param2Label;
		private Label Param3Label;

		private ComboBox Base_comboBox;
		private ComboBox Nested_comboBox;

		private Label ChoiceShapeLabel;

		private bool isDrawRectangle = false;
		private int rectX = 300;
		private int rectY = 300;

		private double shapeParam1 = 200;
		private double shapeParam2 = 200;
		private double shapeParam3 = 200;

		private type_shape Type_shape;

		public Displayer()
		{
			this.Text = "Графика и лог";
			this.Width = 900;
			this.Height = 600;

			drawButton = Displayer_expander.create_Button("Нарисовать", 10, 10);
			drawButton.Click += DrawButton_Click;
			this.Controls.Add(drawButton);

			Param1Label = Displayer_expander.create_Label("Параметр1:", 250, 15);
			Param1TextBox = Displayer_expander.create_TextBox(shapeParam1.ToString(), 320, 12);

			Param2Label = Displayer_expander.create_Label("Параметр2:", 380, 15);
			Param2TextBox = Displayer_expander.create_TextBox(shapeParam2.ToString(), 450, 12);

			Param3Label = Displayer_expander.create_Label("Параметр3:", 510, 15);
			Param3TextBox = Displayer_expander.create_TextBox(shapeParam3.ToString(), 580, 12);

			ChoiceShapeLabel = Displayer_expander.create_Label("Выберите фигуру:", 100, 15);
			this.Controls.Add(ChoiceShapeLabel);

			Base_comboBox = Displayer_expander.create_ComboBox(new string[] { "Окружность", "Прямоугольник", "Треугольник" }, 100, 30, 100, 30);
			Base_comboBox.SelectedIndexChanged += Base_comboBox_SelectedIndexChanged;
			this.Controls.Add(Base_comboBox);

		}

		private void Base_comboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.Controls.Remove(Nested_comboBox);
			if (Base_comboBox.SelectedItem != null)
			{
				switch (Base_comboBox.SelectedItem.ToString())
				{
					case "Окружность":
						Type_shape = type_shape.Ellipse;
						Nested_comboBox = Displayer_expander.create_ComboBox(new string[] { "Овал", "Круг" }, Base_comboBox.Location.X, Base_comboBox.Location.Y + 30, Base_comboBox.Width, Base_comboBox.Height);
						break;
					case "Прямоугольник":
						Type_shape = type_shape.Rectangle;
						Nested_comboBox = Displayer_expander.create_ComboBox(new string[] { "Прямоугольник", "Квадрат" }, Base_comboBox.Location.X, Base_comboBox.Location.Y + 30, Base_comboBox.Width, Base_comboBox.Height);
						break;
					case "Треугольник":
						Type_shape = type_shape.Triangle;
						Nested_comboBox = Displayer_expander.create_ComboBox(new string[] { "Разносторонний", "Равнобедренный", "Равносторонний" }, Base_comboBox.Location.X, Base_comboBox.Location.Y + 30, Base_comboBox.Width, Base_comboBox.Height);
						break;
				}
				Nested_comboBox.SelectedIndexChanged += Nested_comboBox_SelectedIndexChanged;
				this.Controls.Add(Nested_comboBox);
			}
		}

		private void Nested_comboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Nested_comboBox.SelectedItem != null)
			{
				switch (Type_shape)
				{
					case type_shape.Ellipse:
						switch (Nested_comboBox.SelectedItem.ToString())
						{
							case "Овал": parametrs(2); break;
							case "Круг": parametrs(1); break;
						}

						break;
					case type_shape.Rectangle:

						switch (Nested_comboBox.SelectedItem.ToString())
						{
							case "Прямоугольник": parametrs(2); break;
							case "Квадрат": parametrs(1); break;
						}

						break;
					case type_shape.Triangle:

						switch (Nested_comboBox.SelectedItem.ToString())
						{
							case "Разносторонний": parametrs(3); break;
							case "Равнобедренный": parametrs(2); break;
							case "Равносторонний": parametrs(1); break;
						}

						break;
				}
			}
		}

		public void parametrs(int count = 1)
		{
			this.Controls.Add(Param1Label);
			this.Controls.Add(Param1TextBox);

			switch (count)
			{
				case 1:
					this.Controls.Remove(Param2Label);
					this.Controls.Remove(Param2TextBox);

					this.Controls.Remove(Param3Label);
					this.Controls.Remove(Param3TextBox);
					break;
				case 2:
					this.Controls.Add(Param2Label);
					this.Controls.Add(Param2TextBox);

					this.Controls.Remove(Param3Label);
					this.Controls.Remove(Param3TextBox);

					break;
				case 3:
					this.Controls.Add(Param2Label);
					this.Controls.Add(Param2TextBox);

					this.Controls.Add(Param3Label);
					this.Controls.Add(Param3TextBox);
					break;
			}



		}

		private void DrawButton_Click(object sender, EventArgs e)
		{
			if (!double.TryParse(Param1TextBox.Text, out double param1) ||
				!double.TryParse(Param2TextBox.Text, out double param2) ||
				!double.TryParse(Param3TextBox.Text, out double param3)
				)
			{

				MessageBox.Show("Пожалуйста, введите правильные числа.", "Ошибка");
				return;
			}

			shapeParam1 = param1;
			shapeParam2 = param2;
			shapeParam3 = param3;

			switch (Type_shape)
			{
				case type_shape.Ellipse:
					switch (Nested_comboBox.SelectedItem.ToString())
					{
						case "Овал": 
							shape = new Ellipse(param1, param2, Color.Black); break;
						case "Круг": 
							shape = new Circle(param1, Color.Black);
							shapeParam2 = shapeParam1;
							break;
					}
					break;
				case type_shape.Rectangle:

					switch (Nested_comboBox.SelectedItem.ToString())
					{
						case "Прямоугольник": shape = new Rectangle(param1, param2, Color.Blue); break;
						case "Квадрат": 
							shape = new Square(param1, Color.Blue);
							shapeParam2 = shapeParam1;
							break;
					}

					break;
				case type_shape.Triangle:

					switch (Nested_comboBox.SelectedItem.ToString())
					{
						case "Разносторонний": shape = new Triangle(param1, param2, param3, Color.Brown); break;
						case "Равнобедренный": 
							shape = new IsoscelesTriangle(param1, param2, Color.Brown);
							shapeParam3 = shapeParam2;						
							shapeParam2 = shapeParam1;
							break;
						case "Равносторонний": 
							shape = new EquilateralTriangle(param1, Color.Brown);
							shapeParam2 = shapeParam1;
							shapeParam3 = shapeParam1;
							break;
					}

					break;
			}

			isDrawRectangle = true;
			this.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			if (isDrawRectangle)
			{
				Pen pen = new Pen(shape.Color, shape.LineWidth);
				shape.Info();

				switch (Type_shape)
				{
					case type_shape.Ellipse:
						e.Graphics.DrawEllipse(pen, rectX, rectY, Convert.ToInt32(shapeParam1), Convert.ToInt32(shapeParam2));
						break;
					case type_shape.Rectangle:
						e.Graphics.DrawRectangle(pen, rectX, rectY, Convert.ToInt32(shapeParam1), Convert.ToInt32(shapeParam2));
						break;
					case type_shape.Triangle:
						double xC = (Math.Pow(shapeParam3, 2) + Math.Pow(shapeParam2, 2) - Math.Pow(shapeParam1, 2)) / (shapeParam3 * 2);
						double temp = Math.Pow(shapeParam2, 2) - Math.Pow(xC, 2);
						double yC = Math.Sqrt(temp);
						e.Graphics.DrawPolygon(pen, new Point[] {
						new Point(rectX, rectY),
						new Point(rectX + Convert.ToInt32(shapeParam3), rectY),
						new Point(rectX + Convert.ToInt32(xC), rectY - Convert.ToInt32(yC))
						});
						break;
				}
				isDrawRectangle = false;
				pen.Dispose();
			}
		}

	}
}
