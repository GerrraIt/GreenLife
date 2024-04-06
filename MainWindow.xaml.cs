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
using System.Xml;
using System.Net;
using System.IO;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;


namespace GreenLife
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void map_load(object sender, RoutedEventArgs e)
        {
            
            // Настройки для компонента GMap
            gmap.Bearing = 0;
            // Перетаскивание левой кнопки мыши
            gmap.CanDragMap = true;
            // Перетаскивание карты левой кнопкой мыши
            gmap.DragButton = MouseButton.Left;

            gmap.MaxZoom = 18;
            // Минимальное приближение
            gmap.MinZoom = 2;
            // Курсор мыши в центр карты
            gmap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;

            // Скрытие внешней сетки карты
            gmap.ShowTileGridLines = false;
            // При загрузке 10-кратное увеличение
            gmap.Zoom = 10;
            // Убрать красный крестик по центру
            gmap.ShowCenter = false;
            // Чья карта используется
            gmap.MapProvider = GMapProviders.GoogleMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(62.0483223, 129.7553272);


            //GMapMarker marker = new GMapMarker(new PointLatLng(47.200041, 38.8855908));

        }

        public class MarkerInfo
        {
            public PointLatLng Coordinates { get; set; }
            public GMapMarker Marker { get; set; }
        }


        List<MarkerInfo> batareykiMarkers = new List<MarkerInfo>();
        List<MarkerInfo> bumagaMarkers = new List<MarkerInfo>();
        List<MarkerInfo> tehnikaMarkers = new List<MarkerInfo>();
        List<MarkerInfo> krizhkiMarkers = new List<MarkerInfo>();
        List<MarkerInfo> lampochkiMarkers = new List<MarkerInfo>();
        List<MarkerInfo> metallMarkers = new List<MarkerInfo>();
        List<MarkerInfo> odezhdaMarkers = new List<MarkerInfo>();
        List<MarkerInfo> opasnoeMarkers = new List<MarkerInfo>();
        List<MarkerInfo> plastikMarkers = new List<MarkerInfo>();
        List<MarkerInfo> shiniMarkers = new List<MarkerInfo>();
        List<MarkerInfo> stekloMarkers = new List<MarkerInfo>();
        List<MarkerInfo> drygoeMarkers = new List<MarkerInfo>();

        private void AddMarkersBatareyki()
        {
            Dictionary<PointLatLng, string> coordinatesAndNames = new Dictionary<PointLatLng, string>
            {
                 { new PointLatLng(62.04463053664679, 129.75045026906457), "Пункт приема батареек" },
            };

            foreach (var pair in coordinatesAndNames)
            {
                // Проверяем, существует ли уже маркер с такими координатами
                MarkerInfo existingMarker = batareykiMarkers.FirstOrDefault(m => m.Coordinates == pair.Key);

                if (existingMarker == null)
                {
                    batareykiBTN.Opacity = 1;

                    // Создаем новый маркер и добавляем его в коллекцию
                    GMapMarker newMarker = new GMapMarker(pair.Key);

                    newMarker.Shape = new Image
                    {
                        Source = new BitmapImage(new Uri(@"C:\Users\rpozc\source\repos\GreenLife\Resources\batareyka.png")),
                        MinWidth = 25,
                        MaxHeight = 50,
                        ToolTip = pair.Value,
                        Visibility = Visibility.Visible,
                    };

                    // Добавляем новый маркер на карту и в коллекцию
                    gmap.Markers.Add(newMarker);
                    batareykiMarkers.Add(new MarkerInfo { Coordinates = pair.Key, Marker = newMarker });
                }
                else
                {
                    batareykiBTN.Opacity = 0.5;
                    // Удаляем существующий маркер из коллекции и с карты
                    batareykiMarkers.Remove(existingMarker);
                    gmap.Markers.Remove(existingMarker.Marker);
                }
            }
        }

        private void AddMarkersBumaga()
        {
            Dictionary<PointLatLng, string> coordinatesAndNames = new Dictionary<PointLatLng, string>
            {
                 { new PointLatLng(62.07804172176815, 129.7957833821981), "Пункт приема бумаги: Эко-партнер" },
                 { new PointLatLng(62.0446026483699, 129.74661470680198), "Пункт приема бумаги: Пункт Приема платежей" },
            };

            foreach (var pair in coordinatesAndNames)
            {
                // Проверяем, существует ли уже маркер с такими координатами
                MarkerInfo existingMarker = bumagaMarkers.FirstOrDefault(m => m.Coordinates == pair.Key);

                if (existingMarker == null)
                {
                    bumagaBTN.Opacity = 1;

                    // Создаем новый маркер и добавляем его в коллекцию
                    GMapMarker newMarker = new GMapMarker(pair.Key);

                    newMarker.Shape = new Image
                    {
                        Source = new BitmapImage(new Uri(@"C:\Users\rpozc\source\repos\GreenLife\Resources\bumaga.png")),
                        MinWidth = 25,
                        MaxHeight = 50,
                        ToolTip = pair.Value,
                        Visibility = Visibility.Visible,
                    };

                    // Добавляем новый маркер на карту и в коллекцию
                    gmap.Markers.Add(newMarker);
                    bumagaMarkers.Add(new MarkerInfo { Coordinates = pair.Key, Marker = newMarker });
                }
                else
                {
                    bumagaBTN.Opacity = 0.5;
                    // Удаляем существующий маркер из коллекции и с карты
                    bumagaMarkers.Remove(existingMarker);
                    gmap.Markers.Remove(existingMarker.Marker);
                }
            }
        }

        private void AddMarkersTehnika()
        {
            Dictionary<PointLatLng, string> coordinatesAndNames = new Dictionary<PointLatLng, string>
            {
                 { new PointLatLng(62.044625459229756, 129.75041808246573), "Пункт приема техники: Пункт приема батареек" },
                 { new PointLatLng(62.04466614583549, 129.74657747751547), "Пункт приема техники: Пункт Приема Платежей" },
                 { new PointLatLng(62.097201801763184, 129.71020244868035), "Пункт приема техники: Центр Утилизации Техники И Оборудования" },
                 { new PointLatLng(62.026705711055676, 129.72349304314176), "Пункт приема техники: ВСЁ, комиссионный магазин" },
            };

            foreach (var pair in coordinatesAndNames)
            {
                // Проверяем, существует ли уже маркер с такими координатами
                MarkerInfo existingMarker = tehnikaMarkers.FirstOrDefault(m => m.Coordinates == pair.Key);

                if (existingMarker == null)
                {
                    tehnikaBTN.Opacity = 1;

                    // Создаем новый маркер и добавляем его в коллекцию
                    GMapMarker newMarker = new GMapMarker(pair.Key);

                    newMarker.Shape = new Image
                    {
                        Source = new BitmapImage(new Uri(@"C:\Users\rpozc\source\repos\GreenLife\Resources\tehnika.png")),
                        MinWidth = 25,
                        MaxHeight = 50,
                        ToolTip = pair.Value,
                        Visibility = Visibility.Visible,
                    };

                    // Добавляем новый маркер на карту и в коллекцию
                    gmap.Markers.Add(newMarker);
                    tehnikaMarkers.Add(new MarkerInfo { Coordinates = pair.Key, Marker = newMarker });
                }
                else
                {
                    tehnikaBTN.Opacity = 0.5;
                    // Удаляем существующий маркер из коллекции и с карты
                    tehnikaMarkers.Remove(existingMarker);
                    gmap.Markers.Remove(existingMarker.Marker);
                }
            }
        }

        private void AddMarkersKrizhki()
        {
            Dictionary<PointLatLng, string> coordinatesAndNames = new Dictionary<PointLatLng, string>
            {
                 { new PointLatLng(62.044703842982365, 129.74655065372383), "Пункт приема крышек: Пункт Приема Платежей" },
            };

            foreach (var pair in coordinatesAndNames)
            {
                // Проверяем, существует ли уже маркер с такими координатами
                MarkerInfo existingMarker = krizhkiMarkers.FirstOrDefault(m => m.Coordinates == pair.Key);

                if (existingMarker == null)
                {
                    krizhkiBTN.Opacity = 1;

                    // Создаем новый маркер и добавляем его в коллекцию
                    GMapMarker newMarker = new GMapMarker(pair.Key);

                    newMarker.Shape = new Image
                    {
                        Source = new BitmapImage(new Uri(@"C:\Users\rpozc\source\repos\GreenLife\Resources\krizhki.png")),
                        MinWidth = 25,
                        MaxHeight = 50,
                        ToolTip = pair.Value,
                        Visibility = Visibility.Visible,
                    };

                    // Добавляем новый маркер на карту и в коллекцию
                    gmap.Markers.Add(newMarker);
                    krizhkiMarkers.Add(new MarkerInfo { Coordinates = pair.Key, Marker = newMarker });
                }
                else
                {
                    krizhkiBTN.Opacity = 0.5;
                    // Удаляем существующий маркер из коллекции и с карты
                    krizhkiMarkers.Remove(existingMarker);
                    gmap.Markers.Remove(existingMarker.Marker);
                }
            }
        }

        private void AddMarkersLampochki()
        {
            Dictionary<PointLatLng, string> coordinatesAndNames = new Dictionary<PointLatLng, string>
            {

            };

            foreach (var pair in coordinatesAndNames)
            {
                // Проверяем, существует ли уже маркер с такими координатами
                MarkerInfo existingMarker = lampochkiMarkers.FirstOrDefault(m => m.Coordinates == pair.Key);

                if (existingMarker == null)
                {
                    lampochkiBTN.Opacity = 1;

                    // Создаем новый маркер и добавляем его в коллекцию
                    GMapMarker newMarker = new GMapMarker(pair.Key);

                    newMarker.Shape = new Image
                    {
                        Source = new BitmapImage(new Uri(@"C:\Users\rpozc\source\repos\GreenLife\Resources\lampochki.png")),
                        MinWidth = 25,
                        MaxHeight = 50,
                        ToolTip = pair.Value,
                        Visibility = Visibility.Visible,
                    };

                    // Добавляем новый маркер на карту и в коллекцию
                    gmap.Markers.Add(newMarker);
                    lampochkiMarkers.Add(new MarkerInfo { Coordinates = pair.Key, Marker = newMarker });
                }
                else
                {
                    lampochkiBTN.Opacity = 0.5;
                    // Удаляем существующий маркер из коллекции и с карты
                    lampochkiMarkers.Remove(existingMarker);
                    gmap.Markers.Remove(existingMarker.Marker);
                }
            }
        }

        private void AddMarkersMetall()
        {
            Dictionary<PointLatLng, string> coordinatesAndNames = new Dictionary<PointLatLng, string>
            {
                 { new PointLatLng(62.005896501061194, 129.716581028042), "Пункт приема металла: Сахавтормет" },
                 { new PointLatLng(62.07796168815742, 129.7965381703716), "Пункт приема металла: Сахаресурс" },
                 { new PointLatLng(62.06991018534999, 129.79377618201994), "Пункт приема металла: Втормет" },
                 { new PointLatLng(62.08204492976132, 129.80120045503097), "Пункт приема металла: Вторметлом" },
            };

            foreach (var pair in coordinatesAndNames)
            {
                // Проверяем, существует ли уже маркер с такими координатами
                MarkerInfo existingMarker = metallMarkers.FirstOrDefault(m => m.Coordinates == pair.Key);

                if (existingMarker == null)
                {
                    metallBTN.Opacity = 1;

                    // Создаем новый маркер и добавляем его в коллекцию
                    GMapMarker newMarker = new GMapMarker(pair.Key);

                    newMarker.Shape = new Image
                    {
                        Source = new BitmapImage(new Uri(@"C:\Users\rpozc\source\repos\GreenLife\Resources\metall.png")),
                        MinWidth = 25,
                        MaxHeight = 50,
                        ToolTip = pair.Value,
                        Visibility = Visibility.Visible,
                    };

                    // Добавляем новый маркер на карту и в коллекцию
                    gmap.Markers.Add(newMarker);
                    metallMarkers.Add(new MarkerInfo { Coordinates = pair.Key, Marker = newMarker });
                }
                else
                {
                    metallBTN.Opacity = 0.5;
                    // Удаляем существующий маркер из коллекции и с карты
                    metallMarkers.Remove(existingMarker);
                    gmap.Markers.Remove(existingMarker.Marker);
                }
            }
        }

        private void AddMarkersOdezhda()
        {
            Dictionary<PointLatLng, string> coordinatesAndNames = new Dictionary<PointLatLng, string>
            {
                 { new PointLatLng(62.02665916069664, 129.72360837831812), "Пункт приема одежды: ВСЁ, комиссионный магазин" },
                 { new PointLatLng(62.04460956394243, 129.74657479550498), "Пункт приема одежды: Пункт Приема платежей" },
                 { new PointLatLng(62.044672432706, 129.7467303636149), "Пункт приема одежды: Пункт приема объявлений" },
                 { new PointLatLng(62.03207567897188, 129.71234951759294), "Пункт приема одежды: SMART" },

            };

            foreach (var pair in coordinatesAndNames)
            {
                // Проверяем, существует ли уже маркер с такими координатами
                MarkerInfo existingMarker = odezhdaMarkers.FirstOrDefault(m => m.Coordinates == pair.Key);

                if (existingMarker == null)
                {
                    odezhdaBTN.Opacity = 1;

                    // Создаем новый маркер и добавляем его в коллекцию
                    GMapMarker newMarker = new GMapMarker(pair.Key);

                    newMarker.Shape = new Image
                    {
                        Source = new BitmapImage(new Uri(@"C:\Users\rpozc\source\repos\GreenLife\Resources\odezhda.png")),
                        MinWidth = 25,
                        MaxHeight = 50,
                        ToolTip = pair.Value,
                        Visibility = Visibility.Visible,
                    };

                    // Добавляем новый маркер на карту и в коллекцию
                    gmap.Markers.Add(newMarker);
                    odezhdaMarkers.Add(new MarkerInfo { Coordinates = pair.Key, Marker = newMarker });
                }
                else
                {
                    odezhdaBTN.Opacity = 0.5;
                    // Удаляем существующий маркер из коллекции и с карты
                    odezhdaMarkers.Remove(existingMarker);
                    gmap.Markers.Remove(existingMarker.Marker);
                }
            }
        }

        private void AddMarkersOpasnoe()
        {
            Dictionary<PointLatLng, string> coordinatesAndNames = new Dictionary<PointLatLng, string>
            {
                 { new PointLatLng(62.03874047978724, 129.69353295608389), "Пункт приема опасного: Новые экологические технологии" },
                 { new PointLatLng(62.04486694641688, 129.7503537100619), "Пункт приема опасного: Пункт приема батареек" },
                 { new PointLatLng(62.023873152863416, 129.72110417152484), "Пункт приема опасного: ЭКО-Партнер ИП Петров / Утилизация Автомобилей" },
                 { new PointLatLng(62.005680585722835, 129.7165823698404), "Пункт приема опасного: Сахавтормет" },
                 { new PointLatLng(62.08194885874297, 129.80115619927994), "Пункт приема опасного: Вторметлом" },
                 { new PointLatLng(62.06956791141667, 129.79293487658765), "Пункт приема опасного: АО «Втормет-ДВ»" },
                 { new PointLatLng(62.11820744848876, 129.77120970602715), "Пункт приема опасного: Всск" },
            };

            foreach (var pair in coordinatesAndNames)
            {
                // Проверяем, существует ли уже маркер с такими координатами
                MarkerInfo existingMarker = opasnoeMarkers.FirstOrDefault(m => m.Coordinates == pair.Key);

                if (existingMarker == null)
                {
                    opasnoeBTN.Opacity = 1;

                    // Создаем новый маркер и добавляем его в коллекцию
                    GMapMarker newMarker = new GMapMarker(pair.Key);

                    newMarker.Shape = new Image
                    {
                        Source = new BitmapImage(new Uri(@"C:\Users\rpozc\source\repos\GreenLife\Resources\opasnoe.png")),
                        MinWidth = 25,
                        MaxHeight = 50,
                        ToolTip = pair.Value,
                        Visibility = Visibility.Visible,
                    };

                    // Добавляем новый маркер на карту и в коллекцию
                    gmap.Markers.Add(newMarker);
                    opasnoeMarkers.Add(new MarkerInfo { Coordinates = pair.Key, Marker = newMarker });
                }
                else
                {
                    opasnoeBTN.Opacity = 0.5;
                    // Удаляем существующий маркер из коллекции и с карты
                    opasnoeMarkers.Remove(existingMarker);
                    gmap.Markers.Remove(existingMarker.Marker);
                }
            }
        }

        private void AddMarkersPlastik()
        {
            Dictionary<PointLatLng, string> coordinatesAndNames = new Dictionary<PointLatLng, string>
            {
                 { new PointLatLng(62.11820995715305, 129.77120970602715), "Пункт приема пластика: Всск" },
                 { new PointLatLng(62.07792749198321, 129.79587065879647), "Пункт приема пластика: Эко-партнер" },
                 { new PointLatLng(62.038189008744034, 129.69350747658765), "Пункт приема пластика: Новые экологические технологии" },
                 { new PointLatLng(62.044555746757226, 129.75046234100526), "Пункт приема пластика: Пункт приема батареек" },
                 { new PointLatLng(62.02387441109958, 129.72110953670852), "Пункт приема пластика: ЭКО-Партнер ИП Петров" },
                 { new PointLatLng(62.07780029208581, 129.79654487658763), "Пункт приема пластика: Сахаресурс" },
                 { new PointLatLng(62.0697751295483, 129.79389017658764), "Пункт приема пластика: Втормет" },
                 { new PointLatLng(61.990935363173975, 129.6725685146206), "Пункт приема пластика: oooCATALIZATOR.ru" },
                 { new PointLatLng(62.08195011457524, 129.80116156369752), "Пункт приема пластика: Вторметлом" },
                 { new PointLatLng(62.03900425493638, 129.6450015035766), "Пункт приема пластика: САХАРЕСУРС" },
                 { new PointLatLng(62.0407859342583, 129.65796298088435), "Пункт приема пластика: Вторпроект" },
            };

            foreach (var pair in coordinatesAndNames)
            {
                // Проверяем, существует ли уже маркер с такими координатами
                MarkerInfo existingMarker = plastikMarkers.FirstOrDefault(m => m.Coordinates == pair.Key);

                if (existingMarker == null)
                {
                    plastikBTN.Opacity = 1;

                    // Создаем новый маркер и добавляем его в коллекцию
                    GMapMarker newMarker = new GMapMarker(pair.Key);

                    newMarker.Shape = new Image
                    {
                        Source = new BitmapImage(new Uri(@"C:\Users\rpozc\source\repos\GreenLife\Resources\plastik.png")),
                        MinWidth = 25,
                        MaxHeight = 50,
                        ToolTip = pair.Value,
                        Visibility = Visibility.Visible,
                    };

                    // Добавляем новый маркер на карту и в коллекцию
                    gmap.Markers.Add(newMarker);
                    plastikMarkers.Add(new MarkerInfo { Coordinates = pair.Key, Marker = newMarker });
                }
                else
                {
                    plastikBTN.Opacity = 0.5;
                    // Удаляем существующий маркер из коллекции и с карты
                    plastikMarkers.Remove(existingMarker);
                    gmap.Markers.Remove(existingMarker.Marker);
                }
            }
        }

        private void AddMarkersShini()
        {
            Dictionary<PointLatLng, string> coordinatesAndNames = new Dictionary<PointLatLng, string>
            {
                 { new PointLatLng(62.083616374808784, 129.73247114642805), "Пункт приема шин: Шинный центр \"Шины-Квест\"" },
                 { new PointLatLng(62.06224438268721, 129.68790265317534), "Пункт приема шин: Vianor" },
                 { new PointLatLng(62.05426835235932, 129.77447833968088), "Пункт приема шин: Колесница" },
                 { new PointLatLng(62.077936911971506, 129.79585322434016), "Пункт приема шин: Эко-партнер" },
                 { new PointLatLng(62.09870008132206, 129.7474231310874), "Пункт приема шин: Штормавто" },
                 { new PointLatLng(62.06828835404597, 129.77113816297748), "Пункт приема шин: Якутский автоцентр КАМАЗ" },
            };

            foreach (var pair in coordinatesAndNames)
            {
                // Проверяем, существует ли уже маркер с такими координатами
                MarkerInfo existingMarker = shiniMarkers.FirstOrDefault(m => m.Coordinates == pair.Key);

                if (existingMarker == null)
                {
                    shiniBTN.Opacity = 1;

                    // Создаем новый маркер и добавляем его в коллекцию
                    GMapMarker newMarker = new GMapMarker(pair.Key);

                    newMarker.Shape = new Image
                    {
                        Source = new BitmapImage(new Uri(@"C:\Users\rpozc\source\repos\GreenLife\Resources\shini.png")),
                        MinWidth = 25,
                        MaxHeight = 50,
                        ToolTip = pair.Value,
                        Visibility = Visibility.Visible,
                    };

                    // Добавляем новый маркер на карту и в коллекцию
                    gmap.Markers.Add(newMarker);
                    shiniMarkers.Add(new MarkerInfo { Coordinates = pair.Key, Marker = newMarker });
                }
                else
                {
                    shiniBTN.Opacity = 0.5;
                    // Удаляем существующий маркер из коллекции и с карты
                    shiniMarkers.Remove(existingMarker);
                    gmap.Markers.Remove(existingMarker.Marker);
                }
            }
        }

        private void AddMarkersSteklo()
        {
            Dictionary<PointLatLng, string> coordinatesAndNames = new Dictionary<PointLatLng, string>
            {
                 { new PointLatLng(62.044555746757226, 129.7504757520492), "Пункт приема стекла: Пункт приема батареек" },
                 { new PointLatLng(62.077923723987084, 129.79587334100526), "Пункт приема стекла: Эко-партнер" },
                 { new PointLatLng(62.0697889492393, 129.79388481217006), "Пункт приема стекла: Втормет" },
                 { new PointLatLng(62.07779150005729, 129.79654487658763), "Пункт приема стекла: Сахаресурс" },
                 { new PointLatLng(62.02386434522666, 129.72111758333492), "Пункт приема стекла: ЭКО-Партнер ИП Петров" },
                 { new PointLatLng(62.062429334561266, 129.7177069005217), "Пункт приема стекла: Мир стекла" },
                 { new PointLatLng(62.04079222193105, 129.6579307943789), "Пункт приема стекла: Вторпроект" },
            };

            foreach (var pair in coordinatesAndNames)
            {
                // Проверяем, существует ли уже маркер с такими координатами
                MarkerInfo existingMarker = stekloMarkers.FirstOrDefault(m => m.Coordinates == pair.Key);

                if (existingMarker == null)
                {
                    stekloBTN.Opacity = 1;

                    // Создаем новый маркер и добавляем его в коллекцию
                    GMapMarker newMarker = new GMapMarker(pair.Key);

                    newMarker.Shape = new Image
                    {
                        Source = new BitmapImage(new Uri(@"C:\Users\rpozc\source\repos\GreenLife\Resources\steklo.png")),
                        MinWidth = 25,
                        MaxHeight = 50,
                        ToolTip = pair.Value,
                        Visibility = Visibility.Visible,
                    };

                    // Добавляем новый маркер на карту и в коллекцию
                    gmap.Markers.Add(newMarker);
                    stekloMarkers.Add(new MarkerInfo { Coordinates = pair.Key, Marker = newMarker });
                }
                else
                {
                    stekloBTN.Opacity = 0.5;
                    // Удаляем существующий маркер из коллекции и с карты
                    stekloMarkers.Remove(existingMarker);
                    gmap.Markers.Remove(existingMarker.Marker);
                }
            }
        }

        private void AddMarkersDrygoe()
        {
            Dictionary<PointLatLng, string> coordinatesAndNames = new Dictionary<PointLatLng, string>
            {
                 { new PointLatLng(62.04459849760701, 129.7465972761857), "Пункт приема разного: Пункт Приема Платежей / Пункт приема объявлений" },
            };

            foreach (var pair in coordinatesAndNames)
            {
                // Проверяем, существует ли уже маркер с такими координатами
                MarkerInfo existingMarker = drygoeMarkers.FirstOrDefault(m => m.Coordinates == pair.Key);

                if (existingMarker == null)
                {
                    drygoeBTN.Opacity = 1;

                    // Создаем новый маркер и добавляем его в коллекцию
                    GMapMarker newMarker = new GMapMarker(pair.Key);

                    newMarker.Shape = new Image
                    {
                        Source = new BitmapImage(new Uri(@"C:\Users\rpozc\source\repos\GreenLife\Resources\drygoe.png")),
                        MinWidth = 25,
                        MaxHeight = 50,
                        ToolTip = pair.Value,
                        Visibility = Visibility.Visible,
                    };

                    // Добавляем новый маркер на карту и в коллекцию
                    gmap.Markers.Add(newMarker);
                    drygoeMarkers.Add(new MarkerInfo { Coordinates = pair.Key, Marker = newMarker });
                }
                else
                {
                    drygoeBTN.Opacity = 0.5;
                    // Удаляем существующий маркер из коллекции и с карты
                    drygoeMarkers.Remove(existingMarker);
                    gmap.Markers.Remove(existingMarker.Marker);
                }
            }
        }


        private void batareykiBTN_Click(object sender, RoutedEventArgs e)
        {
            AddMarkersBatareyki();
        }

        private void bumagaBTN_Click(object sender, RoutedEventArgs e)
        {
            AddMarkersBumaga();
        }

        private void tehnikaBTN_Click(object sender, RoutedEventArgs e)
        {
            AddMarkersTehnika();
        }

        private void krizhkiBTN_Click(object sender, RoutedEventArgs e)
        {
            AddMarkersKrizhki();
        }

        private void lampochkiBTN_Click(object sender, RoutedEventArgs e)
        {
            AddMarkersLampochki();
        }

        private void metallBTN_Click(object sender, RoutedEventArgs e)
        {
            AddMarkersMetall();
        }

        private void odezhdaBTN_Click(object sender, RoutedEventArgs e)
        {
            AddMarkersOdezhda();
        }

        private void opasnoeBTN_Click(object sender, RoutedEventArgs e)
        {
            AddMarkersOpasnoe();
        }

        private void plastikBTN_Click(object sender, RoutedEventArgs e)
        {
            AddMarkersPlastik();
        }

        private void shiniBTN_Click(object sender, RoutedEventArgs e)
        {
            AddMarkersShini();
        }

        private void stekloBTN_Click(object sender, RoutedEventArgs e)
        {
            AddMarkersSteklo();
        }

        private void drygoeBTN_Click(object sender, RoutedEventArgs e)
        {
            AddMarkersDrygoe();
        }
    }
}
