#include "matrix.h"

namespace MathLogic
{
    Matrix::Matrix(quint8 a, quint8 b)
    {
        m_matrix.resize(a);
        for (int i = 0; i < a; ++i)
        {
            m_matrix[i].resize(b);
            for (int j = 0; j < b; ++j)
                m_matrix[i][j] = 0;
        }
    }

    Matrix::Matrix(QVector<QVector<float> > matrix)
    {
        m_matrix.resize(matrix.size());
        for (int i = 0; i < matrix.size(); ++i)
        {
            m_matrix[i].resize(matrix[0].size());
            for (int j = 0; j < matrix[0].size(); ++j)
                m_matrix[i][j] = matrix[i][j];
        }
    }

    QPair<quint8, quint8> Matrix::getDimension() const
    {
        return QPair<int, int>(m_matrix.size(), m_matrix[0].size());
    }

    float& Matrix::valueOf(int a, int b)
    {
        return m_matrix[a][b];
    }

    QList<float> Matrix::getListRow(int a)
    {
        return QList<float>(m_matrix[a]);
    }

    float Matrix::valueOf(int a, int b) const
    {
        return m_matrix[a][b];
    }

    Matrix Matrix::operator+(const Matrix& matrix_) const
    {
        if (this->getDimension() != matrix_.getDimension())
            qDebug() << "The dimensions of the matrices differ";
        Matrix tmpMatrix(this->getDimension().first, this->getDimension().second);
        for (int i = 0; i < matrix_.getDimension().first; ++i)
            for (int j = 0; j < matrix_.getDimension().second; ++j)
                tmpMatrix.valueOf(i, j) = this->valueOf(i, j) + matrix_.valueOf(i, j);
        return tmpMatrix;
    }

    Matrix Matrix::operator*(const Matrix& matrix_) const
    {
        if (this->getDimension().second != matrix_.getDimension().first)
            qDebug() << "The dimensions of the matrices differ";
        Matrix tmpMatrix(this->getDimension().first, matrix_.getDimension().second);
        for (int i = 0; i < tmpMatrix.getDimension().first; ++i)
            for (int j = 0; j < tmpMatrix.getDimension().second; ++j)
                for (int k = 0; k < this->getDimension().second; ++k)
                    tmpMatrix.valueOf(i, j) += (this->valueOf(i, k) * matrix_.valueOf(k, j));
        return tmpMatrix;
    }

    Matrix Matrix::operator/(const float value_) const
    {
        Matrix tmpMatrix(this->getDimension().first, this->getDimension().second);
        for (int i = 0; i < tmpMatrix.getDimension().first; ++i)
            for (int j = 0; j < tmpMatrix.getDimension().second; ++j)
                tmpMatrix.valueOf(i, j) = this->valueOf(i, j) / value_;
        return tmpMatrix;
    }

    Matrix Matrix::operator*(const float value_) const
    {
        Matrix tmpMatrix(this->getDimension().first, this->getDimension().second);
        for (int i = 0; i < tmpMatrix.getDimension().first; ++i)
            for (int j = 0; j < tmpMatrix.getDimension().second; ++j)
                tmpMatrix.valueOf(i, j) = this->valueOf(i, j) * value_;
        return tmpMatrix;
    }

    Matrix operator*(const float value, const Matrix& matrix)
    {
        return matrix * value;
    }

    Matrix Matrix::operator-() const
    {
        Matrix tmpMatrix(this->getDimension().first, this->getDimension().second);
        for (int i = 0; i < this->getDimension().first; ++i)
            for (int j = 0; j < this->getDimension().second; ++j)
                tmpMatrix.valueOf(i, j) = -this->valueOf(i, j);
        return tmpMatrix;
    }

    Matrix Matrix::operator-(const Matrix& matrix_) const
    {
        if (this->getDimension() != matrix_.getDimension())
            qDebug() << "The dimensions of the matrices differ";
        return *this + (-matrix_);
    }

    Matrix& Matrix::operator=(const Matrix& matrix_)
    {
        m_matrix.clear();
        m_matrix.resize(matrix_.getDimension().first);
        for (int i = 0; i < matrix_.getDimension().first; ++i)
        {
            m_matrix[i].resize(matrix_.getDimension().second);
            for (int j = 0; j < matrix_.getDimension().second; ++j)
                this->valueOf(i, j) = matrix_.valueOf(i, j);
        }
        return *this;
    }

    Matrix Matrix::T()
    {
        Matrix* newMatrix = new Matrix(getDimension().second, getDimension().first);
        for (int i = 0; i < newMatrix->getDimension().first; ++i)
            for (int j = 0; j < newMatrix->getDimension().second; ++j)
                newMatrix->valueOf(i, j) = valueOf(j, i);

        return *newMatrix;
    }

    void Matrix::clear()
    {
        for (int i = 0; i < getDimension().first; ++i)
        {
            for (int j = 0; j < getDimension().second; ++j)
                m_matrix[i][j] = 0;
        }
    }

    QDebug operator<<(QDebug stream, const Matrix& matrix) {
        stream << '\n';
        for (int i = 0; i < matrix.getDimension().first; ++i)
        {
            for (int j = 0; j < matrix.getDimension().second; ++j)
                stream << matrix.m_matrix[i][j];
            stream << '\n';
        }
        return stream;
    }
}