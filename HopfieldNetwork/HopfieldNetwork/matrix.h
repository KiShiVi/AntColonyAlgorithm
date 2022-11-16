#pragma once

#include <QVector>
#include <QDebug>

namespace MathLogic
{
    //!
    //! \brief The Matrix class Класс матрицы для графических преобразований
    //!
    class Matrix
    {
    public:
        //!
        //! \brief Matrix Конструктор - инициализирует все числа нулями
        //! \param a Кол-во строк
        //! \param b Кол-во столбцов
        //!
        Matrix(quint8 a, quint8 b);
        //!
        //! \brief Matrix Конструктор
        //! \param m_matrix Матрица из векторов
        //!
        Matrix(QVector<QVector<float> > m_matrix);
        //!
        //! \brief getDimension Возвращает размерность матрицы
        //! \return QPair с размерностью матрицы
        //!
        QPair<quint8, quint8> getDimension() const;
        //!
        //! \brief valueOf Возвращает адрес на ячейку по её индексу. Индексация от нуля
        //! \param a Первый индекс (номер строки)
        //! \param b Второй индекс (номер столбца)
        //! \return Элемент матрицы (a, b)
        //!
        float& valueOf(int a, int b);
        //!
        //! \brief getListRow Возвращает QList строки
        //! \param a Номер строки
        //! \return Лист со строкой
        //!
        QList<float> getListRow(int a);
        //!
        //! \brief valueOf Возвращает адрес на ячейку по её индексу. Индексация от нуля (CONST)
        //! \param a Второй индекс (номер столбца)
        //! \param b Первый индекс (номер строки)
        //! \return Элемент матрицы (a, b)
        //!
        float valueOf(int a, int b) const;
        //!
        //! \brief operator + Перегрузка оператора суммирования матриц
        //! \param matrix_ Матрица
        //! \return Итоговая матрица
        //!
        Matrix operator+(const Matrix& matrix_) const;
        //!
        //! \brief operator * Перегрузка оператора умножения матриц
        //! \param matrix_ Матрица
        //! \return Итоговая матрица
        //!
        Matrix operator*(const Matrix& matrix_) const;
        //!
        //! \brief operator * Перегрузка оператора умножения на константу
        //! \param value_ Число
        //! \return Итоговая матрица
        //!
        Matrix operator*(const float value_) const;
        //!
        //! \brief operator / Перегрузка оператора деления на константу
        //! \param value_ Число
        //! \return Итоговая матрица
        //!
        Matrix operator/(const float value_) const;
        //!
        //! \brief operator - Перегрузка оператора унарного минуса
        //! \return Итоговая матрица
        //!
        Matrix operator-() const;
        //!
        //! \brief operator - Перегрузка оператора вычитания матриц
        //! \param matrix_ Матрица
        //! \return Итоговая матрица
        //!
        Matrix operator-(const Matrix& matrix_) const;
        //!
        //! \brief operator = Перегрузка оператора присваивания
        //! \param matrix_ Присваиваемая матрица
        //! \return Итоговая матрица
        //!
        Matrix& operator= (const Matrix& matrix_);

        Matrix T();

        void clear();
    private:
        //!
        //! \brief m_matrix Матрица
        //!
        QVector<QVector<float> > m_matrix;

        //!
        //! \brief operator << Перегрузка оператора вывода матрицы в поток
        //! \param stream Поток
        //! \param matrix Матрица
        //! \return Поток вывода
        //!
        friend QDebug operator<<(QDebug stream, const Matrix& matrix);
    }; // Matrix

    //!
    //! \brief operator * Перегрузка оператора умножения на константу (константа слева в выражении)
    //! \param value Число
    //! \param matrix Матрица
    //! \return Итоговая матрица
    //!
    Matrix operator*(const float value, const Matrix& matrix);
} // MathLogic