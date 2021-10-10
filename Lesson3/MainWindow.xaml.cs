using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lesson3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            table.Items.Clear();
            try
            {
                int Start = Int32.Parse(StartTime.Text);
                int Lesson= Int32.Parse(lessonDuration.Text);
                int Break = Int32.Parse(BreakDuration.Text);
                int BigBreak = Int32.Parse(BigBreakDuration.Text);
                int Number = Int32.Parse(NumberOfLessons.Text);
                int Possition = Int32.Parse(BigBreakPosition.Text);
                table.Items.Add("Начало - Конец");
                string[] result = new string [Number];  // Массив уроков
                for (int i = 1; i < Number; i++) // Расчет расписания
                {
                    result[i] = (Start / 60 + ":" + Start % 60).ToString() + "   -   ";
                    Start += Lesson;// Добавление времени урока к общему времени занятий
                    result[i] += (Start / 60 + ":" + Start % 60).ToString();
                    if (i != Number - 1)
                        if (i != BigBreak) // Регулирование обычных и большиъ перемен
                        {
                            Start += Break; // Добавление времени обычной перемены к общему времени занятий
                        }
                        else
                        {
                            Start += BigBreak; // Добавление времени большой перемены к общему времени занятий
                        }
                }
                for (int i = 1; i < Number; i++) // Вывод расписания
                    table.Items.Add(result[i]);
                MessageBox.Show("Расписвание успешно составлено");
            }
            catch
            {
                MessageBox.Show("Проверьте правильность вводимых данных");
            }
        }
        private void Execution()
        {

        }
    }   
}
