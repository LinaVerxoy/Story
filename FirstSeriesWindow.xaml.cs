using Microsoft.VisualBasic.FileIO;
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
using System.Windows.Shapes;
using static System.Formats.Asn1.AsnWriter;

namespace LittleDragon
{
    /// <summary>
    /// Логика взаимодействия для FirstSeriesWindow.xaml
    /// </summary>
    public partial class FirstSeriesWindow : Window
    {
        private int currentSceneIndex = 0;
        private List<Scene> scenes;
        public FirstSeriesWindow()
        {
            InitializeComponent();
            InitializeScenes();
            LoadCurrentScene();

        }
        private void InitializeScenes()
        {
            scenes = new List<Scene>
           {
        new Scene
        {
            Text = "В одном маленьком городке, где утро всегда начиналось с пения птиц, жил мальчик по имени Петя. Однажды, проснувшись рано, он решил, что пора выбраться на улицу и насладиться свежим воздухом. Солнечные лучи пробивались сквозь зелёные деревья, а вокруг было так спокойно. Вдруг он услышал тихое мяуканье, доносящееся из кустов. ",
            ImagePath = "C:\\Users\\user\\source\\repos\\LittleDragon\\LittleDragon\\Images\\Dragon.jpg",
            Options = new List<Option>
            {
                new Option { Text = "Пойти на звук", NextSceneIndex = 1 },
                new Option { Text = "Засомневаться и пойти дальше", NextSceneIndex = 2 }
            }
        },
        new Scene
        {
            Text = "Он подошёл ближе и увидел маленького котёнка, который запутался в ветках. Его зелёные глаза были полны страха, но при этом в них читалось надежда. Петя сразу же понял, что нельзя оставлять малыша в беде. Он осторожно освободил котёнка и прижал его к себе..",
            ImagePath = "C:\\Users\\user\\source\\repos\\LittleDragon\\LittleDragon\\Images\\Dragon.jpg",
            Options = new List<Option>
            {
                new Option { Text = "Оставить котёнка себе", NextSceneIndex = 3 },
                new Option { Text = "Временно приютить", NextSceneIndex = 4 }
            }
        },
        new Scene
        {
            Text = "Пройдя пару шагов, Петя всё же решил проверить в чём дело. Уж больно он любил братьев наших меньших и, наоборот, считал своим долгом помогать животным. Развернувшись, Петя всё же пошёл к источнику звука",
            ImagePath = "C:\\Users\\user\\source\\repos\\LittleDragon\\LittleDragon\\Images\\Dragon.jpg",
            Options = new List<Option>
            {
                new Option { Text = "Вернуться и извиниться", NextSceneIndex = 1 },
                new Option { Text = "Забыть о драконе", NextSceneIndex = 5 }
            }
        },
        new Scene
        {
            Text = "Вы играете с драконом, и он радуется.",
            ImagePath = "C:\\Users\\user\\source\\repos\\LittleDragon\\LittleDragon\\Images\\Dragon.jpg",
            Options = new List<Option>
            {
                new Option { Text = "Построить замок из песка", NextSceneIndex = 6 },
                new Option { Text = "Улететь на драконе", NextSceneIndex = 7 }
            }
        },
        new Scene
        {
            Text = "'Бедный! Я тебя не оставлю здесь. Но смогу приютить тебя на какое-то время, а там уже видно будет'- ласково сказал мальчик котёнку, словно тот понимает слова Пети.",
            ImagePath = "C:\\Users\\user\\source\\repos\\LittleDragon\\LittleDragon\\Images\\Dragon.jpg",
            Options = new List<Option>
            {
                new Option { Text = "Отправиться домой", NextSceneIndex = 8 },
                new Option { Text = "Остаться с ним", NextSceneIndex = 9 }
            }
        },
        // Конечная сцена после постройки замка из песка
        new Scene
        {
            Text = "Вы построили великолепный замок из песка, и дракон очень рад.",
            ImagePath = "C:\\Users\\user\\source\\repos\\LittleDragon\\LittleDragon\\Images\\Dragon.jpg",
            Options = null // Конечная сцена
        },
        // Конечная сцена после полета на драконе
        new Scene
        {
            Text = "Вы взмыла в небо на драконе, и это было незабываемо.",
            ImagePath = "C:\\Users\\user\\source\\repos\\LittleDragon\\LittleDragon\\Images\\Dragon.jpg",
            Options = null // Конечная сцена
        },
        // Конечная сцена после прощания
        new Scene
        {
            Text = "Вы сказали прощай дракону, и он улетел в облака.",
            ImagePath = "C:\\Users\\user\\source\\repos\\LittleDragon\\LittleDragon\\Images\\Dragon.jpg",
            Options = null // Конечная сцена
        },
        // Конечная сцена после остаться с драконом
        new Scene
        {
            Text = "Взяв котёнка на руки по-удобнее, Петя отправился домой. К сожалению, родители не имели возможности содержать питомца, несмотря на их безграничную любовь к животным. Пушистик временно поживёт у Пети дома, но вскоре обретёт любящую семью.",
            ImagePath = "C:\\Users\\user\\source\\repos\\LittleDragon\\LittleDragon\\Images\\Dragon.jpg",
            Options = null // Конечная сцена
        },
        // Конечная сцена после забвения о драконе
        new Scene
        {
            Text = "Вы забыли о драконе и продолжили свою жизнь.",
            ImagePath = "C:\\Users\\user\\source\\repos\\LittleDragon\\LittleDragon\\Images\\Dragon.jpg",
            Options = null // Конечная сцена
        }
    };
        }

        private void LoadCurrentScene()
        {
            if (currentSceneIndex < scenes.Count)
            {
                var scene = scenes[currentSceneIndex];
                StoryTextBlock.Text = scene.Text;
                Image.Source = new BitmapImage(new Uri(scene.ImagePath));
                ButtonPanel.Children.Clear(); // Очищаем предыдущие кнопки

                if (scene.Options != null)
                {
                    foreach (var option in scene.Options)
                    {
                        var button = new Button
                        {
                            Content = option.Text,
                            Margin = new Thickness(5),
                            Height = 50,
                            Width = 171
                        };
                        button.Click += (s, e) =>
                        {
                            currentSceneIndex = option.NextSceneIndex;
                            LoadCurrentScene();
                        };
                        ButtonPanel.Children.Add(button);
                    }
                }
                else
                {
                    EndSeries();
                }
            }
        }
        private void EndSeries()
        {
            SeriesSelectionWindow.IsFirstSeriesCompleted = true;
            MessageBox.Show("Первая серия завершена. Выберите дальнейшее действие.", "Завершение серии", MessageBoxButton.OK);
            SeriesSelectionWindow seriesSelectionWindow = new SeriesSelectionWindow();
            seriesSelectionWindow.Show();
            this.Close();
        }

        private class Scene
        {
            public string Text { get; set; }
            public string ImagePath { get; set; }
            public List<Option> Options { get; set; }
        }

        private class Option
        {
            public string Text { get; set; }
            public int NextSceneIndex { get; set; }
        }
    }
}






