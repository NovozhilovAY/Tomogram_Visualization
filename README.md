# Tomogram_Visualization
Разработанная программа позволяет полойно просматривать томограмму. Использован язык C# и технология OpenGL.
![](https://github.com/NovozhilovAY/Pictures-and-Gifs-for-readme/blob/main/tomogram_visualizer/J1thAKiL9X.gif)

### Томография
Томография - это получение послойного изображения внутренней
структуры объекта.
Чаще всего, но далеко не всегда, объектом томографического
исследования являются живые ткани.
###
Данные томографии представляют собой трехмерный массив вокселов -
элементов трехмерной регулярной сетки. Каждый воксел содержит одно
значение плотности, как правило, типа short или ushort.
Для перевода значения плотности в цвет используется передаточная
функция = Transfer Function (TF). Transfer Function может быть серой, от
черного до белого, или цветной, линейной или нелинейной.
###
В данной программе используется линейная TF от
черного к белому, так как ее очень просто создать, все значения
рассчитываются по формуле:

![](https://github.com/NovozhilovAY/Pictures-and-Gifs-for-readme/blob/main/tomogram_visualizer/formula.PNG)

### Чтение файла томограммы
Обычно файлы томограмм хранятся в файлах формата DICOM, но в связи
с нетривиальностью данного формата в данной работе будет использоваться
томограмма, сохраненная в бинарном формате. Для загрузки томограммы
потребуется прочитать из бинарного файла размеры томограммы (3 числа в
формате int) и массив данных типа short. Для этой цели реализован класс Bin.

### Визуализация томограммы
Класс View содержит методы для визуализации томограммы.

#### Вариант 1 - Отрисовка четырехугольниками
Отрисовка четырехугольниками, вершинами которых
являются центры вокселов текущего слоя регулярной воксельной сетки. Цвет
формируется на центральном процессоре и отрисовывается с помощью
функции GL.Begin(BeginMode.Quads).
#### Вариант 2 - Отрисовка текстурой
Отрисовка текстурой. Текущий слой томограммы
визуализируется как один большой четырехугольник, на который изображение
слоя накладывается как текстура аппаратной билинейной интерполяцией.
#### Вариант 3 - Отрисовка при помощи QuadStrip
В OpenGL есть тип визуализации QuadStrip, когда первый
четырехугольник рисуется 4 вершинами, а последующие - 2 вершинами,
присоединенными к предыдущему четырехугольнику (рис. ниже). Таким
образом для отрисовки N четырехугольников требуется не 4*N вершин, а
2*N + 2 вершин, что положительно сказывается на скорости работы программы.
![](https://github.com/NovozhilovAY/Pictures-and-Gifs-for-readme/blob/main/tomogram_visualizer/kvadraty.PNG)
