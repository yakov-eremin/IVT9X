using System;

namespace R3
{
    ///
    /// @brief Класс для описания окружности на плоскости
    /// 
    ///Описывает окружность с центром, заданным двумя координатами, и методы вывода данных, вычисления площади, расстояния до начала координат до центра и сложение с другим кругом
    ///@image{inline} html circle.png "Описание"
    ///
    public class circle
    {
        /// <summary>
        /// Координаты центра по х
        /// </summary>
        protected double x;
        /// <summary>
        /// Координаты центра по у
        /// </summary>
        protected double y;
        /// <summary>
        /// Радиус окружности
        /// </summary>
        protected double r;
        /// <summary>
        /// Конструктор по-умолчанию, создающий окружность с координатами х, у и радиусом r равными 10
        /// </summary>
        public circle()
        {
            x = 10;
            y = 10;
            r = 10;
        }
        /// <summary>
        /// Конструктор инициализирует объект с задаными параметрами
        /// </summary>
        /// <param name="x">Координата Х центра</param>
        /// <param name="y">Координата Y центра</param>
        /// <param name="r">Радиус окружности</param>
        public circle(double x, double y, double r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }
        /// <summary>
        /// Метод для отображени текущего сотояния объекта
        /// </summary>
        /// <returns>Строка с текущими параметрами объекта</returns>
        public string Display()
        {
            return "Окружность с координатами (" + x + ";" + y + ")  и радиусом " + r;
        }
        /// <summary>
        /// Метод для инициализации полей объекта класса
        /// </summary>
        /// <param name="x_coordinate">Координата Х центра</param>
        /// <param name="y_coordinate">Координата Y центра</param>
        /// <param name="radius">Радиус окружности</param>
        public void Initialize(double x_coordinate, double y_coordinate, double radius)
        {
            x = x_coordinate;
            y = y_coordinate;
            r = radius;
        }
        /// <summary>
        /// Метод,вычисляющий расстояние от цетра окружности до начала координат
        /// </summary>
        /// <returns>double значение расстояния</returns>
        public double DistanceCenter()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
        /// <summary>
        /// Метод, вычисляющий площадь окружности по формуле \f${Pi * R^2}\f$
        /// </summary>
        /// <returns>double значение площади</returns>
        public double Square()
        {
            return Math.PI * r * r;
        }
        /// <summary>
        /// Метод, складывающий две окружности
        /// </summary>
        /// <param name="second_circle">Окружность, с кооторой необходимо сложить</param>
        /// <returns>Объект класса circle, являющийся сложением двух</returns>
        public circle Add(circle second_circle)
        {
            circle result = new circle();
            result.x = (second_circle.x + x) / 2;
            result.y = (second_circle.y + y) / 2;
            result.r = second_circle.r + r;
            return result;
        }
    }

    ///
    /// @brief Класс для описания цилиндра в пространстве
    /// 
    ///Описывает цилиндром с центром нижней плоскости,заданным двумя координатами, и методы вывода данных, вычисления объема, расстояния до начала координат до центра
    ///
    public class cylinder : circle
    {
        /// <summary>
        /// Высота цилиндра
        /// </summary>
        protected double z;
        /// <summary>
        /// Конструктор по-умолчанию, создающий цилиндр с координатами х, у, выосотой z и радиусом r равными 10
        /// </summary>
        public cylinder() : base()
        {
            z = 10;
        }
        /// <summary>
        /// Конструктор инициализирует объект с задаными параметрами
        /// </summary>
        /// <param name="x">Координата Х центра</param>
        /// <param name="y">Координата Y центра</param>
        /// <param name="z">Высота фигуры</param>
        /// <param name="r">Радиус</param>
        public cylinder(double x, double y, double z, double r) : base(x, y, r)
        {
            this.z = z;
        }
        /// <summary>
        /// Метод для отображени текущего сотояния объекта
        /// </summary>
        /// <returns>Строка с текущими параметрами объекта</returns>
        public new string Display()
        {
            return base.Display() + "Длина z: " + z;
        }
        /// <summary>
        /// Метод для инициализации полей объекта класса
        /// </summary>
        /// <param name="x_coordinate">Координата Х центра</param>
        /// <param name="y_coordinate">Координата Y центра</param>
        /// <param name="radius">Радиус окружности</param>
        /// <param name="z_coordinate">Высота</param>
        public void Initialize(double x_coordinate, double y_coordinate, double z_coordinate, double radius)
        {
            Initialize(x_coordinate, y_coordinate, radius);
            z = z_coordinate;
        }
        /// <summary>
        /// Метод, вычисляющий площадь окружности по формуле \f${Pi * R^2}\f$
        /// </summary>
        /// <returns>double значение площади</returns>
        public new double DistanceCenter()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) + z / 2;
        }
        /// <summary>
        /// Метод, вычисляющий объем цилиндра по формуле \f${Pi * R^2 * h}\f$
        /// </summary>
        /// <returns>double значение объема</returns>
        public double Volume()
        {
            return Math.PI * r * r * z;
        }
    }
    ///
    /// @brief Класс для описания фигуры кольца в пространстве
    /// 
    ///Кольцо представляет из себя цилиндр, центр которого вырезан другим цилиндром
    ///Описывает кольцо с центром нижней плоскости,заданным двумя координатами, и методы вывода данных, вычисления объема
    ///
    public class ring : cylinder
    {
        /// <summary>
        /// Радиус внутреннего цилиндра
        /// </summary>
        private double inner_r;
        /// <summary>
        /// Конструктор инициализирует объект с задаными параметрами
        /// </summary>
        /// <param name="x">Координата Х центра</param>
        /// <param name="y">Координата Y центра</param>
        /// <param name="z">Высота фигуры</param>
        /// <param name="r">Радиус</param>
        /// <param name="i_r">Внутренний радиус</param>
        public ring(double x, double y, double z, double r, double i_r) : base(x, y, z, r)
        {
            this.inner_r = i_r;
        }
        /// <summary>
        /// Метод для отображени текущего сотояния объекта
        /// </summary>
        /// <returns>Строка с текущими параметрами объекта</returns>
        public new string Display()
        {
            return base.Display() + "Внутренний радиус: " + inner_r;
        }
        /// <summary>
         /// Метод для инициализации полей объекта класса
         /// </summary>
         /// <param name="x_coordinate">Координата Х центра</param>
         /// <param name="y_coordinate">Координата Y центра</param>
         /// <param name="radius">Радиус окружности</param>
         /// <param name="z_coordinate">Высота</param>
         /// <param name="inner_radius">Радиус внутреннего цилиндра</param>
        public void Initialize(double x_coordinate, double y_coordinate, double z_coordinate, double radius, double inner_radius)
        {
            Initialize(x_coordinate, y_coordinate, z_coordinate, radius);
            inner_r = inner_radius;
        }
        /// <summary>
        /// Метод, вычисляющий объем кольца
        /// </summary>
        /// <returns>double значение объема</returns>
        public new double Volume()
        {
            return Math.PI * r * r * z - Math.PI * inner_r * inner_r * z;
        }
    }
}
