using System;

namespace KLab3
{  
    /// 
    /// @brief Класс для описания точки
    /// 
    /// Описывает точку с двумя координатами и методы расчета расстояния до начала координат и между точками  
    /// 
    
    public class MyPoint
    {
        /// Координата x 
        private int _positionX;
        /// Координата y 
        private int _positionY;

        public int PositionX { get => _positionX; set => _positionX = value; }
        public int PositionY { get => _positionY; set => _positionY = value; }

      
        /// <summary>
        /// Метод считает расстояние от точки до начала координат
        /// </summary>
        /// <returns> Квадратный корень суммы квадратов координат точки </returns>
        public double GetDistantion()
        {
            return Math.Sqrt(_positionX * _positionX + _positionY * _positionY);
        }

        /// <summary>
        /// Данный метод вычисляет расстояние между \f$(x_1,y_1)\f$ и \f$(x_2,y_2)\f$ равное \f$\sqrt\{(x_2-x_1)^2 + (y_2-y_1)^2}\f$
        /// </summary>
        /// <param name="destination"> Конечная точка </param>
        /// <returns> Расстояние между данной точкой и конечной </returns>
        ///
        public double GetDistanceFromPoint(MyPoint destination)
        {
            return Math.Sqrt(Math.Pow(destination.PositionX - this._positionX, 2) + Math.Pow(destination.PositionY - this._positionY, 2));
        }
    }
    /// 
    /// @brief Абстрактный класс описывающий фигура
    /// 
    /// Описывает геометрическую фигуру и методы вычисления площади и периметра фигуры, а также проверки на возможность вписания в другую фигуру
    /// @image{inline} html figure.jpg "Описание"
    ///
    public abstract class Figure
    {
        /// Массив точек 
        protected MyPoint[] _points; 
        /// <summary>
        /// Метод вычисляет площадь фигуры
        /// </summary>
        public abstract double GetSquare();
        /// <summary>
        /// Метод вычисляет периметр фигуры
        /// </summary>
        public abstract double GetPerimeter();
        /// <summary>
        /// Метод проверяет может ли быть фигура вписанной в данную 
        /// </summary>
        /// <param name="figure"> Вписываемая фигура </param>
        /// <returns> Логическое значение </returns>
        ///
        public bool IsFits(Figure figure)
        {
            double _square = figure.GetSquare();
            if (this.GetSquare() / _square > 1)
                return true;
            else
                return false;
        }
    }
    /// 
    /// @brief Класс для реализации треугольника
    /// 
    /// Дочерний класс для описания геометрической фигуры - треугольника
    /// Имеет методы для вычисления прощади и периметра
    /// 

    public class Triangle : Figure
    {
        /// Массив точек
        private MyPoint[] _points = new MyPoint[3];
        /// Высота
        private double _height;
        /// Гипотенуза 
        private double _hypotinuse;
        /// Катет 
        private double _lastSide;

        /// <summary>
        /// Конструктор считает стороны треугольника 
        /// </summary>
        /// <param name="points"> Массив из трех точек </param>
        public MyTriangle(MyPoint[] points)
        {
            _points = points;
            double _distance;
            for (int i = 0; i <= _points.Length; i++)
            {
                int j = i + 1;
                if (j == _points.Length)
                    j = 0;
                _distance = _points[i].GetDistanceFromPoint(_points[j]);
                if (_hypotinuse < _distance)
                    _hypotinuse = _distance;
                else
                    _lastSide = _distance;

            }
            for (int i = 0; i <= _points.Length; i++)
            {
                int j = i + 1;
                if (j == _points.Length)
                    j = 0;
                _distance = _points[i].GetDistanceFromPoint(_points[j]);
                if (_height < _distance && _distance != _hypotinuse)
                    _height = _distance;
                else
                    _lastSide = _distance;
            }
        }

        public override double GetSquare()
        {
            return _height * _lastSide / 2;
        }
        public override double GetPerimeter()
        {
            double _distance = 0;
            for (int i = 0; i <= _points.Length; i++)
            {
                int j = i + 1;
                if (j == _points.Length)
                    j = 0;
                _distance += _points[i].GetDistanceFromPoint(_points[j]);
            }
            return _distance;
        }        
    }

    /// 
    /// @brief Класс для реализации прямоугольника
    /// 
    /// Дочерний класс для описания геометрической фигуры - прямоугольника 
    /// Имеет методы для вычисления площади и периметра 
    /// 
    public class Rectangle : Figure
    {
        /// Массив точек
        protected MyPoint[] _points = new MyPoint[4];

        public override double GetPerimeter()
        {
            double _distance = 0;
            for (int i = 0; i <= _points.Length; i++)
            {
                int j = i + 1;
                if (j == _points.Length)
                    j = 0;
                _distance += _points[i].GetDistanceFromPoint(_points[j]);
            }
            return _distance;
        }
        public override double GetSquare()
        {
            double _sideA = _points[0].GetDistanceFromPoint(_points[1]);
            double _sideB = _points[1].GetDistanceFromPoint(_points[2]);
            return _sideA * _sideB;
        }
    }

    /// 
    /// @brief Класс для реализации параллелограмма 
    /// 
    /// Дочерний класс от прямоугольника 
    /// Имеет метод для вычисления площади
    /// 
    public class Parallelogram : Rectangle
    {
        /// Угол 
        private int _angle;
        public int Angle { get => _angle; set => _angle = value; }

        public override double GetSquare()
        {
            double _sideA = _points[0].GetDistanceFromPoint(_points[1]);
            double _sideB = _points[1].GetDistanceFromPoint(_points[2]);
            return _sideA * _sideB * Math.Sin(_angle);
        }
    }
}
