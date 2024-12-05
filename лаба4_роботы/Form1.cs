using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Krasnyanskaya221327Var1
{
    public partial class Controller : Form
    {

        IPAddress ipAddress;
        public static int port, received, sec = 0;
        byte[] data;

        IPEndPoint iPEndPoint;
        EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

        public static int n, s, c, le, re, az, b, d0, d1, d2, d3, d4, d5, d6, d7, l0, l1, l2, l3, l4;
        private char[,] mapData = new char[40, 64]; // 40 строк, 64 столбца
        private Point? startPosition = null; // Стартовая позиция
        private Point? endPosition = null;   // Конечная позиция
        private bool isEditing = false; // Флаг для отслеживания режима редактирования
        private void map_draw_MouseClick(object sender, MouseEventArgs e)
        { if (isEditing)
            {
                // Определяем координаты клетки
                int col = e.X / 10; // Столбец
                int row = e.Y / 10; // Строка

                // Проверяем границы карты
                if (col < 0 || col >= 64 || row < 0 || row >= 40)
                    return;

                // Запрещаем ставить старт и стоп в стены
                if (mapData[row, col] == '#')
                {
                    MessageBox.Show("Нельзя поставить старт или стоп на стену!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (e.Button == MouseButtons.Left)
                {
                    // ЛКМ: Добавляем или убираем стену
                    mapData[row, col] = mapData[row, col] == '#' ? '.' : '#';
                }
                else if (e.Button == MouseButtons.Right)
                {
                    // ПКМ: Задаем стартовую и конечную позицию
                    if (startPosition == null)
                    {
                        startPosition = new Point(col, row);
                        X_Start.Text = Convert.ToString((col - 1) * 10 + 15);
                        Y_Start.Text = Convert.ToString((row - 1) * 10 + 15);

                    }
                    else if (endPosition == null)
                    {
                        endPosition = new Point(col, row);
                        X_Stop.Text = Convert.ToString((col - 1) * 10 + 15);
                        Y_Stop.Text = Convert.ToString((row - 1) * 10 + 15);
                    }
                    else
                    {
                        // Сбрасываем старт и стоп
                        startPosition = null;
                        endPosition = null;
                    }
                }

                // Перерисовываем карту
                DrawMap();
            }
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            {
                isEditing = false;
                // Очистить битмап (возвращаем белое изображение)
                map_draw.Image = new Bitmap(640, 400);

                // Очистить данные карты (если требуется)
                Array.Clear(mapData, 0, mapData.Length); // Очищаем массив карты
                startPosition = null; // Сбрасываем стартовую позицию
                endPosition = null; // Сбрасываем конечную позицию
                X_Start.Clear();
                Y_Start.Clear();
                X_Stop.Clear(); 
                Y_Stop.Clear();

                // Перерисовываем карту с пустыми данными
                DrawMap();
            }
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            if (isEditing) 
            {
                MessageBox.Show("Режим редактирования выключен");
            }
            else 
            {
                MessageBox.Show("Режим редактирования включен");
            }
            isEditing = !isEditing;

        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
                saveFileDialog.DefaultExt = "txt";
                saveFileDialog.Title = "Сохранить лабиринт";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Сохраняем лабиринт в файл
                    SaveMazeToFile(filePath);
                    MessageBox.Show("Лабиринт успешно сохранён!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void SaveMazeToFile(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    for (int row = 0; row < 40; row++)
                    {
                        string line = "";
                        for (int col = 0; col < 64; col++)
                        {
                            line += mapData[row, col];
                        }

                        writer.WriteLine(line); // Записываем строку в файл
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения лабиринта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Create_button_Click(object sender, EventArgs e)
        {
            if (startPosition == null || endPosition == null)
            {
                MessageBox.Show("Установите стартовую и конечную точки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Выполняем поиск
            lastFoundPath = BreadthFirstSearch(startPosition.Value, endPosition.Value);

            if (lastFoundPath != null && lastFoundPath.Count > 0)
            {
                DrawPath(lastFoundPath); // Отрисовка пути
            }
            else
            {
                MessageBox.Show("Путь не найден!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private List<Point> BreadthFirstSearch(Point start, Point end)
        {
            int rows = 40, cols = 64;
            Queue<Point> queue = new Queue<Point>();
            bool[,] visited = new bool[rows, cols];
            Point[,] parents = new Point[rows, cols]; // Для восстановления пути

            queue.Enqueue(start);
            visited[start.Y, start.X] = true;

            int[][] directions = new int[][]
            {
        new int[] { 0, -1 }, // Вверх
        new int[] { 0, 1 },  // Вниз
        new int[] { -1, 0 }, // Влево
        new int[] { 1, 0 }   // Вправо
            };

            while (queue.Count > 0)
            {
                Point current = queue.Dequeue();

                // Если достигли конца
                if (current == end)
                {
                    return ReconstructPath(parents, start, end);
                }

                foreach (var dir in directions)
                {
                    int newX = current.X + dir[0];
                    int newY = current.Y + dir[1];
                    Point next = new Point(newX, newY);

                    // Проверяем доступность позиции для робота
                    if (newX >= 0 && newX < cols && newY >= 0 && newY < rows &&
                        !visited[newY, newX] && IsPositionValid(next))
                    {
                        queue.Enqueue(next);
                        visited[newY, newX] = true;
                        parents[newY, newX] = current;
                        AnimateStep(next); // Анимация
                    }
                }
            }

            // Если путь не найден
            MessageBox.Show("Путь не найден!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return null;
        }
        private bool IsPositionValid(Point center)
        {
            int rows = 40, cols = 64;

            // Проверяем область 3x3 клеток вокруг центральной точки
            for (int dy = -1; dy <= 1; dy++)
            {
                for (int dx = -1; dx <= 1; dx++)
                {
                    int newX = center.X + dx;
                    int newY = center.Y + dy;

                    // Выходим за границы или натыкаемся на стену
                    if (newX < 0 || newX >= cols || newY < 0 || newY >= rows || mapData[newY, newX] == '#')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        private void AnimateStep(Point center)
        {
            if ((startPosition != null && center == startPosition.Value) ||
        (endPosition != null && center == endPosition.Value))
            {
                return;
            }
            Bitmap bitmap = new Bitmap(map_draw.Image); // Копируем текущее изображение
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // Вычисляем область 3x3 клеток
                Rectangle cellRect = new Rectangle(center.X * 10 - 10, center.Y * 10 - 10, 30, 30);
                using (Brush brush = new SolidBrush(Color.LightBlue)) // Цвет посещённой клетки
                {
                    g.FillRectangle(brush, cellRect);
                }
            }

            map_draw.Image = bitmap;
            map_draw.Refresh(); // Обновляем отображение
            Thread.Sleep(50); // Задержка для анимации
        }
        private List<Point> ReconstructPath(Point[,] parents, Point start, Point end)
        {
            List<Point> path = new List<Point>();
            Point current = end;

            while (current != start)
            {
                path.Add(current);
                current = parents[current.Y, current.X];
            }

            path.Add(start);
            path.Reverse(); // Путь строится от конца к началу, поэтому разворачиваем
            return path;
        }

        private void DrawPath(List<Point> path)
        {
            if (path == null || path.Count == 0) return;

            Bitmap bitmap = new Bitmap(map_draw.Image); // Копируем текущее изображение
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                using (Pen pen = new Pen(Color.Red, 10)) // Цвет и толщина линии
                {
                    for (int i = 0; i < path.Count - 1; i++)
                    {
                        Point start = new Point(path[i].X * 10 - 10, path[i].Y * 10 - 5);
                        Point end = new Point(path[i + 1].X * 10, path[i + 1].Y * 10 - 5);

                        // Проверяем, что точки пути не совпадают со стартовой и конечной
                        if (startPosition != null && path[i] == startPosition.Value) continue;
                        if (endPosition != null && path[i + 1] == endPosition.Value) continue;

                        g.DrawLine(pen, start, end); // Рисуем линию между центрами областей
                    }
                }

                // Отдельно рисуем стартовую и конечную точки, чтобы они не затёрлись
                if (startPosition != null)
                {
                    using (Brush brush = new SolidBrush(Color.Green))
                    {
                        g.FillRectangle(brush, startPosition.Value.X * 10 - 10, startPosition.Value.Y * 10 - 10, 10, 10);
                    }
                }

                if (endPosition != null)
                {
                    using (Brush brush = new SolidBrush(Color.Blue))
                    {
                        g.FillRectangle(brush, endPosition.Value.X * 10 - 10, endPosition.Value.Y * 10 - 10, 10, 10);
                    }
                }
            }

            map_draw.Image = bitmap;
        }

        private void Save_Path_Click(object sender, EventArgs e)
        {
            if (lastFoundPath == null || lastFoundPath.Count == 0)
            {
                MessageBox.Show("Путь ещё не найден! Сначала выполните поиск.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.Title = "Сохранить путь";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Сохраняем путь в файл
                    SavePathToCSV(filePath, lastFoundPath);
                }
            }
        }

        private List<Point> lastFoundPath = null; // Глобальная переменная для хранения последнего найденного пути

        private void StartBFSButton_Click(object sender, EventArgs e)
        {
            if (startPosition == null || endPosition == null)
            {
                MessageBox.Show("Установите стартовую и конечную точки!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lastFoundPath = BreadthFirstSearch(startPosition.Value, endPosition.Value);

            if (lastFoundPath != null)
            {
                DrawPath(lastFoundPath); // Отрисовка пути
            }
        }

        private void SavePathToCSV(string filePath, List<Point> path)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Пишем заголовок
                    writer.WriteLine("X, Y");

                    // Пишем координаты
                    foreach (Point point in path)
                    {
                        writer.WriteLine($"{point.X}, {point.Y}");
                    }
                }

                MessageBox.Show("Путь успешно сохранён в файл CSV!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении пути: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DrawMap()
        {
            Bitmap bitmap = new Bitmap(640, 400);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White); // Устанавливаем фон

                for (int row = 0; row < 40; row++)
                {
                    for (int col = 0; col < 64; col++)
                    {
                        char cell = mapData[row, col];
                        Rectangle cellRect = new Rectangle(col * 10, row * 10, 10, 10);

                        // Определяем цвет клетки с использованием метода GetColorForCell
                        Color cellColor = GetColorForCell(cell);

                        using (Brush brush = new SolidBrush(cellColor))
                        {
                            g.FillRectangle(brush, cellRect);
                        }

                        // Рисуем стартовую и конечную позицию
                        if (startPosition != null && startPosition.Value == new Point(col, row))
                        {
                            using (Brush brush = new SolidBrush(Color.Green))
                            {
                                g.FillRectangle(brush, col * 10, row * 10, 30, 30); // Старт (30x30 пикселей)
                            }
                        }
                        else if (endPosition != null && endPosition.Value == new Point(col, row))
                        {
                            using (Brush brush = new SolidBrush(Color.Blue))
                            {
                                g.FillRectangle(brush, col * 10, row * 10, 30, 30); // Стоп (30x30 пикселей)
                            }
                        }
                    }
                }
            }

            map_draw.Image = bitmap;
        }

        UdpClient udpClient;
        UdpClient udpCommands = new UdpClient();

        private void Load_button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text Files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Считываем файл и рисуем карту
                    Bitmap mapBitmap = LoadMapFromFile(filePath);
                    if (mapBitmap != null)
                    {
                        map_draw.Image = mapBitmap;
                    }
                }
            }
        }

        private Bitmap LoadMapFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                if (!ValidateMapFile(lines))
                    return null;

                // Сохраняем карту в массив
                for (int row = 0; row < 40; row++)
                {
                    for (int col = 0; col < 64; col++)
                    {
                        mapData[row, col] = lines[row][col];
                    }
                }

                DrawMap(); // Отрисовываем карту

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки карты: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private bool ValidateMapFile(string[] lines)
        {
            if (lines.Length != 40)
            {
                MessageBox.Show("Файл должен содержать ровно 40 строк.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length != 64)
                {
                    MessageBox.Show($"Строка {i + 1} должна содержать ровно 64 символа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private Color GetColorForCell(char cell)
        {
            Color cellColor;

            switch (cell)
            {
                case '#':
                    cellColor = Color.Black; // Стена
                    break;
                case '.':
                    cellColor = Color.White; // Свободная клетка
                    break;
                case '0':
                    cellColor = Color.Gray;
                    break;
                case '1':
                    cellColor = Color.Red;
                    break;
                case '2':
                    cellColor = Color.Green;
                    break;
                case '3':
                    cellColor = Color.Blue;
                    break;
                case '4':
                    cellColor = Color.Yellow;
                    break;
                case '5':
                    cellColor = Color.Orange;
                    break;
                case '6':
                    cellColor = Color.Purple;
                    break;
                case '7':
                    cellColor = Color.Cyan;
                    break;
                case '8':
                    cellColor = Color.Brown;
                    break;
                case '9':
                    cellColor = Color.Pink;
                    break;
                default:
                    cellColor = Color.Transparent; // Пропускаем символы, которые не являются стенами или цифрами
                    break;
            }

            return cellColor;
        }

        Thread thread;



        Dictionary<string, int> decodeText;
        public static Dictionary<string, int> commands = new Dictionary<string, int>
        {
            { "N", 0 },
            { "M", 0 },
            { "F", 0 },
            { "B", 0 },
            { "T", 0 },
        };

        public static string jsonString, jsonString2, message;



        public Controller()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ipAddress = IPAddress.Parse(textBox1.Text);
            port = Int32.Parse(textBox2.Text);

            iPEndPoint = new IPEndPoint(ipAddress, port);
            udpClient = new UdpClient(port);

            thread = new Thread(() => Receive());
            thread.Start();
            Thread.Sleep(1000);
            timer1.Enabled = true;
            timer1.Start();
            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (data != null)
            {
                DecodingData(data);
            }
            else
            {
                richTextBox1.Text = richTextBox1.Text + "\r\n" + "No data";
            }
        }

        private void Controller_Load(object sender, EventArgs e)
        {
            map_draw.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void DecodingData(byte[] data)
        {
            var message = Encoding.ASCII.GetString(data);
            decodeText = JsonConvert.DeserializeObject<Dictionary<string, int>>(message);
            var lines = decodeText.Select(kv => kv.Key + ": " + kv.Value.ToString());
            richTextBox2.Text = "IoT: " + string.Join(Environment.NewLine, lines);

            AnalyzeData(decodeText);
        }

        private void AnalyzeData(Dictionary<string, int> pairs)
        {
            if (pairs.ContainsKey("n"))
            {
                n = pairs["n"];
                s = pairs["s"];
                c = pairs["c"];
                le = pairs["le"];
                re = pairs["re"];
                az = pairs["az"];
                b = pairs["b"];
                d0 = pairs["d0"];
                d1 = pairs["d1"];
                d2 = pairs["d2"];
                d3 = pairs["d3"];
                d4 = pairs["d4"];
                d5 = pairs["d5"];
                d6 = pairs["d6"];
                d7 = pairs["d7"];
                l0 = pairs["l0"];
                l1 = pairs["l1"];
                l2 = pairs["l2"];
                l3 = pairs["l3"];
                l4 = pairs["l4"];
            }
            else
            {
                MessageBox.Show("No data");
            }
        }

        private void Receive()
        {
            while (true)
            {
                try
                {
                     data = udpClient.Receive(ref iPEndPoint);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Controller_FormClosed(object sender, FormClosedEventArgs e)
        {
            udpClient.Close();
            timer1.Enabled = false;
            timer1.Stop();
            thread.Abort();
        }

        private void Controller_FormClosing(object sender, FormClosingEventArgs e)
        {
            udpClient.Close();
            timer1.Enabled = false;
            timer1.Stop();
            thread.Abort();
        }

        
    }
}
