using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry_Win_App
{
	internal class Displayer : Form
	{
		private RichTextBox logTextBox;
		private Button drawButton;

		private TextBox Param1TextBox;
		private TextBox Param2TextBox;
		private TextBox Param3TextBox;
		private Label Param1Label;
		private Label Param2Label;
		private Label Param3Label;

		private RadioButton rbTriangle;
		private RadioButton rbEllipse;
		private RadioButton rbRectangle;
		private Label ChoiceShapeLabel;

		private bool isDrawRectangle = false;
		private int rectX = 300;
		private int rectY = 300;

		private double shapeParam1 = 200;
		private double shapeParam2 = 200;
		private double shapeParam3 = 200;

		public Displayer()
		{
			this.Text = "Графика и лог";
			this.Width = 900;
			this.Height = 600;

			drawButton = new Button();
			drawButton.Text = "Нарисовать";
			drawButton.Location = new Point(10, 10);
			drawButton.Click += DrawButton_Click;
			this.Controls.Add(drawButton);


			Param1Label = new Label();
			Param1Label.Text = "Параметр1:";
			Param1Label.Location = new Point(250, 15);
			Param1Label.AutoSize = true;
			this.Controls.Add(Param1Label);

			Param1TextBox = new TextBox();
			Param1TextBox.Text = shapeParam1.ToString();
			Param1TextBox.Location = new Point(320, 12);
			Param1TextBox.Width = 50;
			this.Controls.Add(Param1TextBox);


			Param2Label = new Label();
			Param2Label.Text = "Параметр2:";
			Param2Label.Location = new Point(380, 15);
			Param2Label.AutoSize = true;
			this.Controls.Add(Param2Label);

			Param2TextBox = new TextBox();
			Param2TextBox.Text = shapeParam2.ToString();
			Param2TextBox.Location = new Point(450, 12);
			Param2TextBox.Width = 50;
			this.Controls.Add(Param2TextBox);

			Param3Label = new Label();
			Param3Label.Text = "Параметр3:";
			Param3Label.Location = new Point(510, 15);
			Param3Label.AutoSize = true;
			this.Controls.Add(Param3Label);

			Param3TextBox = new TextBox();
			Param3TextBox.Text = shapeParam3.ToString();
			Param3TextBox.Location = new Point(580, 12);
			Param3TextBox.Width = 50;
			this.Controls.Add(Param3TextBox);

			ChoiceShapeLabel = new Label();
			ChoiceShapeLabel.Text = "Выберите фигуру:";
			ChoiceShapeLabel.AutoSize = true;
			ChoiceShapeLabel.Location = new Point(100, 15);
			this.Controls.Add(ChoiceShapeLabel);

			rbRectangle = new RadioButton();
			rbRectangle.Text = "Прямоугольник";
			rbRectangle.AutoSize = true;
			rbRectangle.Location = new Point(100, 30);
			rbRectangle.Checked = true;
			this.Controls.Add(rbRectangle);

			rbEllipse = new RadioButton();
			rbEllipse.Text = "Окружность";
			rbEllipse.Location = new Point(100, 50);
			this.Controls.Add(rbEllipse);

			rbTriangle = new RadioButton();
			rbTriangle.Text = "Треугольник";
			rbTriangle.Location = new Point(100, 70);
			this.Controls.Add(rbTriangle);

			logTextBox = new RichTextBox();
			logTextBox.Multiline = true;
			logTextBox.Width = 860;
			logTextBox.Height = 50;
			logTextBox.Location = new Point(10, 100);
			logTextBox.ReadOnly = true;
			this.Controls.Add(logTextBox);
		}

		private void DrawButton_Click(object sender, EventArgs e)
		{
			Log("Кнопка нажата. Рисуем выбранную фигуру...");

			if (!double.TryParse(Param1TextBox.Text, out double param1) ||
				!double.TryParse(Param2TextBox.Text, out double param2) ||
				!double.TryParse(Param3TextBox.Text, out double param3)
				)
			{
				Log("Ошибка: введите корректные числа для параметров.");
				MessageBox.Show("Пожалуйста, введите правильные числа.", "Ошибка");
				return;
			}

			shapeParam1 = param1;
			shapeParam2 = param2;
			shapeParam3 = param3;

			isDrawRectangle = true;
			this.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			string shape_type = "пустота";
			if (isDrawRectangle)
			{
				Pen pen = new Pen(Color.Blue, 3);

				if (rbRectangle.Checked)
				{
					Rectangle rec = new Rectangle(shapeParam1, shapeParam2, pen.Color);
					rec.Info();
					e.Graphics.DrawRectangle(pen, rectX, rectY, Convert.ToInt32(shapeParam1), Convert.ToInt32(shapeParam2));
					shape_type = "Прямоугольник/Квадрат";
				}
				else if (rbEllipse.Checked)
				{ 
					Ellipse ell = new Ellipse(shapeParam1, shapeParam2,pen.Color);
					ell.Info();
					e.Graphics.DrawEllipse(pen, rectX, rectY, Convert.ToInt32(shapeParam1), Convert.ToInt32(shapeParam2));
					shape_type = "Овал/Круг";
				}
				else if(rbTriangle.Checked)
				{
					double xC = (Math.Pow(shapeParam3, 2) + Math.Pow(shapeParam2, 2) - Math.Pow(shapeParam1, 2)) / (shapeParam3 * 2);
					double temp = Math.Pow(shapeParam2, 2) - Math.Pow(xC, 2);
					double yC = Math.Sqrt(temp);

					Triangle tri = new Triangle(shapeParam1 , shapeParam2 , shapeParam3 , pen.Color);
					tri.Info();
					e.Graphics.DrawPolygon(pen, new Point[] { 
						new Point(rectX, rectY), 
						new Point(rectX + Convert.ToInt32(shapeParam3), rectY), 
						new Point(rectX + Convert.ToInt32(xC), rectY - Convert.ToInt32(yC))
						});
					shape_type = "Треугольник";

				}

				Log($"Нарисованна фигура - {shape_type}");
				isDrawRectangle = false;
				pen.Dispose();
			}
		}




		private void DrawShape(Action drawAction)
		{
			drawAction.Invoke();
			Log("Фигура нарисована.");
		}

		private void Log(string message)
		{
			logTextBox.AppendText($"{DateTime.Now:HH:mm:ss} - {message}\n");
		}

	}
}
