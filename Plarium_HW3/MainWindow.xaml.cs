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

namespace Plarium_HW3
{
    public partial class MainWindow : Window
    {
        int[] array = new int[7];//массив на 7 элементов
        int min = -20, max = 50;//задаем изначальные границы массива
        public MainWindow()
        {
            InitializeComponent();
        }

        private void get_sum_Click(object sender, RoutedEventArgs e)//функция нажатия кнопки "получить сумму"
        {
            int sum = 0;//переменная суммы
            string str = "";//записываем сюда элементы, кратные 3
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 3 == 0 && array[i] != 0) //проверка на кратность 3
                {
                    sum += array[i];//подсчет суммы
                    if (array[i] > 0)//если элемент > 0
                    {
                        str += "+"+array[i];//то перед ним в строку записываем +
                    }
                    else
                    {
                        str += array[i];
                    }
                    
                }
            }
            str+= "="+sum;//на выходе получаем строку элемент1+элемент2 = sum
            if (str=="=0") //если в строку не вошли числа, то
            {
                str = "Таких элементов нет!";//выводим то, что таких элементов нет
            }
            else
            {
                if (str[0] == '+')//здесь, если в выходной строке первый элемент +
                {
                    str = str.Remove(0, 1);//то мы его удаляем
                }
            }
            sum_text.Text = str;//записываем в текстбокс нашу переменную
            sum_text.FontSize = 20;//размер шрифта
            sum_text.TextAlignment = TextAlignment.Center;//позиционирование текста
        }

        private void get_array_Click(object sender, RoutedEventArgs e)//функция нажатия кнопки "сгенерировать массив"
        {
            Random rand = new Random();//для рандома
            string str="{";//начинаем строку со скобочки
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(min, max+1); //заполнение массива случайными числами
                if (i != (array.Length - 1))//добавляем запятые между элементами, пока он не последний
                {
                    str += array[i] + ", ";
                }
                else
                {
                    str += array[i]+"}";//если элемент последний - закрываем скобку
                }
                
            }
            array_text.Text = str;//вывод в текстбокс
            array_text.FontSize = 20;//размер шрифта
            array_text.TextAlignment = TextAlignment.Center;//позиционирование
        }

        private void change_rnd_values_Click(object sender, RoutedEventArgs e)//нажатие кнопки "изменить значения"
        {
            Random_Values window1 = new Random_Values();//создание диалогового окна
            window1.ShowDialog();//открытие (модальное!)
            //проверка на ввод букв, символов и т.д.
            if (!int.TryParse(window1.min_value.Text, out min) || !int.TryParse(window1.max_value.Text, out max))
            {
                MessageBox.Show("Вы ввели не числовое значение!\nЗначения сброшены! min=-20; max=50!"); //вывод месседжбокса
                min = -20;//сбрасываем значения в начальные
                max = 50;
            }
            else
            {//если были введены не символы, то мы их переводим в инт и присваиваем переменным
                min = int.Parse(window1.min_value.Text);
                max = int.Parse(window1.max_value.Text);
            }
            if (min > max)//если у нас получилось, что пользователь ввел минимум больший за максимум
            {//мы выводим месседж бокс и меняем их местами с помощью временной переменной
                MessageBox.Show("Вы перепутали min и max!\nПрограмма поменяла их местами, не благодарите!");
                int temp = 0;
                temp = min;
                min = max;
                max = temp;
            }
        }
    }
}
