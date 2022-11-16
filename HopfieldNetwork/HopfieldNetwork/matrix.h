#pragma once

#include <QVector>
#include <QDebug>

namespace MathLogic
{
    //!
    //! \brief The Matrix class ����� ������� ��� ����������� ��������������
    //!
    class Matrix
    {
    public:
        //!
        //! \brief Matrix ����������� - �������������� ��� ����� ������
        //! \param a ���-�� �����
        //! \param b ���-�� ��������
        //!
        Matrix(quint8 a, quint8 b);
        //!
        //! \brief Matrix �����������
        //! \param m_matrix ������� �� ��������
        //!
        Matrix(QVector<QVector<float> > m_matrix);
        //!
        //! \brief getDimension ���������� ����������� �������
        //! \return QPair � ������������ �������
        //!
        QPair<quint8, quint8> getDimension() const;
        //!
        //! \brief valueOf ���������� ����� �� ������ �� � �������. ���������� �� ����
        //! \param a ������ ������ (����� ������)
        //! \param b ������ ������ (����� �������)
        //! \return ������� ������� (a, b)
        //!
        float& valueOf(int a, int b);
        //!
        //! \brief getListRow ���������� QList ������
        //! \param a ����� ������
        //! \return ���� �� �������
        //!
        QList<float> getListRow(int a);
        //!
        //! \brief valueOf ���������� ����� �� ������ �� � �������. ���������� �� ���� (CONST)
        //! \param a ������ ������ (����� �������)
        //! \param b ������ ������ (����� ������)
        //! \return ������� ������� (a, b)
        //!
        float valueOf(int a, int b) const;
        //!
        //! \brief operator + ���������� ��������� ������������ ������
        //! \param matrix_ �������
        //! \return �������� �������
        //!
        Matrix operator+(const Matrix& matrix_) const;
        //!
        //! \brief operator * ���������� ��������� ��������� ������
        //! \param matrix_ �������
        //! \return �������� �������
        //!
        Matrix operator*(const Matrix& matrix_) const;
        //!
        //! \brief operator * ���������� ��������� ��������� �� ���������
        //! \param value_ �����
        //! \return �������� �������
        //!
        Matrix operator*(const float value_) const;
        //!
        //! \brief operator / ���������� ��������� ������� �� ���������
        //! \param value_ �����
        //! \return �������� �������
        //!
        Matrix operator/(const float value_) const;
        //!
        //! \brief operator - ���������� ��������� �������� ������
        //! \return �������� �������
        //!
        Matrix operator-() const;
        //!
        //! \brief operator - ���������� ��������� ��������� ������
        //! \param matrix_ �������
        //! \return �������� �������
        //!
        Matrix operator-(const Matrix& matrix_) const;
        //!
        //! \brief operator = ���������� ��������� ������������
        //! \param matrix_ ������������� �������
        //! \return �������� �������
        //!
        Matrix& operator= (const Matrix& matrix_);

        Matrix T();

        void clear();
    private:
        //!
        //! \brief m_matrix �������
        //!
        QVector<QVector<float> > m_matrix;

        //!
        //! \brief operator << ���������� ��������� ������ ������� � �����
        //! \param stream �����
        //! \param matrix �������
        //! \return ����� ������
        //!
        friend QDebug operator<<(QDebug stream, const Matrix& matrix);
    }; // Matrix

    //!
    //! \brief operator * ���������� ��������� ��������� �� ��������� (��������� ����� � ���������)
    //! \param value �����
    //! \param matrix �������
    //! \return �������� �������
    //!
    Matrix operator*(const float value, const Matrix& matrix);
} // MathLogic